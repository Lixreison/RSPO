﻿namespace KClient
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Settings = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.textBox_Ramp_1 = new System.Windows.Forms.TextBox();
            this.groupBox_Device_1 = new System.Windows.Forms.GroupBox();
            this.label_Sin_1 = new System.Windows.Forms.Label();
            this.label_Random_1 = new System.Windows.Forms.Label();
            this.textBox_Sin_1 = new System.Windows.Forms.TextBox();
            this.label_Ramp_1 = new System.Windows.Forms.Label();
            this.textBox_Random_1 = new System.Windows.Forms.TextBox();
            this.groupBox_Device_2 = new System.Windows.Forms.GroupBox();
            this.label_Sin_2 = new System.Windows.Forms.Label();
            this.label_Random_2 = new System.Windows.Forms.Label();
            this.textBox_Sin_2 = new System.Windows.Forms.TextBox();
            this.label_Ramp_2 = new System.Windows.Forms.Label();
            this.textBox_Random_2 = new System.Windows.Forms.TextBox();
            this.textBox_Ramp_2 = new System.Windows.Forms.TextBox();
            this.groupBox_Device_3 = new System.Windows.Forms.GroupBox();
            this.label_Sin_3 = new System.Windows.Forms.Label();
            this.label_Random_3 = new System.Windows.Forms.Label();
            this.textBox_Sin_3 = new System.Windows.Forms.TextBox();
            this.label_Ramp_3 = new System.Windows.Forms.Label();
            this.textBox_Random_3 = new System.Windows.Forms.TextBox();
            this.textBox_Ramp_3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Sin_4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Random_4 = new System.Windows.Forms.TextBox();
            this.textBox_Ramp_4 = new System.Windows.Forms.TextBox();
            this.button_Check_connection = new System.Windows.Forms.Button();
            this.label_server_state = new System.Windows.Forms.Label();
            this.opcPanel1 = new KClient.OPCPanel();
            this.opcPanel4 = new KClient.OPCPanel();
            this.opcPanel3 = new KClient.OPCPanel();
            this.opcPanel2 = new KClient.OPCPanel();
            this.groupBox_Device_1.SuspendLayout();
            this.groupBox_Device_2.SuspendLayout();
            this.groupBox_Device_3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(9, 429);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 0;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.Location = new System.Drawing.Point(90, 429);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(75, 23);
            this.button_Settings.TabIndex = 1;
            this.button_Settings.Text = "Settings";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(448, 429);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_Ramp_1
            // 
            this.textBox_Ramp_1.Location = new System.Drawing.Point(9, 36);
            this.textBox_Ramp_1.Name = "textBox_Ramp_1";
            this.textBox_Ramp_1.Size = new System.Drawing.Size(100, 20);
            this.textBox_Ramp_1.TabIndex = 3;
            // 
            // groupBox_Device_1
            // 
            this.groupBox_Device_1.Controls.Add(this.label_Sin_1);
            this.groupBox_Device_1.Controls.Add(this.label_Random_1);
            this.groupBox_Device_1.Controls.Add(this.textBox_Sin_1);
            this.groupBox_Device_1.Controls.Add(this.label_Ramp_1);
            this.groupBox_Device_1.Controls.Add(this.textBox_Random_1);
            this.groupBox_Device_1.Controls.Add(this.textBox_Ramp_1);
            this.groupBox_Device_1.Location = new System.Drawing.Point(12, 10);
            this.groupBox_Device_1.Name = "groupBox_Device_1";
            this.groupBox_Device_1.Size = new System.Drawing.Size(124, 151);
            this.groupBox_Device_1.TabIndex = 4;
            this.groupBox_Device_1.TabStop = false;
            this.groupBox_Device_1.Text = "Device 1";
            // 
            // label_Sin_1
            // 
            this.label_Sin_1.AutoSize = true;
            this.label_Sin_1.Location = new System.Drawing.Point(6, 99);
            this.label_Sin_1.Name = "label_Sin_1";
            this.label_Sin_1.Size = new System.Drawing.Size(31, 13);
            this.label_Sin_1.TabIndex = 7;
            this.label_Sin_1.Text = "Sin 1";
            // 
            // label_Random_1
            // 
            this.label_Random_1.AutoSize = true;
            this.label_Random_1.Location = new System.Drawing.Point(6, 59);
            this.label_Random_1.Name = "label_Random_1";
            this.label_Random_1.Size = new System.Drawing.Size(56, 13);
            this.label_Random_1.TabIndex = 7;
            this.label_Random_1.Text = "Random 1";
            // 
            // textBox_Sin_1
            // 
            this.textBox_Sin_1.Location = new System.Drawing.Point(9, 115);
            this.textBox_Sin_1.Name = "textBox_Sin_1";
            this.textBox_Sin_1.Size = new System.Drawing.Size(100, 20);
            this.textBox_Sin_1.TabIndex = 6;
            // 
            // label_Ramp_1
            // 
            this.label_Ramp_1.AutoSize = true;
            this.label_Ramp_1.Location = new System.Drawing.Point(6, 20);
            this.label_Ramp_1.Name = "label_Ramp_1";
            this.label_Ramp_1.Size = new System.Drawing.Size(44, 13);
            this.label_Ramp_1.TabIndex = 5;
            this.label_Ramp_1.Text = "Ramp 1";
            // 
            // textBox_Random_1
            // 
            this.textBox_Random_1.Location = new System.Drawing.Point(9, 75);
            this.textBox_Random_1.Name = "textBox_Random_1";
            this.textBox_Random_1.Size = new System.Drawing.Size(100, 20);
            this.textBox_Random_1.TabIndex = 6;
            // 
            // groupBox_Device_2
            // 
            this.groupBox_Device_2.Controls.Add(this.label_Sin_2);
            this.groupBox_Device_2.Controls.Add(this.label_Random_2);
            this.groupBox_Device_2.Controls.Add(this.textBox_Sin_2);
            this.groupBox_Device_2.Controls.Add(this.label_Ramp_2);
            this.groupBox_Device_2.Controls.Add(this.textBox_Random_2);
            this.groupBox_Device_2.Controls.Add(this.textBox_Ramp_2);
            this.groupBox_Device_2.Location = new System.Drawing.Point(142, 10);
            this.groupBox_Device_2.Name = "groupBox_Device_2";
            this.groupBox_Device_2.Size = new System.Drawing.Size(124, 151);
            this.groupBox_Device_2.TabIndex = 5;
            this.groupBox_Device_2.TabStop = false;
            this.groupBox_Device_2.Text = "Device 2";
            // 
            // label_Sin_2
            // 
            this.label_Sin_2.AutoSize = true;
            this.label_Sin_2.Location = new System.Drawing.Point(6, 99);
            this.label_Sin_2.Name = "label_Sin_2";
            this.label_Sin_2.Size = new System.Drawing.Size(31, 13);
            this.label_Sin_2.TabIndex = 7;
            this.label_Sin_2.Text = "Sin 2";
            // 
            // label_Random_2
            // 
            this.label_Random_2.AutoSize = true;
            this.label_Random_2.Location = new System.Drawing.Point(6, 59);
            this.label_Random_2.Name = "label_Random_2";
            this.label_Random_2.Size = new System.Drawing.Size(56, 13);
            this.label_Random_2.TabIndex = 7;
            this.label_Random_2.Text = "Random 2";
            // 
            // textBox_Sin_2
            // 
            this.textBox_Sin_2.Location = new System.Drawing.Point(9, 115);
            this.textBox_Sin_2.Name = "textBox_Sin_2";
            this.textBox_Sin_2.Size = new System.Drawing.Size(100, 20);
            this.textBox_Sin_2.TabIndex = 6;
            // 
            // label_Ramp_2
            // 
            this.label_Ramp_2.AutoSize = true;
            this.label_Ramp_2.Location = new System.Drawing.Point(6, 20);
            this.label_Ramp_2.Name = "label_Ramp_2";
            this.label_Ramp_2.Size = new System.Drawing.Size(44, 13);
            this.label_Ramp_2.TabIndex = 5;
            this.label_Ramp_2.Text = "Ramp 2";
            // 
            // textBox_Random_2
            // 
            this.textBox_Random_2.Location = new System.Drawing.Point(9, 75);
            this.textBox_Random_2.Name = "textBox_Random_2";
            this.textBox_Random_2.Size = new System.Drawing.Size(100, 20);
            this.textBox_Random_2.TabIndex = 6;
            // 
            // textBox_Ramp_2
            // 
            this.textBox_Ramp_2.Location = new System.Drawing.Point(9, 36);
            this.textBox_Ramp_2.Name = "textBox_Ramp_2";
            this.textBox_Ramp_2.Size = new System.Drawing.Size(100, 20);
            this.textBox_Ramp_2.TabIndex = 3;
            // 
            // groupBox_Device_3
            // 
            this.groupBox_Device_3.Controls.Add(this.label_Sin_3);
            this.groupBox_Device_3.Controls.Add(this.label_Random_3);
            this.groupBox_Device_3.Controls.Add(this.textBox_Sin_3);
            this.groupBox_Device_3.Controls.Add(this.label_Ramp_3);
            this.groupBox_Device_3.Controls.Add(this.textBox_Random_3);
            this.groupBox_Device_3.Controls.Add(this.textBox_Ramp_3);
            this.groupBox_Device_3.Location = new System.Drawing.Point(272, 10);
            this.groupBox_Device_3.Name = "groupBox_Device_3";
            this.groupBox_Device_3.Size = new System.Drawing.Size(124, 151);
            this.groupBox_Device_3.TabIndex = 6;
            this.groupBox_Device_3.TabStop = false;
            this.groupBox_Device_3.Text = "Device 3";
            // 
            // label_Sin_3
            // 
            this.label_Sin_3.AutoSize = true;
            this.label_Sin_3.Location = new System.Drawing.Point(6, 99);
            this.label_Sin_3.Name = "label_Sin_3";
            this.label_Sin_3.Size = new System.Drawing.Size(31, 13);
            this.label_Sin_3.TabIndex = 7;
            this.label_Sin_3.Text = "Sin 3";
            // 
            // label_Random_3
            // 
            this.label_Random_3.AutoSize = true;
            this.label_Random_3.Location = new System.Drawing.Point(6, 59);
            this.label_Random_3.Name = "label_Random_3";
            this.label_Random_3.Size = new System.Drawing.Size(56, 13);
            this.label_Random_3.TabIndex = 7;
            this.label_Random_3.Text = "Random 3";
            // 
            // textBox_Sin_3
            // 
            this.textBox_Sin_3.Location = new System.Drawing.Point(9, 115);
            this.textBox_Sin_3.Name = "textBox_Sin_3";
            this.textBox_Sin_3.Size = new System.Drawing.Size(100, 20);
            this.textBox_Sin_3.TabIndex = 6;
            // 
            // label_Ramp_3
            // 
            this.label_Ramp_3.AutoSize = true;
            this.label_Ramp_3.Location = new System.Drawing.Point(6, 20);
            this.label_Ramp_3.Name = "label_Ramp_3";
            this.label_Ramp_3.Size = new System.Drawing.Size(44, 13);
            this.label_Ramp_3.TabIndex = 5;
            this.label_Ramp_3.Text = "Ramp 3";
            // 
            // textBox_Random_3
            // 
            this.textBox_Random_3.Location = new System.Drawing.Point(9, 75);
            this.textBox_Random_3.Name = "textBox_Random_3";
            this.textBox_Random_3.Size = new System.Drawing.Size(100, 20);
            this.textBox_Random_3.TabIndex = 6;
            // 
            // textBox_Ramp_3
            // 
            this.textBox_Ramp_3.Location = new System.Drawing.Point(9, 36);
            this.textBox_Ramp_3.Name = "textBox_Ramp_3";
            this.textBox_Ramp_3.Size = new System.Drawing.Size(100, 20);
            this.textBox_Ramp_3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Sin_4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Random_4);
            this.groupBox1.Controls.Add(this.textBox_Ramp_4);
            this.groupBox1.Location = new System.Drawing.Point(402, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 151);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device 4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sin 4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Random 4";
            // 
            // textBox_Sin_4
            // 
            this.textBox_Sin_4.Location = new System.Drawing.Point(9, 115);
            this.textBox_Sin_4.Name = "textBox_Sin_4";
            this.textBox_Sin_4.Size = new System.Drawing.Size(100, 20);
            this.textBox_Sin_4.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ramp 4";
            // 
            // textBox_Random_4
            // 
            this.textBox_Random_4.Location = new System.Drawing.Point(9, 75);
            this.textBox_Random_4.Name = "textBox_Random_4";
            this.textBox_Random_4.Size = new System.Drawing.Size(100, 20);
            this.textBox_Random_4.TabIndex = 6;
            // 
            // textBox_Ramp_4
            // 
            this.textBox_Ramp_4.Location = new System.Drawing.Point(9, 36);
            this.textBox_Ramp_4.Name = "textBox_Ramp_4";
            this.textBox_Ramp_4.Size = new System.Drawing.Size(100, 20);
            this.textBox_Ramp_4.TabIndex = 3;
            // 
            // button_Check_connection
            // 
            this.button_Check_connection.Location = new System.Drawing.Point(171, 429);
            this.button_Check_connection.Name = "button_Check_connection";
            this.button_Check_connection.Size = new System.Drawing.Size(107, 23);
            this.button_Check_connection.TabIndex = 8;
            this.button_Check_connection.Text = "Check connection";
            this.button_Check_connection.UseVisualStyleBackColor = true;
            this.button_Check_connection.Click += new System.EventHandler(this.button_Check_connection_Click);
            // 
            // label_server_state
            // 
            this.label_server_state.AutoSize = true;
            this.label_server_state.Location = new System.Drawing.Point(12, 413);
            this.label_server_state.Name = "label_server_state";
            this.label_server_state.Size = new System.Drawing.Size(93, 13);
            this.label_server_state.TabIndex = 9;
            this.label_server_state.Text = "label_server_state";
            // 
            // opcPanel1
            // 
            this.opcPanel1.Location = new System.Drawing.Point(6, 167);
            this.opcPanel1.Name = "opcPanel1";
            this.opcPanel1.PanelTitle = null;
            this.opcPanel1.RampTitle = null;
            this.opcPanel1.RampValue = 0D;
            this.opcPanel1.RandomTitle = null;
            this.opcPanel1.RandomValue = 0D;
            this.opcPanel1.SinTitle = null;
            this.opcPanel1.SinValue = 0D;
            this.opcPanel1.Size = new System.Drawing.Size(130, 242);
            this.opcPanel1.TabIndex = 14;
            // 
            // opcPanel4
            // 
            this.opcPanel4.Location = new System.Drawing.Point(402, 167);
            this.opcPanel4.Name = "opcPanel4";
            this.opcPanel4.PanelTitle = null;
            this.opcPanel4.RampTitle = null;
            this.opcPanel4.RampValue = 0D;
            this.opcPanel4.RandomTitle = null;
            this.opcPanel4.RandomValue = 0D;
            this.opcPanel4.SinTitle = null;
            this.opcPanel4.SinValue = 0D;
            this.opcPanel4.Size = new System.Drawing.Size(130, 242);
            this.opcPanel4.TabIndex = 13;
            // 
            // opcPanel3
            // 
            this.opcPanel3.Location = new System.Drawing.Point(272, 167);
            this.opcPanel3.Name = "opcPanel3";
            this.opcPanel3.PanelTitle = null;
            this.opcPanel3.RampTitle = null;
            this.opcPanel3.RampValue = 0D;
            this.opcPanel3.RandomTitle = null;
            this.opcPanel3.RandomValue = 0D;
            this.opcPanel3.SinTitle = null;
            this.opcPanel3.SinValue = 0D;
            this.opcPanel3.Size = new System.Drawing.Size(130, 242);
            this.opcPanel3.TabIndex = 12;
            // 
            // opcPanel2
            // 
            this.opcPanel2.Location = new System.Drawing.Point(142, 167);
            this.opcPanel2.Name = "opcPanel2";
            this.opcPanel2.PanelTitle = null;
            this.opcPanel2.RampTitle = null;
            this.opcPanel2.RampValue = 0D;
            this.opcPanel2.RandomTitle = null;
            this.opcPanel2.RandomValue = 0D;
            this.opcPanel2.SinTitle = null;
            this.opcPanel2.SinValue = 0D;
            this.opcPanel2.Size = new System.Drawing.Size(130, 242);
            this.opcPanel2.TabIndex = 11;
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(538, 456);
            this.Controls.Add(this.opcPanel1);
            this.Controls.Add(this.opcPanel4);
            this.Controls.Add(this.opcPanel3);
            this.Controls.Add(this.opcPanel2);
            this.Controls.Add(this.label_server_state);
            this.Controls.Add(this.button_Check_connection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Device_3);
            this.Controls.Add(this.groupBox_Device_2);
            this.Controls.Add(this.groupBox_Device_1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Settings);
            this.Controls.Add(this.button_Connect);
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KepServer: list of devices";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Device_1.ResumeLayout(false);
            this.groupBox_Device_1.PerformLayout();
            this.groupBox_Device_2.ResumeLayout(false);
            this.groupBox_Device_2.PerformLayout();
            this.groupBox_Device_3.ResumeLayout(false);
            this.groupBox_Device_3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Settings;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TextBox textBox_Ramp_1;
        private System.Windows.Forms.GroupBox groupBox_Device_1;
        private System.Windows.Forms.Label label_Sin_1;
        private System.Windows.Forms.Label label_Random_1;
        private System.Windows.Forms.TextBox textBox_Sin_1;
        private System.Windows.Forms.Label label_Ramp_1;
        private System.Windows.Forms.TextBox textBox_Random_1;
        private System.Windows.Forms.GroupBox groupBox_Device_2;
        private System.Windows.Forms.Label label_Sin_2;
        private System.Windows.Forms.Label label_Random_2;
        private System.Windows.Forms.TextBox textBox_Sin_2;
        private System.Windows.Forms.Label label_Ramp_2;
        private System.Windows.Forms.TextBox textBox_Random_2;
        private System.Windows.Forms.TextBox textBox_Ramp_2;
        private System.Windows.Forms.GroupBox groupBox_Device_3;
        private System.Windows.Forms.Label label_Sin_3;
        private System.Windows.Forms.Label label_Random_3;
        private System.Windows.Forms.TextBox textBox_Sin_3;
        private System.Windows.Forms.Label label_Ramp_3;
        private System.Windows.Forms.TextBox textBox_Random_3;
        private System.Windows.Forms.TextBox textBox_Ramp_3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Sin_4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Random_4;
        private System.Windows.Forms.TextBox textBox_Ramp_4;
        private System.Windows.Forms.Button button_Check_connection;
        private System.Windows.Forms.Label label_server_state;
        private OPCPanel opcPanel2;
        private OPCPanel opcPanel3;
        private OPCPanel opcPanel4;
        private OPCPanel opcPanel1;
    }
}

