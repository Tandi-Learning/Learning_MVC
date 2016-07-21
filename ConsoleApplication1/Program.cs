using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(string messageData)
        {
            Message = messageData;
        }

        public string Message { get; set; }
    }

    public class MyEventHandler
    {
        public event EventHandler<MyEventArgs> OnMyEvent;

        public void RunEvent(string val, int count)
        {
            EventHandler<MyEventArgs> myEvent = OnMyEvent;
            if (OnMyEvent != null)
            {
                for (int i = 0; i < count; i++)
                {
                    Thread.Sleep(1000);
                    Console.Write($"[{i}]");
                }
                Thread.Sleep(1000);
                OnMyEvent(this, new MyEventArgs(val));
            }
        }
    }

    class Program
    {
        static int DiceCount = 5;

        static void Main(string[] args)
        {
            //MyEventHandler handler = new MyEventHandler();
            //handler.OnMyEvent += Handler_OnMyEvent;
            //handler.RunEvent("Event 1", 2);
            //handler.RunEvent("Event 2", 2);
            //handler.RunEvent("Event 3", 2);
            //handler.RunEvent("Event 4", 2);

            int[] numbers = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int total = numbers.Where(n => (n % 3 == 0)).Sum();

            Console.WriteLine(total);
            Console.ReadKey();


            //Dice[] Dices = new Dice[DiceCount];
            //Category[] Categories = new Category[4];
            //Categories[0].Point = 100;
            //Categories[1].Point = 200;

            //int val = Categories.Where(c => c.CategoryType == CATEGORY_TYPE.ONES).Select(c => c.Point).First();
            //var cat = Categories.Where(c => c.CategoryType == CATEGORY_TYPE.ONES).First();
            //cat.Point = 400;
            //val = Categories.Where(c => c.CategoryType == CATEGORY_TYPE.ONES).Select(c => c.Point).First();

            //Bonus[] Bonuses = new Bonus[2];
        }

        private static void Handler_OnMyEvent(object sender, MyEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
