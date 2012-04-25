using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Backend.Utilities
{
    /// <summary>
    /// EncryptionHelper is used to generate unique string and encrypt string.
    /// </summary>
    /// <author>Qi Jing</author>
    /// <created-time>Apr 24, 2008</created-time>
    /// <last-revisor>N/A</last-revisor>
    /// <last-revised-time>N/A</last-revised-time>
    public class EncryptionHelper
    {
        public const string EMPTY = "";

        public static readonly char[] KEY_CHARS = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
        public static readonly char[] YEAR_KEY_CHARS = "jbcrstkdelmnop12zquvwxy3afghi4567890".ToCharArray();
        public static readonly char[] MONTH_KEY_CHARS = "4yedg67uvspjih".ToCharArray();
        public static readonly char[] DAY_KEY_CHARS = "vz128lmnst34upqwxyr567cghijo9bakdef0".ToCharArray();
        public static readonly char[] HOUR_KEY_CHARS = "nst3akd4ujo9bpvef0z128qwxlmyr567cghi".ToCharArray();
        public static readonly char[] MIN1_KEY_CHARS = "1r5qwiy672xlpvf0mgh8cujznst3akd4eo9b".ToCharArray();
        public static readonly char[] MIN2_KEY_CHARS = "56ycujznst37h4eo28i1rkdqwaxlmg9bpvf0".ToCharArray();
        public static readonly char[] SEC1_KEY_CHARS = "yr5q6vf0mglpcujzh8d41wieot3ak9b72xns".ToCharArray();
        public static readonly char[] SEC2_KEY_CHARS = "4est37h8i1rkdqwax2bpvf056ycujzn9lmgo".ToCharArray();
        public static readonly char[] MSEC1_KEY_CHARS = "h4eo9bpt372jm8i1rkdqf0zwav56ycugnsxl".ToCharArray();
        public static readonly char[] MSEC2_KEY_CHARS = "5st3726jzn8i1roxlmyc9vf0bpkdqwaugh4e".ToCharArray();
        public static readonly char[] MSEC3_KEY_CHARS = "ckdq374eo9bpvfujzn56yst8i1r02waxlmgh".ToCharArray();

        public const int KEY_SIZE = 5;

        private static readonly MD5 md5Hasher = MD5.Create();

        /// <summary>
        /// Encrypt string.
        /// </summary>
        /// <param name="o">original string</param>
        /// <returns>encrpted string</returns>
        public static string EncryptString(string o)
        {
            StringBuilder sb = new StringBuilder();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(o));
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Generate unique string with default length.
        /// </summary>
        /// <returns></returns>
        public static string GenerateKey()
        {
            return GenerateKey(KEY_SIZE, true);
        }

        /// <summary>
        /// Generate unique string with specified length.
        /// </summary>
        /// <param name="size">string length</param>
        /// <param name="time">whether generted string contains current time code</param>
        /// <returns></returns>
        public static string GenerateKey(int size, bool time)
        {
            StringBuilder sb = new StringBuilder();
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            crypto.GetNonZeroBytes(data);
            foreach (byte b in data)
            {
                sb.Append(KEY_CHARS[b % (KEY_CHARS.Length - 1)]);
            }

            if (time)
            {
                DateTime dt = DateTime.Now;
                sb.Append(YEAR_KEY_CHARS[dt.Year - 2000]);
                sb.Append(MONTH_KEY_CHARS[dt.Month]);
                sb.Append(DAY_KEY_CHARS[dt.Day]);
                sb.Append(HOUR_KEY_CHARS[dt.Hour]);
                sb.Append(MIN1_KEY_CHARS[dt.Minute / 10]);
                sb.Append(MIN2_KEY_CHARS[dt.Minute % 10]);
                sb.Append(SEC1_KEY_CHARS[dt.Second / 10]);
                sb.Append(SEC2_KEY_CHARS[dt.Second % 10]);
                sb.Append(MSEC1_KEY_CHARS[dt.Millisecond / 100]);
                sb.Append(MSEC2_KEY_CHARS[dt.Millisecond % 100 / 10]);
                sb.Append(MSEC3_KEY_CHARS[dt.Millisecond % 10]);
            }
            return sb.ToString();
        }


        //以下为加密解密方法
        private static string rider = "AaSsDdFfFfDd:AaSsSs.DdFfWw;EeRr$2QqWwEeRr)QqWwEeRrYy TtRrEeQqOo\\PpEeTtUu1YyRrEeOoIiUuTtYyOoUuYyOoY'yTtUuRrYyEe0YyTtRrWwAaDdFf-LlAaS=s|DdFf1PpOoIiUuWwPpEe|QqIiYyRrWwEeOoIiUuYyOoFf|IiUuGgTtOoDdYyFfG~g!TtI'iS-sYy,|UuTtVvIi.UuX,x(Cc_GgVv'KkZz7JjHhXxCcVvKk BbMmNnQqBbEeWw9RrM[mNnAaS$s6LlDdKkJjVvHhZzO[o:CcXxIiU@uYy;VvO@oIiEeWwQqRrLlKkNnBb(Dd@WwFf,BbCcXxVvJj6C/c!BbVvMm3Vv;F/fK^k(QqJ/jE],eW/wRrLl\\+JjHhDdSsFfJjAa DdSs7FfKkHj_AaDdSsFfJjOoIiEe8WwUuRrPpQqOo+IiEe5WwRrPpUuIiTt;$QqYyGgKkH2h=FfAaSs)DdLlKkHhFfLlJjSsA$aH^h~Ff,JjAaHhDdS!sLl FfA\\aHhLlAaTtEeWw)TtAa4GgFfDdSsH'hFfDdJj:GgFf$KkGgLlHhJjZ@zXxCcVvZzXxNnCcB=bV_vMmBb8MmDd9BbMm:0Aa]4NnBbNnBb3MmNnVvMm:BbVvBbVvMmN[]nVvCcNnVvC'cNnBbVvMmXxBb CcMmAaVvDdKkAaUuSsDdHhFfLl5AaIiUuYyEeFfYyKkBbMmXxCcVvBbZzMmXxNnBbVvMmZzXxBbVvMmVvZzXx";
        //提供给加密解密的私有方法
        private static string charFinder(int position)
        {
            int m = position < rider.Length ? position : (position % rider.Length);
            Console.WriteLine(position + "   " + rider.Substring(m, 1));
            return rider.Substring(m, 1);
        }
        //加密
        public static string StringEncrypt(string strParam)
        {

            Random rand = new Random(DateTime.Now.Second);
            StringBuilder temp = new StringBuilder();
            int end;
            int length = strParam.Length;

            temp.Append(string.Format("{0:x4}", length));
            for (int i = 0, o = 0; o < 100; i++, o++)
            {
                if (i == length)
                {
                    i = 0;
                }
                end = rand.Next(65535);

                for (int m = (end < rider.Length ? end : (end % rider.Length)); ; m++, end++)
                {
                    if (m == rider.Length)
                    {
                        m = 0;
                    }
                    if (string.Equals(rider.Substring(m, 1), strParam.Substring(i, 1)))
                    {
                        temp.Append(string.Format("{0:x4}", end));
                        break;
                    }
                }
            }
            return temp.ToString();

        }
        //解密
        public static string StringDecrypt(string strParam)
        {
            StringBuilder tempString = new StringBuilder();

            int length = 100 + 1;
            //提取出长度
            length = Convert.ToInt32(strParam.Substring(0, 4), 16);

            for (int i = 1; i <= length; i++)
            {
                int position = Convert.ToInt32(strParam.Substring(4 * i, 4), 16);
                tempString.Append(charFinder(position));

            }
            return tempString.ToString();
        }

    }
}
