namespace ProcessManagerApp
{
    partial class EventLogForm
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
            this.cmbLogType = new System.Windows.Forms.ComboBox();
            this.btnLoadLogs = new System.Windows.Forms.Button();
            this.dataGridLogs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanelLogs = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogs)).BeginInit();
            this.tableLayoutPanelLogs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLogType
            // 
            this.cmbLogType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.9F);
            this.cmbLogType.FormattingEnabled = true;
            this.cmbLogType.Location = new System.Drawing.Point(3, 63);
            this.cmbLogType.Name = "cmbLogType";
            this.cmbLogType.Size = new System.Drawing.Size(605, 48);
            this.cmbLogType.TabIndex = 0;
            // 
            // btnLoadLogs
            // 
            this.btnLoadLogs.Location = new System.Drawing.Point(614, 63);
            this.btnLoadLogs.Name = "btnLoadLogs";
            this.btnLoadLogs.Size = new System.Drawing.Size(431, 59);
            this.btnLoadLogs.TabIndex = 1;
            this.btnLoadLogs.Text = "Завантаження логів";
            this.btnLoadLogs.UseVisualStyleBackColor = true;
            this.btnLoadLogs.Click += new System.EventHandler(this.btnLoadLogs_Click);
            // 
            // dataGridLogs
            // 
            this.dataGridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLogs.Location = new System.Drawing.Point(3, 3);
            this.dataGridLogs.Name = "dataGridLogs";
            this.dataGridLogs.RowHeadersWidth = 102;
            this.dataGridLogs.RowTemplate.Height = 40;
            this.dataGridLogs.Size = new System.Drawing.Size(2056, 1186);
            this.dataGridLogs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вивід подій:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вибір типу логу (System...):";
            // 
            // tableLayoutPanelLogs
            // 
            this.tableLayoutPanelLogs.ColumnCount = 4;
            this.tableLayoutPanelLogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 611F));
            this.tableLayoutPanelLogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 437F));
            this.tableLayoutPanelLogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 306F));
            this.tableLayoutPanelLogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanelLogs.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanelLogs.Controls.Add(this.cmbLogType, 0, 1);
            this.tableLayoutPanelLogs.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanelLogs.Controls.Add(this.btnLoadLogs, 1, 1);
            this.tableLayoutPanelLogs.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanelLogs.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanelLogs.Controls.Add(this.dtpFrom, 3, 0);
            this.tableLayoutPanelLogs.Controls.Add(this.dtpTo, 3, 1);
            this.tableLayoutPanelLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelLogs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLogs.Name = "tableLayoutPanelLogs";
            this.tableLayoutPanelLogs.RowCount = 3;
            this.tableLayoutPanelLogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelLogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanelLogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanelLogs.Size = new System.Drawing.Size(2062, 186);
            this.tableLayoutPanelLogs.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridLogs, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 186);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2062, 1192);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1087, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 60);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вибір дати ... З:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1281, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 66);
            this.label4.TabIndex = 5;
            this.label4.Text = "По:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpFrom.Location = new System.Drawing.Point(1357, 19);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 38);
            this.dtpFrom.TabIndex = 6;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpTo.Location = new System.Drawing.Point(1357, 85);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 38);
            this.dtpTo.TabIndex = 7;
            this.dtpTo.Value = new System.DateTime(2025, 5, 21, 2, 15, 30, 0);
            // 
            // EventLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2062, 1378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanelLogs);
            this.Name = "EventLogForm";
            this.Text = "EventLogForm";
            this.Load += new System.EventHandler(this.EventLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogs)).EndInit();
            this.tableLayoutPanelLogs.ResumeLayout(false);
            this.tableLayoutPanelLogs.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLogType;
        private System.Windows.Forms.Button btnLoadLogs;
        private System.Windows.Forms.DataGridView dataGridLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLogs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
    }
}