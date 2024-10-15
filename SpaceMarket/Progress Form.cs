using System;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Progress_Form : Form
    {
        public Progress_Form()
        {
            InitializeComponent();
        }

        private void Progress_Form_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
                label1.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop(); // Dừng timer
                this.Close(); // Đóng biểu mẫu
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
