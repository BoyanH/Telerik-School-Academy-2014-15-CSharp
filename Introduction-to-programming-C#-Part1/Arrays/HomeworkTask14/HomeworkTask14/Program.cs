using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask14 {
    class AppStart {

        public static void Quicksort(IComparable[] elements, int left, int right) {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j) {
                while (elements[i].CompareTo(pivot) < 0) {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0) {
                    j--;
                }

                if (i <= j) {

                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j) {
                Quicksort(elements, left, j);
            }

            if (i < right) {
                Quicksort(elements, i, right);
            }
        }

        static string[] SortViaQuickSort(string[] arr) {

            string[] copyArr = (string[]) arr.Clone();
            Quicksort(copyArr, 0, arr.Length - 1);

            return copyArr;
        }

        static void Main() {

            string[] unsorted = { "daa", "sdf", "xasda", "zcxc", "asd", "eqer", "kur"};
            string[] sorted = SortViaQuickSort(unsorted);

            Console.WriteLine("Unsorted: {0}", string.Join(", ", unsorted));
            Console.WriteLine("Sorted: {0}", string.Join(", ", sorted));
        }
    }
}
