using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KClient
{
    public partial class FormSettings : Form
    {
        Settings settings = new Settings();

        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            settings.Load();

            textBox_OPC_URL.Text = settings.OPCServerURL;
            textBox_Ramp1.Text = settings.TagRamp1;
            textBox_Random1.Text = settings.TagRandom1;
            textBox_Sin1.Text = settings.TagSin1;

            textBox_Ramp2.Text = settings.TagRamp2;
            textBox_Random2.Text = settings.TagRandom2;
            textBox_Sin2.Text = settings.TagSin2;

            textBox_Ramp3.Text = settings.TagRamp3;
            textBox_Random3.Text = settings.TagRandom3;
            textBox_Sin3.Text = settings.TagSin3;

            textBox_Ramp4.Text = settings.TagRamp4;
            textBox_Random4.Text = settings.TagRandom4;
            textBox_Sin4.Text = settings.TagSin4;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            settings.OPCServerURL = textBox_OPC_URL.Text;
            settings.TagRamp1 = textBox_Ramp1.Text;
            settings.TagRandom1 = textBox_Random1.Text;
            settings.TagSin1 = textBox_Sin1.Text;
            settings.Save();
            DialogResult = DialogResult.OK;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox_OPC_URL_TextChanged(object sender, EventArgs e)
        {

        } 
    }
}
