using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_1_2
{
    public static class StringExtentions
    {
        public static String FirstCharToUpperCase(this string str) 
        {
            return str.Replace(str[0], char.ToUpper(str[0]));
        } 
    }
}
