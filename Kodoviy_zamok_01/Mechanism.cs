using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodoviy_zamok_01
{
   public class Mechanism
    {
        private bool status;//открыт - true; закрыт - false;
        public Mechanism()//изначально механизм замка закрыт
        {
            status = false;
        }
        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
    }
}
