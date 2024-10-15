using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        
        private void HệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanHang bh = new BanHang();
            bh.ShowDialog();
            //this.Hide();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bảoMậtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void SetUserRole(string chucVu)
        {
            if (chucVu == "Nhân Viên")
            {
                //HệThốngToolStripMenuItem.Visible = false;
                quảnLíToolStripMenuItem.Visible = false;
                bánHàngToolStripMenuItem.Visible = false;
                sảnPhẩmToolStripMenuItem.Visible = false;
                tiệnÍchToolStripMenuItem.Visible = false;
                bảoMậtToolStripMenuItem.Visible = false;
                kháchHàngToolStripMenuItem.Visible = false;
                báoCáoToolStripMenuItem.Visible = false;
                hỗTrợToolStripMenuItem.Visible = false;


            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            Progress_Form progress = new Progress_Form();
            progress.StartPosition = FormStartPosition.Manual;
            progress.BackColor = this.BackColor;
            progress.Location = new Point(this.Location.X + (this.Width - progress.Width) / 2, this.Location.Y + (this.Height - progress.Height) / 2);
            progress.ShowDialog();
        }


        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất ?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account_Management ac = new Account_Management();
            ac.ShowDialog();
            //this.Hide();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff_Management staff_Management = new Staff_Management();
            staff_Management.ShowDialog();
        }

        private void quảnLíKháchHàndToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void càiĐặtHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
