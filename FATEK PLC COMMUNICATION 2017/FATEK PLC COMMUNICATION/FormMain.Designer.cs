namespace IndustrialNetworks.FatekApp
{
    partial class FormMain
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
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnY2ToY5ON = new System.Windows.Forms.Button();
            this.btnY2ToY5OFF = new System.Windows.Forms.Button();
            this.btnSetY2 = new System.Windows.Forms.Button();
            this.btnResetY2 = new System.Windows.Forms.Button();
            this.btnM0ToM15ON = new System.Windows.Forms.Button();
            this.btnM0ToM15OFF = new System.Windows.Forms.Button();
            this.btnReadDiscretes = new System.Windows.Forms.Button();
            this.btnReadRegisters = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.btnWriteRegisters = new System.Windows.Forms.Button();
            this.btnGetPLCStatus = new System.Windows.Forms.Button();
            this.btnGetPLCInfo = new System.Windows.Forms.Button();
            this.btnReadM32ToM47 = new System.Windows.Forms.Button();
            this.btnReadRandomRegisters = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(6, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(111, 46);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 58);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(111, 46);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnY2ToY5ON
            // 
            this.btnY2ToY5ON.Location = new System.Drawing.Point(270, 6);
            this.btnY2ToY5ON.Name = "btnY2ToY5ON";
            this.btnY2ToY5ON.Size = new System.Drawing.Size(115, 46);
            this.btnY2ToY5ON.TabIndex = 1;
            this.btnY2ToY5ON.Text = "Y2 --> Y5 ON";
            this.btnY2ToY5ON.UseVisualStyleBackColor = true;
            this.btnY2ToY5ON.Click += new System.EventHandler(this.btnY2ToY5ON_Click);
            // 
            // btnY2ToY5OFF
            // 
            this.btnY2ToY5OFF.Location = new System.Drawing.Point(270, 58);
            this.btnY2ToY5OFF.Name = "btnY2ToY5OFF";
            this.btnY2ToY5OFF.Size = new System.Drawing.Size(115, 46);
            this.btnY2ToY5OFF.TabIndex = 1;
            this.btnY2ToY5OFF.Text = "Y2 --> Y5 OFF";
            this.btnY2ToY5OFF.UseVisualStyleBackColor = true;
            this.btnY2ToY5OFF.Click += new System.EventHandler(this.btnY2ToY5OFF_Click);
            // 
            // btnSetY2
            // 
            this.btnSetY2.Location = new System.Drawing.Point(391, 6);
            this.btnSetY2.Name = "btnSetY2";
            this.btnSetY2.Size = new System.Drawing.Size(81, 46);
            this.btnSetY2.TabIndex = 2;
            this.btnSetY2.Text = "Y2 ON";
            this.btnSetY2.UseVisualStyleBackColor = true;
            this.btnSetY2.Click += new System.EventHandler(this.btnSetY2_Click);
            // 
            // btnResetY2
            // 
            this.btnResetY2.Location = new System.Drawing.Point(391, 58);
            this.btnResetY2.Name = "btnResetY2";
            this.btnResetY2.Size = new System.Drawing.Size(81, 46);
            this.btnResetY2.TabIndex = 2;
            this.btnResetY2.Text = "Y2 OFF";
            this.btnResetY2.UseVisualStyleBackColor = true;
            this.btnResetY2.Click += new System.EventHandler(this.btnResetY2_Click);
            // 
            // btnM0ToM15ON
            // 
            this.btnM0ToM15ON.Location = new System.Drawing.Point(478, 6);
            this.btnM0ToM15ON.Name = "btnM0ToM15ON";
            this.btnM0ToM15ON.Size = new System.Drawing.Size(115, 46);
            this.btnM0ToM15ON.TabIndex = 1;
            this.btnM0ToM15ON.Text = "M32 --> M47 ON";
            this.btnM0ToM15ON.UseVisualStyleBackColor = true;
            this.btnM0ToM15ON.Click += new System.EventHandler(this.btnM0ToM15ON_Click);
            // 
            // btnM0ToM15OFF
            // 
            this.btnM0ToM15OFF.Location = new System.Drawing.Point(478, 58);
            this.btnM0ToM15OFF.Name = "btnM0ToM15OFF";
            this.btnM0ToM15OFF.Size = new System.Drawing.Size(115, 46);
            this.btnM0ToM15OFF.TabIndex = 1;
            this.btnM0ToM15OFF.Text = "M32 --> M47 OFF";
            this.btnM0ToM15OFF.UseVisualStyleBackColor = true;
            this.btnM0ToM15OFF.Click += new System.EventHandler(this.btnM0ToM15OFF_Click);
            // 
            // btnReadDiscretes
            // 
            this.btnReadDiscretes.Location = new System.Drawing.Point(599, 59);
            this.btnReadDiscretes.Name = "btnReadDiscretes";
            this.btnReadDiscretes.Size = new System.Drawing.Size(160, 46);
            this.btnReadDiscretes.TabIndex = 3;
            this.btnReadDiscretes.Text = "Read Discretes:  Y0 --> Y15";
            this.btnReadDiscretes.UseVisualStyleBackColor = true;
            this.btnReadDiscretes.Click += new System.EventHandler(this.btnReadDiscretes_Click);
            // 
            // btnReadRegisters
            // 
            this.btnReadRegisters.Location = new System.Drawing.Point(765, 6);
            this.btnReadRegisters.Name = "btnReadRegisters";
            this.btnReadRegisters.Size = new System.Drawing.Size(178, 46);
            this.btnReadRegisters.TabIndex = 3;
            this.btnReadRegisters.Text = "Read Registers: WM32 --> WM37";
            this.btnReadRegisters.UseVisualStyleBackColor = true;
            this.btnReadRegisters.Click += new System.EventHandler(this.btnReadRegisters_Click);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.Black;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.Lime;
            this.txtResult.Location = new System.Drawing.Point(7, 108);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(937, 331);
            this.txtResult.TabIndex = 4;
            this.txtResult.Text = "";
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(6, 445);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(142, 35);
            this.btnClearResult.TabIndex = 3;
            this.btnClearResult.Text = "CLEAR RESULT";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // btnWriteRegisters
            // 
            this.btnWriteRegisters.Location = new System.Drawing.Point(765, 59);
            this.btnWriteRegisters.Name = "btnWriteRegisters";
            this.btnWriteRegisters.Size = new System.Drawing.Size(178, 44);
            this.btnWriteRegisters.TabIndex = 3;
            this.btnWriteRegisters.Text = "Write Registers: WM32 --> WM37";
            this.btnWriteRegisters.UseVisualStyleBackColor = true;
            this.btnWriteRegisters.Click += new System.EventHandler(this.btnWriteRegisters_Click);
            // 
            // btnGetPLCStatus
            // 
            this.btnGetPLCStatus.Location = new System.Drawing.Point(123, 7);
            this.btnGetPLCStatus.Name = "btnGetPLCStatus";
            this.btnGetPLCStatus.Size = new System.Drawing.Size(139, 45);
            this.btnGetPLCStatus.TabIndex = 0;
            this.btnGetPLCStatus.Text = "GET PLC STATUS";
            this.btnGetPLCStatus.UseVisualStyleBackColor = true;
            this.btnGetPLCStatus.Click += new System.EventHandler(this.btnGetPLCStatus_Click);
            // 
            // btnGetPLCInfo
            // 
            this.btnGetPLCInfo.Location = new System.Drawing.Point(123, 58);
            this.btnGetPLCInfo.Name = "btnGetPLCInfo";
            this.btnGetPLCInfo.Size = new System.Drawing.Size(139, 45);
            this.btnGetPLCInfo.TabIndex = 0;
            this.btnGetPLCInfo.Text = "GET PLC INFO";
            this.btnGetPLCInfo.UseVisualStyleBackColor = true;
            this.btnGetPLCInfo.Click += new System.EventHandler(this.btnGetPLCInfo_Click);
            // 
            // btnReadM32ToM47
            // 
            this.btnReadM32ToM47.Location = new System.Drawing.Point(599, 7);
            this.btnReadM32ToM47.Name = "btnReadM32ToM47";
            this.btnReadM32ToM47.Size = new System.Drawing.Size(160, 45);
            this.btnReadM32ToM47.TabIndex = 1;
            this.btnReadM32ToM47.Text = "Read Discretes: M32 --> M47";
            this.btnReadM32ToM47.UseVisualStyleBackColor = true;
            this.btnReadM32ToM47.Click += new System.EventHandler(this.btnReadM32ToM47_Click);
            // 
            // btnReadRandomRegisters
            // 
            this.btnReadRandomRegisters.Location = new System.Drawing.Point(167, 445);
            this.btnReadRandomRegisters.Name = "btnReadRandomRegisters";
            this.btnReadRandomRegisters.Size = new System.Drawing.Size(157, 35);
            this.btnReadRandomRegisters.TabIndex = 5;
            this.btnReadRandomRegisters.Text = "Read Random Registers";
            this.btnReadRandomRegisters.UseVisualStyleBackColor = true;
            this.btnReadRandomRegisters.Click += new System.EventHandler(this.btnReadRandomRegisters_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 445);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Write Random Registers";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 485);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnReadRandomRegisters);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnClearResult);
            this.Controls.Add(this.btnWriteRegisters);
            this.Controls.Add(this.btnReadRegisters);
            this.Controls.Add(this.btnReadDiscretes);
            this.Controls.Add(this.btnResetY2);
            this.Controls.Add(this.btnSetY2);
            this.Controls.Add(this.btnReadM32ToM47);
            this.Controls.Add(this.btnM0ToM15OFF);
            this.Controls.Add(this.btnM0ToM15ON);
            this.Controls.Add(this.btnY2ToY5OFF);
            this.Controls.Add(this.btnY2ToY5ON);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnGetPLCInfo);
            this.Controls.Add(this.btnGetPLCStatus);
            this.Controls.Add(this.btnRun);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "FATEK PLC COMMUNICATION PROTOCOL WITH VISUAL C#";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnY2ToY5ON;
        private System.Windows.Forms.Button btnY2ToY5OFF;
        private System.Windows.Forms.Button btnSetY2;
        private System.Windows.Forms.Button btnResetY2;
        private System.Windows.Forms.Button btnM0ToM15ON;
        private System.Windows.Forms.Button btnM0ToM15OFF;
        private System.Windows.Forms.Button btnReadDiscretes;
        private System.Windows.Forms.Button btnReadRegisters;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Button btnWriteRegisters;
        private System.Windows.Forms.Button btnGetPLCStatus;
        private System.Windows.Forms.Button btnGetPLCInfo;
        private System.Windows.Forms.Button btnReadM32ToM47;
        private System.Windows.Forms.Button btnReadRandomRegisters;
        private System.Windows.Forms.Button button2;
    }
}

