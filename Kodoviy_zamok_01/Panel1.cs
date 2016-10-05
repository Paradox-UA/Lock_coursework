using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Kodoviy_zamok_01
{
    public partial class Panel1 : Form
    {
        public Panel1()
        {
            InitializeComponent();
            this.Show();
        }

        static Lock lock1 = new Lock();//при запуске формы у замка дефолтные настройки
        List<int> input_mas = new List<int>();
        bool control_action = false;
        bool call_action = false;
        bool factory_settings;
        bool call_press = false;
        bool control_press = false;
        int time = 0;//счётчик таймера
        Dynamic dynamic1 = new Dynamic();
        
        public void Wrong_input(string str)
        {
            richTextBox_Display.Clear();
            richTextBox_Display.BackColor = Color.Red;
            dynamic1.Play(lock1.memory.nedopusk);
            richTextBox_Display.AppendText(str);
            timer1.Enabled = true;//включили таймер
        }
        public void To_factory_settings()
        {
            richTextBox_Display.Clear();
            richTextBox_Display.BackColor = Color.Firebrick;
            dynamic1.Play(lock1.memory.factory);
            richTextBox_Display.Text = "Resetting to factory settings! ";
            timer1.Enabled = true;//запускаем таймер
            factory_settings = true;
        }
        public void Open_lock()
        {
            richTextBox_Display.Clear();
            richTextBox_Display.BackColor = Color.Green;
            richTextBox_Display.Text = "Open";
            lock1.mechanism.Status = true;//механизм открыт
            dynamic1.Play(lock1.memory.dopusk);
            timer1.Enabled = true;//включили таймер
        }
        public void Successfull_password(string str)
        {
            richTextBox_Display.Clear();
            richTextBox_Display.BackColor = Color.CornflowerBlue;
            dynamic1.Play(lock1.memory.smena);
            richTextBox_Display.Text = str;
        }
        public void Changing_password(string str, int [] in_code_mas)
        {
            if(call_action==true)
            {
                lock1.memory.Access_code = in_code_mas;
            }
            else if (control_action == true)
            {
                lock1.memory.Entrance_code = in_code_mas;//меняем код доступа на введёный пользователем
            }
            richTextBox_Display.Clear();
            richTextBox_Display.BackColor = Color.Green;
            richTextBox_Display.Text = str;
            input_mas.Clear();
            dynamic1.Play(lock1.memory.dopusk);
            timer1.Enabled = true;
        }
        public void If_close(int numb)
        {
            if (richTextBox_Display.Text.Length == 4)
            {
                int[] in_code_mas = new int[4];
                for (int i = 0; i < richTextBox_Display.Text.Length; i++)
                {
                    in_code_mas[i] = input_mas[i];
                }

                if (lock1.memory.Factory_status(in_code_mas) == true)//если введён заводской пароль
                {
                    To_factory_settings();
                }
                else if (lock1.memory.Entrance_status(in_code_mas) == true)//если пароль правильный, значит открыть дверь на 10 секунд
                {
                    Open_lock();
                }
                else//если пароль не правильный
                {
                    Wrong_input("Wrong entrance input!");
                }
                input_mas.Clear();
            }
            else//если введены не 4 значения или значения неверны
            {
                Wrong_input("Wrong entrance input!");
                input_mas.Clear();
            }
        }
        public void If_open(int numb)
        {
            if (control_press == true)//если кнопка "контроль" была нажата
            {
                if (richTextBox_Display.Text == "Locked" || richTextBox_Display.Text == "Open")
                {
                    richTextBox_Display.Clear();
                    richTextBox_Display.BackColor = Color.White;
                }

                if (richTextBox_Display.Text.Length < 4)//пока введено меньше 4 цифр
                {
                    richTextBox_Display.AppendText(Convert.ToString(numb));
                    input_mas.Add(numb);//вводим соответсвующую цифру
                }
                if (richTextBox_Display.Text.Length == 4)//если введено уже 4 цифры, тогда прерывание ввода
                {
                    if (lock1.mechanism.Status == true)//если замок ещё открыт
                    {
                        int[] in_code_mas = new int[4];
                        for (int i = 0; i < richTextBox_Display.Text.Length; i++)
                        {
                            in_code_mas[i] = input_mas[i];
                        }
                        if (lock1.memory.Access_status(in_code_mas) == true)//если пароль контроля правильный 
                        {
                            Successfull_password("Input new entrance password. ");
                            control_press = false;//кнопка действие завершила
                            control_action = true;
                        }
                        else//если пароль не правильный
                        {
                            Wrong_input("Wrong control input!");
                            control_press = false;
                        }
                        input_mas.Clear();
                    }
                    input_mas.Clear();///
                }
            }
            else if (control_action == true)//если все условия для смены пароля доступа выполнены
            {
                int[] in_code_mas = new int[4];
                for (int i = 0; i < richTextBox_Display.Text.Length; i++)
                {
                    in_code_mas[i] = input_mas[i];
                }
                Changing_password("Entrance password is successful changed! ", in_code_mas);
                control_action = false;//процес смены пароля входа завершён
            }
            else if (call_press == true)//если кнопка "звонок" нажата
            {
                if (richTextBox_Display.Text == "Open")
                {
                    richTextBox_Display.Clear();
                    richTextBox_Display.BackColor = Color.White;
                }

                if (richTextBox_Display.Text.Length < 4)//пока введено меньше 4 цифр
                {
                    richTextBox_Display.AppendText(Convert.ToString(numb));
                    input_mas.Add(numb);//вводим соответсвующую цифру
                }
                if (richTextBox_Display.Text.Length == 4)//если введено уже 4 цифры, тогда прерывание ввода
                {
                    if (lock1.mechanism.Status == true)//если замок ещё открыт
                    {
                        int[] in_code_mas = new int[4];
                        for (int i = 0; i < richTextBox_Display.Text.Length; i++)
                        {
                            in_code_mas[i] = input_mas[i];
                        }

                        if (lock1.memory.Access_status(in_code_mas) == true)//если пароль контроля правильный 
                        {
                            Successfull_password("Input new access password. ");
                            call_press = false;//кнопка действие завершила
                            call_action = true;
                        }
                        else//если пароль не правильный
                        {
                            Wrong_input("Wrong control input!");
                            call_press = false;
                        }
                        input_mas.Clear();
                    }
                    input_mas.Clear();///
                }
            }
            else if (call_action == true)//если все условия для смены пароля контроля выполнены
            {
                int[] in_code_mas = new int[4];
                for (int i = 0; i < richTextBox_Display.Text.Length; i++)
                {
                    in_code_mas[i] = input_mas[i];
                }
                Changing_password("Access password is successful changed! ", in_code_mas);
                call_action = false;//процес смены пароля контроля завершён
            }
        }
        public void Action_buttons0_9(int numb)
        {
            if ((richTextBox_Display.Text == "Locked" || richTextBox_Display.Text == "Open" || richTextBox_Display.Text == "Input new entrance password. " || richTextBox_Display.Text == "Input new access password. ") && timer1.Enabled == false)
            {
                richTextBox_Display.Clear();
                richTextBox_Display.BackColor = Color.White;
            }

            if (richTextBox_Display.Text.Length < 4 && timer1.Enabled == false)//пока введено меньше 4 цифр
            {
                richTextBox_Display.AppendText(Convert.ToString(numb));
                input_mas.Add(numb);//вводим соответсвующую цифру
            }
            if (richTextBox_Display.Text.Length == 4)//если введено уже 4 цифры, тогда прерывание ввода
            {
                if (lock1.mechanism.Status == false)//если замок закрыт
                {
                    If_close(numb);
                }
                else if (lock1.mechanism.Status == true)//если замок открыт
                {
                    If_open(numb);
                }
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(0);
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(1);
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(2);
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(3);
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(4);
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(5);
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(6);
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(7);
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(8);
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            Action_buttons0_9(9);
        }
       
        private void button_Call_Click(object sender, EventArgs e)
        {
            if(lock1.mechanism.Status==false)//если замок закрыт
            {
                lock1.bell.Status = true;
                lock1.bell.Action_ring();//звоним в дверь издавая звук
                lock1.bell.Status = false;
            }
            else if (lock1.mechanism.Status == true && richTextBox_Display.Text == "Open" && control_press == false)
            {
                call_press = true;
            }
        }
        
        private void button_Control_Click(object sender, EventArgs e)
        {
            if (lock1.mechanism.Status == true && richTextBox_Display.Text == "Open" && call_press == false)//если замок открыт
            {
                control_press = true;
            }
            else if(lock1.mechanism.Status==false && richTextBox_Display.Text== "Resetting to factory settings! " )
            {
                control_press = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                if (lock1.mechanism.Status == true)//если замок открыт
                {
                    if (time != 4 && control_press == false && call_press == false)//пока не прошло 5 секунд и кнопки не нажаты
                    {
                        time++;
                    }
                    else if (time == 4)//если прошло 5 секунд
                    {
                        lock1.mechanism.Status = false;//закрываем замок
                        richTextBox_Display.Text = "Locked";
                        richTextBox_Display.BackColor = Color.Yellow;
                        time = 0;
                        timer1.Enabled = false;
                    }
                    else//если кнопка была нажата и прошло время после смены паролей (если смены были)
                    {
                            time = 0;
                            timer1.Enabled = false;  
                    }
                }
                else if(lock1.mechanism.Status==false)//если замок закрыт
                {
                    if (time != 4 && control_press==false )//отсчитываем 5 секунд
                    {
                        time++;
                    }
                    else if(control_press==false)
                    {
                        lock1.mechanism.Status = false;//закрываем замок
                        richTextBox_Display.Text = "Locked";
                        richTextBox_Display.BackColor = Color.Yellow;
                        input_mas.Clear();
                        time = 0;
                        timer1.Enabled = false;
                    }
                    else if(control_press==true && factory_settings==true)
                    {
                        time = 0;
                        timer1.Enabled = false;
                        lock1 = new Lock();//дефолтим наш замок
                        richTextBox_Display.Clear();
                        richTextBox_Display.BackColor = Color.Green;
                        dynamic1.Play(lock1.memory.dopusk);
                      //  dynamic1.melodies[0].Play();
                        richTextBox_Display.Text = "Successful resetting to factory settings. ";
                        timer1.Enabled = true;//перезапустили таймер
                        control_press = false;
                        factory_settings = false;               
                    }
                }
            }
        }
    }
}
