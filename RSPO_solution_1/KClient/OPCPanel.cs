using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KClient
{
    public partial class OPCPanel : UserControl
    {
        private String PanelTitle_;
        private String RampTitle_;
        private String SinTitle_;
        private String RandomTitle_;

        private Double RampValue_;
        private Double SinValue_;
        private Double RandomValue_;

        private IndicatorType Indicator_;

        public IndicatorType Indicator
        {
            set
            {
                Indicator_ = value;
                switch (Indicator_)
                {
                    case IndicatorType.Red:
                        pictureBox1.Image = Resources.red_square;
                        break;
                    case IndicatorType.Blue:
                        pictureBox1.Image = Resources.blue_square;
                        break;
                }
            }
        }

        public DataPointCollection SinChartPoint
        {
            get { return chart.Series[0].Points; }
        }
        public DataPointCollection RampChartPoint
        {
            get { return chart.Series[1].Points; }
        }
        public DataPointCollection RandomChartPoint
        {
            get { return chart.Series[2].Points; }
        }

        public Double RampValue
        {
            get { return RampValue_; }
            set
            {
                RampValue_ = value;
                textBox_Ramp.Text = RampValue_.ToString("0.00");
            }
        }
        public Double SinValue
        {
            get { return SinValue_; }
            set
            {
                SinValue_ = value;
                textBox_Sin.Text = SinValue_.ToString("0.00");
            }
        }
        public Double RandomValue
        {
            get { return RandomValue_; }
            set
            {
                RandomValue_ = value;
                textBox_Random.Text = RandomValue_.ToString("0.00");
            }
        }

        public String PanelTitle
        {
            get { return PanelTitle_; }
            set
            {
                PanelTitle_ = value;
                groupBox_Device.Text = PanelTitle_;
            }
        }

        public String RampTitle
        {
            get { return RampTitle_; }
            set
            {
                RampTitle_ = value;
                label_Ramp.Text = RampTitle_;
            }
        }

        public String SinTitle
        {
            get { return SinTitle_; }
            set
            {
                SinTitle_ = value;
                label_Sin.Text = SinTitle_;
            }
        }

        public String RandomTitle
        {
            get { return RandomTitle_; }
            set
            {
                RandomTitle_ = value;
                label_Random.Text = RandomTitle_;
            }
        }

        public OPCPanel()
        {
            InitializeComponent();
        }    
    }
}
