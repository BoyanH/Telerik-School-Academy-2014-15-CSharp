using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask16 {
    class AppStart {

        static List<int> PrimesViaSieveOfErotosthenes(int n) {

            List<int> allPrimes = new List<int>();
        
            bool[] e = new bool[n];
            for (int i = 2; i < n; i++)
            {
                e[i] = true;
            }
            
            for (int j = 2; j < n; j++) {
                if (e[j])
               {
                    for (long p = 2; (p * j) < n; p++) {
                        e[p * j] = false;
                    }
                }
            }

            for (int idx = 0; idx < e.Length; idx++) {

                if (e[idx]) {

                    allPrimes.Add(idx);
                }
            }

            return allPrimes;
        }
        
        static void Main() {

            int n;

            Console.WriteLine("Enter N to get all prime numbers up to N!\n");

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

                Console.WriteLine("Invalid Integer!");
                Console.Write("\nN: ");
            }

            Console.WriteLine("Primes up to {0} are: {1}", n, string.Join(", ", PrimesViaSieveOfErotosthenes(n)));
        }
    }
}
