using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommander
{
    class Program
    {
        static ConsoleCommander cmdr;
        static ConsoleCommanderPane pp1;
        static ConsoleCommanderPane pp21;
        static ConsoleCommanderPane pp22;

        static void Main(string[] args)
        {
            cmdr = new ConsoleCommander(false);
            pp1 = cmdr.AddPane(Console.WindowWidth, 4);
            pp1.Write("1-1 Hello, World!");
            pp1.Write("The time is ");
            pp1.Write(DateTime.Now.ToString());
            pp1.Write("Test text 2");
            ConsoleCommanderParentPane pp2 = cmdr.AddParentPane(Console.WindowWidth, 3);
            pp21 = pp2.AddPane(pp2.getWidth() / 2, pp2.getHeight());
            pp21.Write("2-1 Hello,");
            pp21.Write("Test text 1");
            pp21.Write("This is a really long string that will overflow the pane, and would normally write onto the next pane to the right");
            pp21.Write("Test text 2");
            pp22 = pp2.AddPane(pp2.getWidth() / 2, pp2.getHeight());
            pp22.Write("2-2 World!");
            pp22.Write("Test text 1");
            pp22.Write("This is yet another really long string that will overflow the pane, and would normally write onto the next pane to the right");
            pp22.Write("Test text 2");

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000 / 30;
            timer.Elapsed += timerHandler;
            timer.Start();
            cmdr.Render();

            Console.ReadKey();
        }

        private static void timerHandler(object sender, EventArgs e)
        {
            pp1.Write(DateTime.Now.ToString(), 0, 2);
            cmdr.Render();
        }
    }
}
