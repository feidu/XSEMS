using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Backend.Utilities
{
    public class Validator
    {
        public const string RX_EMAIL = @"\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*";

        public const string RX_NUMBER = @"^[1-9]\d*$";

        public const string RX_KEYWORD = @"(select|delete|insert|update|drop|sp_\w+)\s|'|;|#";

        public const string RX_NUMBER_AND_COMMA = @"^[0-9,]*$";

        public const string RX_NUMBER_AND_COMMA_AND_MINUSONE = @"^[0-9,-1]*$";

        public static readonly char[] CHAR_COMMA_ARRAY = new char[] { ',' };

        public static bool IsMatchRegularExpression(string input, string pattern)
        {
            if (input == null || pattern == null) return false;
            return Regex.IsMatch(input, pattern, RegexOptions.Compiled);
        }

        public static bool IsMatchEmail(string input)
        {
            return IsMatchRegularExpression(input, RX_EMAIL);
        }

        public static bool IsMatchNumber(string input)
        {
            return IsMatchRegularExpression(input, RX_NUMBER);
        }

        public static bool IsMatchKeywords(string input)
        {
            return Regex.IsMatch(input, RX_KEYWORD, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// if input string is match number and comma, eg 1,2,3,4,5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMatchNumberAndComma(string input)
        {
            return IsMatchRegularExpression(input, RX_NUMBER_AND_COMMA);
        }

        /// <summary>
        /// if input string is match number and comma, eg 1,2,3,4,5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMatchNumberAndCommaAndMinusOne(string input)
        {
            return IsMatchRegularExpression(input, RX_NUMBER_AND_COMMA_AND_MINUSONE);
        }

        /// <summary>
        /// convert string like "1,3,4" to int[] like {1,2,3}
        /// </summary>
        /// <param name="input"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool ConvertStringToIntArray(string input, out int[] array)
        {
            if (!IsMatchNumberAndComma(input))
            {
                array = null;
                return false;
            }
            string[] strs = input.Split(CHAR_COMMA_ARRAY, StringSplitOptions.RemoveEmptyEntries);
            array = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                array[i] = int.Parse(strs[i]);
            }
            return true;
        }

        public static bool IsMatchLessThanChineseCharacter(string input, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+|[¡°¡± £¬¡£¡¡ £­]", RegexOptions.Compiled);
            int nLength = input.Length;

            for (int i = 0; i < input.Length; i++)
            {
                if (regex.IsMatch(input.Substring(i, 1)))
                {
                    nLength++;
                }
            }
            if (nLength > length)
                return true;
            return false;
        }

        public static bool IsMatchLessThanChar(string input, int length)
        {
            Encoding gb = Encoding.GetEncoding("gb2312");
            byte[] temp = gb.GetBytes(input);
            return temp.Length < length;
        }

        public static bool IsMatchMoreThanChineseCharacter(string input, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+|[¡°¡± £¬¡£¡¡ £­]", RegexOptions.Compiled);
            int nLength = input.Length;

            for (int i = 0; i < input.Length; i++)
            {
                if (regex.IsMatch(input.Substring(i, 1)))
                {
                    nLength++;
                }
            }
            if (nLength  < length)
                return true;
            return false;
        }
    }     
}
