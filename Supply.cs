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
    public partial class Supply : Form
    {
        private Control[] supplier_elems;
        private Control[] supply_elems;
        private Control[] airbill_elems;
        private void updateTables()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query1 = "Select * from Supplier";
                string query2 = "Select IDsupply,name_suppl,date_supply from Supply JOIN Supplier ON supplier_supply=IDsupplier ORDER BY date_supply DESC";
                string query3 = "Select IDairbill,IDTech,name_tech,name_suppl,amounce_airbill,supply_airbill from  " +
                " ((Airbill JOIN Tech ON tech_airbill=IDTech) JOIN Supply ON supply_airbill=IDsupply) " +
                " JOIN Supplier ON supplier_supply=IDsupplier ORDER BY  IDairbill DESC";
                int fields;
                //1-я таблица - Поставщики
                dataGridView1.Rows.Clear(); dataGridView2.Rows.Clear(); dataGridView3.Rows.Clear();
                dataGridView1.Columns.Clear(); dataGridView2.Columns.Clear(); dataGridView3.Columns.Clear();
                dataGridView1.ColumnCount = fields = 2;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].HeaderText = "Наименовение"; dataGridView1.Columns[1].Width = 120;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int ind = 0;
                NpgsqlDataReader reader1 = cmd1.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader1)
                {
                    dataGridView1.RowCount++;
                    for (int i = 0; i < fields; i++)
                        dataGridView1[i, ind].Value = dbDataRecord[i].ToString();
                    ind++;
                }
                con.Close(); con.Open();
                //2-я таблица - Поставки
                dataGridView2.ColumnCount = fields = 3;
                dataGridView2.Columns[0].HeaderText = "ID"; dataGridView2.Columns[0].Width = 30;
                dataGridView2.Columns[1].HeaderText = "Поставщик"; dataGridView2.Columns[1].Width = 120;
                dataGridView2.Columns[2].HeaderText = "Дата"; dataGridView2.Columns[2].Width = 70;
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con);
                ind = 0;
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader2)
                {
                    dataGridView2.RowCount++;
                    for (int i = 0; i < fields; i++)
                    {
                        if (i != 2)
                            dataGridView2[i, ind].Value = dbDataRecord[i].ToString();
                        else
                            dataGridView2[2, ind].Value = dbDataRecord[2].ToString().Split(' ')[0];
                    }
                    ind++;
                }
                con.Close(); con.Open();
                //3-я таблица - Накладная
                dataGridView3.ColumnCount = fields = 6;
                dataGridView3.Columns[0].HeaderText = "ID накладной"; dataGridView3.Columns[0].Width = 60;
                dataGridView3.Columns[1].HeaderText = "ID товара"; dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].HeaderText = "Товар"; dataGridView3.Columns[2].Width = 120;
                dataGridView3.Columns[3].HeaderText = "Поставщик"; dataGridView3.Columns[3].Width = 120;
                dataGridView3.Columns[4].HeaderText = "Количество"; dataGridView3.Columns[4].Width = 70;
                dataGridView3.Columns[5].HeaderText = "ID поставки"; dataGridView3.Columns[5].Width = 60;
                NpgsqlCommand cmd3 = new NpgsqlCommand(query3, con);
                ind = 0;
                NpgsqlDataReader reader3 = cmd3.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader3)
                {
                    dataGridView3.RowCount++;
                    for (int i = 0; i < fields; i++)
                    {
                        Console.WriteLine(dbDataRecord[i].ToString());
                        dataGridView3[i, ind].Value = dbDataRecord[i].ToString();
                    }
                    ind++;
                }
            }
        }

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
        public Supply()
        {
            InitializeComponent();
            updateTables();
            cbTable.Items.Add("Поставщик");
            cbTable.Items.Add("Поставка");
            cbTable.Items.Add("Накладная");
            write_tech(cbTech);
            write_suppliers(cbSupplier);
            supplier_elems = new Control[] { tbName, label5 };
            supply_elems = new Control[] { cbSupplier, Calendar, label8 };//tbSupply,label11
            airbill_elems = new Control[] { tbAmounce, cbTech, label9, label10 };
            foreach (Control item in supplier_elems.Union(supply_elems).Union(airbill_elems))
            {
                item.Visible = false;
            }
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "";
                try
                {
                    if (cbTable.Text.Equals("Поставщик"))
                    {
                        query = $" INSERT INTO Supplier (name_suppl) VALUES ('{tbName.Text}') ";
                    }
                    else if (cbTable.Text.Equals("Поставка"))
                    {
                        query = $"INSERT into Supply (supplier_supply,date_supply) VALUES (suppl_number('{cbSupplier.Text}'),'{getDate()}') ";
                    }
                    else if (cbTable.Text.Equals("Накладная"))
                    {
                        query = $"insert into Airbill (amounce_airbill,tech_airbill,supply_airbill) VALUES ({tbAmounce.Text},tech_number('{cbTech.Text}'),{dataGridView2[0,dataGridView2.CurrentCell.RowIndex].Value.ToString()}) ";
                    }
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    updateTables();
                    write_suppliers(cbSupplier);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbField.Items.Clear();
            foreach (Control item in supplier_elems.Union(supply_elems).Union(airbill_elems))
            {
                item.Visible = false;
            }
            if (cbTable.Text.Equals("Поставщик"))
            {
                foreach (Control item in supplier_elems) item.Visible = true;
                cbField.Items.Add("Наименование");
            }
            else if (cbTable.Text.Equals("Поставка"))
            {
                foreach (Control item in supply_elems) item.Visible = true;
                cbField.Items.Add("Поставщик");
                cbField.Items.Add("Дата");
            }
            else if (cbTable.Text.Equals("Накладная"))
            {
                foreach (Control item in airbill_elems) item.Visible = true;
                cbField.Items.Add("Количество");
                cbField.Items.Add("ID поставки");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "";
                try
                {
                    if (cbTable.Text.Equals("Поставщик"))
                    {
                        query = $"Delete from Supplier WHERE IDsupplier={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Поставка"))
                    {
                        query = $"Delete from Supply WHERE IDsupply={dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Накладная"))
                    {
                        query = $"Delete from Airbill WHERE IDairbill={dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    updateTables();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void cbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNewValue.Items.Clear();
            if (cbField.Text.Equals("Поставщик"))
                write_suppliers(cbNewValue);
            if (cbField.Text.Equals("Техника"))
                write_tech(cbNewValue);
        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "UPDATE ";
                try
                {
                    switch (cbField.Text)
                    {
                        case "Наименование":
                            query += $" Supplier SET  name_suppl ='{cbNewValue.Text}' ";
                            break;
                        case "Поставщик":
                            query += $" Supply SET  supplier_supply =suppl_number('{cbNewValue.Text}') ";
                            break;
                        case "Дата":
                            query += $" Supply SET date_supply ='{getDate()}'";
                            break;
                        case "Количество":
                            query += $" Airbill SET amounce_airbill = {cbNewValue.Text}";
                            break;
                        case "ID поставки":
                            query += $" Airbill SET supply_airbill = {cbNewValue.Text}";
                            break;
                    }
                    if (cbTable.Text.Equals("Поставщик"))
                    {
                        query += $" WHERE IDsupplier={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Поставка"))
                    {
                        query += $" WHERE IDsupply={dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Накладная"))
                    {
                        query += $" WHERE IDairbill={dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    Console.WriteLine(query);
                    cmd.ExecuteNonQuery();
                    updateTables();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
