using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    class Bills
    {
        private int _numBill;
        private Bill[] _listBill;
        public void Input()
        {
            Console.Clear();
            do
            {
                Console.ResetColor();
                Console.Write("- So luong hoa don muon nhap: ");
                try
                {
                    _numBill = int.Parse(Console.ReadLine());
                }
                catch
                {
                    _numBill = 0;
                }
            }
            while (!checkNumBill(_numBill));
            _listBill = new Bill[_numBill];
           for(int i = 0; i < _numBill; i++)
            {
                _listBill[i] = new Bill();
                Console.Clear();
                Console.WriteLine($"- Nhap thong tin hoa don {i + 1}:");
                _listBill[i].Input();
            }
        }

        public void Output()
        {
            Console.Clear();
            bool check = true;
            int index = 0;
            Console.Clear();
            Console.WriteLine($"Thong tin hoa don thu {1}/{_numBill}");
            _listBill[index].Output();
            do
            {
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Dung 2 phim < va > de di chuyen hoa don tuong ung trai phai, cac phim con lai se dung chuong trinh");
                var sig = Console.ReadKey();
                if (sig.Key == ConsoleKey.LeftArrow)
                {
                    if (index <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n=> Day la hoa don cuoi cung ben trai khong the sang trai duoc nua");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Clear();
                        Console.WriteLine($"Thong tin hoa don thu {index}/{_numBill}");
                        _listBill[--index].Output();
                    }
                }
                else
                if (sig.Key == ConsoleKey.RightArrow)
                {
                    if (index == _numBill - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n=> Day la hoa don cuoi cung ben phai khong the sang phai duoc nua");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Clear();
                        Console.WriteLine($"Thong tin hoa don thu {index + 2}/{_numBill}");
                        _listBill[++index].Output();
                    }
                }
                else
                /*if(sig.Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDang tai file xuong !!!");
                    Console.ResetColor();
                    StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt");
                    sw.Close();
                    _listBill[index].OutputText();
                }    
                else*/
                {
                    Console.Clear();
                    /*Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Cam on ban da su dung chuong trinh !");
                    Console.WriteLine(@"Neu ban co tai hoa don xuong thi vao desktop file ten la : danh_sach_hoa_don.txt");*/
                    check = false;
                    /*Console.ResetColor();*/
                }
            }
            while (check);

        }

        public void Save()
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt", "");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\t\t\t Dang tai file xuong ");
            for(int i = 0; i < 3; i++)
            {
                Console.Write("!");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
            Console.ResetColor();
            StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt");
            sw.Close();
            for (int i = 0; i < _numBill; i++)
                _listBill[i].OutputText();
        }
        private bool checkNumBill(int numBillCheck)
        {
            if (numBillCheck <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=>  So luong hoa don phai la so nguyen duong !!!");
                return false;
            }
            else
                return true;
        }
    }
}
