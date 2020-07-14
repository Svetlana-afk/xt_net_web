using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_2_1_Dynamic_Array
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        private T[] Arr { get; set; }        
        public int Capasity 
        {   get => Arr.Length; 
            set 
            {
                T[] tempArray = new T[value];
                if (value >= Length) 
                {
                    Array.Copy(Arr, tempArray, Arr.Count());
                    Arr = tempArray;
                }               
                else 
                {
                    Array.Copy(Arr, tempArray, value);
                    Arr = tempArray;                   
                    Length = value;
                }
            }
        }
        public int Length { get; private set; }
        private const int  SIZE = 8;        

        public DynamicArray()
        {
            Length = 0;
            Arr = new T[SIZE];
        }

        public DynamicArray(int capasity) 
        {
            Length = 0;
            Arr = new T[2*capasity];
        }

        public DynamicArray(ICollection<T> collection) 
        {
            Length = 0;
            Arr = new T[2*collection.Count];  
            int i = 0;
            foreach (var item in collection)
            {
                Arr[i++] = item;
                Length += 1;
            } 
        }
        /// <summary>
        /// Возвращает или задает элемент по указанному индексу, включая отрицательный индекс.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (Math.Abs(index) >= Length)
                {
                    throw new ArgumentOutOfRangeException(); 
                }
                if (index >= 0)
                {
                    return Arr[index];
                }
                else
                {
                    return Arr[Length + index];
                }
            }
            set
            {
                if (Math.Abs(index) >= Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (index >= 0)
                {
                    Arr[index] = value;
                }
                else
                {
                    Arr[Length + index] = value;
                }
            }
        }
        /// <summary>
        /// Добавляет объект в конец коллекции
        /// </summary>
        /// <param name="item">Объект, добавляемый в конец коллекции</param>
        public void Add(T item) 
        {
            if (Length >= Capasity) 
            {
                Capasity += Capasity;
            }            
            Arr[Length] = item;
            Length++;  
        }
        /// <summary>
        ///  Добавляет элементы указанной коллекции в конец списка
        /// </summary>
        /// <param name="collection">Коллекция, элементы которой добавляются в конец списка</param>               
        public void AddRange(ICollection<T> collection) 
        {
            if (collection.Count + Length > Capasity)
            {
                Capasity += collection.Count;
            }

            foreach (var item in collection)
            {
                Arr[Length] = item;
                Length++;
            }
        }
        /// <summary>
        /// Удаляет первое вхождение указанного объекта из коллекции
        /// </summary>
        /// <param name="item">Объект, который необходимо удалить из коллекции</param>
        /// <returns></returns>
        public bool Remove(T item) 
        {
            for (int i = 0; i < Length; i++)
            {
                if (Arr[i].Equals(item)) 
                {                    
                    for (int j = i; j < Length-1; j++)
                    {
                        Arr[j] = Arr[j + 1];
                    }
                    Length--;
                    return true;
                }                
            }
            return false;
        }
        /// <summary>
        /// Вставляет элементы коллекции в Dynamic_Array в позиции с указанным индексом.
        /// </summary>
        /// <param name="index"> Отсчитываемый от нуля индекс места вставки новых элементов. </param>
        /// <param name="item"> Элемент, который следует вставить в коллекцию. </param>
        public void Insert(int index, T item) 
        {            
            if (index < Length) 
            {             
                if (Length >= Capasity)
                {
                    Capasity += Capasity;                   
                }
                Length++;
                for (int i = Length-1; i > index; i--)
                {
                    Arr[i] = Arr[i-1];
                }
                Arr[index] = item;
            }
        }
        /// <summary>
        ///  Копирует элементы Dynamic Array новый массив.
        /// </summary>
        /// <returns>Массив, содержащий копии элементов Dynamic Array</returns>
        public T[] ToArray() 
        {
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = Arr[i];
            }
            return array;
        }
        public IEnumerator<T> GetEnumerator()
        {            
            return new DynamicArrayEnumerator(Arr, Length);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrayEnumerator(Arr, Length);
        }

        public object Clone()
        {
            return new DynamicArray<T>() 
            { 
                Capasity = this.Capasity, 
                Length = this.Length,
                Arr = (T[])this.Arr.Clone()
            };
        }

        public class DynamicArrayEnumerator : IEnumerator, IEnumerator<T>
        {
            T[] dArray;
            int length;
            int position = -1;
            public DynamicArrayEnumerator(T[] array, int length)
            {
                dArray = array;
                this.length = length;
            }
            public bool MoveNext()
            {
                if (position == length-1)
                {
                    Reset();
                    return false;
                }
                position++;
                return true;
            }
            public void Reset()
            {
                position = -1;
            }

            void IDisposable.Dispose()
            {
               
            }

            public object Current
            {
                get
                {
                    if (position == -1 || position >= length)
                        throw new InvalidOperationException();
                    return dArray[position];
                }
            }

            T IEnumerator<T>.Current => dArray[position];
        }
    }
}
