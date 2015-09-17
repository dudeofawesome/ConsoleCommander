using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommander
{
    public class ConsoleCommanderParentPane
    {
        private List<ConsoleCommanderParentPane> panes = new List<ConsoleCommanderParentPane>();
        int width = 0;
        int height = 0;
        bool horizontal = true;

        public ConsoleCommanderParentPane()
        {

        }

        public ConsoleCommanderParentPane(int width, int height, bool horizontal = true)
        {
            this.width = width;
            this.height = height;
            this.horizontal = horizontal;
        }

        public virtual void Write(string line, int x = -1, int y = -1, bool insert = false, bool allowOverFlow = true)
        {

        }

        public virtual void Write(object line, int x = -1, int y = -1, bool insert = false, bool allowOverFlow = true)
        {
            Write(line.ToString(), x, y, insert, allowOverFlow);
        }

        public virtual void Clear(int x = 0, int y = 0, int w = -1, int h = -1)
        {
            for (int i = 0; i < panes.Count; i++)
            {
                panes[i].Clear();
            }
        }

        public virtual string Render()
        {
            string ret = "";
            List<List<string>> retPanes = new List<List<string>>();
            if (horizontal)
            {
                for (int i = 0; i < panes.Count; i++)
                {
                    retPanes.Add(new List<string>());
                    string[] renderLines = panes[i].Render().Split('\n');
                    for (int j = 0; j < renderLines.Length; j++)
                    {
                        if (j + 1 < renderLines.Length || renderLines[j] != "")
                        {
                            string newLine = "";
                            for (int k = 0; k < panes[i].getWidth() - renderLines[j].Length; k++)
                            {
                                newLine += " ";
                            }
                            if (i + 1 < panes.Count)
                            {
                                if (newLine.Length == 0)
                                {
                                    renderLines[j] = renderLines[j].Remove(renderLines[j].Length - 1, 1) + "│";
                                    newLine = "";
                                }
                                else
                                {
                                    newLine = newLine.Remove(newLine.Length - 1, 1) + "│";
                                }
                            }
                            else
                            {
                                newLine += "\n";
                            }
                            retPanes[i].Add(renderLines[j] + newLine);
                        }
                    }

                    //retPanes.Add(ret);
                    //ret = "";
                }

                int tallestPane = 0;
                for (int i = 0; i < retPanes.Count; i++)
                {
                    tallestPane = retPanes[i].Count > tallestPane ? retPanes[i].Count : tallestPane;
                }
                for (int i = 0; i < tallestPane; i++)
                {
                    for (int j = 0; j < retPanes.Count; j++)
                    {
                        if (retPanes[j].Count > i)
                        {
                            ret += retPanes[j][i];
                        }
                        else
                        {
                            if (j + 1 >= retPanes.Count)
                            {
                                ret += "\n";
                            }
                            else
                            {
                                string blanks = "";
                                while (blanks.Length < panes[j].getWidth() - 1)
                                {
                                    blanks += " ";
                                }
                                blanks += "│";
                                ret += blanks;
                            }
                        }
                    }
                }

            }
            else
            {
                //Console.Write("─");
            }

            if (ret.EndsWith("\n"))
            {
                ret = ret.Remove(ret.Length - 1, 1);
            }

            return ret;

            //int width = Console.WindowWidth / panes.Count;
            //for (int i = 0; i < panes.Count; i++)
            //{
            //    string render = panes[i].Render();
            //    string[] renderLines = render.Split('\n');
            //    for (int j = 0; j < renderLines.Length && j < Console.WindowHeight; j++)
            //    {
            //        Console.SetCursorPosition(i * width, j);
            //        Console.Write(renderLines[j]);
            //    }
            //    if (i + 1 < panes.Count)
            //    {
            //        for (int j = 0; j < Console.WindowHeight; j++)
            //        {
            //            Console.SetCursorPosition(((i + 1) * width) - 1, j);
            //            Console.Write("│");
            //        }
            //    }
            //}
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

        public virtual int getWidth()
        {
            return width;
        }

        public virtual int getHeight()
        {
            return height;
        }

        public bool getDirection()
        {
            return horizontal;
        }
    }
}
