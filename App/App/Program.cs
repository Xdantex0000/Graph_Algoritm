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

        static bool Find(List<int> list, int x)
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

        static void Ways(List<Edge> edges, int numberEdge, List<int> list, List<List<int>> listWays)
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

        static void Print(List<int> list, int end)
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

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int start = 2;
            int end = 6;
            List<Edge> edges = new List<Edge>();
            List<List<int>> listWays = new List<List<int>>();
            CHIDA();
            edges.Add(new Edge(1, 2));
            edges.Add(new Edge(1, 3));
            edges.Add(new Edge(1, 6));
            edges.Add(new Edge(2, 3));
            edges.Add(new Edge(2, 4));
            edges.Add(new Edge(3, 6));
            edges.Add(new Edge(3, 4));
            edges.Add(new Edge(4, 5));
            edges.Add(new Edge(5, 6));
            //Ways(edges, start, new List<int>(), listWays);
            //foreach (var i in listWays) Print(i, end);
            Console.ReadLine();
        }

        static void CHIDA()
        {
            string path = "input.txt";

            try
            {
                Console.WriteLine();
                Console.WriteLine("******считываем построчно********");
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        String[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        foreach (var VARIABLE in words)
                        {
                            i++;
                            if(i==2)
                            {

                            }
                            Console.WriteLine(VARIABLE);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CHIDA2(int one,int two)
        {

        }
    }
}
