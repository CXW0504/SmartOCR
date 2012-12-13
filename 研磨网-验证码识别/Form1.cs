using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Captche;

namespace GoogleCaptche
{
    public partial class GoogleCaptche : Form
    {
        Bitmap bit = null;

        public GoogleCaptche()
        {
            InitializeComponent();
            txtImageFileName.Enabled = false;
        }

        private void btnImgFileName_Click(object sender, EventArgs e)
        {
            picSource.Image = null;
            picCaptche.Image = null;

            OpenFileDialog open = new OpenFileDialog();
            open.Reset();
            open.ShowDialog();
            txtImageFileName.Text = open.FileName;
            
            if (txtImageFileName.Text.Trim() != string.Empty)
            {
                try
                {
                    picSource.Image = Image.FromFile(txtImageFileName.Text.Trim());

                    bit = new Bitmap(picSource.Image);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "郁闷！你选的是图片吗？");
                }
            }
        }

        private void btnCaptche_Click(object sender, EventArgs e)
        {
            if (bit != null)
            {
                //灰度
                //picCaptche.Image = SetImageHeiSe(bit);

                //去点
                //picCaptche.Image = ClearPixel(SetImageHeiSe(bit));  //灰度操作:SetImageHeiSe(bit)

                //打印
                //PrintPixel(bit);

                //分割
                //Bitmap[] b = PixelN(4, bit);
                //for (int i = 0; i < b.Length; i++)
                //{
                //    b[i].Save("H" + i.ToString() + ".bmp");
                //    rtxCaptche.AppendText(CountBlack(b[i], 0).ToString() + " " + CountBlack(b[i], 255).ToString() + "\r\n");
                //    rtxCaptche.AppendText(CharacterLine(b[i], true, 4) + "\r\n");
                //    rtxCaptche.AppendText(CharacterLine(b[i], true, 9) + "\r\n\r\n");
                //    rtxCaptche.AppendText(CharacterLine(b[i], false, 5) + "\r\n");
                //    rtxCaptche.AppendText(CharacterLine(b[i], false, 10) + "\r\n");
                //}

                YanMoCaptche yanmo = new YanMoCaptche();
                bit = yanmo.GrayImage(bit);
                bit = yanmo.ClearNoise(bit);
                Bitmap[] b = yanmo.InciseImage(bit);
                for (int i = 0; i < b.Length; i++)
                {
                    b[i].Save("R" + i.ToString() + ".bmp");
                    rtxCaptche.AppendText((i+1).ToString() +":" + yanmo.CharacterLine(b[i], true, 5) + "\r\n");
                }
                rtxCaptche.AppendText("\r\n");
            }
            else
            {
                MessageBox.Show("对你无语了！", "出错");
            }
        }

        private void picCaptche_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            string filename = rd.Next(20000).ToString() + ".jpg";
            picCaptche.Image.Save(filename);
            MessageBox.Show("保存成功!", "哈哈");
        }

        //打印像素点
        public void PrintPixel(Bitmap image)
        {
            string pixel = "";
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color colGet = image.GetPixel(j, i);
                    int rgbAverage = (colGet.R + colGet.G + colGet.B) / 3;
                    if (rgbAverage == 255) rgbAverage = 1;
                    if (rgbAverage == 0) rgbAverage = 0;
                    pixel += rgbAverage.ToString() + "";
                }
                pixel += "\r\n";
            }
            rtxCaptche.Text = pixel;
        }
    }
}
