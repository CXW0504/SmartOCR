using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CaptcheIO
{
    public class CaptcheIO
    {
        /// <summary>
        /// 全部特征码
        /// </summary>
        public CaptcheData[] captcheArray;
        /// <summary>
        /// 文件名称
        /// </summary>
        private string file = "lib.txt";

        /// <summary>
        /// 构造函数
        /// </summary>
        public CaptcheIO()
        {
            ReadCharacterLib(); //读取特征码库
        }

        /// <summary>
        /// 添加一条特征
        /// </summary>
        /// <param name="captche">特征码数据结构</param>
        public void Add(CaptcheData captche)
        {
            string line_1 = "";
            string line_2 = "";
            line_1 = string.Format("{0}={1}={2}={3}",captche.Code,captche.Bearing,captche.Line,captche.Character);

            if (captcheArray.Length == 0)
            {
                File.AppendAllText(file, line_1 + "\n");
                ReadCharacterLib();
                return;
            }
            else
            {
                for (int i = 0; i < captcheArray.Length; i++)
                {
                    line_2 = string.Format("{0}={1}={2}={3}",
                        captcheArray[i].Code,
                        captcheArray[i].Bearing,
                        captcheArray[i].Line,
                        captcheArray[i].Character);
                    if (line_1 == line_2) return;
                }
            }
            File.AppendAllText(file, line_1 + "\n");
            ReadCharacterLib();
        }

        /// <summary>
        /// 识别验证码
        /// </summary>
        /// <param name="captche">验证码结构</param>
        /// <returns>识别错误返回null,正确返回字符</returns>
        public string Is_Equal(CaptcheData captche)
        {
            string s = "";
            for (int i = 0; i < captcheArray.Length; i++)
            {
                if (captcheArray[i].Bearing == captche.Bearing &&
                    captcheArray[i].Line == captche.Line &&
                    captcheArray[i].Character == captche.Character)
                {
                   s+=captcheArray[i].Code;
                }
            }
            return s;
        }

        /// <summary>
        /// 保存特征库文件
        /// </summary>
        public void Save()
        {
            string line = "";
            for (int i = 0; i < captcheArray.Length; i++)
            {
                line += captcheArray[i].Code + "=";
                line += captcheArray[i].Bearing + "=";
                line += captcheArray[i].Line + "=";
                line += captcheArray[i].Character + "\n";
            }
            File.WriteAllText(file, line, Encoding.UTF8);
        }

        /// <summary>
        /// 读取特征码库
        /// </summary>
        private void ReadCharacterLib()
        {
            string[] lines = File.ReadAllLines(file, Encoding.UTF8);
            captcheArray = new CaptcheData[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split('=');
                captcheArray[i].Code = line[0].ToString();      //数字
                captcheArray[i].Bearing = line[1].ToString();   //方向
                captcheArray[i].Line = line[2].ToString();      //基数行
                captcheArray[i].Character = line[3].ToString();      //特征码
            }
        }
    }

    /// <summary>
    /// 验证码识别库数据结构
    /// </summary>
    public struct CaptcheData
    {
        /// <summary>
        /// 数字
        /// </summary>
        public string Code;
        /// <summary>
        /// 水平:H 垂直:V
        /// </summary>
        public string Bearing;
        /// <summary>
        /// 基线行
        /// </summary>
        public string Line;
        /// <summary>
        /// 特征码
        /// </summary>
        public string Character;
    }
}
