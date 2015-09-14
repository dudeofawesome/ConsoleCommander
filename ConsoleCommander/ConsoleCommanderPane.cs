using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleCommander
{
    public class ConsoleCommanderPane : ConsoleCommanderParentPane
    {
        //private ConsoleCommanderParentPane parent;
        List<string> pane = new List<string>();
        int width = 0;
        int height = 0;

        public ConsoleCommanderPane(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        override public void Write(string line, int x = -1, int y = -1, bool insert = false, bool allowOverFlow = true)
        {
            if (x < 0)
            {
                x = 0;
            }
            if (y < 0)
            {
                y = pane.Count;
            }
            if (insert)
            {
                string spacing = "";
                while (spacing.Length < x)
                {
                    spacing += " ";
                }
                while (pane.Count <= y)
                {
                    pane.Add("");
                }
                pane.Insert(y, spacing + line);
            }
            else
            {
                if (y >= pane.Count)
                {
                    while (pane.Count < y)
                    {
                        pane.Add("");
                    }

                    string spacing = "";
                    while (spacing.Length < x)
                    {
                        spacing += " ";
                    }
                    pane.Add(spacing + line);
                }
                else
                {
                    int w = line.Length;
                    if (x + w > pane[y].Length)
                    {
                        w = pane[y].Length;
                    }

                    pane[y] = pane[y].Remove(x, w).Insert(x, line);
                }
            }
        }

        public override void Clear(int x = 0, int y = 0, int w = -1, int h = -1)
        {
            if (pane.Count > 0)
            {
                if (w == -1)
                {
                    w = width;
                }
                if (h == -1)
                {
                    h = height;
                }

                for (int i = y; i < h && i < pane.Count; i++)
                {
                    int _w = w;
                    if (x + w > pane[i].Length)
                    {
                        _w = pane[i].Length;
                    }

                    string blanks = "";
                    for (int j = y; j < _w; j++)
                    {
                        blanks += " ";
                    }
                    pane[i] = pane[i].Remove(x, _w).Insert(x, blanks);
                }
            }
        }

        override public string Render()
        {
            string ret = "";
            for (int i = 0; i < pane.Count && i < height; i++)
            {
                int _width = width < pane[i].Length ? width : pane[i].Length;
                ret += pane[i].Substring(0, _width);
                // TODO: figure out how to make a line that runs to the end of the console not overflow to the next line
                if (i + 1 < pane.Count)
                {
                    ret += "\n";
                }
            }
            return ret;
        }


        public override int getWidth()
        {
            return width;
        }

        public override int getHeight()
        {
            return height;
        }
    }
}
