namespace BandKeywordsCheck
{
    partial class fmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxKW = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbCountResult = new System.Windows.Forms.Label();
            this.lbCountKW = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.btnStartCheck = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCurrentNo = new System.Windows.Forms.Label();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 422);
            this.panel1.TabIndex = 0;
            // 
            // tbxKW
            // 
            this.tbxKW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxKW.Location = new System.Drawing.Point(0, 0);
            this.tbxKW.MaxLength = 0;
            this.tbxKW.Multiline = true;
            this.tbxKW.Name = "tbxKW";
            this.tbxKW.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxKW.Size = new System.Drawing.Size(170, 399);
            this.tbxKW.TabIndex = 0;
            this.tbxKW.Text = "bracelet";
            this.tbxKW.TextChanged += new System.EventHandler(this.tbxKW_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbCurrent);
            this.panel4.Controls.Add(this.lbCurrentNo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Controls.Add(this.btnStartCheck);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(170, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 422);
            this.panel4.TabIndex = 2;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lbCountResult
            // 
            this.lbCountResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCountResult.AutoSize = true;
            this.lbCountResult.Location = new System.Drawing.Point(3, 4);
            this.lbCountResult.Name = "lbCountResult";
            this.lbCountResult.Size = new System.Drawing.Size(47, 12);
            this.lbCountResult.TabIndex = 4;
            this.lbCountResult.Text = "Count:0";
            this.lbCountResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCountKW
            // 
            this.lbCountKW.AutoSize = true;
            this.lbCountKW.Location = new System.Drawing.Point(3, 4);
            this.lbCountKW.Name = "lbCountKW";
            this.lbCountKW.Size = new System.Drawing.Size(47, 12);
            this.lbCountKW.TabIndex = 3;
            this.lbCountKW.Text = "Count:0";
            this.lbCountKW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(51, 371);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 28);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tbxResult
            // 
            this.tbxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxResult.Location = new System.Drawing.Point(0, 0);
            this.tbxResult.MaxLength = 0;
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxResult.Size = new System.Drawing.Size(172, 399);
            this.tbxResult.TabIndex = 1;
            this.tbxResult.TextChanged += new System.EventHandler(this.tbxResult_TextChanged);
            // 
            // btnStartCheck
            // 
            this.btnStartCheck.Location = new System.Drawing.Point(51, 243);
            this.btnStartCheck.Name = "btnStartCheck";
            this.btnStartCheck.Size = new System.Drawing.Size(123, 28);
            this.btnStartCheck.TabIndex = 0;
            this.btnStartCheck.Text = "Start &Check";
            this.btnStartCheck.UseVisualStyleBackColor = true;
            this.btnStartCheck.Click += new System.EventHandler(this.btnStartCheck_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(211, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 422);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbCountResult);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 399);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 23);
            this.panel3.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbxResult);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(172, 399);
            this.panel5.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbCountKW);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 399);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(170, 23);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbxKW);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(170, 399);
            this.panel7.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "正在处理：";
            // 
            // lbCurrentNo
            // 
            this.lbCurrentNo.AutoSize = true;
            this.lbCurrentNo.ForeColor = System.Drawing.Color.Maroon;
            this.lbCurrentNo.Location = new System.Drawing.Point(100, 49);
            this.lbCurrentNo.Name = "lbCurrentNo";
            this.lbCurrentNo.Size = new System.Drawing.Size(11, 12);
            this.lbCurrentNo.TabIndex = 7;
            this.lbCurrentNo.Text = "0";
            // 
            // lbCurrent
            // 
            this.lbCurrent.Location = new System.Drawing.Point(6, 77);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(199, 26);
            this.lbCurrent.TabIndex = 8;
            this.lbCurrent.Text = "lbCurrent";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 422);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(569, 461);
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "品牌词检查工具";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxKW;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Button btnStartCheck;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbCountResult;
        private System.Windows.Forms.Label lbCountKW;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.Label lbCurrentNo;
        private System.Windows.Forms.Label label1;
    }
}

