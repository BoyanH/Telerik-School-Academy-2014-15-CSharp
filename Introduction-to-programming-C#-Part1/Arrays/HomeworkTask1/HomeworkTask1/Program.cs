using System;

namespace HomeworkTask1 {
    class AppStart {
        static void Main() {

            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++) {

                array[i] = 5 * i;
                Console.WriteLine("arrray[{0}] = {1}", i, array[i]);
            }
        }
    }
}
