using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MultiMonWindowTool
{
    public partial class FrmMain : Form
    {
        // enum class for enumerating windows
        private Native.EnumWindows mWindows = new Native.EnumWindows();
        // dictionary/map holding all the windows and their info
        private Dictionary<IntPtr, Native.WindowInfo> mWindowInfo = new Dictionary<IntPtr, Native.WindowInfo>();
        // primary screen/monitor
        private Screen mScreenPrimary;
        // secondary screen/monitor
        private Screen mScreenSecondary;

        public FrmMain()
        {
            InitializeComponent();
            lvWindows.ColumnClick += new ColumnClickEventHandler(lvWindows_ColumnClick);
            updateWindowInfo();
            updateWindowListView();
            updateScreens();
        }

        private void updateScreens()
        {
            // loop through available screens and save primary and secondary
            foreach (var screen in Screen.AllScreens)
            {
                if (screen.Primary)
                {
                    mScreenPrimary = screen;
                }
                else
                {
                    mScreenSecondary = screen;
                }
            }

            listBox1.Items.Clear();
            // For each screen, add the screen properties to a list box.
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                listBox1.Items.Add("Device Name: " + screen.DeviceName);
                listBox1.Items.Add("Bounds: " + screen.Bounds.ToString());
                listBox1.Items.Add("Type: " + screen.GetType().ToString());
                listBox1.Items.Add("Working Area: " +  screen.WorkingArea.ToString());
                listBox1.Items.Add("Primary Screen: " + screen.Primary.ToString());
            }
        }

        // enumerates all application windows and saves them to the window info map
        private void updateWindowInfo()
        {
            mWindows.Enum();
            mWindowInfo.Clear();
            foreach (IntPtr ip in mWindows.hWnds)
            {
                Native.WindowInfo wi = new Native.WindowInfo(ip);
                if (wi.Visible && wi.IsWindow)
                {
                    mWindowInfo[ip] = wi;
                    //Console.WriteLine("Handle = {4} Window text = {0} Class = {1} Height = {2} PID = {3} ", wi.WindowText, wi.ClassName, wi.WindowRect.Height, wi.Pid, ip);
                }
            }
        }

        // update the list view with the enumerated windows
        private void updateWindowListView()
        {
            // remove windows from the listview that are no longer running
            for( int i = 0; i < lvWindows.Items.Count; i++ )
            {
                ListViewItem item = lvWindows.Items[i];
                IntPtr hwnd = (IntPtr)(Convert.ToInt64(item.Name));
                if (!mWindowInfo.ContainsKey(hwnd))
                {
                    lvWindows.Items.RemoveAt(i);
                }
            }

            //List<Native.WindowInfo> windows = mWindowInfo.

            // loop through all of the windows and add to listview or update existing item in the listview
            foreach( KeyValuePair<IntPtr,Native.WindowInfo> kvp in mWindowInfo)
            {
                ListViewItem item;
                int index = lvWindows.Items.IndexOfKey(Convert.ToString(kvp.Key));
                string pid = Convert.ToString(kvp.Value.Pid);
                string key = Convert.ToString(kvp.Key);
                string xy = Convert.ToString(kvp.Value.WindowRect.X) + " " + Convert.ToString(kvp.Value.WindowRect.Y);
                
                // check if window info is already in the listview fields as necessary
                if (index >= 0 )
                {
                    item = lvWindows.Items[index];
                    if (item.Text != kvp.Value.WindowText)
                        item.Text = kvp.Value.WindowText;
                    if (item.SubItems[1].Text != pid)
                        item.SubItems[1].Text = pid;
                    //if (item.SubItems[2].Text != key)
                        //item.SubItems[2].Text = key;
                    if (item.SubItems[2].Text != xy)
                        item.SubItems[2].Text = xy;
                }
                else
                {
                    // new item so add it to listview
                    item = new ListViewItem(kvp.Value.WindowText);
                    item.Name = key;
                    item.SubItems.Add(pid);
                    //item.SubItems.Add(key);
                    item.SubItems.Add(xy);
                    lvWindows.Items.Add(item);
                }                 
            }
        }

        // moves the window identified by the given window info from one screen/monitor to another
        private void moveToScreen(Native.WindowInfo wi, Screen from, Screen to)
        {
            int newX;
            int newY;
            int curX;
            int curY;
            int diffX;
            int diffY;

            curX = wi.WindowRect.X;
            curY = wi.WindowRect.Y;

            diffX = curX - from.Bounds.X;
            diffY = curY - from.Bounds.Y;

            newX = diffX + to.Bounds.X;
            newY = diffY + to.Bounds.Y;

            Console.WriteLine("Moving from {0} on screen {1} to {2} on screen {3}", Convert.ToString(curX) + " " + Convert.ToString(curY), from.Bounds.ToString(), Convert.ToString(newX) + " " + Convert.ToString(newY), to.Bounds.ToString());

            Native.WinAPI.SetWindowPos(wi.Handle, Native.WinAPI.HWNDInsertAfter.TOP, newX, newY, wi.WindowRect.Width, wi.WindowRect.Height, Native.WinAPI.SWP.SHOWWINDOW);
        }

        // capture an image of the window identified by the handle
        private Image captureWindow(IntPtr handle)
        {
            try
            {
                // uses the printwindow api to grab a windows contents
                // doesn't work for apps running as root or minimized
                // and won't grab a window's contents such as playing video
                Bitmap img = Native.ScreenCapture.PrintWindow(handle);
                picPreview.Image = img;
                return img;
            }
            catch (Exception)
            {
                Bitmap bmpWindowCapture = new Bitmap(1,1);
                return (Image)bmpWindowCapture;
            }
        }

        // capture an image of the desktop with the given coordinates and dimensions
        private Image captureArea(int width, int height, int x, int y)
        {
            try
            {
                // this code grabs what's visible in the window rectangle
                // this is useful for apps running as root or apps that use special 
                // drawing like a media player
                Bitmap bmpWindowCapture = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bmpWindowCapture);
                g.CopyFromScreen(x, y, 0, 0, bmpWindowCapture.Size, CopyPixelOperation.SourceCopy);
                picPreview.Image = bmpWindowCapture;
                return bmpWindowCapture;
            }
            catch (Exception)
            {
                Bitmap bmpWindowCapture = new Bitmap(1, 1);
                return (Image)bmpWindowCapture;
            }
        }

        // updates the preview image on the main form with that of the window or monitor based on options
        private void updateSelectedPreview()
        {
            if (radioCapSelected.Checked)
            {
                ListView.SelectedListViewItemCollection selected = lvWindows.SelectedItems;
                foreach (ListViewItem item in selected)
                {
                    IntPtr hwnd = (IntPtr)(Convert.ToInt64(item.Name));
                    if (mWindowInfo.ContainsKey(hwnd))
                    {
                        if (radioScreenArea.Checked)
                        {
                            Image screenCap = captureArea(mWindowInfo[hwnd].WindowRect.Width, mWindowInfo[hwnd].WindowRect.Height, mWindowInfo[hwnd].WindowRect.X, mWindowInfo[hwnd].WindowRect.Y);
                            picPreview.Image = screenCap;
                        }
                        else
                        {
                            Image windowCap = captureWindow(mWindowInfo[hwnd].Handle);
                            picPreview.Image = windowCap;
                        }
                    }
                }
            }
            else if (radioCapPrimary.Checked)
            {
                Image primaryCap = captureArea(mScreenPrimary.Bounds.Width, mScreenPrimary.Bounds.Height, mScreenPrimary.Bounds.X, mScreenPrimary.Bounds.Y);
                picPreview.Image = primaryCap;
            }
            else if (radioCapSecondary.Checked)
            {
                Image secondaryCap = captureArea(mScreenSecondary.Bounds.Width, mScreenSecondary.Bounds.Height, mScreenSecondary.Bounds.X, mScreenSecondary.Bounds.Y);
                picPreview.Image = secondaryCap;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateWindowInfo();
            updateWindowListView();
            if (chkAutoRefresh.Checked )
            {
                updateSelectedPreview();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // when the selected window changes, update the X Y textboxes and the preview image
        private void lvWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selected = lvWindows.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                IntPtr hwnd = (IntPtr)(Convert.ToInt64(item.Name));
                if (mWindowInfo.ContainsKey(hwnd))
                {
                    txtX.Text = Convert.ToString(mWindowInfo[hwnd].WindowRect.X);
                    txtY.Text = Convert.ToString(mWindowInfo[hwnd].WindowRect.Y);
                }
            }
            updateSelectedPreview();
        }

        // sort column when clicked
        private void lvWindows_ColumnClick(object sender,  ColumnClickEventArgs e)
        {
            lvWindows.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        // move window when move button is clicked
        private void btnMove_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selected = lvWindows.SelectedItems;
            int x = Convert.ToInt32(txtX.Text);
            int y = Convert.ToInt32(txtY.Text);
            foreach (ListViewItem item in selected)
            {
                IntPtr hwnd = (IntPtr)(Convert.ToInt64(item.Name));
                if (mWindowInfo.ContainsKey(hwnd))
                {
                    Native.WinAPI.SetWindowPos(hwnd, Native.WinAPI.HWNDInsertAfter.TOP, x, y, mWindowInfo[hwnd].WindowRect.Width, mWindowInfo[hwnd].WindowRect.Height, Native.WinAPI.SWP.SHOWWINDOW);
                }
            }
        }

        // move to primary monitor
        private void bntMovePrimary_Click(object sender, EventArgs e)
        {
            updateScreens();
            ListView.SelectedListViewItemCollection selected = lvWindows.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                IntPtr hwnd = (IntPtr)(Convert.ToInt64(item.Name));
                if (mWindowInfo.ContainsKey(hwnd))
                {
                    Native.WindowInfo wi = mWindowInfo[hwnd];
                    Rectangle r = new Rectangle(wi.WindowRect.X, wi.WindowRect.Y, wi.WindowRect.Width, wi.WindowRect.Height);
                    Screen scr = Screen.FromRectangle(r);
                    if (!scr.Primary && mScreenPrimary != null && mScreenSecondary != null)
                    {
                        // only move if window is not already on primary
                        moveToScreen(wi, scr, mScreenPrimary);
                    }
                }
            }
        }

        // move to secondary monitor
        private void btnMoveSecondary_Click(object sender, EventArgs e)
        {
            updateScreens();
            ListView.SelectedListViewItemCollection selected = lvWindows.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                IntPtr hwnd = (IntPtr)(Convert.ToInt64(item.Name));
                if (mWindowInfo.ContainsKey(hwnd))
                {
                    Native.WindowInfo wi = mWindowInfo[hwnd];
                    Rectangle r = new Rectangle(wi.WindowRect.X, wi.WindowRect.Y, wi.WindowRect.Width, wi.WindowRect.Height);
                    Screen scr = Screen.FromRectangle(r);
                    if (scr.Primary && mScreenPrimary != null && mScreenSecondary != null)
                    {
                        // only move if window is not already on secondary
                        moveToScreen( wi, scr, mScreenSecondary);
                    }
                }
            }
        }


        private void radioScreenArea_CheckedChanged(object sender, EventArgs e)
        {
            updateSelectedPreview();
        }

        private void radioWindow_CheckedChanged(object sender, EventArgs e)
        {
            updateSelectedPreview();
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            updateSelectedPreview();
        }

        private void radioCapSelected_CheckedChanged(object sender, EventArgs e)
        {
            // when selected window option is checked, enable the area and window content options
            radioScreenArea.Enabled = true;
            radioWindow.Enabled = true;
            updateSelectedPreview();
        }

        private void radioCapPrimary_CheckedChanged(object sender, EventArgs e)
        {
            // when primary monitor is checked disable area and window options since we can only do area
            radioScreenArea.Enabled = false;
            radioWindow.Enabled = false;
            updateSelectedPreview();
        }

        private void radioCapSecondary_CheckedChanged(object sender, EventArgs e)
        {
            // when secondary monitor is checked disable area and window options since we can only do area
            radioScreenArea.Enabled = false;
            radioWindow.Enabled = false;
            updateSelectedPreview();
        }


        // Implements the manual sorting of items by columns.
        class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }
    }
}
