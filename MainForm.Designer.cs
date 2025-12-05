namespace ProcessManagerApp
{
    partial class MainForm
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
            this.btnOpenProcesses = new System.Windows.Forms.Button();
            this.btnOpenLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenProcesses
            // 
            this.btnOpenProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenProcesses.Location = new System.Drawing.Point(44, 55);
            this.btnOpenProcesses.Name = "btnOpenProcesses";
            this.btnOpenProcesses.Size = new System.Drawing.Size(400, 124);
            this.btnOpenProcesses.TabIndex = 0;
            this.btnOpenProcesses.Text = "Менеджер процесів";
            this.btnOpenProcesses.UseVisualStyleBackColor = true;
            this.btnOpenProcesses.Click += new System.EventHandler(this.btnOpenProcesses_Click);
            // 
            // btnOpenLogs
            // 
            this.btnOpenLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenLogs.Location = new System.Drawing.Point(543, 45);
            this.btnOpenLogs.Name = "btnOpenLogs";
            this.btnOpenLogs.Size = new System.Drawing.Size(413, 133);
            this.btnOpenLogs.TabIndex = 1;
            this.btnOpenLogs.Text = "Журнали подій Windows";
            this.btnOpenLogs.UseVisualStyleBackColor = true;
            this.btnOpenLogs.Click += new System.EventHandler(this.btnOpenLogs_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 370);
            this.Controls.Add(this.btnOpenLogs);
            this.Controls.Add(this.btnOpenProcesses);
            this.Name = "MainForm";
            this.Text = "Головна форма";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenProcesses;
        private System.Windows.Forms.Button btnOpenLogs;
    }
}