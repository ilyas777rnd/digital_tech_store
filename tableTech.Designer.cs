namespace Ulmart
{
    partial class tableTech
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbNewValue = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDefPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbField = new System.Windows.Forms.ComboBox();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCat = new System.Windows.Forms.ComboBox();
            this.tbRetPrice = new System.Windows.Forms.TextBox();
            this.tbWarranty = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbLength = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNewValue
            // 
            this.cbNewValue.FormattingEnabled = true;
            this.cbNewValue.Location = new System.Drawing.Point(714, 579);
            this.cbNewValue.Name = "cbNewValue";
            this.cbNewValue.Size = new System.Drawing.Size(301, 24);
            this.cbNewValue.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(424, 450);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 39;
            this.label8.Text = "Ширина:";
            // 
            // tbDefPrice
            // 
            this.tbDefPrice.Location = new System.Drawing.Point(23, 524);
            this.tbDefPrice.Name = "tbDefPrice";
            this.tbDefPrice.Size = new System.Drawing.Size(188, 22);
            this.tbDefPrice.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(710, 546);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 19);
            this.label7.TabIndex = 37;
            this.label7.Text = "Новое значение:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(710, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 19);
            this.label6.TabIndex = 36;
            this.label6.Text = "Выберите атрибут:";
            // 
            // cbField
            // 
            this.cbField.FormattingEnabled = true;
            this.cbField.Location = new System.Drawing.Point(714, 519);
            this.cbField.Name = "cbField";
            this.cbField.Size = new System.Drawing.Size(301, 24);
            this.cbField.TabIndex = 35;
            this.cbField.SelectedIndexChanged += new System.EventHandler(this.cbField_SelectedIndexChanged);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(714, 428);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(218, 44);
            this.Update.TabIndex = 34;
            this.Update.Text = "Обновить(выберите строку)";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(714, 381);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(218, 35);
            this.Delete.TabIndex = 33;
            this.Delete.Text = "Удалить(выберите строку)";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(182, 344);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(218, 42);
            this.Add.TabIndex = 32;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "Категория:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(224, 502);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 19);
            this.label4.TabIndex = 30;
            this.label4.Text = "Розничная цена(руб):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 502);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Цена у поставщика(руб):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 28;
            this.label2.Text = "Наименование:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(424, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "Длина:";
            // 
            // cbCat
            // 
            this.cbCat.FormattingEnabled = true;
            this.cbCat.Location = new System.Drawing.Point(23, 465);
            this.cbCat.Name = "cbCat";
            this.cbCat.Size = new System.Drawing.Size(245, 24);
            this.cbCat.TabIndex = 26;
            // 
            // tbRetPrice
            // 
            this.tbRetPrice.Location = new System.Drawing.Point(217, 524);
            this.tbRetPrice.Name = "tbRetPrice";
            this.tbRetPrice.Size = new System.Drawing.Size(183, 22);
            this.tbRetPrice.TabIndex = 25;
            // 
            // tbWarranty
            // 
            this.tbWarranty.Location = new System.Drawing.Point(274, 467);
            this.tbWarranty.Name = "tbWarranty";
            this.tbWarranty.Size = new System.Drawing.Size(126, 22);
            this.tbWarranty.TabIndex = 24;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(23, 410);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(377, 22);
            this.tbName.TabIndex = 23;
            // 
            // tbLength
            // 
            this.tbLength.Location = new System.Drawing.Point(424, 411);
            this.tbLength.Name = "tbLength";
            this.tbLength.Size = new System.Drawing.Size(177, 22);
            this.tbLength.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1272, 272);
            this.dataGridView1.TabIndex = 21;
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(23, 344);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(116, 24);
            this.cbTable.TabIndex = 41;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "Таблица:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(270, 443);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 19);
            this.label10.TabIndex = 43;
            this.label10.Text = "Гарантия(мес):";
            // 
            // cbSupplier
            // 
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(23, 584);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(377, 24);
            this.cbSupplier.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(23, 562);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 19);
            this.label11.TabIndex = 45;
            this.label11.Text = "Поставщик:";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(424, 472);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(177, 22);
            this.tbWidth.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(424, 508);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 19);
            this.label12.TabIndex = 47;
            this.label12.Text = "Высота:";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(424, 530);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(177, 22);
            this.tbHeight.TabIndex = 48;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(228, 12);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(653, 22);
            this.tbSearch.TabIndex = 49;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(25, 12);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(186, 23);
            this.Search.TabIndex = 50;
            this.Search.Text = "Поиск по названию";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // tableTech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 630);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbSupplier);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.cbNewValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbDefPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbField);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCat);
            this.Controls.Add(this.tbRetPrice);
            this.Controls.Add(this.tbWarranty);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbLength);
            this.Controls.Add(this.dataGridView1);
            this.Name = "tableTech";
            this.Text = "tableTech";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNewValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDefPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbField;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCat;
        private System.Windows.Forms.TextBox tbRetPrice;
        private System.Windows.Forms.TextBox tbWarranty;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbLength;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button Search;
    }
}