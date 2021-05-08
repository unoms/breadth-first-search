using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Обход графов в глубину:
Удобно использовать стек или рекурсивные вызовы. На примере обхода графа, мы сначала идем до самого
дальнего / глубокого элемента, потому что стек — это структура данных по принципу LIFO (Last In First Out),
поэтому элементы так и обрабатываются.

Обход графов в ширину:
Нужно использовать очередь, тогда работает принцип FIFO(First In First Out), то есть мы обрабатываем
ближайшие элементы во всех направлениях.  
     
*/

namespace LabyrinthStack
{
    class Program
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        enum State
        {
            Empty,
            Wall,
            Visited
        }

        static void PrintMap(State[,] map)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            for (int y = 0; y < labyr.Length; y++)
            {
                for (int x = 0; x < labyr[0].Length; x++)
                {
                    switch (map[x, y])
                    {
                        case State.Wall:
                            Console.Write('X');
                            break;
                        case State.Empty:
                            Console.Write(' ');
                            break;
                        case State.Visited:
                            Console.Write('*');
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var map = new State[labyr[0].Length, labyr.Length];//x, y
            //Filling the map
            for (int y = 0; y < labyr.Length; y++)
            {
                for (int x = 0; x < labyr[0].Length; x++)
                {
                    //rows, columns
                    map[x, y] = labyr[y][x] == 'X' ? State.Wall : State.Empty;
                }
            }

            //Let's create a queue of Points
            var queue = new Queue<Point>();
            //we start from here
            queue.Enqueue(new Point { X = 0, Y = 0 });
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (point.X < 0 || point.X >= labyr[0].Length || point.Y < 0 || point.Y >= labyr.Length)
                    continue;
                if (map[point.X, point.Y] != State.Empty) continue;

                map[point.X, point.Y] = State.Visited;
                PrintMap(map);

                queue.Enqueue(new Point { X = point.X + 1, Y = point.Y });
                queue.Enqueue(new Point { X = point.X - 1, Y = point.Y });
                queue.Enqueue(new Point { X = point.X, Y = point.Y + 1 });
                queue.Enqueue(new Point { X = point.X, Y = point.Y - 1 });
            }
        }


        static string[] labyr = new string[]
        {
                " X   X    ",
                " X XXXXX X",
                "      X   ",
                "XXXX XXX X",
                "         X",
                " XXX XXXXX",
                " X        ",
         };
    }
}
