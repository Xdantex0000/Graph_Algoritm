﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {      
        static void InputFile(out List<int> one,out List<int> two)
        {
            one = new List<int>();
            two = new List<int>();
            string path = @"input.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for(int i=0;i<words.Length;i++)
                    {
                        if(i>0)
                        {
                            one.Add(Convert.ToInt32(words[i - 1]));
                            two.Add(Convert.ToInt32(words[i]));
                        }
                    }
                }
            }
        }
        static void OutputFile(List<int>[] massiv)
        {
            string writePath = @"Output.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < massiv.Length; i++)
                    {
                        for (int j = 0; j < massiv[i].Count; j++)
                        {
                            sw.Write(massiv[i][j] + " ");
                        }
                        sw.WriteLine();
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        static void Main(string[] args)
        {
            List<int> one;
            List<int> two;
            InputFile(out one,out two);
            Dekstra(10, one, two);
        }

        static void Dict(List<Tuple<int,int>> one)
        {
            List<int>[] massiv = new List<int>[one.Count];

             int start = one[0].Item1;


            for (int i = 0; i < one.Count; i++)
            {
                massiv[i] = new List<int>();
                massiv[i].Add(one[i].Item2);

                var item = one[i].Item1;
                
                while (true)
                {
                    if (item == start)
                    {
                        massiv[i].Add(start);
                        break;
                    }
                    else
                    {
                        foreach (var it in one)
                        {
                            if (item == it.Item2)
                            {
                                if(massiv[i][massiv[i].Count-1] != item)
                                massiv[i].Add(item);

                                if (it.Item1 != start)
                                {
                                    massiv[i].Add(it.Item1);
                                }
                                item = it.Item1;                        
                            }
                        }                     
                    }
                }
            }
            for(int i=0;i<massiv.Length;i++)
            {
                massiv[i].Reverse();
                for(int j=0;j<massiv[i].Count;j++)
                {
                    Console.Write(massiv[i][j] + "  ");
                }
                Console.WriteLine();
            }
            OutputFile(massiv);

        }

        static void  Dekstra(int size,List<int> one,List<int> two)
        {
            int[,] a = new int[size,size];
            int[]  d = new int[size];
            int[]  v = new int[size];
            int temp= 0;
            int minindex, min;

            List<Tuple<int,int>> dict = new List<Tuple<int,int>>();

            //for(int i=0;i<size;i++)
            {
               // a[i, i] = 0;
               // for(int j=i+1;j<size;j++)
                {
                  //  a[i, j] = 0;
                  //  a[j, i] = 0;
                }
            }

            for(int i=0;i<one.Count; i++)
            {
                a[one[i]-1, two[i]-1] = 5;
                a[two[i] - 1, one[i] - 1] = 5;
            }

            /*
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j = 0; j < a.GetLength(1);j++)
                {
                   Console.Write(a[i,j]+ "  ");
                }
               Console.WriteLine();
            }*/


            for(int i=0;i<size;i++)
            {
                d[i] = 10000;
                v[i] = 1;
            }

            int start = 1;
            start--;
            d[start] = 0;

            int h = 1;
            do
            {
                minindex = 10000;
                min = 10000;
                for (int i = 0; i < size; i++)
                {
                    if ((v[i] == 1) && (d[i] < min))
                    {
                        min = d[i];
                        minindex = i;
                    }
                }

                if (minindex != 10000)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (a[minindex, i] > 0)
                        {
                            temp = min + a[minindex, i];
                            if (temp < d[i])
                            {
                                d[i] = temp;
                                //Console.WriteLine("i={0}, j={1} value={2} temp{3} h={4}", minindex + 1, i + 1, a[minindex, i],temp,h);
                                dict.Add(Tuple.Create(minindex+1,i+1));

                            }
                        }
                    }
                    v[minindex] = 0;
                }
               h++;
            } while (minindex < 10000);
            Dict(dict);

            /*
            Console.WriteLine("Кратчайшие расстояние до вершин");
            for(int i=0;i<size;i++)
            {
              Console.Write(d[i] + "   ");
            }

            Console.WriteLine("\n"+ new string('-',30));
            for (int end2 = 0; end2 < size; end2++)
            {
                int[] ver = new int[size];

                int end = end2;

                ver[0] = end + 1;

                int k = 1;

                int weight = d[end];

                while (end > 0)
                {
                    for (int i = 0; i < size; i++)
                    {

                        if (a[end, i] != 0)
                        {
                            temp = weight - a[end, i];

                            if (temp == d[i])
                            {
                                weight = temp;
                                end = i;                               
                                ver[k] = i + 1;
                                k++;
                            }
                        }
                    }

                }
              Console.WriteLine("Вывод кратчайшого пути");
                for (int i = k - 1; i >= 0; i--)
                {
                 Console.Write(ver[i] + "   ");
                }
                Console.WriteLine();
            }*/

        }
    }

}
