using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Edge
    {
        public int u, v;
        public Edge(int u, int v)
        {
            this.u = u;
            this.v = v;
        }
    }

    class Program
    {

        static bool Find(List<int> list, int x) // Функция, которая проверяет на занесенность в список
        {
            if (list == null) return false;
            else
            {
                foreach (var i in list)
                {
                    if (i == x) return true;
                }
            }

            return false;
        }

        static bool Compare(List<int> L1, List<int> L2)
        {
            if (L1.Count == L2.Count)
            {
                for (var i = 0; i < L1.Count; i++)
                    if (L1[i] != L2[i])
                        return false;
            }
            else return false;

            return true;
        }

        static void AddWay(List<int> list, List<List<int>> listWays)
        {
            int i = 0;
            bool temp = true;
            while (i < listWays.Count && temp)
            {
                if (Compare(list, listWays[i])) temp = false;
                else i++;
            }

            if (temp || i == listWays.Count)
            {
                listWays.Add(new List<int>());
                foreach (var j in list)
                {
                    listWays[listWays.Count - 1].Add(j);
                }
            }
        }

        static void Ways(List<Edge> edges, int numberEdge, List<int> list, List<List<int>> listWays) // Функция поиска путей
        {
            foreach (var edge in edges)
            {
                if (!Find(list, numberEdge))
                {
                    if (edge.u == numberEdge)
                    {
                        list.Add(numberEdge);

                        if (!Find(list, edge.v)) Ways(edges, edge.v, list, listWays);
                        else AddWay(list, listWays);
                        list.Remove(numberEdge);
                    }
                    else if (edge.v == numberEdge)
                    {
                        list.Add(numberEdge);

                        if (!Find(list, edge.u)) Ways(edges, edge.u, list, listWays);
                        else AddWay(list, listWays);
                        list.Remove(numberEdge);
                    }
                }
            }
        }

        static int Print(List<int> list, int end, int min_size)
        {
            if (list[list.Count - 1] == end)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (i != list.Count - 1)
                    {
                        Console.Write($"{list[i]}-");
                    }
                    else
                    {
                        Console.Write(list[i]);
                    }
                }
                min_size = list.Count;
                Console.WriteLine();
            }
            return min_size;
        }
        static void Print(List<int> list, int end)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                {
                    Console.Write($"{list[i]}-");
                }
                else
                {
                    Console.Write(list[i]);
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Write the starting point: ");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Write the ending point: ");
            int end = Convert.ToInt32(Console.ReadLine());
            int min_size = 100;
            List<int> iteration = new List<int>();
            List<Edge> edges = new List<Edge>();
            List<List<int>> listWays = new List<List<int>>();
            List<string> ways = new List<string>();
            ways = Reading();
            AddEdge(ways, edges);
            Ways(edges, start, new List<int>(), listWays);
            foreach (var i in listWays)
            {
                if (min_size > i.Count)
                {
                    min_size = Print(i, end, min_size);
                    iteration = i;
                }
                else
                    Print(i, end, min_size); ;
            }
            Console.Write("The shortest way: ");
            Print(iteration, end);
            Console.ReadLine();
        }

        static void AddEdge(List<string> ways, List<Edge> edge)
        {
            foreach (string s in ways)
            {
                edge.Add(new Edge(Convert.ToInt32(s.Substring(0, 1)), Convert.ToInt32(s.Substring(2, 1))));
            }
        }
        static List<String> Reading()
        {
            string path = "input.txt";
            int index = -2, pre_num = -2, post_num = -2;
            List<string> words2 = new List<string>();
            string Readed_String;
            Console.WriteLine();
            Console.WriteLine("Reading...");
            using (StreamReader sr = new StreamReader(@"input.txt"))
            {
                Readed_String = sr.ReadToEnd();
                Console.WriteLine("Data was readed!");
            }
            string[] words = Readed_String.Split(new char[] { '\n' });
            foreach(string s in words)
            {
                Readed_String = s;
                while (true)
                {
                    if (s == "}\r" || s == "{\r") { break; }
                    index = Readed_String.IndexOf("'");
                    if (index == -1) { pre_num = -2; post_num = -2; break; }
                    if (pre_num == -2 && post_num == -2) { pre_num = Convert.ToInt32(Readed_String.Substring(index + 1, 1)); }
                    else
                    {
                        post_num = Convert.ToInt32(Readed_String.Substring(index + 1, 1));
                        words2.Add($"{pre_num} {post_num}");
                    }
                    Readed_String = Readed_String.Substring(index + 3);
                }
            }
            foreach (string s in words2) Console.WriteLine(s);
            //using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            //{
            //    string line;
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        String[] words = line.Split(new char[] { '\n' });
            //        foreach (string s in words)
            //        {
            //            while (true)
            //            {
            //                if (index == -2) line = s;
            //                index = line.IndexOf(" ");
            //                if (index == -1) { index = -2; break; }
            //                else
            //                {
            //                    words2.Add($"{line.Substring(index - 1, 1)} {line.Substring(index + 1, 1)}");
            //                    line = line.Substring(index + 1);
            //                }
            //            }
            //        }
            //    }
            //}
            return words2;
        }
    }
}
