using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class DetailBill
    {
        private int _numDetailBill;
        private Device[] _device;
        protected int totalCost = 0;

        public int TotalCost => totalCost;
        public void Input()
        {
            Console.WriteLine("- Nhap danh sach chi tiet cac hoa don: ");
            do
            {
                Console.ResetColor();
                Console.Write("- Nhap so luong chi tiet trong danh sach chi tiet hoa don: ");
                try
                {
                    _numDetailBill = int.Parse(Console.ReadLine());
                }
                catch
                {
                    _numDetailBill = 0;
                }
            }
            while (!checkNumDetailBill(_numDetailBill));

            _device = new Device[_numDetailBill];
            int typeDevice, typeFan, typeAirConditioner;

            for (int i = 0; i < _numDetailBill; i++)
            {
                Console.WriteLine();
                Console.WriteLine("             -------------------------------");
                Console.WriteLine($"  - Nhap chi tiet cho hoa don thu {i + 1}");

                do
                {
                    Console.ResetColor();
                    Console.Write("  - Chon loai thiet bi dien (1 - quat, 2 - may lanh) : ");
                    try
                    {
                        typeDevice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        typeDevice = 0;
                    }
                }
                while (!checkTypeDevice(typeDevice));

                if (typeDevice == 1)
                {
                    do
                    {
                        Console.ResetColor();
                        Console.Write("     + Chon loai quat (1 - quat dung, 2 - quat hoi nuoc, 3 - quat sac pin) : ");
                        try
                        {
                            typeFan = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            typeFan = 0;
                        }
                    }
                    while (!checkTypeFan(typeFan));

                    if (typeFan == 1)
                        _device[i] = new OriginalFan();
                    else
                    if (typeFan == 2)
                        _device[i] = new SteamFan();
                    else
                        _device[i] = new ElectricFan();
                }
                else
                {
                    do
                    {
                        Console.ResetColor();
                        Console.Write("     + Chon loai may lanh (1 - chieu, 2 - chieu) : ");
                        try
                        {
                            typeAirConditioner = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            typeAirConditioner = 0;
                        }
                    } while (!checkTypeAirConditioner(typeAirConditioner));
                    if (typeAirConditioner == 1)
                        _device[i] = new OneWayAirConditioner();
                    else
                        _device[i] = new TwoWayAirConditioner();
                }
                _device[i].Input();
                totalCost += _device[i].GetSumValue();
            }    
        }

        public void Output()
        {
            Console.WriteLine("\nDanh sach cac chi tiet hoa don:");
            for (int i = 0; i < _numDetailBill; i++)
            {
                Console.WriteLine();
                _device[i].Output();
            }
        }

        public void OutputText()
        {
            StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt");
            sw.WriteLine("\nDanh sach cac chi tiet hoa don:");
            sw.Close();
            for (int i = 0; i < _numDetailBill; i++)
                _device[i].OutputText();            
        }

        private bool checkNumDetailBill(int numDetailBillCheck)
        {
            if (numDetailBillCheck <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=>  So luong chi tiet phai nguyen duong !!!");
                return false;
            }
            else
                return true;
        }

        private bool checkTypeDevice(int typeDeviceCheck)
        {
            if (typeDeviceCheck < 1 || typeDeviceCheck > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  => Chi nhap (1 hoac 2) !!!");
                return false;
            }
            else
                return true;
        }

        private bool checkTypeFan(int typeFanCheck)
        {
            if (typeFanCheck < 1 || typeFanCheck > 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     => Chi nhap (1, 2 hoac 3) !!!");
                return false;
            }
            else
                return true;
        }

        private bool checkTypeAirConditioner(int typeAirConditionerCheck)
        {
            if (typeAirConditionerCheck < 1 || typeAirConditionerCheck > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     => Chi nhap (1 hoac 2) !!!");
                return false;
            }
            else
                return true;
        }
    }
}
