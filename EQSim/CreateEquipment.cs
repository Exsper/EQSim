using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQSim
{
    public partial class CreateEquipment : Form
    {
        public CreateEquipment()
        {
            InitializeComponent();
        }

        private MyInvoke mi = null;
        public CreateEquipment(MyInvoke myInvoke)
        {
            InitializeComponent();
            this.mi = myInvoke;
        }


        private void CreateEquipment_Load(object sender, EventArgs e)
        {
            SetComboBox.SelectedIndex = 1;
            TypeComboBox.SelectedIndex = 0;
            QualityComboBox.SelectedIndex = 5;
            Parameter1ComboBox.SelectedIndex = 0;
            Parameter2ComboBox.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            int set = SetComboBox.SelectedIndex - 1;
            int type = TypeComboBox.SelectedIndex - 1;
            int quality = QualityComboBox.SelectedIndex - 1;
            int p1 = Parameter1ComboBox.SelectedIndex - 1;
            int p2 = Parameter2ComboBox.SelectedIndex - 1;
            int v1;
            int v2;

            if (RandomValue1CheckBox.Checked == true)
            {
                v1 = -1;
            }
            else
            {
                try
                {
                    v1 = Convert.ToInt32(Convert.ToDouble(Value1TextBox.Text) * 100);
                }
                catch
                {
                    v1 = -1;
                    Log.LogInfo("属性1的值填写错误");
                }
            }

            if (RandomValue2CheckBox.Checked == true)
            {
                v2 = -1;
            }
            else
            {
                try
                {
                    v2 = Convert.ToInt32(Convert.ToDouble(Value2TextBox.Text) * 100);
                }
                catch
                {
                    v2 = -1;
                    Log.LogInfo("属性2的值填写错误");
                }
            }

            this.mi(set, type, quality, p1, v1, p2, v2);
        }

        private void RandomValue1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomValue1CheckBox.Checked== true)
            {
                Value1TextBox.Enabled = false;
            }
            else
            {
                Value1TextBox.Enabled = true;
            }
        }

        private void RandomValue2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomValue2CheckBox.Checked == true)
            {
                Value2TextBox.Enabled = false;
            }
            else
            {
                Value2TextBox.Enabled = true;
            }
        }
    }
}
