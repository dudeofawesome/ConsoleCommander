using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleCommander
{
    class ConsoleCommanderPane
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

        public void Write(string line, int x = -1, int y = -1)
        {
            if (x < 0)
            {
                x = pane.Count;
            }
            if (y < 0)
            {
                y = 0;
            }
            else if (y > width)
            {
                pane.Add("");
                return;
            }
            pane.Add(line);
        }

        public string Render()
        {
            string ret = "";
            for (int i = 0; i < pane.Count && i < height; i++)
            {
                int _width = width < pane[i].Length ? width : pane[i].Length;
                ret += pane[i].Substring(0, _width) + "\n";
            }
            return ret;
        }
    }
}
