using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel
{
    class Program
    {

        public static void Main(String[] args)
        {
            NumArrangement na = new NumArrangement();

            //交互界面
            Console.WriteLine("Input your Num:");
            string input = Console.ReadLine();
            Console.WriteLine("Your Number Arrangement:");

            ArrayList list = na.Arrange(input);
            na.PrintList(list);

        }




        /// <summary>
        /// 排列问题
        /// </summary>
        class NumArrangement
        {
            public ArrayList Arrange(string str)
            {
                ArrayList list = new ArrayList();
                for (int i = 0; i < str.Length; i++)
                {
                    list = InsertValue(str[i].ToString(), list);
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

            //打印
            public void PrintList(ArrayList list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList list2 = (ArrayList)list[i];
                    for (int j = 0; j < list2.Count; j++)
                    {
                        Console.Write(list2[j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }

       
          
        
    }
}
