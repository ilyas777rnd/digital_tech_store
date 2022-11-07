using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;

namespace Ulmart
{
    public partial class tableClients : Form
    {
        public tableClients()
        {
            InitializeComponent();
            show();
            cbField.Items.Add("Организация");
            cbField.Items.Add("Адрес");
            cbField.Items.Add("Телефон");           
        }

        private void show()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].HeaderText = "Телефон"; dataGridView1.Columns[1].Width = 110;
                dataGridView1.Columns[2].HeaderText = "Адрес"; dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].HeaderText = "Организация"; dataGridView1.Columns[3].Width = 150;
                string query = "Select * from Purchaser";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = cmd.ExecuteReader(); int ind = 0;
                foreach (DbDataRecord dbDataRecord in reader)
                {
                    dataGridView1.RowCount++;
                    dataGridView1[0, ind].Value = dbDataRecord[0].ToString();
                    dataGridView1[1, ind].Value = dbDataRecord[1].ToString();
                    dataGridView1[2, ind].Value = dbDataRecord[2].ToString();
                    dataGridView1[3, ind].Value = dbDataRecord[3].ToString();
                    ind++;
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                if (tbPassword.Text.Equals("") || tbPhone.Text.Equals(""))
                {
                    MessageBox.Show("Введите данные!");
                    return;
                }
                string query = " INSERT into Purchaser(phone_purch,addr_purch,company,passwor) " +
                    $" VALUES ('{tbPhone.Text}','{tbAddress.Text}','{tbCompany.Text}','{cod.EncodeString(tbPassword.Text)}') ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteNonQuery();
                show(); tbPassword.Text = "";
                //MessageBox.Show("Готово!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open(); string id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    string query = " Delete from Purchaser WHERE IDpurch=" + id;
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    show();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            show();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open(); string query1 = "UPDATE Purchaser SET ";
                    switch (cbField.Text)
                    {
                        case "Телефон":
                            query1 += $" phone_purch='{cbNewValue.Text}' ";
                            break;
                        case "Адрес":
                            query1 += $" addr_purch='{cbNewValue.Text}' ";
                            break;
                        case "Организация":
                            query1 += $" company='{cbNewValue.Text}' ";
                            break;
                    }
                    query1 += " WHERE IDpurch=" + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    NpgsqlCommand cmd = new NpgsqlCommand(query1, con);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show(query1);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                show();
            }
        }
    }
}
