using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp1
{
    class ElectricFan : Fan
    {

        protected override int getValue()
        {
            return batteryCapacity * 500;
        }

        public override void Input()
        {
            fanType = 3;
            base.Input();
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap dung tich pin : ");
                try
                {
                    batteryCapacity = int.Parse(Console.ReadLine());
                }
                catch
                {
                    batteryCapacity = 0;
                }
            }
            while (!checkBatteryCapacity(batteryCapacity));
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap so luong ban ra : ");
                try
                {
                    amountSold = int.Parse(Console.ReadLine());
                }
                catch
                {
                    amountSold = 0;
                }
            }
            while (!checkAmountSold(amountSold));
        }

        private bool checkBatteryCapacity(int batteryCapacityCheck)
        {
            if (batteryCapacityCheck <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Dung tich pin phai nguyen duong !!!");
                return false;
            }
            else
                return true;
        }
        private bool checkAmountSold(int amountSoldCheck)
        {
            if (amountSold <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  So luong ban ra phai nguyen duong !!!");
                return false;
            }
            else
                return true;
        }
    }
}
