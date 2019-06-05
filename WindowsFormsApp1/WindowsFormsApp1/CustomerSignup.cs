using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CustomerSignup : Form
    {
        string username, emailid, address, account;
        long mobileno;
        DateTime dateofbirth;
        public CustomerSignup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            mobileno = Convert.ToInt64(textBox2.Text);
            emailid = textBox3.Text;
            dateofbirth = dateTimePicker1.Value;
            if (saving.Checked)
            {
                account = saving.Text;
            }
            else if(current.Checked)
            {
                account = current.Text;
            }
            address = textBox4.Text;
            int d=DatabaseConnection.InsertCustomer(username, mobileno, emailid, dateofbirth, account, address);
            if (d == 1)
            {
                MessageBox.Show("customer added successesfuly");
            }
            else
            {
                MessageBox.Show("customer not added");
            }
        }
    }
}
