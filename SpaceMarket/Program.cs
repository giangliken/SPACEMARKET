﻿using System;
using System.Windows.Forms;

namespace SpaceMarket
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new BanHang());
            //Application.Run(new Main());
            //Application.Run(new Account_Management());
            //Application.Run(new Staff_Management());    
            //Application.Run(new Progress_Form());
            //Application.Run(new Customer_Management());
            //Application.Run(new DanhMucSanPham());
        }
    }
}
