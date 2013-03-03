using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Captche
{
    public class YanMoCaptche
    {
        /// <summary>
        /// 图像灰度化
        /// </summary>
        /// <param name="img">图像</param>
        /// <returns>灰度化图像</returns>
        public Bitmap GrayImage(Bitmap img, int mean)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color co = img.GetPixel(x, y);
                    int avg = (co.R + co.G + co.B) / 3;
                    if (avg > mean) avg = 255;
                    if (avg <= mean) avg = 0;
                    img.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            return img;
        }

        public Bitmap ClearRedColor(Bitmap img, byte mean)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color color = img.GetPixel(x, y);

                    if (color.R > mean)
                    {
                        img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return img;
        }

        public Bitmap ClearGreenColor(Bitmap img, byte mean)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color color = img.GetPixel(x, y);

                    if (color.G > mean)
                    {
                        img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return img;
        }

        public Bitmap ClearBlueColor(Bitmap img, byte mean)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color color = img.GetPixel(x, y);

                    if (color.G > mean)
                    {
                        img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return img;
        }
        
        /// <summary>
        /// 清楚背景噪声点
        /// </summary>
        /// <param name="img">图像</param>
        /// <returns>清除噪声后图像</returns>
        public Bitmap ClearNoise(Bitmap img)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color co = img.GetPixel(x, y);
                    int avg = (co.R + co.G + co.B) / 3;
                    if (avg == 0)   //下面检测是否是杂点
                    {
                        int count = 0;
                        if (x > 0) //获取临近左边像素
                        {
                            Color left_co = img.GetPixel(x - 1, y);
                            int left_P = (left_co.R + left_co.G + left_co.B) / 3;
                            count += left_P;
                        }
                        if (x < img.Width - 1) //获取临近右边像素
                        {
                            Color right_co = img.GetPixel(x + 1, y);
                            int right_P = (right_co.R + right_co.G + right_co.B) / 3;
                            count += right_P;
                        }
                        if (y > 0) //上边
                        {
                            Color top_co = img.GetPixel(x, y - 1);
                            int top = (top_co.R + top_co.G + top_co.B) / 3;
                            count += top;
                        }
                        if (y < img.Height - 1) //下边
                        {
                            Color bot_co = img.GetPixel(x, y + 1);
                            int bottom = (bot_co.R + bot_co.G + bot_co.B) / 3;
                            count += bottom;
                        }
                        if (count > 255 * 2) //临近的任意三个点是白色255*3，将当前设置为白色
                        {
                            img.SetPixel(x, y, Color.FromArgb(255, 255, 255));    //设置为白色
                        }
                    }
                }
            }
            return img;
        }

        /// <summary>
        /// 冲洗图像
        /// </summary>
        /// <param name="img">图像</param>
        /// <returns>冲洗后图像</returns>
        public Bitmap RinseImage(Bitmap img)
        {
            int is_Gray = 0;
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color co = img.GetPixel(x, y);
                    int avg = (co.R + co.G + co.B) / 3;
                    if (avg == 0) is_Gray++;
                    if (is_Gray > 1)
                    {
                        img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
                is_Gray = 0;
            }
            return img;
        }

        /// <summary>
        /// 切割图像
        /// </summary>
        /// <param name="image">图像</param>
        /// <returns>图像集合数组</returns>
        public Bitmap[] InciseImage(Bitmap img)
        {
            Bitmap[] imgList = new Bitmap[4];   //切割图片总数
            int age = 0;
            for (int num = 0; num < imgList.Length; num++)
            {
                imgList[num] = new Bitmap(Image.FromFile("pic.bmp"));
                int x = 0;
                int y = 0;
                for (int i = 0; i < img.Height; i++)
                {
                    for (int j = age; j < age + 17; j++)
                    {
                        Color co = img.GetPixel(j, i);
                        imgList[num].SetPixel(x, y, co);
                        x++;
                    }
                    y++;
                    x = 0;
                }
                age += 17;
            }
            return imgList;
        }

        /// <summary>
        /// 统计图像像素点总数
        /// </summary>
        /// <param name="img">图像</param>
        /// <param name="mod">0:黑色 255白色</param>
        /// <returns>像素点总数</returns>
        public int CountBlack(Bitmap img, int mod)
        {
            if (mod != 255) mod = 0;
            int count = 0;
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color co = img.GetPixel(x, y);
                    int avg = (co.R + co.G + co.B) / 3;
                    if (avg == mod) count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 取出一条特征线
        /// </summary>
        /// <param name="image">图像</param>
        /// <param name="bearing">方向:true水平 false垂直</param>
        /// <param name="place">位置:小于图像宽度和高度,如果大于则选取默认值1/2。</param>
        /// <returns>格式:0100000111000011110000011110011</returns>
        public string CharacterLine(Bitmap image, bool bearing, int place)
        {
            string character = "";
            if ((place > image.Height || place < 0) && bearing == false) place = image.Height / 2; //垂直1/2值
            if ((place > image.Width || place < 0) && bearing) place = image.Width / 2;    //水平1/2值
            if (bearing) //水平
            {
                for (int i = 0; i < image.Width; i++)
                {
                    Color co = image.GetPixel(i, place);
                    int avg = (co.R + co.G + co.B) / 3;
                    if (avg == 0) character += "0";
                    else character += "1";
                }
            }
            else //垂直
            {
                for (int i = 0; i < image.Height; i++)
                {
                    Color co = image.GetPixel(place, i);
                    int avg = (co.R + co.G + co.B) / 3;
                    if (avg == 0) character += "0";
                    else character += "1";
                }
            }
            return character;
        }
    }
}
