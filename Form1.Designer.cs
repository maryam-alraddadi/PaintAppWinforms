
namespace PaintAppWinforms
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lineStyle = new System.Windows.Forms.ListBox();
            this.lineWeight = new System.Windows.Forms.ListBox();
            this.circleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.rectangleButton);
            this.panel1.Controls.Add(this.lineButton);
            this.panel1.Controls.Add(this.circleButton);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1270, 70);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(864, 20);
            this.button6.Margin = new System.Windows.Forms.Padding(5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 38);
            this.button6.TabIndex = 1;
            this.button6.Text = "clear";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button5.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F);
            this.button5.Location = new System.Drawing.Point(1116, 20);
            this.button5.Margin = new System.Windows.Forms.Padding(5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 38);
            this.button5.TabIndex = 3;
            this.button5.Text = "Color";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lineStyle);
            this.panel2.Controls.Add(this.lineWeight);
            this.panel2.Location = new System.Drawing.Point(1087, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 658);
            this.panel2.TabIndex = 1;
            // 
            // lineStyle
            // 
            this.lineStyle.FormattingEnabled = true;
            this.lineStyle.ItemHeight = 25;
            this.lineStyle.Items.AddRange(new object[] {
            "dashed",
            "dotted",
            "solid"});
            this.lineStyle.Location = new System.Drawing.Point(0, 156);
            this.lineStyle.Name = "lineStyle";
            this.lineStyle.Size = new System.Drawing.Size(161, 29);
            this.lineStyle.TabIndex = 1;
            this.lineStyle.SelectedIndexChanged += new System.EventHandler(this.lineStyle_SelectedIndexChanged);
            // 
            // lineWeight
            // 
            this.lineWeight.FormattingEnabled = true;
            this.lineWeight.ItemHeight = 25;
            this.lineWeight.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.lineWeight.Location = new System.Drawing.Point(20, 84);
            this.lineWeight.Name = "lineWeight";
            this.lineWeight.Size = new System.Drawing.Size(136, 29);
            this.lineWeight.TabIndex = 0;
            this.lineWeight.SelectedIndexChanged += new System.EventHandler(this.lineWeight_SelectedIndexChanged);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(181, 20);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 37);
            this.circleButton.TabIndex = 4;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(409, 20);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(104, 47);
            this.lineButton.TabIndex = 5;
            this.lineButton.Text = "line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(637, 12);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(104, 54);
            this.rectangleButton.TabIndex = 6;
            this.rectangleButton.Text = "rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1263, 750);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lineWeight;
        private System.Windows.Forms.ListBox lineStyle;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button lineButton;
    }
}

