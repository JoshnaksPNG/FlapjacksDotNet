namespace TextHiderDotNet
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            groupBox1 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            trackBar1 = new TrackBar();
            button3 = new Button();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            groupBox2 = new GroupBox();
            textBox4 = new TextBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            label5 = new Label();
            textBox3 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(trackBar1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(17, 20);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(463, 1180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Write Image";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(346, 808);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(32, 25);
            label9.TabIndex = 8;
            label9.Text = "0B";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(307, 205);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(32, 25);
            label8.TabIndex = 7;
            label8.Text = "0B";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(217, 205);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(87, 25);
            label7.TabIndex = 6;
            label7.Text = "Text Size: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(217, 808);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(129, 25);
            label6.TabIndex = 2;
            label6.Text = "Storage Space:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 783);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 5;
            label4.Text = "1 bit";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 753);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 1;
            label3.Text = "Significant Bits";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(9, 783);
            trackBar1.Margin = new Padding(4, 5, 4, 5);
            trackBar1.Maximum = 8;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(149, 69);
            trackBar1.TabIndex = 1;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // button3
            // 
            button3.Location = new Point(164, 862);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(290, 38);
            button3.TabIndex = 1;
            button3.Text = "Write To Image";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(9, 868);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(153, 29);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Compress Text";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(9, 397);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(446, 340);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(9, 348);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(107, 38);
            button2.TabIndex = 4;
            button2.Text = "Select Image";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(9, 300);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(444, 31);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 270);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(109, 25);
            label2.TabIndex = 2;
            label2.Text = "Input Image";
            // 
            // button1
            // 
            button1.Location = new Point(9, 198);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(107, 38);
            button1.TabIndex = 1;
            button1.Text = "Select File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 120);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 1;
            label1.Text = "Text Input";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(9, 150);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Horizontal;
            textBox1.Size = new Size(444, 31);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(9, 37);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 33);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Input Method";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Location = new Point(489, 20);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(463, 1180);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "ReadImage";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(9, 397);
            textBox4.Margin = new Padding(4, 5, 4, 5);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ScrollBars = ScrollBars.Vertical;
            textBox4.Size = new Size(444, 337);
            textBox4.TabIndex = 5;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button6
            // 
            button6.Location = new Point(9, 862);
            button6.Margin = new Padding(4, 5, 4, 5);
            button6.Name = "button6";
            button6.Size = new Size(186, 38);
            button6.TabIndex = 4;
            button6.Text = "Save Text as File";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(9, 298);
            button5.Margin = new Padding(4, 5, 4, 5);
            button5.Name = "button5";
            button5.Size = new Size(446, 38);
            button5.TabIndex = 3;
            button5.Text = "Decode Image";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(9, 198);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(107, 38);
            button4.TabIndex = 2;
            button4.Text = "Select File";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 120);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(109, 25);
            label5.TabIndex = 1;
            label5.Text = "Input Image";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(9, 150);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(444, 31);
            textBox3.TabIndex = 0;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1749, 1050);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormMain";
            Text = "Flapjacks";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private Button button3;
        private TrackBar trackBar1;
        private Label label4;
        private Label label3;
        private GroupBox groupBox2;
        private Button button5;
        private Button button4;
        private Label label5;
        private TextBox textBox3;
        private Button button6;
        private TextBox textBox4;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
    }
}