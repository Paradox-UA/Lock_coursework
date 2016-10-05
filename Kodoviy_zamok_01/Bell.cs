using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;




namespace Kodoviy_zamok_01
{
    public class Bell
    {
        private bool status;//false-не звонит; true-звонит;
        private SoundPlayer Call_ring;
        public  Bell()
        {
            
            status = false;
            Call_ring = new SoundPlayer(Properties.Resources.doorbell_7);
            
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
        public void Action_ring()
        {
            if (this.status == true)//здесь должен будет проигрываться звук звонка
            {
                Call_ring.Play();
            }
        }
    }
}
