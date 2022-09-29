using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Common
{
    public class CommonHelper
    {
        public static Models.LoginUserInfo? logsInfo { get; set; }
        public static DateTime GetDateTimeYYYYMMddHHmmss()
        {
            return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        /// <summary>
        /// 汉字，字母，单词外的所有字符视为非法特殊字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIllegalChar(String value)
        {
            return !(new Regex("^[0-9a-zA-Z\u4E00-\u9FA5]+$").IsMatch(value)); // \u4E00-\u9FA5表示汉字
        }

        //var uuid = Guid.NewGuid().ToString(); // 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  

        //var uuidN = Guid.NewGuid().ToString("N"); // e0a953c3ee6040eaa9fae2b667060e09   

        //var uuidD = Guid.NewGuid().ToString("D"); // 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  

        //var uuidB = Guid.NewGuid().ToString("B"); // {734fd453-a4f8-4c5d-9c98-3fe2d7079760}  

        //var uuidP = Guid.NewGuid().ToString("P"); //  (ade24d16-db0f-40af-8794-1e08e2040df3)  

        //var uuidX = Guid.NewGuid().ToString("X"); // {0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}  
        /// <summary>
        /// 由连字符分隔的32位数字
        /// </summary>
        /// <returns></returns>
        private static string GetGuid()
        {
            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            return guid.ToString();
        }
        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        /// <param name=\"guid\"></param>  
        /// <returns></returns>  
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        /// <summary>  
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>  
        /// <returns></returns>  
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        public static string GetUUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 生成特定位数的唯一字符串
        /// </summary>
        /// <param name="num">特定位数</param>
        /// <returns></returns>
        public static string GenerateUniqueText(int num)
        {
            string randomResult = string.Empty;
            string readyStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] rtn = new char[num];
            Guid gid = Guid.NewGuid();
            var ba = gid.ToByteArray();
            for (var i = 0; i < num; i++)
            {
                rtn[i] = readyStr[((ba[i] + ba[num + i]) % 35)];
            }
            foreach (char r in rtn)
            {
                randomResult += r;
            }
            return randomResult;
        }
    }
}
