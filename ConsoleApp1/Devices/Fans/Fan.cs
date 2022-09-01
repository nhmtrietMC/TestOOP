using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Fan : Device
    {
        protected int fanType; //1 - quat dung, 2 - quat hoi nuoc, 3 - quat sac pin
        protected int waterCapacity;
        protected int batteryCapacity;
        public override void Input()
        {
            base.Input();
        }

        public override void Output()
        {
            Console.Write("\tMay quat: ");
            Console.Write(id + " ");
            if (fanType == 1)
                Console.Write("quat dung ");
            else
            if (fanType == 2)
                Console.Write("quat hoi nuoc ");
            else
                Console.Write("quat sac pin ");
            Console.Write(name +  " ");
            Console.Write(producer + " ");
            Console.Write(getValue() + " ");
            if (fanType == 2)
                Console.Write(waterCapacity + " ");
            else
            if (fanType == 3)
                Console.Write(batteryCapacity + " ");
            Console.WriteLine(amountSold);
        }


        public override void OutputText()
        {
            StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt");
            sw.Write("\tMay quat: ");
            sw.Write(id + " ");
            if (fanType == 1)
                sw.Write("quat dung ");
            else
            if (fanType == 2)
                sw.Write("quat hoi nuoc ");
            else
                sw.Write("quat sac pin ");
            sw.Write(name + " ");
            sw.Write(producer + " ");
            sw.Write(getValue() + " ");
            if (fanType == 2)
                sw.Write(waterCapacity + " ");
            else
            if (fanType == 3)
                sw.Write(batteryCapacity + " ");
            sw.WriteLine(amountSold);
            sw.Close();
        }

        protected virtual int getValue()
        {
            return 500;
        }

        public override int GetSumValue()
        {
            return getValue() * amountSold;
        }
    }
}
