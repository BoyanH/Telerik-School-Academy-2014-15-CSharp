using System;
using System.Linq;

namespace Generic.Reimplementation
{
    public class GenericList<T>
        where T : IComparable<T>
    {

        private T[] elementsArr;
        private int count = 0;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < this.count && index >= 0)
                {
                    return elementsArr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("Index must be between 0 and {0}", this.count - 1));
                }
            }
            set
            {
                if (index < this.count && index >= 0)
                {
                    this.elementsArr[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("Index must be between 0 and {0}", this.count - 1));
                }
            }
        }

        public GenericList(int length)
        {
            elementsArr = new T[length];
        }

        private void ResizeToDouble()
        {
            var tempArr = new T[this.elementsArr.Length * 2];
            Array.ConstrainedCopy(this.elementsArr, 0, tempArr, 0, this.elementsArr.Length);
            this.elementsArr = tempArr;
        }

        public void Add(T newElement)
        {
            if (this.count >= this.elementsArr.Length)
            {
                ResizeToDouble();
            }

            this.elementsArr[count] = newElement;
            ++this.count;
        }

        public void Remove(T removeElement)
        {
            if (this.count > 0)
            {
                for (int i = 0; i < this.count; i++)
                {
                    if (removeElement.CompareTo(this.elementsArr[i]) == 0)
                    {
                        this.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        public void RemoveAt(int removeIndex)
        {

            if (removeIndex < this.count)
            {
                for (int i = removeIndex; i < this.count; i++)
                {
                    if (i == this.count - 1)
                    {
                        this.elementsArr[i] = default(T);
                    }
                    else
                    {
                        this.elementsArr[i] = this.elementsArr[i + 1];
                    }
                }

                --this.count;
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format("Index must be between 0 and {0}", this.count - 1));
            }
        }

        public void AddAt(T newElement, int addIndex)
        {
            if (this.count >= this.elementsArr.Length)
            {
                ResizeToDouble();
                Console.WriteLine(this.elementsArr.Length);
            }

            if (addIndex <= this.count && this.count < this.elementsArr.Length)
            {

                for (int i = this.count - 1; i >= addIndex; i--)
                {
                    this.elementsArr[i + 1] = this.elementsArr[i];
                }
                this.elementsArr[addIndex] = newElement;

                ++this.count;
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format("Index must be between 0 and {0}", this.count));
            }

        }

        public int IndexOf(T elem)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (elem.CompareTo(this.elementsArr[i]) == 0)
                {
                    return i;
                }

            }

            return -1;
        }

        public void Clear()
        {
            this.elementsArr = new T[this.elementsArr.Length];
        }

        public T Min()
        {
            return this.elementsArr.Min();
        }

        public T Max()
        {
            return this.elementsArr.Max();
        }

        public override string ToString()
        {
            return string.Join(", ", this.elementsArr);
        }
    }
}
