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
            SetComboBox.SelectedIndex = 0;
            TypeComboBox.SelectedIndex = 0;
            QualityComboBox.SelectedIndex = 5;
            Parameter1ComboBox.SelectedIndex = 0;
            Parameter2ComboBox.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.mi(SetComboBox.SelectedIndex, TypeComboBox.SelectedIndex, QualityComboBox.SelectedIndex, Parameter1ComboBox.SelectedIndex, Convert.ToInt32(Convert.ToDouble(Value1TextBox.Text)*100), Parameter2ComboBox.SelectedIndex, Convert.ToInt32(Convert.ToDouble(Value2TextBox.Text) * 100));
        }
    }
}
