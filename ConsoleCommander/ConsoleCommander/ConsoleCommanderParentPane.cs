//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleCommander
//{
//    class ConsoleCommanderParentPane
//    {
//        private ConsoleCommanderParentPane parent;
//        private List<ConsoleCommanderParentPane> panes = new List<ConsoleCommanderParentPane>();

//        public ConsoleCommanderParentPane(ConsoleCommanderParentPane parent)
//        {
//            this.parent = parent;
//        }

//        public void Draw()
//        {
//            for (int i = 0; i < panes.Count; i++)
//            {
//                panes[i].Draw();
//            }
//        }
//    }
//}
