using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnikeyAutoSwitch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();


        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);
        [DllImport("psapi.dll")]
        private static extern uint GetModuleFileNameEx(IntPtr hWnd, IntPtr hModule, StringBuilder lpFileName, int nSize);

        private string GetPathFocusWindow()
        {
            IntPtr hWnd = GetForegroundWindow();
            uint lpdwProcessId;
            GetWindowThreadProcessId(hWnd, out lpdwProcessId);

            IntPtr hProcess = OpenProcess(0x0410, false, lpdwProcessId);

            StringBuilder text = new StringBuilder(1000);
            //GetModuleBaseName(hProcess, IntPtr.Zero, text, text.Capacity);
            GetModuleFileNameEx(hProcess, IntPtr.Zero, text, text.Capacity);

            CloseHandle(hProcess);

            return text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(System.Reflection.Assembly.GetEntryAssembly().Location);
            // SendKeys.Send("^+");

            Thread.Sleep(2000);
            MessageBox.Show(GetPathFocusWindow());
        }

        bool running;
        bool inListSetV; // set V in rule list
        bool addingRuleList, addingBlackList;
        bool setE; // true (E), false (V)
        bool shortcut; // true (Ctrl+Shift), false (alt+Z)
        List<string> ruleList, blackList;
        HashSet<string> ruleListSet, blackListSet;
        string myAppPath;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!addingRuleList)
            {
                MessageBox.Show("Đóng hộp thoại này, sau đó mở chương trình bạn cần thêm vào danh sách, và quay lại đây. Chương trình được thêm vào danh sách sẽ là chương trình cuối cùng bạn mở trước khi quay lại.", "Hướng dẫn");
                addBtn.Text = "Hủy thêm";
                addingRuleList = true;
                addingBlackList = false;
                running = false;
                updateGui();
            }
            else
            {
                addBtn.Text = "Thêm";
                addingRuleList = false;
                running = true;
                updateGui();
            }
        }

        private void init()
        {
            running = true;
            addingRuleList = false;
            addingBlackList = false;
            setE = true;
            string filename = "uas.data";
            myAppPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            ruleList = new List<string>();
            blackList = new List<string>();
            ruleListSet = new HashSet<string>();
            blackListSet = new HashSet<string>();
            blackListSet.Add("");
            blackListSet.Add(@"C:\Windows\explorer.exe");
            blackList.Add("");
            blackList.Add(@"C:\Windows\explorer.exe");
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                inListSetV = (lines[0].Equals("1"));
                shortcut = (lines[1].Equals("1"));
                int size = int.Parse(lines[2]);
                for (int i = 3; i < 3 + size; ++i)
                {
                    ruleList.Add(lines[i]);
                    ruleListSet.Add(lines[i]);
                }
                for (int i = 3 + size; i < lines.Length; ++i)
                {
                    blackListSet.Add(lines[i]);
                    blackList.Add(lines[i]);
                }
            }
            else
            {
                inListSetV = true;
                shortcut = true;
            }
            updateGui();
            updateFile();
            addingRuleListThread();
            addingBlackListThread();
            runningThread();
        }

        private void updateGui()
        {
            if (inListSetV) setVRb.Select(); else setERb.Select();
            if (setE) eRb.Select(); else vRb.Select();
            if (shortcut) ctrlshiftRb.Select(); else altzRb.Select();
            pathsLv.Items.Clear();
            if (addingBlackList) addBlackListBtn.Text = "Hủy thêm";
            else addBlackListBtn.Text = "Thêm";
            if (addingRuleList) addBtn.Text = "Hủy thêm";
            else addBtn.Text = "Thêm";
            if (running) pauseBtn.Text = "Tạm dừng";
            else pauseBtn.Text = "Tiếp tục";
            foreach (string path in ruleList) pathsLv.Items.Add(new ListViewItem(path));
            blackLv.Items.Clear();
            foreach (string path in blackListSet) blackLv.Items.Add(new ListViewItem(path));
        }

        private void updateFile()
        {
            string[] s = new string[3 + ruleList.Count + blackListSet.Count];
            s[0] = inListSetV ? "1" : "0";
            s[1] = shortcut ? "1" : "0";
            s[2] = ruleList.Count + "";
            for (int i = 3; i < 3 + ruleList.Count; ++i) s[i] = ruleList[i - 3];
            int j = 3 + ruleList.Count;
            foreach (string p in blackListSet) s[j++] = p;
            File.WriteAllLines("uas.data", s);
        }

        private void addingRuleListThread()
        {
            Thread t = new Thread(() => {
                string prevPath = "";
                while (formRunning)
                {
                    if (addingRuleList)
                    {
                        string path = GetPathFocusWindow();
                        // File.AppendAllText("log", path + "\n" + prevPath + "\n" + myAppPath.Equals(path) + "\n" + !prevPath.Equals("") + "\n" + !prevPath.Equals(myAppPath) + "\n\n");
                        if (myAppPath.Equals(path) && !prevPath.Equals(""))
                        {
                            if (!ruleListSet.Contains(prevPath))
                            {
                                ruleList.Add(prevPath);
                                ruleListSet.Add(prevPath);
                            }
                            prevPath = "";
                            addingRuleList = false;
                            running = true;
                            updateGui();
                            updateFile();
                        }
                        if (!myAppPath.Equals(path) && !blackListSet.Contains(path)) prevPath = path;
                    }
                    Thread.Sleep(100);
                }
            });
            t.Start();
        }

        private void addingBlackListThread()
        {
            Thread t = new Thread(() => {
                string prevPath = "";
                while (formRunning)
                {
                    if (addingBlackList)
                    {
                        string path = GetPathFocusWindow();
                        // File.AppendAllText("log", path + "\n" + prevPath + "\n" + myAppPath.Equals(path) + "\n" + !prevPath.Equals("") + "\n" + !prevPath.Equals(myAppPath) + "\n\n");
                        if (myAppPath.Equals(path) && !prevPath.Equals(""))
                        {
                            if (!blackListSet.Contains(prevPath))
                            {
                                blackList.Add(prevPath);
                                blackListSet.Add(prevPath);
                            }
                            prevPath = "";
                            addingBlackList = false;
                            running = true;
                            updateGui();
                            updateFile();
                        }
                        if (!myAppPath.Equals(path) && !blackListSet.Contains(path)) prevPath = path;
                    }
                    Thread.Sleep(100);
                }
            });
            t.Start();
        }

        bool formRunning = true;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            formRunning = false;
            base.OnFormClosing(e);
        }

        private void sendkey(String key)
        {
            try
            {
                SendKeys.Send(key);
            }
            catch
            {
                SendKeys.SendWait(key);
            }
        }
        private void runningThread()
        {
            Thread t = new Thread(() => {
                while (formRunning)
                {
                    if (running)
                    {
                        string path = GetPathFocusWindow();
                        //File.AppendAllText("log2", path + "\n");
                        if (!blackListSet.Contains(path))
                        {
                            if (ruleListSet.Contains(path))
                            {
                                if (inListSetV == setE)
                                {
                                    if (shortcut) sendkey("^+");
                                    else sendkey("%Z");
                                    setE = !setE;
                                    if (setE) eRb.Select();
                                    else vRb.Select();
                                }
                            }
                            else
                            {
                                if (inListSetV != setE)
                                {
                                    if (shortcut) sendkey("^+");
                                    else sendkey("%Z");
                                    setE = !setE;
                                    if (setE) eRb.Select();
                                    else vRb.Select();
                                }
                            }
                        }
                    }
                    Thread.Sleep(50);
                }
            });
            t.Start();
        }

        private void pathsLv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ruleListSet.Remove(ruleList[ruleListSelectedIdx]);
                ruleList.RemoveAt(ruleListSelectedIdx);
                updateGui();
                updateFile();
            }
        }
        int ruleListSelectedIdx = -1;
        private void pathsLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pathsLv.Items.Count > 0)
            {
                try
                {
                    ruleListSelectedIdx = pathsLv.Items.IndexOf(pathsLv.SelectedItems[0]);
                }
                catch { }
            }
            else
            {
                ruleListSelectedIdx = -1;
            }
        }

        private void eRb_CheckedChanged(object sender, EventArgs e)
        {
            if (eRb.Checked) setE = true; else setE = false;
            updateGui();
        }

        private void ctrlshiftRb_CheckedChanged(object sender, EventArgs e)
        {
            if (ctrlshiftRb.Checked) shortcut = true; else shortcut = false;
            updateGui();
            updateFile();
        }

        private void onRb_CheckedChanged(object sender, EventArgs e)
        {
            if (setVRb.Checked) inListSetV = true; else inListSetV = false;
            updateGui();
            updateFile();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (running)
            {
                running = false;
                pauseBtn.Text = "Tiếp tục";
            }
            else
            {
                running = true;
                pauseBtn.Text = "Tạm dừng";
                updateGui();
            }
        }

        private void pathsLv_DoubleClick(object sender, EventArgs e)
        {

        }

        private void showInfo()
        {
            MessageBox.Show("1. Mở chương trình, cài đặt đúng trạng thái Unikey hiện tại với trạng thái Unikey trên chương trình.\n" +
                "2. Với lần đầu mở, thêm ứng dụng cần điều chỉnh Unikey vào danh sách, sau đó chọn kiểu danh sách là bật hay tắt Unikey, ví dụ cài đặt là Set V trong danh sách thì với mọi chương trình cần bật Unikey như trình duyệt, Word,...  khi chuyển cửa sổ sang nó, Unikey sẽ tự bật tiếng Việt, và nếu bạn mở chương trình không trong danh sách, Unikey sẽ tự bật tiếng Anh, và ngược lại.\n" +
                "3. Cài đặt đúng phím tắt trong Unikey máy của bạn cho chương trình biết.\n\n" +
                "Chương trình được viết bởi Hien Hoang, mong nhận được đóng góp từ mọi người.", "Thông tin");
        }


        int blackListSelectedIdx = -1;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blackLv.Items.Count > 0)
            {
                try
                {
                    blackListSelectedIdx = blackLv.Items.IndexOf(blackLv.SelectedItems[0]);
                }
                catch { }
            }
            else
            {
                blackListSelectedIdx = -1;
            }
        }

        private void blackLv_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Danh sách không ảnh hưởng là danh sách các chương trình sẽ không bị thay đổi trạng thái Unikey khi mở vào. Một số chương trình ngăn chặn việc gõ phím tắt thay đổi trạng thái Unikey, để chương trình không bị gián đoạn, hãy thêm những chương trình đó vào danh sách này.", "Thông tin");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showInfo();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!addingBlackList)
            {
                MessageBox.Show("Đóng hộp thoại này, sau đó mở chương trình bạn cần thêm vào danh sách, và quay lại đây. Chương trình được thêm vào danh sách sẽ là chương trình cuối cùng bạn mở trước khi quay lại.", "Hướng dẫn");
                addBlackListBtn.Text = "Hủy thêm";
                addingBlackList = true;
                addingRuleList = false;
                running = false;
                updateGui();
            }
            else
            {
                addBlackListBtn.Text = "Thêm";
                addingBlackList = false;
                running = true;
                updateGui();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nếu 1 chương trình có trong danh sách này, khi đang được mở trên cùng, Unikey sẽ tự động chuyển chế độ gõ tiếng Việt/Anh tương ứng với cài đặt phía dưới. Và những chương trình không nằm trong danh sách khi được mở trên cùng sẽ áp dụng ngược lại.", "Thông tin");
        }

        private void blackLv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                blackListSet.Remove(blackList[blackListSelectedIdx]);
                blackList.RemoveAt(blackListSelectedIdx);
                updateGui();
                updateFile();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Danh sách không ảnh hưởng là danh sách các chương trình sẽ không bị thay đổi trạng thái Unikey khi mở vào. Một số chương trình ngăn chặn việc gõ phím tắt thay đổi trạng thái Unikey, để không bị gián đoạn, hãy thêm những chương trình đó vào danh sách này.", "Thông tin");
        }
    }
}
