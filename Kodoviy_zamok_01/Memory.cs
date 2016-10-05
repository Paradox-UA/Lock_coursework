using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Kodoviy_zamok_01
{
    public class Memory
    {
        private int[] factory_reset;//уникальный заводской пароль для сброса всех настроек
        private int[] entrance_code;//пароль для открытия замка
        private int[] access_code;//пароль для внесения настроек
        public SoundPlayer dopusk = new SoundPlayer(Properties.Resources.Dopustit);//звук допуска
        public SoundPlayer nedopusk = new SoundPlayer(Properties.Resources.buzzer);//звук недопуска
        public SoundPlayer factory = new SoundPlayer(Properties.Resources.Nedipust);//звук возвращения к заводским параметрам
        public SoundPlayer smena = new SoundPlayer(Properties.Resources.smena);//звук смены паролей
        

        public Memory()//настройки по умолчанию
        {
            factory_reset = new int[4] { 3, 2, 7, 4 };//заводской пароль
            entrance_code = new int[4] { 0, 0, 0, 0 };//пароль по умолчанию для разблокировки двери
            access_code = new int[4] { 1, 1, 1, 1 };//пароль по умолчанию для входа в настройки
 
        }

        public bool Factory_status(int[] mas)//проверка правильности введенного кода , для сброса настроек до заводских
        {
            int j = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (factory_reset[i] != mas[i])
                {
                    j++;
                }
            }
            if (j == 0)
            {
                return true;//пароль верный
            }
            else
            {
                return false;//пароль неверный
            }
        }
        public bool Entrance_status(int[] mas)//проверка правильности введенного кода доступа
        {
            int j = 0;
            for(int i=0;i<mas.Length;i++)
            {
                if(entrance_code[i]!=mas[i])
                {
                    j++;
                }
            }
            if(j==0)
            {
                return true;//пароль верный
            }
            else
            {
                return false;//пароль неверный
            }
        }
        public bool Access_status(int[] mas)//проверка правильности введенного кода контроля
        {
            int j = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (access_code[i] != mas[i])
                {
                    j++;
                }
            }
            if (j == 0)
            {
                return true;//пароль верный
            }
            else
            {
                return false;//пароль неверный
            }
        }
        public int[] Entrance_code
        {
            get
            {
                return entrance_code;
            }
            set
            {
                entrance_code = value;
            }
        }
        public int[] Access_code
        {
            get
            {
                return access_code;
            }
            set
            {
                access_code = value;
            }
        }

    }
}
