using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_1
{
    class StringAsArray
    {
        private char[] _charArray;

        public int Length
        {
            get => _charArray.Length; 
        }

        public StringAsArray(int length)
        {
            if (length < 0) throw new ArgumentException();
            _charArray = new char[length];
        }
        public StringAsArray(char[] charArr) 
        {
            _charArray = new char[charArr.Length];
            for (int i = 0; i < charArr.Length; i++)
            {
                _charArray[i] = charArr[i];
            }
        }
        public StringAsArray(StringAsArray stringAsArray)
        {
            _charArray = new char[stringAsArray.Length];
            for (int i =0; i< stringAsArray.Length; i++)
            {
                _charArray[i] = stringAsArray._charArray[i];
            }
        }

        public char this[int i]
        {
            get => _charArray[i];
            set => _charArray[i] = value;
        }

        public bool Contains(char ch)
        {
            for (int i = 0; i < _charArray.Length; i++)
            {
                if (_charArray[i] == ch) { return true; }
            }
            return false;
        }

        public int IndexOf(char ch, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex > _charArray.Length) throw new ArgumentException();

            for (int i = startIndex; i < endIndex; i++)
            {
                if (_charArray[i] == ch) { return i; }
            }
            return -1;
        }
        public static StringAsArray Concat(StringAsArray strA, StringAsArray strB)
        {
            return strA + strB;
        }

        public char[] ToCharArray()
        {
            return _charArray;
        }

        public override string ToString()
        {
            return new String(_charArray);
        }

        public int CompareTo(object obj)
        {
            int result = 0;
            if (obj == null) return 1;
            
            StringAsArray src = obj as StringAsArray;
            if (src == null) { throw new Exception("No Comparable, it isn't StringAsArray"); }
            int length = (this.Length <= src.Length) ? this.Length : src.Length;
            for (int i = 0; i < length; i++)
            {
                result = this._charArray[i].CompareTo(src.ToCharArray()[i]);

                if (result > 0) { return 1; }
                if (result < 0) { return - 1; }
            }
            return result;
        }

        public static bool Equals(StringAsArray strA, StringAsArray strB)
        {            
            if (strA.Length != strB.Length) { return false; }
            for (int i = 0; i < strA.Length; i++)
            {
                if (!strA._charArray[i].Equals(strB._charArray[i])) { return false; }                
            }
            return true;
        }

        public void Replace(int index, char ch)
        {
            if (index < 0 || index > _charArray.Length) { throw new ArgumentException("Index out of Range"); }
            _charArray[index] = ch;
        }
                

        public static StringAsArray operator + (StringAsArray strA, StringAsArray strB)
        {
            StringAsArray resultStr = new StringAsArray(strA.Length + strB.Length);
            for (int i = 0; i < strA.Length; i++)
            {
                resultStr[i] = strA._charArray[i];
            }
            for (int i = strA.Length; i < strA.Length + strB.Length; i++)
            {
                resultStr[i] = strB._charArray[i - strA.Length];
            }
            return resultStr;
        }
    }
}
