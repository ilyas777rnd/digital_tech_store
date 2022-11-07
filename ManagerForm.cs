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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += output;
        }

        private void btClients_Click(object sender, EventArgs e)
        {
            tableClients clients = new tableClients();
            clients.Show();
        }

        private void btSupply_Click(object sender, EventArgs e)
        {
            Supply supply = new Supply();
            supply.Show();
        }

        private void btRequest_Click(object sender, EventArgs e)
        {
            Request request = new Request();
            request.Show();
        }

        private void updateBasket(string ord_id)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                dgvBasket.Rows.Clear(); dgvBasket.Columns.Clear(); int fields = 0;
                dgvBasket.ColumnCount = fields = 4;
                dgvBasket.Columns[0].HeaderText = "ID заказа"; dgvBasket.Columns[0].Width = 60;
                dgvBasket.Columns[1].HeaderText = "ID товара"; dgvBasket.Columns[1].Width = 60;
                dgvBasket.Columns[2].HeaderText = "Наименование товара"; dgvBasket.Columns[2].Width = 100;
                dgvBasket.Columns[3].HeaderText = "Кол-во товара"; dgvBasket.Columns[3].Width = 70;
                string query = "Select order_id, tech_ord , name_tech, amounce_order from "
                + " (Ord_list JOIN Tech ON Ord_list.tech_ord=IDtech) "
                    + $" WHERE order_id={ord_id}"; int ind = 0;
                NpgsqlCommand find = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    dgvBasket.RowCount++;
                    for (int i = 0; i < fields; i++)
                        dgvBasket[i, ind].Value = dbDataRecord[i].ToString();
                    ind++;
                }
            }
        }
        private void output(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                lbDelivery.Items.Clear();
                string ord_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                updateBasket(ord_id);
                string deliv = dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                if (!deliv.Equals("Нет"))
                {
                    con.Open();
                    string query = $"Select * from Delivery WHERE iddeliv = {deliv}";
                    NpgsqlCommand find = new NpgsqlCommand(query, con);
                    NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        lbDelivery.Items.Add(dbDataRecord[2].ToString().Split(' ')[0] + ",\t в " +
                                             dbDataRecord[3].ToString().Split('.')[0] + ",\t Статаус: " +
                                             dbDataRecord[4].ToString() + ",\t Адрес: " +
                                             dbDataRecord[5].ToString() + ",\t Объем: " +
                                             dbDataRecord[6].ToString() + " мм. куб.");
                    }

                }
            }
        }

        private void show_my_orders()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = "Select idorder,cost_ord,date_ord,time_ord,status_ord,delivery_ord from Orderr  " +
            $"  WHERE status_ord<>'В корзине' AND cost_ord>0 AND (employee_ord={Login.empl_id} OR employee_ord IS NULL) ORDER BY date_ord DESC ";
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear(); int fields = 6;
                dataGridView1.ColumnCount = fields;
                dataGridView1.Columns[0].HeaderText = "ID заказа"; dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Стоимость"; dataGridView1.Columns[1].Width = 60;
                dataGridView1.Columns[2].HeaderText = "Дата заказа"; dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].HeaderText = "Время заказа"; dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[4].HeaderText = "Статус заказа"; dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Доставка"; dataGridView1.Columns[5].Width = 60;
                NpgsqlCommand find = new NpgsqlCommand(query, con); int ind = 0;
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    dataGridView1.RowCount++;
                    dataGridView1[0, ind].Value = dbDataRecord[0].ToString();
                    dataGridView1[1, ind].Value = dbDataRecord[1].ToString();
                    dataGridView1[2, ind].Value = dbDataRecord[2].ToString().Split(' ')[0];
                    dataGridView1[3, ind].Value = dbDataRecord[3].ToString().Split('.')[0];
                    dataGridView1[4, ind].Value = dbDataRecord[4].ToString();
                    if (!dbDataRecord[5].ToString().Equals(""))
                        dataGridView1[5, ind].Value = dbDataRecord[5].ToString();
                    else
                        dataGridView1[5, ind].Value = "Нет";
                    ind++;
                }
            }
        }

        private void ShowOrders_Click(object sender, EventArgs e)
        {
            show_my_orders();
        }

        private void IsDone_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Выберите строку в таблице заказов (таблица слева)!");
                return;
            }
            string ord_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = $"UPDATE Orderr SET status_ord='Выдан' WHERE idorder={ord_id}";
                new NpgsqlCommand(query, con).ExecuteNonQuery();
            }
            show_my_orders();
        }

        private void IsReady_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Выберите строку в таблице заказов (таблица слева)!");
                return;
            }
            string ord_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = $"UPDATE Orderr SET status_ord='Готов к выдаче' WHERE idorder={ord_id}";
                new NpgsqlCommand(query, con).ExecuteNonQuery();
            }
            show_my_orders();
        }
    }
}
