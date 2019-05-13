using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projec1
{
    class Program
    {
        static void Func1(int u, int[][] g, Random rand)
        {
            for (int i = 0; i < u + 1; i++)
            {
                g[i] = new int[u + 1];
                Console.Write("\n({0}) вершина -->[", i + 1);
                for (int j = 0; j < u + 1; j++)
                {
                    g[i][j] = rand.Next(0, 2);
                }
                g[i][i] = 0;
                foreach (var item in g[i])
                {
                    Console.Write(" {0}", item);
                }
                Console.Write("]\n");
            }
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            Queue<int> q = new Queue<int>();    //Это очередь, хранящая номера вершин
            string exit = "";
            int u;
            u = rand.Next(3, 5);
            bool[] used = new bool[u + 1];  //массив отмечающий посещённые вершины
            int[][] g = new int[u + 1][];   //массив содержащий записи смежных вершин

            Func1(u,g,rand);
            used[u] = true;     //массив, хранящий состояние вершины(посещали мы её или нет)

            q.Enqueue(u);
            Console.WriteLine("Начинаем обход с {0} вершины", u + 1);
            while (q.Count != 0)
            {
                u = q.Peek();
                q.Dequeue();
                Console.WriteLine("Перешли к узлу {0}", u + 1);

                for (int i = 0; i < g.Length; i++)
                {
                    if (Convert.ToBoolean(g[u][i]))
                    {
                        if (!used[i])
                        {
                            used[i] = true;
                            q.Enqueue(i);
                            Console.WriteLine("Добавили в очередь узел {0}", i + 1);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
