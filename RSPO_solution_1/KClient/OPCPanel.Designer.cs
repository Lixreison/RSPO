namespace KClient
{
    partial class OPCPanel
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox_Device = new System.Windows.Forms.GroupBox();
            this.label_Sin = new System.Windows.Forms.Label();
            this.label_Random = new System.Windows.Forms.Label();
            this.textBox_Sin = new System.Windows.Forms.TextBox();
            this.label_Ramp = new System.Windows.Forms.Label();
            this.textBox_Random = new System.Windows.Forms.TextBox();
            this.textBox_Ramp = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_Device.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Device
            // 
            this.groupBox_Device.Controls.Add(this.pictureBox1);
            this.groupBox_Device.Controls.Add(this.label_Sin);
            this.groupBox_Device.Controls.Add(this.label_Random);
            this.groupBox_Device.Controls.Add(this.textBox_Sin);
            this.groupBox_Device.Controls.Add(this.label_Ramp);
            this.groupBox_Device.Controls.Add(this.textBox_Random);
            this.groupBox_Device.Controls.Add(this.textBox_Ramp);
            this.groupBox_Device.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Device.Name = "groupBox_Device";
            this.groupBox_Device.Size = new System.Drawing.Size(124, 234);
            this.groupBox_Device.TabIndex = 5;
            this.groupBox_Device.TabStop = false;
            this.groupBox_Device.Text = "Device";
            this.groupBox_Device.Enter += new System.EventHandler(this.groupBox_Device_Enter);
            // 
            // label_Sin
            // 
            this.label_Sin.AutoSize = true;
            this.label_Sin.Location = new System.Drawing.Point(6, 99);
            this.label_Sin.Name = "label_Sin";
            this.label_Sin.Size = new System.Drawing.Size(22, 13);
            this.label_Sin.TabIndex = 7;
            this.label_Sin.Text = "Sin";
            // 
            // label_Random
            // 
            this.label_Random.AutoSize = true;
            this.label_Random.Location = new System.Drawing.Point(6, 59);
            this.label_Random.Name = "label_Random";
            this.label_Random.Size = new System.Drawing.Size(47, 13);
            this.label_Random.TabIndex = 7;
            this.label_Random.Text = "Random";
            // 
            // textBox_Sin
            // 
            this.textBox_Sin.Location = new System.Drawing.Point(9, 115);
            this.textBox_Sin.Name = "textBox_Sin";
            this.textBox_Sin.Size = new System.Drawing.Size(100, 20);
            this.textBox_Sin.TabIndex = 6;
            // 
            // label_Ramp
            // 
            this.label_Ramp.AutoSize = true;
            this.label_Ramp.Location = new System.Drawing.Point(6, 20);
            this.label_Ramp.Name = "label_Ramp";
            this.label_Ramp.Size = new System.Drawing.Size(35, 13);
            this.label_Ramp.TabIndex = 5;
            this.label_Ramp.Text = "Ramp";
            // 
            // textBox_Random
            // 
            this.textBox_Random.Location = new System.Drawing.Point(9, 75);
            this.textBox_Random.Name = "textBox_Random";
            this.textBox_Random.Size = new System.Drawing.Size(100, 20);
            this.textBox_Random.TabIndex = 6;
            // 
            // textBox_Ramp
            // 
            this.textBox_Ramp.Location = new System.Drawing.Point(9, 36);
            this.textBox_Ramp.Name = "textBox_Ramp";
            this.textBox_Ramp.Size = new System.Drawing.Size(100, 20);
            this.textBox_Ramp.TabIndex = 3;
            this.textBox_Ramp.TextChanged += new System.EventHandler(this.textBox_Ramp_TextChanged);
            // 
            // chart
            // 
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Location = new System.Drawing.Point(3, 160);
            this.chart.Name = "chart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series2";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series3";
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Series.Add(series6);
            this.chart.Size = new System.Drawing.Size(121, 77);
            this.chart.TabIndex = 15;
            this.chart.Text = "chart";
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(94, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 14);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // OPCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart);
            this.Controls.Add(this.groupBox_Device);
            this.Name = "OPCPanel";
            this.Size = new System.Drawing.Size(130, 238);
            this.groupBox_Device.ResumeLayout(false);
            this.groupBox_Device.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Device;
        private System.Windows.Forms.Label label_Sin;
        private System.Windows.Forms.Label label_Random;
        private System.Windows.Forms.TextBox textBox_Sin;
        private System.Windows.Forms.Label label_Ramp;
        private System.Windows.Forms.TextBox textBox_Random;
        private System.Windows.Forms.TextBox textBox_Ramp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
