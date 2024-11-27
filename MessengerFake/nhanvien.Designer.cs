namespace MessengerFake
{
    partial class nhanvien
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
            this.label1 = new System.Windows.Forms.Label();
            this.txttennv = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtquenv = new System.Windows.Forms.TextBox();
            this.txttuoinv = new System.Windows.Forms.TextBox();
            this.txtluongnv = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvttnhanvien = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvttnhanvien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHẬP TÊN NHÂN VIÊN";
            // 
            // txttennv
            // 
            this.txttennv.Location = new System.Drawing.Point(293, 67);
            this.txttennv.Name = "txttennv";
            this.txttennv.Size = new System.Drawing.Size(173, 22);
            this.txttennv.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "THÊM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "QUÊ QUÁN NHÂN VIÊN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "TUỔI NHÂN VIÊN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "LƯƠNG NHÂN VIÊN";
            // 
            // txtquenv
            // 
            this.txtquenv.Location = new System.Drawing.Point(293, 157);
            this.txtquenv.Name = "txtquenv";
            this.txtquenv.Size = new System.Drawing.Size(173, 22);
            this.txtquenv.TabIndex = 6;
            // 
            // txttuoinv
            // 
            this.txttuoinv.Location = new System.Drawing.Point(293, 241);
            this.txttuoinv.Name = "txttuoinv";
            this.txttuoinv.Size = new System.Drawing.Size(173, 22);
            this.txttuoinv.TabIndex = 7;
            // 
            // txtluongnv
            // 
            this.txtluongnv.Location = new System.Drawing.Point(293, 312);
            this.txtluongnv.Name = "txtluongnv";
            this.txtluongnv.Size = new System.Drawing.Size(173, 22);
            this.txtluongnv.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(528, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 48);
            this.button2.TabIndex = 9;
            this.button2.Text = "SỬA ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(528, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 49);
            this.button3.TabIndex = 10;
            this.button3.Text = "XÓA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Location = new System.Drawing.Point(44, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 474);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NHẬP THÔNG TIN NHÂN VIÊN";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(54, 411);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 57);
            this.button5.TabIndex = 0;
            this.button5.Text = "THOÁT";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.dgvttnhanvien);
            this.groupBox2.Location = new System.Drawing.Point(684, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 474);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HIỂN THỊ THÔNG TIN NHÂN VIÊN";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(321, 435);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 33);
            this.button4.TabIndex = 1;
            this.button4.Text = "RESET";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvttnhanvien
            // 
            this.dgvttnhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvttnhanvien.Location = new System.Drawing.Point(15, 54);
            this.dgvttnhanvien.Name = "dgvttnhanvien";
            this.dgvttnhanvien.RowHeadersWidth = 51;
            this.dgvttnhanvien.RowTemplate.Height = 24;
            this.dgvttnhanvien.Size = new System.Drawing.Size(491, 351);
            this.dgvttnhanvien.TabIndex = 0;
            this.dgvttnhanvien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvttnhanvien_CellContentClick);
            // 
            // nhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 517);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtluongnv);
            this.Controls.Add(this.txttuoinv);
            this.Controls.Add(this.txtquenv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txttennv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "nhanvien";
            this.Text = "NHÂN VIÊN";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvttnhanvien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttennv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtquenv;
        private System.Windows.Forms.TextBox txttuoinv;
        private System.Windows.Forms.TextBox txtluongnv;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvttnhanvien;
        private System.Windows.Forms.Button button5;
    }
}