using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class OneWayAirConditioner : AirConditioner
    {
        public override void Input()
        {
            airConditionerType = 1;
            base.Input();
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

        protected override int getValue()
        {
            if (isInverter == 0)
                return 1000;
            else
                return 1500;
        }
    }
}
