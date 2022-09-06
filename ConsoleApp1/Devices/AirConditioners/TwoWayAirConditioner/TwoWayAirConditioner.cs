using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class TwoWayAirConditioner:AirConditioner
    {
        public override void Input()
        {
            airConditionerType = 2;
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap ma san pham (theo format ML2_(ma so) vi du ML2_001) : ");
                id = Console.ReadLine();
            }
            while (!checkID(id));
            base.Input();
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Co su dung cong nghe khang khuan khong (0 - khong, 1 - co) : ");
                try
                {
                    isAntibacterial = int.Parse(Console.ReadLine());
                }
                catch
                {
                    isAntibacterial = -1;
                }
            }
            while (!checkIsAntibacterial(isAntibacterial));

            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Co su dung cong nghe khu mui khong (0 - khong, 1 - co) : ");
                try
                {
                    isDeodorization = int.Parse(Console.ReadLine());
                }
                catch
                {
                    isDeodorization = -1;
                }
            }
            while (!checkIsDeodorization(isDeodorization));
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
        private bool checkIsAntibacterial(int isAntibacterialCheck)
        {
            if ((isAntibacterialCheck < 0) || (isAntibacterialCheck > 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Vui long luu y chi nhap (0 hoac 1) !!!");
                return false;
            }
            else
                return true;
        }
        private bool checkIsDeodorization(int isDeodorizationCheck)
        {
            if ((isDeodorizationCheck < 0) || (isDeodorizationCheck > 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Vui long luu y chi nhap (0 hoac 1) !!!");
                return false;
            }
            else
                return true;
        }

        protected override int getValue()
        {
            int totalValue = 0;
            totalValue += (isInverter == 0) ? 2000 : 2500;
            totalValue += (isAntibacterial == 0) ? 0 : 500;
            totalValue += (isDeodorization == 0) ? 0 : 500;
            return totalValue;
        }

        private bool checkID(string idCheck)
        {

            var regexItem = new Regex("^[a-zA-Z0-9_]*$");
            bool check;
            check = (idCheck.IndexOf("ML2_") == 0) ? true : false;
            if (regexItem.IsMatch(idCheck) && idCheck != "" && check)
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Luu y nhap ma so chi bao gom ky tu so va chu !!!");
                Console.WriteLine($"\t{c}=>  Cu phap ma so co dang (ML2_(ma so) vi du ML2_001)");
                return false;
            }
        }
    }
}
