namespace MorgantiCalculator
{
    partial class Calculator
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
            this.txt_output = new System.Windows.Forms.TextBox();
            this.btn_sqrt = new System.Windows.Forms.Button();
            this.btn_power = new System.Windows.Forms.Button();
            this.btn_square = new System.Windows.Forms.Button();
            this.btn_inv = new System.Windows.Forms.Button();
            this.btn_div = new System.Windows.Forms.Button();
            this.btn_c = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_ce = new System.Windows.Forms.Button();
            this.btn_mult = new System.Windows.Forms.Button();
            this.btn_8 = new System.Windows.Forms.Button();
            this.btn_9 = new System.Windows.Forms.Button();
            this.btn_7 = new System.Windows.Forms.Button();
            this.btn_sub = new System.Windows.Forms.Button();
            this.btn_5 = new System.Windows.Forms.Button();
            this.btn_6 = new System.Windows.Forms.Button();
            this.btn_4 = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_2 = new System.Windows.Forms.Button();
            this.btn_3 = new System.Windows.Forms.Button();
            this.btn_1 = new System.Windows.Forms.Button();
            this.btn_equal = new System.Windows.Forms.Button();
            this.btn_0 = new System.Windows.Forms.Button();
            this.btn_dec = new System.Windows.Forms.Button();
            this.but_neg = new System.Windows.Forms.Button();
            this.txt_prev = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(42, 37);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(239, 22);
            this.txt_output.TabIndex = 0;
            this.txt_output.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_sqrt
            // 
            this.btn_sqrt.Location = new System.Drawing.Point(42, 66);
            this.btn_sqrt.Name = "btn_sqrt";
            this.btn_sqrt.Size = new System.Drawing.Size(50, 40);
            this.btn_sqrt.TabIndex = 1;
            this.btn_sqrt.Text = "Sqrt";
            this.btn_sqrt.UseVisualStyleBackColor = true;
            this.btn_sqrt.Click += new System.EventHandler(this.btn_sqrt_Click);
            // 
            // btn_power
            // 
            this.btn_power.Location = new System.Drawing.Point(168, 66);
            this.btn_power.Name = "btn_power";
            this.btn_power.Size = new System.Drawing.Size(50, 40);
            this.btn_power.TabIndex = 2;
            this.btn_power.Text = "x^y";
            this.btn_power.UseVisualStyleBackColor = true;
            this.btn_power.Click += new System.EventHandler(this.btn_power_Click);
            // 
            // btn_square
            // 
            this.btn_square.Location = new System.Drawing.Point(105, 66);
            this.btn_square.Name = "btn_square";
            this.btn_square.Size = new System.Drawing.Size(50, 40);
            this.btn_square.TabIndex = 3;
            this.btn_square.Text = "x^2";
            this.btn_square.UseVisualStyleBackColor = true;
            this.btn_square.Click += new System.EventHandler(this.btn_square_Click);
            // 
            // btn_inv
            // 
            this.btn_inv.Location = new System.Drawing.Point(231, 66);
            this.btn_inv.Name = "btn_inv";
            this.btn_inv.Size = new System.Drawing.Size(50, 40);
            this.btn_inv.TabIndex = 4;
            this.btn_inv.Text = "1/x";
            this.btn_inv.UseVisualStyleBackColor = true;
            this.btn_inv.Click += new System.EventHandler(this.btn_inv_Click);
            // 
            // btn_div
            // 
            this.btn_div.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_div.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_div.Location = new System.Drawing.Point(231, 117);
            this.btn_div.Name = "btn_div";
            this.btn_div.Size = new System.Drawing.Size(50, 40);
            this.btn_div.TabIndex = 8;
            this.btn_div.Text = "÷";
            this.btn_div.UseVisualStyleBackColor = false;
            this.btn_div.Click += new System.EventHandler(this.btn_div_Click);
            // 
            // btn_c
            // 
            this.btn_c.Location = new System.Drawing.Point(105, 117);
            this.btn_c.Name = "btn_c";
            this.btn_c.Size = new System.Drawing.Size(50, 40);
            this.btn_c.TabIndex = 7;
            this.btn_c.Text = "C";
            this.btn_c.UseVisualStyleBackColor = true;
            this.btn_c.Click += new System.EventHandler(this.btn_c_Click);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(168, 117);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(50, 40);
            this.btn_del.TabIndex = 6;
            this.btn_del.Text = "Del";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_ce
            // 
            this.btn_ce.Location = new System.Drawing.Point(42, 117);
            this.btn_ce.Name = "btn_ce";
            this.btn_ce.Size = new System.Drawing.Size(50, 40);
            this.btn_ce.TabIndex = 5;
            this.btn_ce.Text = "CE";
            this.btn_ce.UseVisualStyleBackColor = true;
            this.btn_ce.Click += new System.EventHandler(this.btn_ce_Click);
            // 
            // btn_mult
            // 
            this.btn_mult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_mult.Location = new System.Drawing.Point(231, 168);
            this.btn_mult.Name = "btn_mult";
            this.btn_mult.Size = new System.Drawing.Size(50, 40);
            this.btn_mult.TabIndex = 12;
            this.btn_mult.Text = "X";
            this.btn_mult.UseVisualStyleBackColor = false;
            this.btn_mult.Click += new System.EventHandler(this.btn_mult_Click);
            // 
            // btn_8
            // 
            this.btn_8.BackColor = System.Drawing.Color.White;
            this.btn_8.Location = new System.Drawing.Point(105, 168);
            this.btn_8.Name = "btn_8";
            this.btn_8.Size = new System.Drawing.Size(50, 40);
            this.btn_8.TabIndex = 11;
            this.btn_8.Text = "8";
            this.btn_8.UseVisualStyleBackColor = false;
            this.btn_8.Click += new System.EventHandler(this.btn_8_Click);
            // 
            // btn_9
            // 
            this.btn_9.BackColor = System.Drawing.Color.White;
            this.btn_9.Location = new System.Drawing.Point(168, 168);
            this.btn_9.Name = "btn_9";
            this.btn_9.Size = new System.Drawing.Size(50, 40);
            this.btn_9.TabIndex = 10;
            this.btn_9.Text = "9";
            this.btn_9.UseVisualStyleBackColor = false;
            this.btn_9.Click += new System.EventHandler(this.btn_9_Click);
            // 
            // btn_7
            // 
            this.btn_7.BackColor = System.Drawing.Color.White;
            this.btn_7.Location = new System.Drawing.Point(42, 168);
            this.btn_7.Name = "btn_7";
            this.btn_7.Size = new System.Drawing.Size(50, 40);
            this.btn_7.TabIndex = 9;
            this.btn_7.Text = "7";
            this.btn_7.UseVisualStyleBackColor = false;
            this.btn_7.Click += new System.EventHandler(this.btn_7_Click);
            // 
            // btn_sub
            // 
            this.btn_sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_sub.Location = new System.Drawing.Point(231, 219);
            this.btn_sub.Name = "btn_sub";
            this.btn_sub.Size = new System.Drawing.Size(50, 40);
            this.btn_sub.TabIndex = 16;
            this.btn_sub.Text = "-";
            this.btn_sub.UseVisualStyleBackColor = false;
            this.btn_sub.Click += new System.EventHandler(this.btn_sub_Click);
            // 
            // btn_5
            // 
            this.btn_5.BackColor = System.Drawing.Color.White;
            this.btn_5.Location = new System.Drawing.Point(105, 219);
            this.btn_5.Name = "btn_5";
            this.btn_5.Size = new System.Drawing.Size(50, 40);
            this.btn_5.TabIndex = 15;
            this.btn_5.Text = "5";
            this.btn_5.UseVisualStyleBackColor = false;
            this.btn_5.Click += new System.EventHandler(this.btn_5_Click);
            // 
            // btn_6
            // 
            this.btn_6.BackColor = System.Drawing.Color.White;
            this.btn_6.Location = new System.Drawing.Point(168, 219);
            this.btn_6.Name = "btn_6";
            this.btn_6.Size = new System.Drawing.Size(50, 40);
            this.btn_6.TabIndex = 14;
            this.btn_6.Text = "6";
            this.btn_6.UseVisualStyleBackColor = false;
            this.btn_6.Click += new System.EventHandler(this.btn_6_Click);
            // 
            // btn_4
            // 
            this.btn_4.BackColor = System.Drawing.Color.White;
            this.btn_4.Location = new System.Drawing.Point(42, 219);
            this.btn_4.Name = "btn_4";
            this.btn_4.Size = new System.Drawing.Size(50, 40);
            this.btn_4.TabIndex = 13;
            this.btn_4.Text = "4";
            this.btn_4.UseVisualStyleBackColor = false;
            this.btn_4.Click += new System.EventHandler(this.btn_4_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_add.Location = new System.Drawing.Point(231, 270);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(50, 40);
            this.btn_add.TabIndex = 20;
            this.btn_add.Text = "+";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_2
            // 
            this.btn_2.BackColor = System.Drawing.Color.White;
            this.btn_2.Location = new System.Drawing.Point(105, 270);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(50, 40);
            this.btn_2.TabIndex = 19;
            this.btn_2.Text = "2";
            this.btn_2.UseVisualStyleBackColor = false;
            this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
            // 
            // btn_3
            // 
            this.btn_3.BackColor = System.Drawing.Color.White;
            this.btn_3.Location = new System.Drawing.Point(168, 270);
            this.btn_3.Name = "btn_3";
            this.btn_3.Size = new System.Drawing.Size(50, 40);
            this.btn_3.TabIndex = 18;
            this.btn_3.Text = "3";
            this.btn_3.UseVisualStyleBackColor = false;
            this.btn_3.Click += new System.EventHandler(this.btn_3_Click);
            // 
            // btn_1
            // 
            this.btn_1.BackColor = System.Drawing.Color.White;
            this.btn_1.Location = new System.Drawing.Point(42, 270);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(50, 40);
            this.btn_1.TabIndex = 17;
            this.btn_1.Text = "1";
            this.btn_1.UseVisualStyleBackColor = false;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // btn_equal
            // 
            this.btn_equal.Location = new System.Drawing.Point(231, 321);
            this.btn_equal.Name = "btn_equal";
            this.btn_equal.Size = new System.Drawing.Size(50, 40);
            this.btn_equal.TabIndex = 24;
            this.btn_equal.Text = "=";
            this.btn_equal.UseVisualStyleBackColor = true;
            this.btn_equal.Click += new System.EventHandler(this.btn_equal_Click);
            // 
            // btn_0
            // 
            this.btn_0.BackColor = System.Drawing.Color.White;
            this.btn_0.Location = new System.Drawing.Point(105, 321);
            this.btn_0.Name = "btn_0";
            this.btn_0.Size = new System.Drawing.Size(50, 40);
            this.btn_0.TabIndex = 23;
            this.btn_0.Text = "0";
            this.btn_0.UseVisualStyleBackColor = false;
            this.btn_0.Click += new System.EventHandler(this.btn_0_Click);
            // 
            // btn_dec
            // 
            this.btn_dec.BackColor = System.Drawing.Color.White;
            this.btn_dec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_dec.Location = new System.Drawing.Point(168, 321);
            this.btn_dec.Name = "btn_dec";
            this.btn_dec.Size = new System.Drawing.Size(50, 40);
            this.btn_dec.TabIndex = 22;
            this.btn_dec.Text = ".";
            this.btn_dec.UseVisualStyleBackColor = false;
            this.btn_dec.Click += new System.EventHandler(this.btn_dec_Click);
            // 
            // but_neg
            // 
            this.but_neg.BackColor = System.Drawing.Color.White;
            this.but_neg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.but_neg.Location = new System.Drawing.Point(42, 321);
            this.but_neg.Name = "but_neg";
            this.but_neg.Size = new System.Drawing.Size(50, 40);
            this.but_neg.TabIndex = 21;
            this.but_neg.Text = "+/-";
            this.but_neg.UseVisualStyleBackColor = false;
            this.but_neg.Click += new System.EventHandler(this.but_neg_Click);
            // 
            // txt_prev
            // 
            this.txt_prev.Location = new System.Drawing.Point(42, 16);
            this.txt_prev.Name = "txt_prev";
            this.txt_prev.ReadOnly = true;
            this.txt_prev.Size = new System.Drawing.Size(239, 22);
            this.txt_prev.TabIndex = 25;
            this.txt_prev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 381);
            this.Controls.Add(this.txt_prev);
            this.Controls.Add(this.btn_equal);
            this.Controls.Add(this.btn_0);
            this.Controls.Add(this.btn_dec);
            this.Controls.Add(this.but_neg);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_2);
            this.Controls.Add(this.btn_3);
            this.Controls.Add(this.btn_1);
            this.Controls.Add(this.btn_sub);
            this.Controls.Add(this.btn_5);
            this.Controls.Add(this.btn_6);
            this.Controls.Add(this.btn_4);
            this.Controls.Add(this.btn_mult);
            this.Controls.Add(this.btn_8);
            this.Controls.Add(this.btn_9);
            this.Controls.Add(this.btn_7);
            this.Controls.Add(this.btn_div);
            this.Controls.Add(this.btn_c);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_ce);
            this.Controls.Add(this.btn_inv);
            this.Controls.Add(this.btn_square);
            this.Controls.Add(this.btn_power);
            this.Controls.Add(this.btn_sqrt);
            this.Controls.Add(this.txt_output);
            this.KeyPreview = true;
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Button btn_sqrt;
        private System.Windows.Forms.Button btn_power;
        private System.Windows.Forms.Button btn_square;
        private System.Windows.Forms.Button btn_inv;
        private System.Windows.Forms.Button btn_div;
        private System.Windows.Forms.Button btn_c;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_ce;
        private System.Windows.Forms.Button btn_mult;
        private System.Windows.Forms.Button btn_8;
        private System.Windows.Forms.Button btn_9;
        private System.Windows.Forms.Button btn_7;
        private System.Windows.Forms.Button btn_sub;
        private System.Windows.Forms.Button btn_5;
        private System.Windows.Forms.Button btn_6;
        private System.Windows.Forms.Button btn_4;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.Button btn_3;
        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.Button btn_equal;
        private System.Windows.Forms.Button btn_0;
        private System.Windows.Forms.Button btn_dec;
        private System.Windows.Forms.Button but_neg;
        private System.Windows.Forms.TextBox txt_prev;
    }
}

