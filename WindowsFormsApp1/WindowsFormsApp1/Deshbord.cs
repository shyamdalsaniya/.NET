using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Deshbord : Form
    {
        public static bool logemployee = false, logmanager = false;
        public Deshbord()
        {
            InitializeComponent();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.MdiParent = this;
            login.Show();
        }
        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logmanager == true || logemployee == true)
            {
                CustomerSignup csignup = new CustomerSignup();
                csignup.MdiParent = this;
                csignup.Show();
            }
            else
            {
                MessageBox.Show("Please login first");
            }

        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logmanager == true || logemployee == true)
            {
                EmployeeSignup esignup = new EmployeeSignup();
                esignup.MdiParent = this;
                esignup.Show();
            }
            else
            {
                MessageBox.Show("Please login first");
                
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(logemployee == true || logmanager == true)
            {
                MessageBox.Show("you have been logout");
            }
            logemployee = false;
            logmanager = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logemployee = false; logmanager = false;
            this.Close();
        }

        private void deshbordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(logmanager == true || logemployee == true)
            {
                Mainform mainform = new Mainform();
                mainform.MdiParent = this;
                mainform.AddData(Login.id, Login.password, Login.type);
                mainform.Show();
                }
                else
                {
                    MessageBox.Show("Please login first");
            }
        }

        private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logmanager == true || logemployee == true)
            {
                AccountHistory history = new AccountHistory();
                history.MdiParent = this;
                history.Show();
            }
            else
            {
                MessageBox.Show("Please login first");
            }
        }
        private void addManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logmanager == true || logemployee == true)
            {
                ManagerSignup msignup = new ManagerSignup();
                msignup.MdiParent = this;
                msignup.Show();
            }
            else
            {
                MessageBox.Show("Please login first");
            }
        }
    }
}
