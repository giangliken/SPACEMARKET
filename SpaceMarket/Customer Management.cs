using System;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Customer_Management : Form
    {
        public Customer_Management()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Customer_Management_Load(object sender, EventArgs e)
        {

        }
    }
}
