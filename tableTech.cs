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
    public partial class tableTech : Form
    {
        private static string tech_query = "Select idtech,name_tech,name_cat,amount_tech,warranty,def_price,ret_price,name_suppl,height,width,len from " +
        " (Tech JOIN Supplier ON supplier_tech=IDsupplier)  JOIN Category ON category_tech=IDcat " +
        " ORDER BY name_tech ";
        private static string cat_query = "Select * from Category ORDER BY name_cat";
        private Control[] tech_attributes;
        private void take_away_or_show()
        {
            foreach (Control item in tech_attributes)
            {
                if (item.Visible == true) item.Visible = false;
                else if (item.Visible == false) item.Visible = true;
            }
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
        private void show(string query)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                Console.WriteLine(query);
                con.Open(); int fields = 0;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                if (cbTable.Text.Equals("Техника"))
                {
                    dataGridView1.ColumnCount = fields = 11;
                    dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 35;
                    dataGridView1.Columns[1].HeaderText = "Наименовение"; dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[2].HeaderText = "Категория"; dataGridView1.Columns[2].Width = 80;
                    dataGridView1.Columns[3].HeaderText = "Кол-во"; dataGridView1.Columns[3].Width = 50;
                    dataGridView1.Columns[4].HeaderText = "Гарантия (мес)"; dataGridView1.Columns[4].Width = 55;
                    dataGridView1.Columns[5].HeaderText = "Цена(руб) поставщика"; dataGridView1.Columns[5].Width = 70;
                    dataGridView1.Columns[6].HeaderText = "Розничная цена(руб)"; dataGridView1.Columns[6].Width = 70;
                    dataGridView1.Columns[7].HeaderText = "Поставщик"; dataGridView1.Columns[7].Width = 120;
                    dataGridView1.Columns[8].HeaderText = "Высота (мм)"; dataGridView1.Columns[8].Width = 50;
                    dataGridView1.Columns[9].HeaderText = "Ширина (мм)"; dataGridView1.Columns[9].Width = 50;
                    dataGridView1.Columns[10].HeaderText = "Длина (мм)"; dataGridView1.Columns[10].Width = 50;
                }
                else if (cbTable.Text.Equals("Категория"))
                {
                    dataGridView1.ColumnCount = fields = 2;
                    dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[1].HeaderText = "Наименование"; dataGridView1.Columns[1].Width = 120;
                }
                NpgsqlCommand cmd1 = new NpgsqlCommand(query, con);
                int ind = 0;
                NpgsqlDataReader reader1 = cmd1.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader1)
                {
                    dataGridView1.RowCount++;
                    for (int i = 0; i < fields; i++)
                        dataGridView1[i, ind].Value = dbDataRecord[i].ToString();
                    ind++;
                }
            }
        }
        public tableTech()
        {
            InitializeComponent();
            cbTable.Items.Add("Категория");
            cbTable.Items.Add("Техника");
            tech_attributes = new Control[] { cbCat, tbWarranty, tbDefPrice, tbRetPrice,
            cbSupplier, tbLength, tbWidth, tbHeight, label1, label3, label4, label5, label8,
            label10,label11,label12};
            cbTable.Text = "Техника";
            write_categories(cbCat);
            write_suppliers(cbSupplier);           
        }

        private void Add_Click(object sender, EventArgs e)
        { 
             using (NpgsqlConnection con = Login.getConnection())
             {
                con.Open();
                try
                {
                    if (cbTable.Text.Equals("Техника"))
                    {
                        string query = " Insert INTO Tech  " +
                        $" (name_tech, category_tech, amount_tech, warranty, def_price, ret_price, supplier_tech, height, width, len) " +
                        $" VALUES ('{tbName.Text}', cat_number('{cbCat.Text}'),0,{tbWarranty.Text},{tbDefPrice.Text},{tbRetPrice.Text},suppl_number('{cbSupplier.Text}'),{tbHeight.Text},{tbWidth.Text},{tbLength.Text}) ";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        show(tech_query);
                    }
                    else if (cbTable.Text.Equals("Категория"))
                    {
                        if (tbName.Text.Equals(""))
                        {
                            MessageBox.Show("Введите данные!");
                            return;
                        }
                        string query = " INSERT into Category(name_cat) " +
                            $" VALUES ('{tbName.Text}') ";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        write_categories(cbCat);
                        show(cat_query);
                    }
                } catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open(); string id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    if (cbTable.Text.Equals("Техника"))
                    {
                        string query = " Delete from Tech WHERE IDtech=" + id;
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        show(tech_query);
                    }
                    else if (cbTable.Text.Equals("Категория"))
                    {
                        string query = " Delete from Category WHERE IDcat=" + id;
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        show(cat_query);
                    }    
                    
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                string qeury = "UPDATE ";
                try
                {
                    con.Open(); string id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    if (cbTable.Text.Equals("Техника"))
                    {
                        qeury += " Tech SET ";
                        switch (cbField.Text)
                        {
                            case "Наименование":
                                qeury += $" name_tech='{cbNewValue.Text}' ";
                                break;
                            case "Категория":
                                qeury += $" category_tech=cat_number('{cbNewValue.Text}') ";
                                break;
                            case "Гарантия":
                                qeury += $" warranty={cbNewValue.Text} ";
                                break;
                            case "Розничная цена":
                                qeury += $" ret_price={cbNewValue.Text} ";
                                break;
                            case "Цена поставщика":
                                qeury += $" def_price={cbNewValue.Text} ";
                                break;
                            case "Поставщик":
                                qeury += $" supplier_tech=suppl_number('{cbNewValue.Text}') ";
                                break;
                            case "Длина":
                                qeury += $" len={cbNewValue.Text} ";
                                break;
                            case "Ширина":
                                qeury += $" width={cbNewValue.Text} ";
                                break;
                            case "Высота":
                                qeury += $" height={cbNewValue.Text} ";
                                break;
                        }
                        qeury += " WHERE IDtech=" + id;
                    }
                    else if (cbTable.Text.Equals("Категория"))
                    {
                        qeury += " Category SET ";
                        switch (cbField.Text)
                        {
                            case "Наименование":
                                qeury += $" name_cat='{cbNewValue.Text}'  ";
                                break;
                        }
                        qeury += " WHERE IDcat= " + id;
                    }
                    NpgsqlCommand cmd = new NpgsqlCommand(qeury, con);
                    cmd.ExecuteNonQuery();
                    if (cbTable.Text.Equals("Техника")) show(tech_query);
                    else show(cat_query);
                }
                catch (Exception ex) { MessageBox.Show(qeury); }
            }
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbField.Items.Clear();
            if (cbTable.Text.Equals("Категория"))
            {
                cbField.Items.Add("Наименование");
                show(cat_query);
            }
            else if (cbTable.Text.Equals("Техника"))
            {
                cbField.Items.Add("Наименование");
                cbField.Items.Add("Категория");
                cbField.Items.Add("Гарантия");
                cbField.Items.Add("Розничная цена");
                cbField.Items.Add("Цена поставщика");
                cbField.Items.Add("Поставщик");
                cbField.Items.Add("Длина");
                cbField.Items.Add("Ширина");
                cbField.Items.Add("Высота");
                show(tech_query);
            }
            take_away_or_show();
        }

        private void cbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNewValue.Items.Clear();
            if (cbField.Text.Equals("Категория"))
                write_categories(cbNewValue);
            if (cbField.Text.Equals("Поставщик"))
                write_suppliers(cbNewValue);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string query = "Select idtech,name_tech,name_cat,amount_tech,warranty,def_price,ret_price,name_suppl,height,width,len ";
            query += " from  (Tech JOIN Supplier ON supplier_tech=IDsupplier)  JOIN Category ON category_tech=IDcat ";
            query += $" WHERE name_tech LIKE '%{tbSearch.Text}%'  ";
            query += " ORDER BY name_tech ";
            show(query);
        }
    }
}
