namespace SerialCom_Exer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbComPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.rchTxtBoxRcvMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cbComPorts
            // 
            this.cbComPorts.FormattingEnabled = true;
            this.cbComPorts.Location = new System.Drawing.Point(74, 36);
            this.cbComPorts.Name = "cbComPorts";
            this.cbComPorts.Size = new System.Drawing.Size(172, 23);
            this.cbComPorts.TabIndex = 0;
            this.cbComPorts.DropDown += new System.EventHandler(this.cbComPorts_DropDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(306, 36);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Location = new System.Drawing.Point(74, 97);
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.Size = new System.Drawing.Size(172, 25);
            this.txtBoxSend.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(306, 99);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rchTxtBoxRcvMsg
            // 
            this.rchTxtBoxRcvMsg.Location = new System.Drawing.Point(74, 160);
            this.rchTxtBoxRcvMsg.Name = "rchTxtBoxRcvMsg";
            this.rchTxtBoxRcvMsg.Size = new System.Drawing.Size(696, 336);
            this.rchTxtBoxRcvMsg.TabIndex = 4;
            this.rchTxtBoxRcvMsg.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 522);
            this.Controls.Add(this.rchTxtBoxRcvMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtBoxSend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbComPorts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbComPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtBoxSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rchTxtBoxRcvMsg;
    }
}

