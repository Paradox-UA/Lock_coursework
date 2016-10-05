using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodoviy_zamok_01
{
   public class Lock
    {
        public Memory memory;
        public Mechanism mechanism;
        public Bell bell;
        public Lock()
        {
            memory = new Memory();
            mechanism = new Mechanism();
            bell = new Bell();
        }
    }
}
