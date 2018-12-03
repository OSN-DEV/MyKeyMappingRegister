using MyLib.WF.Component;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text;

namespace MyKeyMappingGenerator {
    public partial class MainForm : FormEx {

        #region Declaration
        //private enum Col:int {
        //    ScanCode1  = 0,
        //    WindowsKey1,
        //    Flags1,
        //    ScanCode2,
        //    WindowsKey2,
        //    Flags2,
        //    Edit,
        //    Delete,
        //}
        private class Col {
            public const int ScanCode1 = 0;
            public const int WindowsKey1 = ScanCode1 + 1;
            public const int Flags1 = WindowsKey1 + 1;
            public const int ScanCode2 = Flags1 + 1;
            public const int WindowsKey2 = ScanCode2 + 1;
            public const int Flags2 = WindowsKey2 + 1;
            public const int Edit = Flags2 + 1;
            public const int Delete = Edit + 1;
        }

        private class KeyListModel {
            public string ScanCode1 = "";
            public string WindowsKey1 = "";
            public string Flags1 = "";
            public string ScanCode2 = "";
            public string WindowsKey2 = "";
            public string Flags2 = "";
        }

        private class KeyListItem {
            public string ScanCode = "";
            public string WindowsKey = "";
            public string Flags = "";
            public KeyListItem(string scanCode, string windowsKey, string flags) {
                this.ScanCode = scanCode;
                this.WindowsKey = windowsKey;
                this.Flags = flags;
            }
            public override string ToString() {
                return this.WindowsKey;
            }
        }

        private Dictionary<string, string> _displayNameMapping = new Dictionary<string, string>() {
            {"LShiftKey","Shift(Left)" },
            {"LControlKey","Control(Left)" },
            {"LWin","Windows(Left)" },
            {"LMenu","Alt(Left)" },
            {"IMENoconvert","無変換" },
            {"IMEConvert","変換" },
            {"RMenu","Alt(Right)" },
            {"RShiftKey","Shift(Right)" },
            {"Next","PageDown" },
        };
        private DataGridViewRowEx _row = null;
        private string _fileName = "";
        private bool _changed = false;
        #endregion

        #region Constructor
        public MainForm() {
            InitializeComponent();
        }
        #endregion

        #region Form Event
        private void MainForm_Load(object sender, EventArgs e) {
            this.InitForm();
            this.CreateKeyCodeList();
            this.StartHook();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.StopHook();
        }
        #endregion

        #region Menu Event
        private void cFile_New_Click(object sender, EventArgs e) {
            if (this._changed) {
                if (base.ShowConfirmDlg("編集内容を破棄しますか？")) {
                    return;
                }
            }
            this.InitForm();
            this._changed = false;
        }

        private void cFile_Open_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "default.mkmr";
            dialog.InitialDirectory = System.Environment.CurrentDirectory;
            dialog.Filter = "設定ファイル(*.mkmr)|*.mkmr";
            dialog.FilterIndex = 0;
            dialog.Title = "開くファイルを選択してください";
            dialog.RestoreDirectory = true;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;

            if (dialog.ShowDialog() == DialogResult.OK) {
                MyLib.File.XmlOperator xml = new MyLib.File.XmlOperator();
                this.cKeyList.SetSerializeValue(xml.Deserialize<List<List<string>>>(dialog.FileName));
            }
        }

        private void cFile_Save_Click(object sender, EventArgs e) {
            if (0 == this._fileName.Length) {
                this.cFile_SaveAs.PerformClick();
                return;
            }
            this.SaveKeyList(this._fileName);
            this._changed = false;
        }

        private void cFile_SaveAs_Click(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "新しいファイル.mkmr";
            if (0 == this._fileName.Length) {
                dialog.InitialDirectory = System.Environment.CurrentDirectory;
            } else {
                dialog.InitialDirectory = this._fileName;
            }
            dialog.Filter = "設定ファイル(*.mkmr)|*.mkmr";
            dialog.FilterIndex = 0;
            dialog.Title = "保存先のファイルを選択してください";
            dialog.RestoreDirectory = true;
            dialog.OverwritePrompt = true;
            dialog.CheckPathExists = true;

            if (dialog.ShowDialog() != DialogResult.OK) {
                return;
            }
            this._fileName = dialog.FileName;
            this.SaveKeyList(this._fileName);
            this._changed = false;
        }

        private void cFile_Exit_Click(object sender, EventArgs e) {
            Application.Exit();
        }


        private void cRegistry_Register_Click(object sender, EventArgs e) {
            try {
                this.Register();
            } catch (Exception ex) {
                MessageBox.Show("登録に失敗しました\n" + ex.Message);
            }
        }

        private void cRegistry_CreateRegisterFile_Click(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "KeyMap.reg";
            if (0 == this._fileName.Length) {
                dialog.InitialDirectory = System.Environment.CurrentDirectory;
            } else {
                dialog.InitialDirectory = this._fileName;
            }
            dialog.Filter = "設定ファイル(*.reg)|*.reg";
            dialog.FilterIndex = 0;
            dialog.Title = "保存先のファイルを選択してください";
            dialog.RestoreDirectory = true;
            dialog.OverwritePrompt = true;
            dialog.CheckPathExists = true;

            if (dialog.ShowDialog() != DialogResult.OK) {
                return;
            }
            this.CreateRegisterFile(dialog.FileName);
        }
        #endregion

        #region Control Event
        private void cSave_Click(object sender, EventArgs e) {
            if (0 == this.cScanCode1.Text.Length || 0 == this.cScanCode2.Text.Length) {
                return;
            }

            DataGridViewRowEx row = this._row;
            if (null == row) {
                row = this.cKeyList.FindRow(Col.ScanCode1, this.cScanCode1.Text);
                if (row == null) {
                    row = this.cKeyList.NewRow();
                }
            }
            row.setValue(Col.ScanCode1, this.cScanCode1.Text);
            row.setValue(Col.WindowsKey1, this.cWindowsKey1.Text);
            row.setValue(Col.Flags1, this.cFlags1.Text);
            row.setValue(Col.ScanCode2, this.cScanCode2.Text);
            row.setValue(Col.WindowsKey2, this.cWindowsKey2.Text);
            row.setValue(Col.Flags2, this.cFlags2.Text);
            row.setValue(Col.Edit, "edit");
            row.setValue(Col.Delete, "delete");

            this._changed = true;
        }

        private void cKeyList_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            switch (e.ColumnIndex) {
                case Col.Edit:
                    this.KeyList_Edit_Click(e.RowIndex);
                    break;
                case Col.Delete:
                    this.KeyList_Delete_Click(e.RowIndex);
                    break;
            }
        }
        private void cKeyCodeList_SelectedIndexChanged(object sender, EventArgs e) {
            KeyListItem item = (KeyListItem)this.cKeyCodeList.SelectedItem;
            if (0 == item.ScanCode.Length) {
                return;
            }
            this.cScanCode2.Text = item.ScanCode;
            this.cWindowsKey2.Text = item.WindowsKey;
            this.cFlags2.Text = item.Flags;
        }
        #endregion

        #region Keyboard Event
        void hookKeyboardEvent(ref KeyboardGlobalHook.KeyboardData data) {
            if (data.Stroke != KeyboardGlobalHook.Stroke.KEY_UP) {
                return;
            }

            LabelEx scanCode = this.cMode1.Checked ? this.cScanCode1 : this.cScanCode2;
            LabelEx windowsKey = this.cMode1.Checked ? this.cWindowsKey1 : this.cWindowsKey2;
            LabelEx flags = this.cMode1.Checked ? this.cFlags1 : this.cFlags2;

            scanCode.Text = "0x" + data.ScanCode.ToString("X");
            windowsKey.Text = this.ConvertDisplayName(((System.Windows.Forms.Keys)data.Key).ToString());
            if (data.Extended) {
                flags.Text = "Extended";
            } else {
                flags.Text = "";
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 
        /// </summary>
        private void StartHook() {
            if (KeyboardGlobalHook.IsHooking) {
                return;
            }
            KeyboardGlobalHook.AddEvent(hookKeyboardEvent);
            KeyboardGlobalHook.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void StopHook() {
            if (!KeyboardGlobalHook.IsHooking) {
                return;
            }
            KeyboardGlobalHook.Stop();
        }

        /// <summary>
        /// initialize
        /// </summary>
        private void InitForm() {
            this.cScanCode1.Text = "";
            this.cScanCode2.Text = "";
            this.cWindowsKey1.Text = "";
            this.cWindowsKey2.Text = "";
            this.cFlags1.Text = "";
            this.cFlags2.Text = "";
            this.cKeyList.Rows.Clear();
            this.cMode1.Checked = true;
        }

        /// <summary>
        /// add key mapping to key list
        /// </summary>
        /// <param name="file"></param>
        private void SaveKeyList(string file) {
            MyLib.File.XmlOperator xml = new MyLib.File.XmlOperator();
            xml.Serialize<List<List<string>>>(file, this.cKeyList.GetSerializeValue());
        }

        /// <summary>
        /// delete click
        /// </summary>
        /// <param name="index"></param>
        private void KeyList_Delete_Click(int index) {
            this.cKeyList.DeleteRow(index);
            this._changed = true;
        }

        /// <summary>
        /// edit click
        /// </summary>
        /// <param name="index"></param>
        private void KeyList_Edit_Click(int index) {
            this._row = this.cKeyList.GetRow(index);
            this.cScanCode1.Text = this._row.getValue(Col.ScanCode1);
            this.cScanCode2.Text = this._row.getValue(Col.ScanCode2);
            this.cWindowsKey1.Text = this._row.getValue(Col.WindowsKey1);
            this.cWindowsKey2.Text = this._row.getValue(Col.WindowsKey2);
            this.cFlags1.Text = this._row.getValue(Col.Flags1);
            this.cFlags2.Text = this._row.getValue(Col.Flags2);
        }

        private void CreateKeyCodeList() {
            //            this.cKeyCodeList.Items.Add(new KeyListItem("", "", ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x2A", this.ConvertDisplayName("LShiftKey"), ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x1D", this.ConvertDisplayName("LControlKey"), ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x5B", this.ConvertDisplayName("LWin"), "Extended"));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x38", this.ConvertDisplayName("LMenu"), ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x7B", this.ConvertDisplayName("IMENoconvert"), ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x79", this.ConvertDisplayName("IMEConvert"), ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x70", this.ConvertDisplayName("Oemtide"), ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x38", this.ConvertDisplayName("RMenu"), "Extended"));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x36", this.ConvertDisplayName("Shift(Right)"), ""));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x47", this.ConvertDisplayName("Home"), "Extended"));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x4F", this.ConvertDisplayName("End"), "Extended"));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x49", this.ConvertDisplayName("PageUp"), "Extended"));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x51", this.ConvertDisplayName("Next"), "Extended"));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x53", this.ConvertDisplayName("Delete"), "Extended"));
            this.cKeyCodeList.Items.Add(new KeyListItem("0x37", this.ConvertDisplayName("PrintScreen"), "Extended"));
        }

        private string ConvertDisplayName(string windowsKey) {
            string result = windowsKey;
            if (this._displayNameMapping.ContainsKey(windowsKey)) {
                result = this._displayNameMapping[windowsKey];
            }
            return result;
        }

        private void Register() {
            RegistryKey regKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Keyboard Layout");
            string[] code = this.GetMapgginData().Split(',');
            byte[] byteData = this.FromHexString(this.GetMapgginData().Replace(",",""));
            regKey.SetValue("Scancode Map", byteData);
            regKey.Close();
        }

        private void CreateRegisterFile(string file) {
            using (MyLib.File.FileOperator fileOperator = new MyLib.File.FileOperator(file)) {
                fileOperator.openForWrite(System.Text.Encoding.ASCII);
                fileOperator.writeLine("Windows Registry Editor Version 5.00");
                fileOperator.writeLine("");
                fileOperator.writeLine(@"[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Keyboard Layout]");
                fileOperator.writeLine(@"""Scancode Map""=hex:" + this.GetMapgginData());
            }
        }

        private string GetMapgginData() {
            StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("00,00,00,00");      // ヘッダー(バージョン番号)
            builder.Append(",00,00,00,00");      // ヘッダー(フラグ)
            builder.Append("," + this.cKeyList.RowCount.ToString("X2") + ",00,00,00"); // エントリー数

            for (int i = 0; i < this.cKeyList.RowCount; i++) {
                DataGridViewRowEx row = this.cKeyList.GetRow(i);
                builder.Append("," + row.getValue(Col.ScanCode2));
                if (0 == row.getValue(Col.Flags2).Length) {
                    builder.Append(",00");
                } else {
                    builder.Append(",E0");
                }
                builder.Append("," + row.getValue(Col.ScanCode1));
                if (0 == row.getValue(Col.Flags1).Length) {
                    builder.Append(",00");
                } else {
                    builder.Append(",E0");
                }
            }
            builder.Append(",00,00,00,00");  // NULLターミネーター

            return builder.ToString().Replace("0x","");
        }


        // http://tilfin.hatenablog.com/entry/20070923/1190528490
        /// <summary>
        /// バイト配列から16進数の文字列を生成します。
        /// </summary>
        /// <param name="bytes">バイト配列</param>
        /// <returns>16進数文字列</returns>
        public  string ToHexString(byte[] bytes) {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes) {
                if (b < 16) sb.Append('0'); // 二桁になるよう0を追加
                sb.Append(Convert.ToString(b, 16));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 16進数の文字列からバイト配列を生成します。
        /// </summary>
        /// <param name="str">16進数文字列</param>
        /// <returns>バイト配列</returns>
        public  byte[] FromHexString(string str) {
            int length = str.Length / 2;
            byte[] bytes = new byte[length];
            int j = 0;
            for (int i = 0; i < length; i++) {
                bytes[i] = Convert.ToByte(str.Substring(j, 2), 16);
                j += 2;
            }
            return bytes;
        }
        #endregion

    }
}
