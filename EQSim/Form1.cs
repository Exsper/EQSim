using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EQSim
{

    public delegate void EQCInvoke(int set, int type, int quality, int sp1, int sv1, int sp2, int sv2);

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
            //MilitaryRankComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniMilitaryRank();
            MilitaryRankComboBox.SelectedIndex = 0;
            WeaponQualitycomboBox.SelectedIndex = 1;
            CamouflageQualityComboBox.SelectedIndex = 0;
            MilitaryUnitComboBox.SelectedIndex = 0;
            DefenseSystemComboBox.SelectedIndex = 0;
            HospitalComboBox.SelectedIndex = 0;
            StorageCheckedListBox.CheckOnClick = true;
            EquipedCheckedListBox.CheckOnClick = true;
        }

        #region 装备设置

        #region 界面更新

        private void UpdateWearedEquipment()
        {
            EquipedCheckedListBox.Items.Clear();
            for (int i = 0; i <= GlobalSpace.maxType; i++)
            {
                if (GlobalSpace.wearedEquipment[i] != null)
                {
                    EquipedCheckedListBox.Items.Add(GlobalSpace.wearedEquipment[i]);
                }
            }
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


        private void StrengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void MilitaryRankComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        #endregion

        #region 按钮

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
            CreateEquipment CE = new CreateEquipment(new EQCInvoke(GetInfoFromCE));
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


        private void SaveButton_Click(object sender, EventArgs e)
        {
            LoadSave.SaveFile(Convert.ToInt32(StrengthNumericUpDown.Value), MilitaryRankComboBox.SelectedIndex);
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

        private void GetEquipmentFromWebsiteButton_Click(object sender, EventArgs e)
        {
            GetEquipmentsFormWebsite.GetEquipment(ProfileTextBox.Text);
            UpdateStorage();
            UpdateWearedEquipment();
            UpdateState();
        }

        #endregion

        #endregion

        #region 伤害模拟

        private void LogInfo(string s)
        {
            int start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText(s + "\r\n");
            SimulationRichTextBox.Select(start, s.Length);
            SimulationRichTextBox.SelectionColor = Color.Black;
            SimulationRichTextBox.ScrollToCaret();
        }

        public void AppendInfo(string s)
        {
            int start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText(s);
            SimulationRichTextBox.Select(start, s.Length);
            SimulationRichTextBox.SelectionColor = Color.Black;
            SimulationRichTextBox.ScrollToCaret();
        }

        private void LogOneBerserk(bool isAvoid, bool isMiss, bool isCritical, int oneDamage)
        {
            int start;

            start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText("免体");
            SimulationRichTextBox.Select(start, 2);
            if (isAvoid == true)
            {
                SimulationRichTextBox.SelectionColor = Color.Green;
            }
            else
            {
                SimulationRichTextBox.SelectionColor = Color.White;
            }

            SimulationRichTextBox.AppendText("  ");

            start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText("暴击");
            SimulationRichTextBox.Select(start, 2);
            if (isCritical == true)
            {
                SimulationRichTextBox.SelectionColor = Color.Green;
            }
            else
            {
                SimulationRichTextBox.SelectionColor = Color.White;
            }

            SimulationRichTextBox.AppendText("  ");

            string od = oneDamage.ToString("###,###");
            start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText(od);
            SimulationRichTextBox.Select(start, od.Length);
            if (isCritical == true)
            {
                SimulationRichTextBox.SelectionColor = Color.Red;
            }
            else
            {
                SimulationRichTextBox.SelectionColor = Color.Black;
            }

            SimulationRichTextBox.AppendText("\r\n");
            SimulationRichTextBox.ScrollToCaret();
        }


        private void StartDamageSimulationButton_Click(object sender, EventArgs e)
        {
            int weaponQuality = WeaponQualitycomboBox.SelectedIndex;

            int steroids = 0;
            if (SteroidsCheckBox.Checked == true)
            {
                steroids = 1;
            }
            if (DeSteroidsCheckBox.Checked == true)
            {
                steroids = -1;
            }

            int tank = 0;
            if (TankBuffCheckBox.Checked == true)
            {
                tank = 1;
            }
            if (DeTankBuffCheckBox.Checked == true)
            {
                tank = -1;
            }

            int painDealer = 0;
            if (PaindealerCheckBox.Checked == true)
            {
                painDealer = 1;
            }

            int camouflageQuality = CamouflageQualityComboBox.SelectedIndex;

            int sewerGuide = 0;
            if (SewerGuideCheckBox.Checked == true)
            {
                sewerGuide = 1;
            }
            if (DeSewerGuideCheckBox.Checked == true)
            {
                sewerGuide = -1;
            }

            int bunker = 0;
            if (BunkerCheckBox.Checked == true)
            {
                bunker = 1;
            }
            if (DeBunkerCheckBox.Checked == true)
            {
                bunker = -1;
            }

            int locationModifier = 0;
            if (LocalCheckBox.Checked == true)
            {
                locationModifier = 1;
            }

            int surendedModifier = 0;
            if (SurroundedCheckBox.Checked == true)
            {
                surendedModifier = 1;
            }

            int muQuality = MilitaryUnitComboBox.SelectedIndex;

            double coBonus = 0;
            if (CoalitionCheckBox.Checked == true)
            {
                try
                {
                    coBonus = Convert.ToDouble(CoalitionBonusTextBox.Text);
                }
                catch
                {
                    coBonus = 0;
                    LogInfo("联盟令加成数值错误：" + CoalitionBonusTextBox.Text + "%");
                }
            }

            int dsQuality = DefenseSystemComboBox.SelectedIndex;

            int hospitalQuality = HospitalComboBox.SelectedIndex;

            int moreDmg = 0;
            try
            {
                moreDmg = Convert.ToInt32(DamageBonusTextBox.Text);
            }
            catch
            {
                moreDmg = 0;
                LogInfo("更多伤害数值错误：" + DamageBonusTextBox.Text + "%");
            }

            int moreCritics = 0;
            try
            {
                moreCritics = Convert.ToInt32(CriticalBonusTextBox.Text);
            }
            catch
            {
                moreCritics = 0;
                LogInfo("更多伤害数值错误：" + CriticalBonusTextBox.Text + "%");
            }

            int strength = Convert.ToInt32(StrengthNumericUpDown.Value);
            int militaryRankCount = MilitaryRankComboBox.SelectedIndex;

            int[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] state = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i <= GlobalSpace.maxType; i++)
            {
                if (GlobalSpace.wearedEquipment[i] != null)
                {
                    sum[GlobalSpace.wearedEquipment[i].Parameter1] += GlobalSpace.wearedEquipment[i].Value1;
                    sum[GlobalSpace.wearedEquipment[i].Parameter2] += GlobalSpace.wearedEquipment[i].Value2;
                }
            }
            for (int i = 0; i <= GlobalSpace.maxParameter; i++)
            {
                state[i] = sum[i] + GlobalSpace.stateInitialValue[i];
                if (state[i] > GlobalSpace.stateMaxValue[i] && GlobalSpace.stateMaxValue[i] >= 0)
                {
                    state[i] = GlobalSpace.stateMaxValue[i];
                }
            }

            if (militaryRankCount < 0 || militaryRankCount > GlobalSpace.militaryRankBonus.Length)
            {
                Log.LogBug("军衔索引越界：" + militaryRankCount.ToString());
                militaryRankCount = 0;
            }
            double militaryRank = GlobalSpace.militaryRankBonus[militaryRankCount];
            if (strength <= 0)
            {
                Log.LogBug("力量非正数：" + strength.ToString());
                strength = 1;
            }

            double miss = -(double)state[0] / 10000;    //正数
            double critical = (double)state[1] / 10000;
            double maxDamage = (double)state[2] / 10000;
            double minDamage = (double)state[3] / 10000;
            double avoid = (double)state[4] / 10000;
            double strengthq = strength + state[5];
            double increaseHit = state[6];

            double[] baseDamage = DamageSimulation.CalculateOneBerserkBaseDamage(militaryRank, strengthq, minDamage, maxDamage, increaseHit);
            double berserkModifiers = DamageSimulation.CalculateOneBerserkModifiers(steroids, tank, bunker, sewerGuide, surendedModifier, locationModifier, muQuality, coBonus, dsQuality, moreDmg, weaponQuality);
            int[] berserkDamage = DamageSimulation.CalculateOneBerserkDamage(baseDamage, berserkModifiers);

            int notMissChance = DamageSimulation.CalculateNotMissChance(miss);
            int criticalChance = DamageSimulation.CalculateCriticalChance(critical, painDealer, moreCritics);
            int avoidChance = DamageSimulation.CalculateAvoidChance(avoid, hospitalQuality, camouflageQuality);


            if (DamageRadioButton.Checked == true)
            {
                long damageGoal = 0;
                try
                {
                    damageGoal = Convert.ToInt64(TotalDamageNumericUpDown.Value);
                }
                catch
                {
                    damageGoal = 1;
                    LogInfo("伤害目标数值错误：" + TotalDamageNumericUpDown.Value);
                }
                if (damageGoal <= 0)
                {
                    damageGoal = 1;
                    LogInfo("伤害目标数值错误：" + TotalDamageNumericUpDown.Value);
                }


                DSByDamage(damageGoal, avoidChance, notMissChance, criticalChance, berserkDamage);
            }
            else if (LimitRadioButton.Checked == true)
            {
                int limit = 0;
                try
                {
                    limit = Convert.ToInt32(LimitTextBox.Text);
                }
                catch
                {
                    limit = 1;
                    LogInfo("额度数值错误：" + LimitTextBox.Text);
                }
                if (limit <= 0)
                {
                    limit = 1;
                    LogInfo("额度数值错误：" + LimitTextBox.Text);
                }


                DSByLimit(limit, avoidChance, notMissChance, criticalChance, berserkDamage);
            }
            else if (TimeRadioButton.Checked == true)
            {
                int hitCount = 0;
                double time;
                double hps;
                try
                {
                    time = Convert.ToDouble(TimeTextBox.Text);
                }
                catch
                {
                    time = 1;
                    LogInfo("时间数值错误：" + TimeTextBox.Text);
                }
                if (time <= 0)
                {
                    time = 1;
                    LogInfo("时间数值错误：" + TimeTextBox.Text);
                }

                try
                {
                    hps = Convert.ToDouble(HitCountPerSecondTextBox.Text);
                }
                catch
                {
                    hps = 1;
                    LogInfo("每秒攻击次数错误：" + HitCountPerSecondTextBox.Text);
                }
                if (hps <= 0)
                {
                    hps = 1;
                    LogInfo("每秒攻击次数错误：" + HitCountPerSecondTextBox.Text);
                }

                hitCount = Convert.ToInt32(time * hps);
                if (hitCount < 1)
                {
                    LogInfo("规定时间内攻击次数少于1次：" + hitCount.ToString());
                    hitCount = 1;
                }


                DSByTime(hitCount, avoidChance, notMissChance, criticalChance, berserkDamage);
            }
        }


        private void LogDS(int hitCount, int limit, long totalDamage)
        {
            int start;

            string hc = hitCount.ToString();
            string li = limit.ToString();
            string td = totalDamage.ToString("###,###");


            AppendInfo("连击了 ");

            start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText(hc);
            SimulationRichTextBox.Select(start, hc.Length);
            SimulationRichTextBox.SelectionColor = Color.Green;

            AppendInfo(" 次，耗费 ");

            start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText(li);
            SimulationRichTextBox.Select(start, li.Length);
            SimulationRichTextBox.SelectionColor = Color.Green;

            AppendInfo(" 点额度，造成 ");

            start = SimulationRichTextBox.Text.Length;
            SimulationRichTextBox.AppendText(td);
            SimulationRichTextBox.Select(start, td.Length);
            SimulationRichTextBox.SelectionColor = Color.Green;

            AppendInfo(" 点伤害\r\n");

            SimulationRichTextBox.ScrollToCaret();
        }


        private void DSByDamage(long damageGoal, int avoidChance, int notMissChance, int criticalChance, int[] berserkDamage)
        {
            bool isAvoid;
            bool isMiss;
            bool isCritical;
            int oneDamage;
            int limit = 0;
            int hitCount = 0;
            long totalDamage = 0;
            Random r = new Random();

            while (damageGoal > totalDamage)
            {
                if (r.Next(0, 100) < avoidChance)
                {
                    isAvoid = true;
                }
                else
                {
                    isAvoid = false;
                    limit = limit + 1;
                }

                if (r.Next(0, 100) < notMissChance)
                {
                    isMiss = false;
                    oneDamage = r.Next(berserkDamage[0], berserkDamage[1]);
                    if (r.Next(0, 100) < criticalChance)
                    {
                        isCritical = true;
                        oneDamage = oneDamage * 2;
                    }
                    else
                    {
                        isCritical = false;
                    }
                }
                else
                {
                    isMiss = true;
                    isCritical = false;
                    oneDamage = 0;
                }

                hitCount = hitCount + 1;
                totalDamage = totalDamage + oneDamage;

                if (ShowOneDamageCheckBox.Checked == true)
                {
                    LogOneBerserk(isAvoid, isMiss, isCritical, oneDamage);
                }
            }

            LogDS(hitCount, limit, totalDamage);
        }


        private void DSByLimit(int limit, int avoidChance, int notMissChance, int criticalChance, int[] berserkDamage)
        {
            bool isAvoid;
            bool isMiss;
            bool isCritical;
            int usedLimit = 0;
            int oneDamage;
            int hitCount = 0;
            long totalDamage = 0;
            Random r = new Random();

            while (limit > 0)
            {
                if (r.Next(0, 100) < avoidChance)
                {
                    isAvoid = true;
                }
                else
                {
                    isAvoid = false;
                    limit = limit - 1;
                    usedLimit = usedLimit + 1;
                }

                if (r.Next(0, 100) < notMissChance)
                {
                    isMiss = false;
                    oneDamage = r.Next(berserkDamage[0], berserkDamage[1]);
                    if (r.Next(0, 100) < criticalChance)
                    {
                        isCritical = true;
                        oneDamage = oneDamage * 2;
                    }
                    else
                    {
                        isCritical = false;
                    }
                }
                else
                {
                    isMiss = true;
                    isCritical = false;
                    oneDamage = 0;
                }

                hitCount = hitCount + 1;
                totalDamage = totalDamage + oneDamage;

                if (ShowOneDamageCheckBox.Checked == true)
                {
                    LogOneBerserk(isAvoid, isMiss, isCritical, oneDamage);
                }
            }

            LogDS(hitCount, usedLimit, totalDamage);
        }


        private void DSByTime(int hitCount, int avoidChance, int notMissChance, int criticalChance, int[] berserkDamage)
        {
            bool isAvoid;
            bool isMiss;
            bool isCritical;
            int nowHitCount = 0;
            int oneDamage;
            int limit = 0;
            long totalDamage = 0;
            Random r = new Random();

            while (hitCount > nowHitCount)
            {
                if (r.Next(0, 100) < avoidChance)
                {
                    isAvoid = true;
                }
                else
                {
                    isAvoid = false;
                    limit = limit + 1;
                }

                if (r.Next(0, 100) < notMissChance)
                {
                    isMiss = false;
                    oneDamage = r.Next(berserkDamage[0], berserkDamage[1]);
                    if (r.Next(0, 100) < criticalChance)
                    {
                        isCritical = true;
                        oneDamage = oneDamage * 2;
                    }
                    else
                    {
                        isCritical = false;
                    }
                }
                else
                {
                    isMiss = true;
                    isCritical = false;
                    oneDamage = 0;
                }

                nowHitCount = nowHitCount + 1;
                totalDamage = totalDamage + oneDamage;

                if (ShowOneDamageCheckBox.Checked == true)
                {
                    LogOneBerserk(isAvoid, isMiss, isCritical, oneDamage);
                }
            }

            LogDS(hitCount, limit, totalDamage);
        }

        #endregion
    }
}
