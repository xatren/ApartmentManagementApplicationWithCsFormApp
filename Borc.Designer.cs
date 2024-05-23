namespace mysql
{
    partial class Borc
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbOdenmemis = new System.Windows.Forms.RadioButton();
            this.rbOdenmis = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.Location = new System.Drawing.Point(137, 60);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(187, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tüm Borçları Göster";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbOdenmemis
            // 
            this.rbOdenmemis.AutoSize = true;
            this.rbOdenmemis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbOdenmemis.Location = new System.Drawing.Point(397, 60);
            this.rbOdenmemis.Name = "rbOdenmemis";
            this.rbOdenmemis.Size = new System.Drawing.Size(247, 24);
            this.rbOdenmemis.TabIndex = 1;
            this.rbOdenmemis.TabStop = true;
            this.rbOdenmemis.Text = "Ödenmemiş Borçları Göster";
            this.rbOdenmemis.UseVisualStyleBackColor = true;
            this.rbOdenmemis.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbOdenmis
            // 
            this.rbOdenmis.AutoSize = true;
            this.rbOdenmis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbOdenmis.Location = new System.Drawing.Point(698, 60);
            this.rbOdenmis.Name = "rbOdenmis";
            this.rbOdenmis.Size = new System.Drawing.Size(223, 24);
            this.rbOdenmis.TabIndex = 2;
            this.rbOdenmis.TabStop = true;
            this.rbOdenmis.Text = "Ödenmiş Borçları Göster";
            this.rbOdenmis.UseVisualStyleBackColor = true;
            this.rbOdenmis.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(393, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 55);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ödendi Olarak İşaretle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(670, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(266, 55);
            this.button2.TabIndex = 5;
            this.button2.Text = "Ödenmedi Olarak İşaretle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Highlight;
            this.dataGridView1.Location = new System.Drawing.Point(12, 248);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1032, 336);
            this.dataGridView1.TabIndex = 22;
            // 
            // Borc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 596);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbOdenmis);
            this.Controls.Add(this.rbOdenmemis);
            this.Controls.Add(this.radioButton1);
            this.Name = "Borc";
            this.Text = "Borc";
            this.Load += new System.EventHandler(this.Borc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbOdenmemis;
        private System.Windows.Forms.RadioButton rbOdenmis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}