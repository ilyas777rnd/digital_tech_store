namespace Ulmart
{
    partial class ManagerForm
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
            this.btClients = new System.Windows.Forms.Button();
            this.btSupply = new System.Windows.Forms.Button();
            this.ShowOrders = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbDelivery = new System.Windows.Forms.ListBox();
            this.IsDone = new System.Windows.Forms.Button();
            this.IsReady = new System.Windows.Forms.Button();
            this.btRequest = new System.Windows.Forms.Button();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // btClients
            // 
            this.btClients.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btClients.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClients.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btClients.Location = new System.Drawing.Point(12, 12);
            this.btClients.Name = "btClients";
            this.btClients.Size = new System.Drawing.Size(275, 60);
            this.btClients.TabIndex = 0;
            this.btClients.Text = "Добавить/Изменить/Удалить клиента";
            this.btClients.UseVisualStyleBackColor = false;
            this.btClients.Click += new System.EventHandler(this.btClients_Click);
            // 
            // btSupply
            // 
            this.btSupply.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSupply.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSupply.Location = new System.Drawing.Point(293, 10);
            this.btSupply.Name = "btSupply";
            this.btSupply.Size = new System.Drawing.Size(221, 62);
            this.btSupply.TabIndex = 1;
            this.btSupply.Text = "Поставщики и поставки";
            this.btSupply.UseVisualStyleBackColor = false;
            this.btSupply.Click += new System.EventHandler(this.btSupply_Click);
            // 
            // ShowOrders
            // 
            this.ShowOrders.BackColor = System.Drawing.Color.LightGreen;
            this.ShowOrders.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowOrders.Location = new System.Drawing.Point(12, 78);
            this.ShowOrders.Name = "ShowOrders";
            this.ShowOrders.Size = new System.Drawing.Size(275, 46);
            this.ShowOrders.TabIndex = 2;
            this.ShowOrders.Text = "Показать заказы";
            this.ShowOrders.UseVisualStyleBackColor = false;
            this.ShowOrders.Click += new System.EventHandler(this.ShowOrders_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(618, 397);
            this.dataGridView1.TabIndex = 3;
            // 
            // lbDelivery
            // 
            this.lbDelivery.FormattingEnabled = true;
            this.lbDelivery.ItemHeight = 16;
            this.lbDelivery.Location = new System.Drawing.Point(12, 544);
            this.lbDelivery.Name = "lbDelivery";
            this.lbDelivery.Size = new System.Drawing.Size(1255, 84);
            this.lbDelivery.TabIndex = 4;
            // 
            // IsDone
            // 
            this.IsDone.BackColor = System.Drawing.Color.SkyBlue;
            this.IsDone.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsDone.Location = new System.Drawing.Point(739, 13);
            this.IsDone.Name = "IsDone";
            this.IsDone.Size = new System.Drawing.Size(428, 59);
            this.IsDone.TabIndex = 5;
            this.IsDone.Text = "Заказ выдан (доставлен)";
            this.IsDone.UseVisualStyleBackColor = false;
            this.IsDone.Click += new System.EventHandler(this.IsDone_Click);
            // 
            // IsReady
            // 
            this.IsReady.BackColor = System.Drawing.Color.LightSkyBlue;
            this.IsReady.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsReady.Location = new System.Drawing.Point(738, 78);
            this.IsReady.Name = "IsReady";
            this.IsReady.Size = new System.Drawing.Size(429, 46);
            this.IsReady.TabIndex = 6;
            this.IsReady.Text = "Заказ готов к выдаче (к доставке)";
            this.IsReady.UseVisualStyleBackColor = false;
            this.IsReady.Click += new System.EventHandler(this.IsReady_Click);
            // 
            // btRequest
            // 
            this.btRequest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btRequest.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRequest.Location = new System.Drawing.Point(294, 78);
            this.btRequest.Name = "btRequest";
            this.btRequest.Size = new System.Drawing.Size(220, 46);
            this.btRequest.TabIndex = 7;
            this.btRequest.Text = "Заявки";
            this.btRequest.UseVisualStyleBackColor = false;
            this.btRequest.Click += new System.EventHandler(this.btRequest_Click);
            // 
            // dgvBasket
            // 
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(637, 141);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.RowHeadersWidth = 51;
            this.dgvBasket.RowTemplate.Height = 24;
            this.dgvBasket.Size = new System.Drawing.Size(630, 397);
            this.dgvBasket.TabIndex = 8;
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 639);
            this.Controls.Add(this.dgvBasket);
            this.Controls.Add(this.btRequest);
            this.Controls.Add(this.IsReady);
            this.Controls.Add(this.IsDone);
            this.Controls.Add(this.lbDelivery);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ShowOrders);
            this.Controls.Add(this.btSupply);
            this.Controls.Add(this.btClients);
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClients;
        private System.Windows.Forms.Button btSupply;
        private System.Windows.Forms.Button ShowOrders;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lbDelivery;
        private System.Windows.Forms.Button IsDone;
        private System.Windows.Forms.Button IsReady;
        private System.Windows.Forms.Button btRequest;
        private System.Windows.Forms.DataGridView dgvBasket;
    }
}