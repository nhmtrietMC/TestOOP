using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Device
    {
        public string c = ((char)124).ToString();
        protected string id;
        protected string name;
        protected string producer;
        protected int amountSold;
        protected int type; // 0 - quat, 1 - may lanh
        public int AmountSold
        {
            get => amountSold;
            set => amountSold = value;
        }

        public int Type
        {
            get => type;
            set => type = value;
        }

        public virtual void Input()
        {
            /*do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap ma san pham (Vi du nhap SP001) : ");
                id = Console.ReadLine();
            }
            while (!checkID(id));*/

            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap ten san pham: ");
                name = Console.ReadLine();
            }
            while (!checkName(name));

            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap dia chi san xuat: ");
                producer = Console.ReadLine();
            }
            while (!checkProducer(producer));
        }

        public virtual void Output()
        {

        }

        public virtual void OutputText()
        {

        }

        private bool checkID(string idCheck)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(idCheck) && idCheck != "")
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Luu y nhap ma so chi bao gom ky tu so va chu !!!");
                return false;
            }
        }

        private bool checkName(string nameCheck)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(nameCheck) && nameCheck != "")
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Luu y ten san pham chi bao gom ky tu so va chu !!!");
                return false;
            }
        }

        private bool checkProducer(string producerCheck)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(producerCheck) && producerCheck != "")
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Luu y nhap noi san xuat chi bao gom ky tu so va chu !!!");
                return false;
            }
        }

        public virtual int GetSumValue()
        {
            return 0;
        }
    }
}
