using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Captche;
using CaptcheIO;
using Http;

namespace SmartLib
{
    public partial class Form1 : Form
    {
        Bitmap img;
        Bitmap[] bit;
        CaptcheData[] captche = new CaptcheData[4];

        public Form1()
        {
            InitializeComponent();
        }

        //识别图片
        private void btnSmart_Click(object sender, EventArgs e)
        {
            CaptcheIO.CaptcheIO io = new CaptcheIO.CaptcheIO();
            txtp1.Text = io.Is_Equal(captche[0]);
            txtp2.Text = io.Is_Equal(captche[1]);
            txtp3.Text = io.Is_Equal(captche[2]);
            txtp4.Text = io.Is_Equal(captche[3]);

            //YanMoCaptche yanmo = new YanMoCaptche();
            //if (txtp1.Text.Length != 1)
            //{
            //    captche[0].Character = yanmo.CharacterLine(bit[0], true, 7);
            //    captche[0].Bearing = "H";
            //    captche[0].Line = "7";
            //    txtp1.Text = io.Is_Equal(captche[0]);

            //    if (txtp1.Text.Length != 1)
            //    {
            //        captche[0].Character = yanmo.CharacterLine(bit[0], true, 8);
            //        captche[0].Bearing = "H";
            //        captche[0].Line = "8";
            //        txtp1.Text = io.Is_Equal(captche[0]);
            //    }
            //}
            //if (txtp2.Text.Length != 1)
            //{
            //    captche[1].Character = yanmo.CharacterLine(bit[1], false, 7);
            //    captche[1].Bearing = "H";
            //    captche[1].Line = "7";
            //    txtp1.Text = io.Is_Equal(captche[1]);

            //    if (txtp2.Text.Length != 1)
            //    {
            //        captche[1].Character = yanmo.CharacterLine(bit[1], true, 8);
            //        captche[1].Bearing = "H";
            //        captche[1].Line = "8";
            //        txtp2.Text = io.Is_Equal(captche[1]);
            //    }
            //}
            //if (txtp3.Text.Length != 1)
            //{
            //    captche[2].Character = yanmo.CharacterLine(bit[2], false, 7);
            //    captche[2].Bearing = "H";
            //    captche[2].Line = "7";
            //    txtp1.Text = io.Is_Equal(captche[2]);

            //    if (txtp3.Text.Length != 1)
            //    {
            //        captche[2].Character = yanmo.CharacterLine(bit[2], true, 8);
            //        captche[2].Bearing = "H";
            //        captche[2].Line = "8";
            //        txtp3.Text = io.Is_Equal(captche[2]);
            //    }
            //}
            //if (txtp4.Text.Length != 1)
            //{
            //    captche[3].Character = yanmo.CharacterLine(bit[3], false, 7);
            //    captche[3].Bearing = "H";
            //    captche[3].Line = "7";
            //    txtp1.Text = io.Is_Equal(captche[3]);

            //    if (txtp4.Text.Length != 1)
            //    {
            //        captche[3].Character = yanmo.CharacterLine(bit[3], true, 8);
            //        captche[3].Bearing = "H";
            //        captche[3].Line = "8";
            //        txtp4.Text = io.Is_Equal(captche[3]);
            //    }
            //}
        }

        //下载图像并分割
        private void btnDown_Click(object sender, EventArgs e)
        {
            Http.Http http = new Http.Http();
            picSource.Image = http.PostImg(txtUrlImg.Text.Trim());

            img = new Bitmap(picSource.Image);  //加载图像

            if (img != null)
            {
                YanMoCaptche yanmo = new YanMoCaptche();

                

                //去除红色
                img = yanmo.ClearRedColor(img, 130);

                //去除绿色
                img = yanmo.ClearGreenColor(img, 150);

                //去除蓝色
                img = yanmo.ClearBlueColor(img, 200);

                //灰度化
                img = yanmo.GrayImage(img, 200);

                //去噪
                img = yanmo.ClearNoise(img);    
                picSource.Image = img;
                
                
                
                return;


                

                bit = yanmo.InciseImage(img);  //切割

                for (int i = 0; i < captche.Length; i++)    //填充
                {
                    string code = string.Format("{0}", yanmo.CharacterLine(bit[i], false, 4));
                    captche[i].Character = code;
                    //captche[i].Character = yanmo.CountBlack(bit[i],0).ToString();
                    captche[i].Bearing = "H";
                    captche[i].Line = "6";
                }

                pic1.Image = bit[0];
                pic2.Image = bit[1];
                pic3.Image = bit[2];
                pic4.Image = bit[3];
            }
            rtxState.Clear();
        }

        //H4填充
        private void button2_Click(object sender, EventArgs e)
        {
            YanMoCaptche yanmo = new YanMoCaptche();
            for (int i = 0; i < captche.Length; i++)
            {
                string code = string.Format("{0}{1}{2}{3}{4}",
                    yanmo.CharacterLine(bit[i], true, 3),
                    yanmo.CharacterLine(bit[i], true, 5),
                    yanmo.CharacterLine(bit[i], true, 8),
                    yanmo.CharacterLine(bit[i], true, 11),
                    yanmo.CharacterLine(bit[i], true, 13));
                captche[i].Character = code;
                captche[i].Bearing = "H";
                captche[i].Line = "6";
            }
        }

        //H9填充
        private void button3_Click(object sender, EventArgs e)
        {
            YanMoCaptche yanmo = new YanMoCaptche();
            for (int i = 0; i < captche.Length; i++)
            {
                captche[i].Character = yanmo.CharacterLine(bit[i], true, 8);
                captche[i].Bearing = "H";
                captche[i].Line = "8";
            }
        }

        //H7填充
        private void button4_Click(object sender, EventArgs e)
        {
            YanMoCaptche yanmo = new YanMoCaptche();
            for (int i = 0; i < captche.Length; i++)
            {
                captche[i].Character = yanmo.CharacterLine(bit[i], true, 7);
                captche[i].Bearing = "H";
                captche[i].Line = "7";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            picSource.Image.Save(string.Format("key/{0}{1}{2}{3}.bmp",
                txtp1.Text.Trim(),
                txtp2.Text.Trim(),
                txtp3.Text.Trim(),
                txtp4.Text.Trim()));

            Save();
        }

        //保存
        public void Save()
        {
            if (txtp1.Text.Trim() != string.Empty &&
                txtp2.Text.Trim() != string.Empty &&
                txtp3.Text.Trim() != string.Empty &&
                txtp4.Text.Trim() != string.Empty)
            {
                /************************************/
                captche[0].Code = txtp1.Text.Trim();
                captche[1].Code = txtp2.Text.Trim();
                captche[2].Code = txtp3.Text.Trim();
                captche[3].Code = txtp4.Text.Trim();
                /************************************/

                CaptcheIO.CaptcheIO io = new CaptcheIO.CaptcheIO();
                for (int i = 0; i < captche.Length; i++)
                {
                    io.Add(captche[i]);
                }
            }
            else rtxState.Text = "为空";
            rtxState.Text = "保存成功";

            txtp1.Clear();
            txtp2.Clear();
            txtp3.Clear();
            txtp4.Clear();
        }

        //选择图像
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Reset();
            open.RestoreDirectory = true;
            open.ShowDialog();
            txtUrlImg.Text = open.FileName;
            if (txtUrlImg.Text.Trim() != string.Empty)
            {
                try
                {
                    picSource.Image = Image.FromFile(txtUrlImg.Text);
                    img = new Bitmap(picSource.Image);
                    if (img != null)
                    {
                        YanMoCaptche yanmo = new YanMoCaptche();
                        img = yanmo.GrayImage(img, 180);     //灰度化
                        img = yanmo.ClearNoise(img);    //去噪
                        bit = yanmo.InciseImage(img);  //切割

                        for (int i = 0; i < bit.Length; i++)    //冲洗
                        {
                            //bit[i].Save("S" + i.ToString() + ".bmp");
                            bit[i] = yanmo.RinseImage(bit[i]);
                            //bit[i].Save("H" + i.ToString() + ".bmp");
                        }

                        pic1.Image = bit[0];
                        pic2.Image = bit[1];
                        pic3.Image = bit[2];
                        pic4.Image = bit[3];
                    }
                    rtxState.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "郁闷！你选的是图片吗？");
                }
            }
        }
    }
}
