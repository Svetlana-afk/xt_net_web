using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст, блистательный автор:");
            string text = Console.ReadLine();   
            TextCheck(text);           

        }
        /// <summary>
        /// Метод разбивает полученную строку на слова с помощью массива разделительных символом, и формирует Dictionary
        ///  где ключем являются слова из полученной на входе строки, а значением – количество их повторений 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static Dictionary<string, int> CountTheWords(string text)
        {            
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '!', '?', '\"' , '–'};
            string[] arrayOfWords = text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            MakeFirstLetterCapital(arrayOfWords);
            var result = arrayOfWords
                         .Select(str => new { Word = str, Count = arrayOfWords.Count(s => s==str) })         
                         .Distinct()
                         .ToDictionary(obj => obj.Word, obj => obj.Count);
            return result;                                   
        }
        /// <summary>
        /// Преобразует элементы массива строк таким образом, чтобы все строки начинались с большой буквы
        /// </summary>
        /// <param name="arrayOfWords"></param>
        static void MakeFirstLetterCapital(string[] arrayOfWords) 
        {
            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                arrayOfWords[i] = arrayOfWords[i].FirstCharToUpperCase();
            }
        }
        
        static void PrintDictionary(Dictionary<string, int> result) 
        {
            foreach (KeyValuePair<string, int> keyValue in result)
            {
                Console.WriteLine("     " + keyValue.Key + " – " + keyValue.Value);
            }
        }
        static void TextCheck(string text) 
        {
            var wordsAndCountsDictionary = CountTheWords(text);
            var averageCount = wordsAndCountsDictionary.Average(s => s.Value);
            var countOfUniqueWords = wordsAndCountsDictionary.Count();
            var coefficientOfUniqueWords = (double)averageCount / countOfUniqueWords;
            Console.WriteLine("Давайте посмотрим из каких слов состоит ваш текст, и на количество их повторений:");
            Console.WriteLine();
            PrintDictionary(wordsAndCountsDictionary);
            Console.WriteLine();            
            if (coefficientOfUniqueWords < 0.15)
            {
                Console.WriteLine("Прекрасный текст, такой разннобразный!");
            }
            else if (coefficientOfUniqueWords < 0.25)
            {
                var result = wordsAndCountsDictionary.Where(e => (double)e.Value / countOfUniqueWords >= 0.25)
                                       .OrderByDescending(e => e.Value)
                                       .Select(str => new { Word = str.Key, Count = str.Value }).ToDictionary(obj => obj.Word, obj => obj.Count);

                Console.WriteLine("Неплохо! Но, возможно, следующие слова встречаются слишком часто:");
                PrintDictionary(result);
                Console.WriteLine("Попробуйте заменить их синонимами.");
            }
            else if (averageCount < 2)
            {
                Console.WriteLine("Если это хокку – то неплохо!");
            }
            else 
            {
                Console.WriteLine("Все плохо, автор - бездарь.");
            }
        }

    }
}
