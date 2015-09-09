using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleCommander
{
    class ConsoleCommander
    {
        //private List<ConsoleCommanderPane> panes = new List<ConsoleCommanderPane>();

        public ConsoleCommander()
        {
            List<ConsoleCommanderPane> panes = new List<ConsoleCommanderPane>();
            panes.Add(new ConsoleCommanderPane(Console.WindowWidth / 2, Console.WindowHeight));
            panes[0].Write("Hello,asdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf");
            panes.Add(new ConsoleCommanderPane(Console.WindowWidth / 2, Console.WindowHeight));
            panes[1].Write("World!");
            //for (int i = 0; i < 3; i++)
            //{
            //    panes.Add(new List<string>());
            //    if (i % 2 == 0)
            //    {
            //        panes[i].Add("Hello! " + i);
            //    }
            //    else
            //    {
            //        for (int j = 0; j < 100; j++)
            //        {
            //            panes[i].Add("World! " + i + " " + j);
            //        }
            //    }
            //}
            
            int width = Console.WindowWidth / panes.Count;
            for (int i = 0; i < panes.Count; i++)
            {
                Console.SetCursorPosition(i * width, 0);
                Console.Write(panes[i].Render());
                if (i + 1 < panes.Count)
                {
                    for (int j = 0; j < Console.WindowHeight; j++)
                    {
                        Console.SetCursorPosition(width - 1, j);
                        Console.Write("│");
                    }
                }
            }

            Console.ReadKey();
        }

        public void AddPane()
        {
            //panes.Add(new ConsoleCommanderPane(null));
        }
    }
}
