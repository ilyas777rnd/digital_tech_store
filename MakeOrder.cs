using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;

namespace Ulmart
{
    public partial class makeOrder : Form
    {
        private string ord_id;
        private bool is_done;
        private Control[] deliv_elems;

        private string getDate()
        {
            string[] date = Calendar.SelectionStart.ToString().Split(' ')[0].Split('.');
            return $"{date[0]}-{date[1]}-{date[2]}";
        }

        private void write_categories(ComboBox cb)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); cb.Items.Clear();
                string query = "Select distinct on (name_cat) name_cat from Category ORDER BY (name_cat)";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    cb.Items.Add(dbDataRecord[0].ToString());
            }
        }

        private void update_Catalog()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = "Select idtech, name_tech, name_cat, ret_price, amount_tech, warranty, len, width, height    "
                + " from (Tech JOIN Category ON category_tech=IDcat) "
                + " WHERE (amount_tech>0) "; int fields = 0; int ind = 0;
                if (!tbName.Text.Equals(""))
                    query += $" AND name_tech LIKE '%{tbName.Text}%'  ";
                if (!cbCategory.Text.Equals(""))
                    query += $" AND name_cat = '{cbCategory.Text}'  ";
                if (!priceOT.Text.Equals(""))
                    query += $" AND price>={priceOT.Text} ";
                if (!priceDO.Text.Equals(""))
                    query += $" AND price<={priceDO.Text} ";
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = fields = 9;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].HeaderText = "Название"; dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "Категория"; dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].HeaderText = "Цена"; dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Количество"; dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].HeaderText = "Гарантия (мес)"; dataGridView1.Columns[5].Width = 50;
                dataGridView1.Columns[6].HeaderText = "Длина"; dataGridView1.Columns[6].Width = 60;
                dataGridView1.Columns[7].HeaderText = "Ширина"; dataGridView1.Columns[7].Width = 60;
                dataGridView1.Columns[8].HeaderText = "Высота"; dataGridView1.Columns[8].Width = 60;

                NpgsqlCommand find = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    dataGridView1.RowCount++;
                    for (int i = 0; i < fields; i++)
                        dataGridView1[i, ind].Value = dbDataRecord[i].ToString();
                    ind++;
                }
            }
        }

        private void finally_order(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                if (is_done)
                {
                    con.Open(); //Поставить сумму и статус заказа
                    string query = $"Select summ_ord({ord_id})"; int summ=0;
                    NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                    NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        summ = Convert.ToInt32(dbDataRecord[0].ToString());
                    }
                    con.Close(); con.Open();
                    if (chbDelivery.Checked)
                    {
                        string vol = "";                 
                            vol = $"Select summ_vloume({ord_id})";
                            NpgsqlCommand vol_cmd = new NpgsqlCommand(query, con);
                            NpgsqlDataReader vol_reader = vol_cmd.ExecuteReader();
                        foreach (DbDataRecord dbDataRecord in vol_reader)
                            vol = dbDataRecord[0].ToString();
                        con.Close(); con.Open();
                        string deliv_query = $"INSERT INTO Delivery (date_deliv, time_deliv, status_deliv, addr_deliv, volume)"
                            + $"VALUES ('{getDate()}','{cbTimeH.Text}:{cbTimeM.Text}','Не назначена','{tbAddress.Text}',summ_vloume({ord_id}))";
                        NpgsqlCommand deliv_cmd = new NpgsqlCommand(deliv_query, con);
                        deliv_cmd.ExecuteNonQuery();
                        con.Close(); con.Open();
                        query = $"UPDATE Orderr SET cost_ord={summ}, status_ord='Обрабатывается', delivery_ord=last_deliv() "
                    + $" WHERE IDorder={ord_id}";
                    }
                    else query = $"UPDATE Orderr SET cost_ord={summ}, status_ord='Обрабатывается'  "
                    +$" WHERE IDorder={ord_id}";
                    NpgsqlCommand cmd2 = new NpgsqlCommand(query, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show($"Номер вашего заказа: {ord_id}, сумма: {summ} руб.");
                    return;
                }
                else if (!is_done)
                {
                    cancel();
                }
            }
        }
        private string createOrdNumber()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = $"INSERT Into Orderr (cost_ord, status_ord, date_ord, time_ord, purch_ord) VALUES (0,'В корзине', now(), now(), {Login.purch_id}) ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteNonQuery(); string ORD = "";
                con.Close(); con.Open();//Теперь находим номер заказа
                query = "Select MAX(IDorder) from Orderr";
                NpgsqlCommand find = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    ORD = dbDataRecord[0].ToString();
                }
                if (ORD.Equals("")) throw new Exception();
                return ORD;
            }
        }
        private void cancel()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = $"Delete from Orderr WHERE IDorder={ord_id}";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public makeOrder()
        {
            InitializeComponent();
            write_categories(cbCategory);
            update_Catalog();
            this.FormClosed += finally_order;
            is_done = false;
            ord_id = createOrdNumber();
            deliv_elems = new Control[] { Calendar, label6, label7, label8, tbAddress, cbTimeH, cbTimeM };
            //Заполняем ComboBox'ы времени
            for (int i = 0; i < 24; i++)
            {
                if (i < 10) cbTimeH.Items.Add("0" + i);
                else cbTimeH.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                if (i < 10) cbTimeM.Items.Add("0" + i);
                else cbTimeM.Items.Add(i);
            }
            foreach (Control item in deliv_elems)
            {
                item.Visible = false;
            }
        }

        private void chbDelivery_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control item in deliv_elems)
            {
                if (item.Visible == false) item.Visible = true;
                else item.Visible = false;
            }
        }

        private void finish_ord_Click(object sender, EventArgs e)
        {
            is_done = true;
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {            
            update_Catalog();
        }

        private void updateBasket()
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

        private void addInBasket_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open();
                    if (dataGridView1.CurrentCell.Value == null || dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString().Equals("")) return;
                    string product_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    //if (product_id.Equals("")) return; 
                    int amounce;
                    if (!int.TryParse(cbAmounce.Text, out amounce) || amounce < 1)
                        throw new Exception("Введите количество!");
                    if (Convert.ToInt32(cbAmounce.Text) > Convert.ToInt32(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString()))
                    {
                        throw new Exception("Такого количества товара на складе нет!");
                    }

                    string query = $"INSERT INTO Ord_list VALUES ({product_id},{ord_id},{amounce}) ";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    updateBasket();
                } 
                catch (NullReferenceException)
                {
                    MessageBox.Show("Ошибка! Выберите строку в таблице техники!");
                }
                catch (Exception ex)
                {
                        MessageBox.Show(ex.Message);                     
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //cbAmounce.Items.Clear();
            //int amounce = Convert.ToInt32(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            //for (int i = 1; i <= amounce; i++)
            //{
            //    cbAmounce.Items.Add(i);
            //}
        }

        private void deleteFromBasket_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                string product_id = dgvBasket[0, dgvBasket.CurrentCell.RowIndex].Value.ToString();
                string amounce = dgvBasket[4, dgvBasket.CurrentCell.RowIndex].Value.ToString();
                string query = $"Delete from Ord_list WHERE tech_ord={product_id}  AND order_id={ord_id} ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteNonQuery();
                updateBasket();
            }
        }
    }
}
