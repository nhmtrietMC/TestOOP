using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp1
{
    class AirConditioner : Device 
    {
        protected int airConditionerType; /// 1 - 1 chieu, 2 - 2 chieu
        protected int isInverter;
        protected int isAntibacterial;
        protected int isDeodorization;
        public override void Input()
        {
            base.Input();
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Co su dung cong nghe Inverter khong (0 - khong, 1 - co) : ");
                try
                {
                    isInverter = int.Parse(Console.ReadLine());
                }
                catch
                {
                    isInverter = -1;
                }
            }
            while (!checkInverter(isInverter));
        }

        public override void Output()
        {
            Console.Write("\tMay lanh: ");
            Console.Write(id + " ");
            if (airConditionerType == 1)
                Console.Write("1 chieu ");
            else
                Console.Write("2 chieu ");
            Console.Write(name + " ");
            Console.Write(producer + " ");
            Console.Write(getValue() + " ");

            if(isInverter == 0)
                Console.Write("khong inverter ");
            else
                Console.Write("inverter ");

            if (airConditionerType == 2)
            {
                if (isAntibacterial == 0)
                    Console.Write("khong khang khuan ");
                else
                    Console.Write("khang khuan ");

                if (isDeodorization == 0)
                    Console.Write("khong khu mui ");
                else
                    Console.Write("khu mui ");
            }
            Console.WriteLine(amountSold);
        }

        public override void OutputText()
        {
            StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt");
            sw.Write("\tMay lanh: ");
            sw.Write(id + " ");
            if (airConditionerType == 1)
                sw.Write("1 chieu ");
            else
                sw.Write("2 chieu ");
            sw.Write(name + " ");
            sw.Write(producer + " ");
            sw.Write(getValue() + " ");

            if (isInverter == 0)
                sw.Write("khong inverter ");
            else
                sw.Write("inverter ");

            if (airConditionerType == 2)
            {
                if (isAntibacterial == 0)
                    sw.Write("khong khang khuan ");
                else
                    sw.Write("khang khuan ");

                if (isDeodorization == 0)
                    sw.Write("khong khu mui ");
                else
                    sw.Write("khu mui ");
            }
            sw.WriteLine(amountSold);
            sw.Close();
        }
        private bool checkInverter(int isInverterCheck)
        {
            if ((isInverterCheck < 0) || (isInverterCheck > 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Vui long luu y chi nhap (0 hoac 1) !!!");
                return false;
            }
            else
                return true;
        }

        protected virtual int getValue()
        {
            return 0;
        }

        public override int GetSumValue()
        {
            return getValue() * amountSold;
        }
    }
}
