using System;

namespace StringAsArrayLibrary
{
    public class StringAsArray
    {
        private char[] _charArray;

        public int Length => _charArray.Length;

        public StringAsArray(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than 0");
            }
            _charArray = new char[length];
        }
        public StringAsArray(char[] charArr)
        {
            _charArray = new char[charArr.Length];
            Array.Copy(charArr, _charArray, charArr.Length);
        }
        public StringAsArray(StringAsArray str)
        {
            _charArray = str.ToCharArray();
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
                if (_charArray[i] == ch)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(char ch, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex > _charArray.Length)
            {
                throw new ArgumentException("Index out of Range");
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                if (_charArray[i] == ch)
                {
                    return i;
                }
            }
            return -1;
        }
        public static StringAsArray Concat(StringAsArray strA, StringAsArray strB)
        {
            return strA + strB;
        }

        public char[] ToCharArray()
        {
            char[] charArray = new char[this.Length];
            Array.Copy(_charArray, charArray, this.Length);

            return charArray;
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
            if (src == null)
            {
                throw new Exception("No Comparable, it isn't StringAsArray");
            }
            int length = (this.Length <= src.Length) ? this.Length : src.Length;
            for (int i = 0; i < length; i++)
            {
                result = this._charArray[i].CompareTo(src.ToCharArray()[i]);

                if (result > 0) { return 1; }
                if (result < 0) { return -1; }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            StringAsArray src = obj as StringAsArray;
            if (src == null)
            {
                return false;
            }

            if (src.Length != this.Length)
            {
                return false;
            }

            for (int i = 0; i < src.Length; i++)
            {
                if (!src._charArray[i].Equals(this._charArray[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            if (_charArray == null)
            {
                return 0;
            }
            int hashCode = 1;
            foreach (char elem in _charArray)
            {
                hashCode = 5 * hashCode + elem;
            }

            return hashCode;
        }

        public void Replace(int index, char ch)
        {
            if (index < 0 || index > _charArray.Length)
            {
                throw new ArgumentException("Index out of Range");
            }
            _charArray[index] = ch;
        }

        public static StringAsArray operator +(StringAsArray strA, StringAsArray strB)
        {
            var sumLength = strA.Length + strB.Length;
            StringAsArray resultStr = new StringAsArray(sumLength);
            for (int i = 0; i < strA.Length; i++)
            {
                resultStr[i] = strA._charArray[i];
            }
            for (int i = strA.Length; i < sumLength; i++)
            {
                resultStr[i] = strB._charArray[i - strA.Length];
            }
            return resultStr;
        }
    }
}
