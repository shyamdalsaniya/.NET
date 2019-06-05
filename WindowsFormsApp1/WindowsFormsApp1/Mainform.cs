using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }
        public void AddData(int id, string pass, string position)
        {
            SqlDataReader dr = DatabaseConnection.AddInDatabase(id, pass, position);
            label3.Text = dr["username"].ToString();
            label7.Text = dr["emailid"].ToString();
            label11.Text = dr["address"].ToString();
            label8.Text = dr["mobileno"].ToString();
            label4.Text = position;
            dr.Close();
            DatabaseConnection.con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int accountno = Convert.ToInt32(textBox3.Text);
            double amount = Convert.ToDouble(textBox4.Text);
            int s = DatabaseConnection.Deposit(accountno, (float)amount);
            if (s == 1)
            {
                MessageBox.Show("Your transaction is successful");
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("There are some issue in transaction");
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int accountno = Convert.ToInt32(textBox1.Text);
            double amount = Convert.ToDouble(textBox2.Text);
            int s = DatabaseConnection.Withdraw(accountno, (float)amount);
            if (s == 1)
            {
                MessageBox.Show("Your Balance is low");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Your transaction is successful");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}

