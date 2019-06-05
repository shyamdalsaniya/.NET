using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class DatabaseConnection
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\$ GTU $\Sem 6\DNT\practical\Bank Management System\WindowsFormsApp1\WindowsFormsApp1\Database.mdf"";Integrated Security=True");
        public static int Logincheck(int id, string password, string type)
        {
            if (type == "Employee")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Password from Employee where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr1 = cmd.ExecuteReader();
                dr1.Read();
                string pass = dr1["Password"].ToString();
                dr1.Close();
                con.Close();
                if (pass.Equals(password))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Password from Manager where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr1 = cmd.ExecuteReader();
                dr1.Read();
                string pass = dr1["Password"].ToString();
                dr1.Close();
                con.Close();
                if (pass.Equals(password))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
        public static SqlDataReader AddInDatabase(int id, string password, string position)
        {
            if (position == "Employee")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee where ( Id=@id AND Password=@password )", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return dr;

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Manager where ( Id=@id AND Password=@password )", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return dr;
            }
        }
        public static int InsertManager(string username, string password, long mobileno, string emailid, DateTime dateofbirth, long salary, string address)
        {
            con.Open();
            SqlCommand insertmanager = new SqlCommand("insert into Manager values (@username,@password,@mobileno,@emailid,@dateofbirth,@salary,@address)", con);
            insertmanager.Parameters.AddWithValue("@username", username);
            insertmanager.Parameters.AddWithValue("@password", password);
            insertmanager.Parameters.AddWithValue("@mobileno", mobileno);
            insertmanager.Parameters.AddWithValue("@emailid", emailid);
            insertmanager.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            insertmanager.Parameters.AddWithValue("@salary", salary);
            insertmanager.Parameters.AddWithValue("@address", address);
            if (insertmanager.ExecuteNonQuery() == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }
        public static int InsertEmployee(string username, string password, long mobileno, string emailid, DateTime dateofbirth, long salary, string address)
        {
            con.Open();
            SqlCommand insertemployee = new SqlCommand("insert into Employee values (@username,@password,@mobileno,@emailid,@dateofbirth,@salary,@address)", con);
            insertemployee.Parameters.AddWithValue("@username", username);
            insertemployee.Parameters.AddWithValue("@password", password);
            insertemployee.Parameters.AddWithValue("@mobileno", mobileno);
            insertemployee.Parameters.AddWithValue("@emailid", emailid);
            insertemployee.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            insertemployee.Parameters.AddWithValue("@salary", salary);
            insertemployee.Parameters.AddWithValue("@address", address);
            if (insertemployee.ExecuteNonQuery() == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }
        public static int InsertCustomer(string username, long mobileno, string emailid, DateTime dateofbirth, string accounttype, string address)
        {
            con.Open();
            SqlCommand insertcustomer = new SqlCommand("insert into Customer values (@username,@mobileno,@emailid,@dateofbirth,@accounttype,@address,@amount)", con);
            insertcustomer.Parameters.AddWithValue("@username", username);
            insertcustomer.Parameters.AddWithValue("@mobileno", mobileno);
            insertcustomer.Parameters.AddWithValue("@emailid", emailid);
            insertcustomer.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            insertcustomer.Parameters.AddWithValue("@accounttype", accounttype);
            insertcustomer.Parameters.AddWithValue("@address", address);
            insertcustomer.Parameters.AddWithValue("@amount", 0);
            if (insertcustomer.ExecuteNonQuery()==1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
            
        }
        public static int Deposit(int accountno, float amount)
        {
            float a;
            con.Open();
            SqlCommand cd = new SqlCommand("select amount from Customer where (accountno=@accountno)", con);
            cd.Parameters.AddWithValue("@accountno", accountno);
            SqlDataReader dr = cd.ExecuteReader();
            dr.Read();
            string s = dr["amount"].ToString();
            a = (float)Convert.ToDouble(s);
            a = a + amount;

            dr.Close();
            SqlCommand de = new SqlCommand("update Customer set  amount=@amount  where accountno=@accountno ", con);
            de.Parameters.AddWithValue("@amount", a);
            de.Parameters.AddWithValue("@accountno", accountno);
            int check = de.ExecuteNonQuery();

            SqlCommand dh = new SqlCommand("insert into History values(@accountno,@date,@amount,@accounttype,@remainamount)", con);
            dh.Parameters.AddWithValue("@accountno", accountno);
            dh.Parameters.AddWithValue("@date", DateTime.Now);
            dh.Parameters.AddWithValue("@amount", amount);
            dh.Parameters.AddWithValue("@accounttype", "Deposit");
            dh.Parameters.AddWithValue("@remainamount", a);
            dh.ExecuteNonQuery();
            con.Close();
            return check;
        }

        public static int Withdraw(int accountno, float amount)
        {
            float a;
            con.Open();
            SqlCommand cd = new SqlCommand("select amount from Customer where (accountno=@accountno)", con);
            cd.Parameters.AddWithValue("@accountno", accountno);
            SqlDataReader dr = cd.ExecuteReader();
            dr.Read();
            string s = dr["amount"].ToString();
            a = (float)Convert.ToDouble(s);
            if (a <= 0)
            {
                return 1;
            }
            a = a - amount;

            dr.Close();
            SqlCommand de = new SqlCommand("update Customer set  amount=@amount  where accountno=@accountno ", con);
            de.Parameters.AddWithValue("@amount", a);
            de.Parameters.AddWithValue("@accountno", accountno);
            de.ExecuteNonQuery();
            SqlCommand dh = new SqlCommand("insert into History values(@accountno,@date,@amount,@accounttype,@remainamount)", con);
            dh.Parameters.AddWithValue("@accountno", accountno);
            dh.Parameters.AddWithValue("@date", DateTime.Now);
            dh.Parameters.AddWithValue("@amount", amount);
            dh.Parameters.AddWithValue("@accounttype", "Withdraw");
            dh.Parameters.AddWithValue("@remainamount", a);
            dh.ExecuteNonQuery();
            con.Close();
            return 0;
        }

        public static SqlDataReader AddData(int id, string password, string ta)
        {
            if (ta == "Employee")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee where ( Id=@id AND password=@password )", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return dr;
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Manager where ( Id=@id AND password=@password )", con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return dr;
            }
        }
        public static DataSet Searchh(int id)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from History where ( Id=" + id + " )", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "History");
            return ds;
        }
    }
}