using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Kodoviy_zamok_01
{
    class Dynamic
    {
        public Dynamic() { }

        public void Play(SoundPlayer sound)
        {
            sound.Play();
        }
        ~Dynamic(){}
    }
}
