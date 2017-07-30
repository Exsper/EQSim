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
    public delegate void MyInvoke(int set, int type, int quality, int sp1, int sv1, int sp2, int sv2);

    public partial class Form1 : Form
    {
        public static Form1 f = null;
        public Form1()
        {
            InitializeComponent();
            f = this;
        }

        private void IniMilitaryRank()
        {
            for (int i = 0; i < GlobalSpace.militaryRankName.Length; i++)
            {
                MilitaryRankComboBox.Items.Add(GlobalSpace.militaryRankName[i]);
            }
        }


        private void UpdateWearedEquipment()
        {
            EquipedCheckedListBox.Items.Clear();
            if (GlobalSpace.equipedHelmet != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedHelmet);
            if (GlobalSpace.equipedVision != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedVision);
            if (GlobalSpace.equipedArmor != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedArmor);
            if (GlobalSpace.equipedPants != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedPants);
            if (GlobalSpace.equipedShoes != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedShoes);
            if (GlobalSpace.equipedWeapon != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedWeapon);
            if (GlobalSpace.equipedOffhand != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedOffhand);
            if (GlobalSpace.equipedLuckycharm != null) EquipedCheckedListBox.Items.Add(GlobalSpace.equipedLuckycharm);
        }

        private void UpdateState()
        {
            StateTextBox.Text = EquipmentOperation.UpdateState(Convert.ToInt32(StrengthNumericUpDown.Value), MilitaryRankComboBox.SelectedIndex);
        }

        private void UpdateStorage()
        {
            StorageCheckedListBox.Items.Clear();
            if (GlobalSpace.storage.Count <= 0)
                return;
            foreach (Equipment eq in GlobalSpace.storage)
            {
                StorageCheckedListBox.Items.Add(eq);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniMilitaryRank();
            MilitaryRankComboBox.SelectedIndex = 0;
            StorageCheckedListBox.CheckOnClick = true;
            EquipedCheckedListBox.CheckOnClick = true;
        }

        private void RandomCreateEQButtonButton_Click(object sender, EventArgs e)
        {
            EquipmentOperation.CreateRandomEquipment(-1, -1, -1, -1, -1, -1, -1);
            UpdateStorage();
        }



        private void GetInfoFromCE(int set, int type, int quality, int sp1, int sv1, int sp2, int sv2)
        {
            EquipmentOperation.CreateRandomEquipment(set, type, quality, sp1, sv1, sp2, sv2);
            UpdateStorage();
        }

        private void CreateEQButton_Click(object sender, EventArgs e)
        {
            CreateEquipment CE = new CreateEquipment(new MyInvoke(GetInfoFromCE));
            CE.ShowDialog(this);
        }


        private void MergeButton_Click(object sender, EventArgs e)
        {
            if (StorageCheckedListBox.CheckedItems.Count != 3)
            {
                Log.LogInfo("请选择三件同等级装备");
                return;
            }
            Equipment[] eq = new Equipment[3];
            int j = 0;
            for (int i = 0; i < StorageCheckedListBox.Items.Count; i++)
            {
                if (StorageCheckedListBox.GetItemChecked(i))
                {
                    eq[j]= (Equipment)StorageCheckedListBox.Items[i];
                    j = j + 1;
                }
            }
            if (eq[0].Quality == eq[1].Quality && eq[0].Quality == eq[2].Quality && eq[0].Quality<5)
            {
                EquipmentOperation.MergeEquipment(eq);
                UpdateStorage();
            }
            else
            {
                Log.LogInfo("请选择三件同等级装备");
            }
        }

        private void SplitButton_Click(object sender, EventArgs e)
        {
            if (StorageCheckedListBox.CheckedItems.Count < 1)
            {
                Log.LogInfo("请选择一件装备");
                return;
            }
            for (int i = 0; i < StorageCheckedListBox.Items.Count; i++)
            {
                if (StorageCheckedListBox.GetItemChecked(i))
                {
                    Equipment eq = (Equipment)StorageCheckedListBox.Items[i];
                    if (eq.Quality < 1)
                    {
                        Log.LogInfo("无法分解Q1装备");
                    }
                    else
                    {
                        EquipmentOperation.SplitEquipment(eq);
                    }
                }
            }
            UpdateStorage();
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            if (StorageCheckedListBox.CheckedItems.Count < 1)
            {
                Log.LogInfo("请选择一件装备");
                return;
            }
            for (int i = 0; i < StorageCheckedListBox.Items.Count; i++)
            {
                if (StorageCheckedListBox.GetItemChecked(i))
                {
                    Equipment eq = (Equipment)StorageCheckedListBox.Items[i];
                    EquipmentOperation.SellEquipment(eq);
                }
            }
            UpdateStorage();
        }

        private void WearButton_Click(object sender, EventArgs e)
        {
            if (StorageCheckedListBox.CheckedItems.Count < 1)
            {
                Log.LogInfo("请选择一件装备");
                return;
            }
            for (int i = 0; i < StorageCheckedListBox.Items.Count; i++)
            {
                if (StorageCheckedListBox.GetItemChecked(i))
                {
                    Equipment eq = (Equipment)StorageCheckedListBox.Items[i];
                    EquipmentOperation.WearEquipment(eq);
                }
            }
            UpdateStorage();
            UpdateWearedEquipment();
            UpdateState();
        }

        private void UnwearButton_Click(object sender, EventArgs e)
        {
            if (EquipedCheckedListBox.CheckedItems.Count < 1)
            {
                Log.LogInfo("请选择一件装备");
                return;
            }
            for (int i = 0; i < EquipedCheckedListBox.Items.Count; i++)
            {
                if (EquipedCheckedListBox.GetItemChecked(i))
                {
                    Equipment eq = (Equipment)EquipedCheckedListBox.Items[i];
                    EquipmentOperation.UnwearEquipment(eq.Type);
                }
            }
            UpdateStorage();
            UpdateWearedEquipment();
            UpdateState();
        }

        private void StrengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void MilitaryRankComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            LoadSave.SaveFile();
            UpdateStorage();
            UpdateWearedEquipment();
            UpdateState();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadSave.ReadFile();
            UpdateStorage();
            UpdateWearedEquipment();
            UpdateState();
        }

        private void EmptyStorageButton_Click(object sender, EventArgs e)
        {
            GlobalSpace.storage.Clear();
            UpdateStorage();
            Log.LogInfo("仓库已清空");
        }
    }
}
