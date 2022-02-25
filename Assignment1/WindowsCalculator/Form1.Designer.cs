
namespace WindowsCalculator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.input1 = new System.Windows.Forms.TextBox();
            this.input2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multi = new System.Windows.Forms.RadioButton();
            this.div = new System.Windows.Forms.RadioButton();
            this.add = new System.Windows.Forms.RadioButton();
            this.sub = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.resLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "计算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(242, 32);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(178, 25);
            this.input1.TabIndex = 1;
            this.input1.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(648, 32);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(178, 25);
            this.input2.TabIndex = 2;
            this.input2.TextChanged += new System.EventHandler(this.input2_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("楷体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1025, 84);
            this.label1.TabIndex = 1;
            this.label1.Text = "加减乘除计算器";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.input1);
            this.panel2.Controls.Add(this.input2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 86);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "运算数1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.multi);
            this.panel1.Controls.Add(this.div);
            this.panel1.Controls.Add(this.add);
            this.panel1.Controls.Add(this.sub);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 100);
            this.panel1.TabIndex = 4;
            // 
            // multi
            // 
            this.multi.AutoSize = true;
            this.multi.Location = new System.Drawing.Point(606, 48);
            this.multi.Name = "multi";
            this.multi.Size = new System.Drawing.Size(36, 19);
            this.multi.TabIndex = 6;
            this.multi.Text = "*";
            this.multi.UseVisualStyleBackColor = true;
            this.multi.CheckedChanged += new System.EventHandler(this.multi_CheckedChanged);
            // 
            // div
            // 
            this.div.AutoSize = true;
            this.div.Location = new System.Drawing.Point(790, 48);
            this.div.Name = "div";
            this.div.Size = new System.Drawing.Size(36, 19);
            this.div.TabIndex = 7;
            this.div.Text = "/";
            this.div.UseVisualStyleBackColor = true;
            this.div.CheckedChanged += new System.EventHandler(this.div_CheckedChanged);
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.Checked = true;
            this.add.Location = new System.Drawing.Point(274, 48);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(36, 19);
            this.add.TabIndex = 4;
            this.add.TabStop = true;
            this.add.Text = "+";
            this.add.UseVisualStyleBackColor = true;
            this.add.CheckedChanged += new System.EventHandler(this.add_CheckedChanged_1);
            // 
            // sub
            // 
            this.sub.AutoSize = true;
            this.sub.Location = new System.Drawing.Point(425, 48);
            this.sub.Name = "sub";
            this.sub.Size = new System.Drawing.Size(36, 19);
            this.sub.TabIndex = 5;
            this.sub.Text = "-";
            this.sub.UseVisualStyleBackColor = true;
            this.sub.CheckedChanged += new System.EventHandler(this.sub_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(582, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "运算数2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "运算结果";
            // 
            // resLabel
            // 
            this.resLabel.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resLabel.Location = new System.Drawing.Point(488, 416);
            this.resLabel.Name = "resLabel";
            this.resLabel.Size = new System.Drawing.Size(142, 51);
            this.resLabel.TabIndex = 6;
            this.resLabel.Text = "null";
            this.resLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 558);
            this.Controls.Add(this.resLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
          
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.TextBox input2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton multi;
        private System.Windows.Forms.RadioButton div;
        private System.Windows.Forms.RadioButton add;
        private System.Windows.Forms.RadioButton sub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label resLabel;
    }
}

