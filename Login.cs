using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace Ulmart
{
    public partial class Login : Form
    {
        public static string empl_id { get; private set; }
        public static string purch_id { get; private set; }
        private static string connectionString =
        "Server=localhost;Port=7777;User ID=postgres;Password=0000;Database=ulmart_f;";
        
        public Login()
        {
            InitializeComponent();
            passw.UseSystemPasswordChar = true;
        }

        public static NpgsqlConnection getConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        private void enter_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                empl_id = "";
                if ((log.Text.Equals("Admin") || log.Text.Equals("admin")) && passw.Text.Equals("7777"))
                {
                    AdminForm admin = new AdminForm();
                    admin.Show();
                    return;
                }
                con.Open(); string password = "";
                if (log.Text.Substring(0, 1).Equals("C"))
                {
                    purch_id = log.Text.Substring(1, log.Text.Length - 1);
                    string cl_query = "Select passwor from Purchaser WHERE IDpurch=" + purch_id;
                    NpgsqlCommand cl_Command = new NpgsqlCommand(cl_query, con);
                    NpgsqlDataReader cl_DataReader = cl_Command.ExecuteReader();
                    foreach (DbDataRecord dbDataRecord in cl_DataReader)
                    {
                        password = cod.DecodeString(dbDataRecord[0].ToString());
                    }
                    if (password.Equals(passw.Text))
                    {
                        ClientForm client = new ClientForm();
                        client.Show();
                    }
                    else MessageBox.Show("Неверный логин или пароль!");
                    return;
                }
                empl_id = log.Text.Substring(1, log.Text.Length - 1);
                string query = "Select passwor from Employee WHERE IDemploy=" + empl_id;
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                  foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                  {
                    password = cod.DecodeString(dbDataRecord[0].ToString());
                  }
                if (log.Text.Substring(0, 1).Equals("M"))
                {//M3 bbbb
                    if (password.Equals(passw.Text))
                    {
                        ManagerForm manager = new ManagerForm();
                        manager.Show();
                    }
                    else MessageBox.Show("Неверный логин или пароль!");
                }
                else if (log.Text.Substring(0, 1).Equals("O"))
                {//O2 aaaa
                    if (password.Equals(passw.Text))
                    {
                        OperatorForm oper = new OperatorForm();
                        oper.Show();
                    }
                    else MessageBox.Show("Неверный логин или пароль!");
                }
                else MessageBox.Show("Ошибка авторизации");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                passw.UseSystemPasswordChar = false;
            else passw.UseSystemPasswordChar = true;
        }
    }
}
