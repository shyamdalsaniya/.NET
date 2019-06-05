using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public static int id;
        public static string password, type;
        public Login()
        {
            InitializeComponent();
        }
        
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(textBox1.Text);
            password = textBox2.Text;
            if (EmployeeCheck.Checked)
            {
                type = "Employee";
                Deshbord.logemployee = true;
                int check = DatabaseConnection.Logincheck(id, password, "Employee");
                if (check == 0)
                {
                    MessageBox.Show("Login Successful");
                    Mainform mainform = new Mainform();
                    mainform.MdiParent = Deshbord.ActiveForm;
                    mainform.AddData(id, password, "Employee");
                    mainform.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Detail");
                }
            }
            if (ManagerCheck.Checked)
            {
                type = "Manager";
                Deshbord.logmanager = true;
                int check = DatabaseConnection.Logincheck(id, password, "Manager");
                if (check == 0)
                {
                    MessageBox.Show("Login Successful");
                    Mainform mainform = new Mainform();
                    mainform.MdiParent = Deshbord.ActiveForm;
                    mainform.AddData(id, password, "Employee");
                    mainform.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Detail");
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

