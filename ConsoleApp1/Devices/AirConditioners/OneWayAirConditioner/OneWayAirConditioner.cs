using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class OneWayAirConditioner : AirConditioner
    {
        public override void Input()
        {
            airConditionerType = 1;
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap ma san pham (theo format ML1_(ma so) vi du ML1_001) : ");
                id = Console.ReadLine();
            }
            while (!checkID(id));
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
        private bool checkID(string idCheck)
        {

            var regexItem = new Regex("^[a-zA-Z0-9_]*$");
            bool check;
            check = (idCheck.IndexOf("ML1_") == 0) ? true : false;
            if (regexItem.IsMatch(idCheck) && idCheck != "" && check)
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Luu y nhap ma so chi bao gom ky tu so va chu !!!");
                Console.WriteLine($"\t{c}=>  Cu phap ma so co dang (ML1_(ma so) vi du ML1_001)");
                return false;
            }
        }
    }
}
