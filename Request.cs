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
    public partial class Request : Form
    {
        private Control[] req_elems;
        private Control[] req_list_elems;
        private string getDate()
        {
            string[] date = Calendar.SelectionStart.ToString().Split(' ')[0].Split('.');
            return $"{date[0]}-{date[1]}-{date[2]}";
        }

        private void write_suppliers(ComboBox cb)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); cb.Items.Clear();
                string query = "Select distinct on (name_suppl) name_suppl from Supplier ORDER BY (name_suppl)";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    cb.Items.Add(dbDataRecord[0].ToString());
            }
        }
        private void write_tech(ComboBox cb)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); cb.Items.Clear();
                string query = "Select distinct on (name_tech) name_tech from Tech ORDER BY (name_tech)";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    cb.Items.Add(dbDataRecord[0].ToString());
            }
        }

        public Request()
        {
            InitializeComponent();
            cbTable.Items.Add("Заявка");
            cbTable.Items.Add("Заявочная ведомость");
            req_elems = new Control[] { label8, cbSupplier };
            req_list_elems = new Control[] { label9, label10, label11, tbAmounce, cbTech, tbRequest};
            write_suppliers(cbSupplier);
            write_tech(cbTech);
            show();
        }

        private void show()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query1 = "Select idrequest, name_suppl, date_req, date_req_complete " +
                " from Request JOIN Supplier ON supplier_req=IDsupplier ";
                string query2 = "Select name_tech, req_id, amounce_req from Req_list  " +
                " JOIN Tech ON tech_req=IDtech ";
                int fields;
                //1-я таблица - Заявка
                dataGridView1.Rows.Clear(); dataGridView2.Rows.Clear();
                dataGridView1.Columns.Clear(); dataGridView2.Columns.Clear();
                dataGridView1.ColumnCount = fields = 4;
                dataGridView1.Columns[0].HeaderText = "ID заявки"; dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].HeaderText = "Поставщик"; dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Дата заяки"; dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].HeaderText = "Дата выполнения"; dataGridView1.Columns[3].Width = 80;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int ind = 0;
                NpgsqlDataReader reader1 = cmd1.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader1)
                {
                    dataGridView1.RowCount++;
                    for (int col=0;col<fields;col++)
                    {
                        if ((col==2 || col==3) && dbDataRecord[col].ToString().Contains(' '))
                            dataGridView1[col, ind].Value = dbDataRecord[col].ToString().Split(' ')[0];
                        else
                            dataGridView1[col, ind].Value = dbDataRecord[col].ToString();
                    }
                    ind++;
                }
                con.Close(); con.Open();
                //2я таблица - заявочная ведомость
                dataGridView2.ColumnCount = fields = 3;
                dataGridView2.Columns[0].HeaderText = "ID заявки"; dataGridView2.Columns[0].Width = 60;
                dataGridView2.Columns[1].HeaderText = "Техника"; dataGridView2.Columns[1].Width = 100;
                dataGridView2.Columns[2].HeaderText = "Количество"; dataGridView2.Columns[2].Width = 60;
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con);
                ind = 0;
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader2)
                {
                    dataGridView2.RowCount++;
                    dataGridView2[0, ind].Value = dbDataRecord[1].ToString();
                    dataGridView2[1, ind].Value = dbDataRecord[0].ToString();
                    dataGridView2[2, ind].Value = dbDataRecord[2].ToString();                   
                    ind++;
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "";
                if (cbTable.Text.Equals("Заявка"))
                {
                    query = $"Insert into Request(supplier_req, date_req)" +
                        $"VALUES (suppl_number('{cbSupplier.Text}'), '{getDate()}')";
                }
                else if (cbTable.Text.Equals("Заявочная ведомость"))
                {
                    query = "Insert INTO Req_list (tech_req, req_id, amounce_req) "
                    + $"VALUES (tech_number('{cbTech.Text}'),{tbRequest.Text},{tbAmounce.Text})";
                }
                try
                {
                    if (cbTable.Text.Equals(""))
                        throw new Exception("Выберите таблицу!");
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    show();
                } catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "";
                if (cbTable.Text.Equals("Заявка"))
                {
                    query = $"Delete from Request WHERE IDrequest = {dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()}";
                }
                else if (cbTable.Text.Equals("Заявочная ведомость"))
                {
                    query = $"Delete from Req_list WHERE (tech_req=tech_number('{dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString()}') " +
                        $"AND req_id={dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString()}) ";
                }
                try
                {
                    if (cbTable.Text.Equals(""))
                        throw new Exception("Выберите таблицу!");
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); 
                string query = "";
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Request_Load(object sender, EventArgs e)
        {

        }
    }
}
