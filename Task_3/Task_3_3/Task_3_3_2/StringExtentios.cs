using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3_3_2
{
    public static class StringExtentios
    {
        public static string CheckLanguage(this string text)
        {
            int rus = 0;
            int num = 0;
            int eng = 0;
            
            if (Regex.IsMatch(text, "[а-яА-ЯеЁ]"))
            {
                rus = 1;
            }
            if (Regex.IsMatch(text, @"[\d\p{Z}]"))
            {
                num = 1;
            }
            if (Regex.IsMatch(text, "[a-zA-Z]"))
            {                
                eng = 1;                
            }            
            if (rus + num + eng > 1) 
            {
                return "Mixed";
            }            
            if (rus == 1) 
            {
                return "Russian";
            }
            if (num == 1)
            {
                return "Number";
            }
            if (eng == 1)
            {
                return "English";
            }
            return "Unknown language";
        }
    }
}
