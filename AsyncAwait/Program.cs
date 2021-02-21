using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {//task metoda, kreira se task koji se izvrsava na trenutnoj niti
        //na postojecim nitima, kacimo asinhrone metode!!!
        static async Task Main(string[] args)
        {
            var taska = Print1();
            var taskb = Print2();
            //int a = await Print1();
            //int b = await Print2();
            Console.ReadLine();
        }

        public async static Task<int> Print1() {
            for (int i = 0; i < 20; i++) {
                Console.WriteLine("Print1");
                await Task.Delay(1000);
            }
            return 1;
        }
        public async static Task<int> Print2()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Print2");
                await Task.Delay(1000);
            }
            return 2;
        }
    }
}
