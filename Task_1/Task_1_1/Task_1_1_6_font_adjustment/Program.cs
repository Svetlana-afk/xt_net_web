using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_6_font_adjustment
{
    class Program
    {
        private static TitleState titleState = TitleState.None;
        static void Main(string[] args)
        {      
            Console.WriteLine("Параметры Надписи: {0} ", titleState);
            while (true)
            {                               
                Console.WriteLine("Введите:");
                Console.WriteLine("       1: bold");
                Console.WriteLine("       2: italic");
                Console.WriteLine("       3: underline");

                String strNumberOfTitleState = Console.ReadLine();
                byte numberOfTitleState = byte.Parse(strNumberOfTitleState);
                SetNewState(numberOfTitleState);
                PrintState(titleState);
            }
        }

        static void SetNewState(byte numberOfTitleState) 
        {      
            if (numberOfTitleState == 1)
            {
                if ((titleState & TitleState.Bold) != TitleState.Bold)
                {
                    titleState |= TitleState.Bold;
                }
                else
                {
                    titleState ^= TitleState.Bold;
                }

            }

            if (numberOfTitleState == 2)
            {
                if ((titleState & TitleState.Italic) != TitleState.Italic)
                {
                    titleState |= TitleState.Italic;
                }
                else
                {
                    titleState ^= TitleState.Italic;
                }
            }
            if (numberOfTitleState == 3)
            {
                if ((titleState & TitleState.Underline) != TitleState.Underline)
                {
                    titleState |= TitleState.Underline;
                }
                else
                {
                    titleState ^= TitleState.Underline;
                }
            }
        }

        static void PrintState(TitleState state)
        {
            string res = "";
            if ((state & TitleState.Bold)==TitleState.Bold)
            {
                if (res.Length > 0) res += ", ";
                res += TitleState.Bold;
            }
            if ((state & TitleState.Italic) == TitleState.Italic)
            {
                if (res.Length > 0) res += ", ";
                res += TitleState.Italic;
            }
            if ((state & TitleState.Underline) == TitleState.Underline)
            {
                if (res.Length > 0) res += ", ";
                res += TitleState.Underline;
            }
            if (res.Length == 0) res += TitleState.None;
            Console.WriteLine("Параметры Надписи: {0} ", res);
        }
            

        //[Flags]
        enum TitleState : byte
        { 
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
    }
}
