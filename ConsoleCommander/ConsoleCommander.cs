using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleCommander
{
    public class ConsoleCommander
    {
        private List<ConsoleCommanderParentPane> panes = new List<ConsoleCommanderParentPane>();
        private bool horizontal = true;

        public ConsoleCommander(bool horizontal = true)
        {
            Console.BufferWidth++;
            Console.BufferHeight += 2;
            this.horizontal = horizontal;

            //panes.Add(new ConsoleCommanderPane(Console.WindowWidth / 3, Console.WindowHeight));
            //panes[0].Write("Hello,");
            //panes[0].Write("Test text 1");
            //panes[0].Write("This is a really long string that will overflow the pane, and would normally write onto the next pane to the right");
            //panes[0].Write("Test text 2");
            //panes.Add(new ConsoleCommanderPane(Console.WindowWidth / 3, Console.WindowHeight));
            //panes[1].Write("World!");
            //panes.Add(new ConsoleCommanderPane(Console.WindowWidth / 3, Console.WindowHeight));
            //panes[2].Write("Hello, World again!");
            //panes[2].Write("Hello, World again! 2");
        }

        public void Render()
        {
            Console.Clear();
            if (horizontal)
            {
                for (int i = 0; i < panes.Count; i++)
                {
                    string render = panes[i].Render();
                    string[] renderLines = render.Split('\n');
                    for (int j = 0; j < renderLines.Length && j < Console.WindowHeight; j++)
                    {
                        Console.SetCursorPosition(i * panes[i].getWidth(), j);
                        Console.Write(renderLines[j]);
                    }
                    if (i + 1 < panes.Count)
                    {
                        for (int j = 0; j < panes[i].getHeight(); j++)
                        {
                            Console.SetCursorPosition(((i + 1) * panes[i].getWidth()) - 1, j);
                            Console.Write("│");
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < panes.Count; i++)
                {
                    string render = panes[i].Render();
                    //string render = "";
                    //string[] renderLines = panes[i].Render().Split('\n');

                    //for (int k = 0; k < renderLines.Length; k++)
                    //{
                    //    int _width = renderLines[k].Length >= Console.WindowWidth ? Console.WindowWidth : renderLines[k].Length;
                    //    render += renderLines[k].Substring(0, _width);
                    //}

                    Console.SetCursorPosition(0, i == 0 ? 0 : panes[i - 1].getHeight());
                    Console.Write(render);
                    if (i + 1 < panes.Count)
                    {
                        for (int j = 0; j < panes[i].getWidth(); j++)
                        {
                            Console.SetCursorPosition(j, panes[i].getHeight() - 1);
                            Console.Write("─");
                        }
                    }
                }
            }
        }

        public ConsoleCommanderParentPane AddParentPane(int width, int height)
        {
            ConsoleCommanderParentPane pane = new ConsoleCommanderParentPane(width, height);
            panes.Add(pane);
            return pane;
        }

        public ConsoleCommanderPane AddPane(int width, int height)
        {
            ConsoleCommanderPane pane = new ConsoleCommanderPane(width, height);
            panes.Add(pane);
            return pane;
        }
    }
}
