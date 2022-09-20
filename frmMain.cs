using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWNFont
{
    public partial class frmMain : Form
    {
        string findChar = "ịăâôơưáàảọãạắằẳẵặđấầẩẫậéèẻẽẹêếềểễệíìỉĩóòỏõốồổỗộớờởỡợúùủũụứừửữựĐABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string replaceChr = "!\"#$%&'()*+,-;<=>@ABCDEFGHIJeFGHIJKLMNOPQRSTUVWXYZ\\^_`fjwz{|}~@abcde ghi klmnopqrstuv xy ";

        char[] replChr = null;
        char[] findChr = null;
        public frmMain()
        {
            InitializeComponent();
        }

        long fileLen = 0;
        byte[] twnData;
        string fileName = "TATPC1.TWN";
        private void ReadTWN(string fileName = "TATPC1.TWN")
        {
            Stream stream = File.OpenRead(fileName);
            BinaryReader br = new BinaryReader(stream);
            fileLen = stream.Length;
            twnData = br.ReadBytes((int)fileLen);
            stream.Close();
            br.Close();
            for (int i = 0; i < twnData.Length; i++)
            {
                twnData[i] ^= 88;
            }

            //stream = File.OpenWrite("xored.jpc");
            //BinaryWriter bw = new BinaryWriter(stream);
            //bw.Write(twnData);
            //bw.Close();
            //stream.Close();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            replChr = replaceChr.ToCharArray();
            findChr = findChar.ToCharArray();

            // Read Data
            pnlEditor.Controls.Clear();
            InitCharacterEditor();

            ReadTWN();
            //WriteTWN();
            WriteTWN1Pic();
        }
        private void WriteTWN2Pic()
        {
            int pos = 0;
            int curX = 7;
            int curY = 1;
            int count = 0;
            Color color = Color.White;
            Bitmap bmp = new Bitmap(3280, 5834); // 160x176 character

            for (pos = 0; pos < fileLen; pos += 23)
            {
                count++;
                byte[] data = new byte[23];
                if (pos + 13 >= fileLen) break;
                Array.Copy(twnData, pos, data, 0, 23);

                int posY = curY;
                for (int i = 0; i < 23; i++)
                {
                    posY++;
                    int lineVal = data[i];
                    for (int j = 0; j < 6; j++)
                    {
                        int colVal = lineVal & (2 << j);
                        if (colVal != 0)
                        {
                            bmp.SetPixel(curX + j, posY, color);
                        }
                        else
                        {
                            bmp.SetPixel(curX + j, posY, Color.Green);
                        }
                    }
                }
                curX += 8;
                if (curX + 8 >= bmp.Width) { curX = 7; curY += 24; }
            }
            bmp.Save("test.png");
        }
        private void WriteTWN1Pic()
        {
            int pos = 0;
            int curX = 7;
            int curY = 1;
            int count = 0;
            Color color = Color.White;
            Bitmap bmp = new Bitmap(1285, 36); // 160x176 character

            for (pos = 480; pos < fileLen; pos += 15)
            {
                if (pos + 15 >= fileLen) break;
                count++; // Count number characters
                int posY = curY;
                byte[] data = new byte[15];
                Array.Copy(twnData, pos, data, 0, 15);
                //string dStr = BitConverter.ToString(data, 0, 15); // For debug

                int charY = 0;
                Bitmap chrBMP = new Bitmap(7, 15);
                for (int i = 0; i < 15; i++)
                {
                    posY++;
                    int lineVal = data[i];
                    for (int j = 6; j >= 0; j--)
                    {
                        double pow = Math.Pow(2, j);
                        int colVal = lineVal & (int)pow;
                        if (colVal == pow)
                        {
                            ///bmp.SetPixel(curX - j, posY, color);
                            chrBMP.SetPixel(6 - j, charY, color);
                        }
                        else
                        {
                            ///bmp.SetPixel(curX - j, posY, Color.Gray);
                            //character.SetPixel(6 - j, charY, Color.Black);
                        }
                    }
                    charY++;
                }
                // Add new char into button
                Button chrBtn = new Button();
                chrBtn.FlatStyle = FlatStyle.Flat;
                chrBtn.BackColor = Color.Black;
                chrBtn.Location = new Point(curX * 2, curY * 2);
                chrBtn.Size = new Size(12, 20);
                chrBtn.Image = chrBMP;

                ChrData ch = new ChrData();
                ch.Data = data;
                ch.Index = count;
                ch.Position = pos;

                chrBtn.Tag = ch;
                chrBtn.Click += new System.EventHandler(CharacterClick);
                this.Controls.Add(chrBtn);

                ///character.Save("chr.png");

                curX += 7;
                if (curX + 7 >= bmp.Width || count % 16 == 0) { curX = 7; curY += 16; }
                if (count >= 128) break;
            }
            //bmp.Save("test.png");
        }
        private void WriteTWN()
        {
            int pos = 0;
            int curX = 7;
            int curY = 1;
            int count = 0;
            Color color = Color.White;
            Bitmap bmp = new Bitmap(1285, 36);

            for (pos = 3840; pos < fileLen; pos += 30)
            {
                if (pos + 30 >= fileLen) break;
                count++; // Count number characters
                int posY = curY;
                byte[] data = new byte[30];
                Array.Copy(twnData, pos, data, 0, 30);

                int LeftY = 0; int RightY = 0;
                Bitmap chrBMP = new Bitmap(15, 15);
                for (int i = 0; i < 15; i++)
                {
                    int lineVal = data[i];

                    for (int j = 6; j >= 0; j--)
                    {
                        double pow = Math.Pow(2, j);
                        int colVal = lineVal & (int)pow;
                        if (colVal == pow)
                        {
                            if (i % 2 == 0) // Odd
                            {
                                chrBMP.SetPixel(6 - j, LeftY, Color.Yellow);
                            }
                            if (i % 2 == 1) // Even
                            {
                                chrBMP.SetPixel(13 - j, RightY, Color.Yellow);
                            }
                        }
                    }
                    if (i % 2 == 0) // Odd
                    {
                        LeftY++;
                    }
                    if (i % 2 == 1) // Even
                    {
                        RightY++;
                    }
                }

                LeftY = 8;
                RightY = 7;
                for (int i = 15; i < 30; i++)
                {
                    int lineVal = data[i];

                    for (int j = 6; j >= 0; j--)
                    {
                        double pow = Math.Pow(2, j);
                        int colVal = lineVal & (int)pow;
                        if (colVal == pow)
                        {
                            if (i % 2 == 0) // Odd
                            {
                                chrBMP.SetPixel(6 - j, LeftY, Color.Yellow);
                            }
                            if (i % 2 == 1) // Even
                            {
                                chrBMP.SetPixel(13 - j, RightY, Color.Yellow);
                            }
                        }
                    }
                    if (i % 2 == 0) // Odd
                    {
                        LeftY++;
                    }
                    if (i % 2 == 1) // Even
                    {
                        RightY++;
                    }
                }

                //chrBMP.Save("test.png");
                // Add new char into button
                Button chrBtn = new Button();
                chrBtn.FlatStyle = FlatStyle.Flat;
                chrBtn.BackColor = Color.Black;
                chrBtn.Location = new Point(curX * 2, curY * 2);
                chrBtn.Size = new Size(16, 16);
                chrBtn.Image = chrBMP;
                //chrBtn.BackgroundImageLayout = ImageLayout.Center;
                //chrBtn.BackgroundImage = chrBMP;

                ChrData ch = new ChrData();
                ch.Data = data;
                ch.Index = count;
                ch.Position = pos;

                chrBtn.Tag = ch;
                //chrBtn.Click += new System.EventHandler(CharacterClick);
                this.Controls.Add(chrBtn);

                //character.Save("chr.png");

                curX += 8;
                if (curX + 8 >= bmp.Width || count % 16 == 0) { curX = 7; curY += 16; }
                if (count >= 640)
                    break;
            }
        }

        ChrData ch;
        Button clickBtn;
        public void CharacterClick(Object sender, System.EventArgs e)
        {
            clickBtn = (Button)sender;
            ch = (ChrData)clickBtn.Tag;
            lblPosition.Text = ch.Index.ToString();
            ///MessageBox.Show(BitConverter.ToString(ch.Data));
            LoadCharacterEditor(ch.Data);
        }
        public void EditorClick(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == "1")
            {
                btn.Tag = "0";
                btn.BackColor = Color.White;
            }
            else
            {
                btn.Tag = "1";
                btn.BackColor = Color.Black;
            }

            //ChrData ch = (ChrData)btn.Tag;
            //LoadCharacterEditor(ch.Data);
            //MessageBox.Show("You clicked character [" + btn.Tag + "]");
        }
        public void UpdateCharacter()
        {
            byte[] data = new byte[15];

            for (int i = 0; i < 15; i++)
            {
                int lineVal = 0;
                for (int j = 6; j >= 0; j--)
                {
                    if (lstBtnEditor[i, j].Tag == "1")
                    {
                        lineVal ^= (int)Math.Pow(2, 6 - j);
                    }
                    //double pow = Math.Pow(2, j);
                    //int colVal = lineVal & (int)pow;                    
                }
                data[i] = (byte)lineVal;
            }
            Array.Copy(data, ch.Data, 15); // Update to ch Data
            clickBtn.Tag = ch;
            UpdateImage(clickBtn, data);

            for (int i = 0; i < 15; i++)
            {
                data[i] ^= 88;
            }
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(fileName));
            bw.Seek(ch.Position, SeekOrigin.Begin);
            bw.Write(data, 0, 15);
            bw.Close();
            MessageBox.Show("Updated!");
        }
        void UpdateImage(Button chrBtn, byte[] data)
        {
            int charY = 0;
            Bitmap chrBMP = new Bitmap(7, 15);
            for (int i = 0; i < 15; i++)
            {
                //posY++;
                int lineVal = data[i];
                for (int j = 6; j >= 0; j--)
                {
                    double pow = Math.Pow(2, j);
                    int colVal = lineVal & (int)pow;
                    if (colVal == pow)
                    {
                        ///bmp.SetPixel(curX - j, posY, color);
                        chrBMP.SetPixel(6 - j, charY, Color.White);
                    }
                    else
                    {
                        ///bmp.SetPixel(curX - j, posY, Color.Gray);
                        //character.SetPixel(6 - j, charY, Color.Black);
                    }
                }
                charY++;
            }
            chrBtn.Image = chrBMP;
        }

        Button[,] lstBtnEditor = new Button[15, 7];
        public void InitCharacterEditor()
        {
            for (int row = 0; row < 15; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Button btnEditor = new Button();
                    //btnEditor.FlatStyle = FlatStyle.Flat;
                    btnEditor.BackColor = Color.White;
                    btnEditor.Location = new Point(1 + (col * 39), 1 + (row * 39));
                    btnEditor.Size = new Size(39, 39);
                    btnEditor.Tag = "0";

                    btnEditor.Click += new System.EventHandler(EditorClick);

                    pnlEditor.Controls.Add(btnEditor);
                    lstBtnEditor[row, col] = btnEditor;
                }
            }
        }
        public void ClearCharacterEditor()
        {
            for (int row = 0; row < 15; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    lstBtnEditor[row, col].BackColor = Color.White;
                }
            }
        }
        public void LoadCharacterEditor(byte[] data)
        {
            ClearCharacterEditor();
            for (int i = 0; i < 15; i++)
            {
                int lineVal = data[i];
                for (int j = 0; j < 7; j++)
                {
                    double pow = Math.Pow(2, j);
                    int colVal = lineVal & (int)pow;
                    if (colVal == pow)
                    {
                        lstBtnEditor[i, 6 - j].BackColor = Color.Black;
                        lstBtnEditor[i, 6 - j].Tag = "1";
                    }
                    else
                    {
                        lstBtnEditor[i, 6 - j].Tag = "0";
                    }
                }
            }
        }

        struct ChrData
        {
            public byte[] Data;
            public int Index;
            public int Position;
        }

        private void btnUpdateCharacter_Click(object sender, EventArgs e)
        {
            UpdateCharacter();
        }

        byte[] copied = new byte[15];
        private void btnCopy_Click(object sender, EventArgs e)
        {
            copied = ch.Data;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            LoadCharacterEditor(copied);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {            
            string cText = txtConvert.Text;
            string result = "";
            foreach(char c in cText)
            {
                if (findChr.Contains(c))
                {
                    int index = Array.IndexOf(findChr, c);
                    result += replChr[index];
                }
                else result += c;
            }
            txtConvert.Text = result;
        }
    }
}
