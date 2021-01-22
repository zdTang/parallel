using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Timers;
using System.Diagnostics;
using System.Threading;

namespace parallel
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        
        public static void Main(String[] args)
        {

            
            NumArrangement na = new NumArrangement();
            Console.WriteLine("Input your password:");
            string input = Console.ReadLine();


            //Char[] alpha = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string[] alpha = { "A", "B", "C", "D", "E" };



            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            SetTimer();
            //Get combination collection
            var result=CommonSense.Combinations(alpha, 3);
            //For each combination unit, list permutations
            foreach (var VARIABLE in result)
            {
                ArrayList list = na.Arrange(VARIABLE);
                na.PrintList(list,input);
                if (CommonSense.isMatch == true)
                {
                    break;
                }
            }
            Console.WriteLine("done");
            aTimer.Stop();
            stopWatch.Stop();
            long duration = stopWatch.ElapsedMilliseconds;
            //long duration = stopWatch.ElapsedTicks;
            Console.WriteLine("time elapsed:{0} Milliseconds", duration);
            aTimer.Dispose();
            Console.WriteLine("compare{0} times", CommonSense.Counter++);
            Console.ReadLine();
        }


        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer();
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(Execute);//到达时间的时候执行事件；
            aTimer.Interval = 4;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            //aTimer.SynchronizingObject = Program;
            
        }

        //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
        //        e.SignalTime);
        //}
        private static void Execute(object source, System.Timers.ElapsedEventArgs e)
        {
            aTimer.Stop(); //先关闭定时器
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                e.SignalTime);
        }

    }


    class NumArrangement
    {

        public ArrayList Arrange(IEnumerable<string> col)
        {
            ArrayList list = new ArrayList();
            foreach (var VAR in col)
            {
                list = InsertValue(VAR, list);
            }
            return list;
        }

        public ArrayList InsertValue(string str, ArrayList list)
        {
            int rowct = list.Count;
            int rayct;

            ArrayList list2 = new ArrayList();

            if (list.Count > 0)
            {
                ArrayList temp = (ArrayList)list[0];
                rayct = temp.Count;

                for (int i = 0; i < rowct; i++)
                {

                    for (int j = 0; j < rayct + 1; j++)
                    {
                        ArrayList list4 = new ArrayList((ArrayList)list[i]);//Arraylist 的深度复制

                        list4.Insert(j, str);
                        list2.Add(list4);
                    }
                }

            }
            else
            {
                rayct = 0;
                list.Add(str);
                list2.Add(list);
            }

            return list2;
        }

        /// <summary>
        /// Print out 
        /// </summary>
        /// <param name="list"></param>
        public void PrintList(ArrayList list,string Password)
        {
            for (int i = 0; i < list.Count; i++)
            {
                ArrayList list2 = (ArrayList)list[i];
                string newLine=null;
                for (int j = 0; j < list2.Count; j++)
                {
                    newLine += list2[j];
                }

                CommonSense.Counter++;
                Console.WriteLine(newLine);
                if (newLine == Password)
                {
                    Console.WriteLine("match!!!");
                    CommonSense.isMatch = true;
                    return;
                }
              
                //Console.WriteLine();
            }
            // Console.ReadLine();
            //Console.WriteLine("done");
        }
    }

    static class CommonSense
    {

        public static bool isMatch = false;   // used as global key to indicate if progrom should stop
        public static int Counter { set; get; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// https://stackoverflow.com/questions/127704/algorithm-to-return-all-combinations-of-k-elements-from-n
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
                elements.SelectMany((e, i) =>
                    elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        public static void Display()
        {
            Console.WriteLine("timer!!!!!");
        }
    }

}
