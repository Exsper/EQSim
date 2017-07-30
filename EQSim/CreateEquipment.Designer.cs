namespace EQSim
{
    partial class CreateEquipment
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
            this.SetComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.QualityComboBox = new System.Windows.Forms.ComboBox();
            this.Parameter1ComboBox = new System.Windows.Forms.ComboBox();
            this.Value1TextBox = new System.Windows.Forms.TextBox();
            this.Parameter2ComboBox = new System.Windows.Forms.ComboBox();
            this.Value2TextBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.RandomValue1CheckBox = new System.Windows.Forms.CheckBox();
            this.RandomValue2CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SetComboBox
            // 
            this.SetComboBox.FormattingEnabled = true;
            this.SetComboBox.Items.AddRange(new object[] {
            "<随机>",
            "普通（Standard Set）",
            "Pirate Set",
            "Post Apocalyptic Set",
            "Future Set",
            "Funny Set"});
            this.SetComboBox.Location = new System.Drawing.Point(53, 6);
            this.SetComboBox.Name = "SetComboBox";
            this.SetComboBox.Size = new System.Drawing.Size(202, 20);
            this.SetComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "品质：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "属性1：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "数值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "属性2：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "数值：";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "<随机>",
            "头盔",
            "护目镜",
            "盔甲",
            "作战裤",
            "作战靴",
            "武器配件",
            "副手",
            "幸运符"});
            this.TypeComboBox.Location = new System.Drawing.Point(53, 33);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(89, 20);
            this.TypeComboBox.TabIndex = 8;
            // 
            // QualityComboBox
            // 
            this.QualityComboBox.FormattingEnabled = true;
            this.QualityComboBox.Items.AddRange(new object[] {
            "<随机>",
            "Q1",
            "Q2",
            "Q3",
            "Q4",
            "Q5",
            "Q6"});
            this.QualityComboBox.Location = new System.Drawing.Point(195, 33);
            this.QualityComboBox.Name = "QualityComboBox";
            this.QualityComboBox.Size = new System.Drawing.Size(60, 20);
            this.QualityComboBox.TabIndex = 9;
            // 
            // Parameter1ComboBox
            // 
            this.Parameter1ComboBox.FormattingEnabled = true;
            this.Parameter1ComboBox.Items.AddRange(new object[] {
            "<随机>",
            "减少失误率",
            "增加暴击率",
            "增加最大伤害",
            "增加伤害",
            "增加闪避率",
            "增加力量",
            "增加伤害点",
            "提高经济技能",
            "提高免机票飞行概率",
            "提高减少每次连击手枪消耗概率",
            "提高获得一支手枪概率"});
            this.Parameter1ComboBox.Location = new System.Drawing.Point(53, 59);
            this.Parameter1ComboBox.Name = "Parameter1ComboBox";
            this.Parameter1ComboBox.Size = new System.Drawing.Size(202, 20);
            this.Parameter1ComboBox.TabIndex = 10;
            // 
            // Value1TextBox
            // 
            this.Value1TextBox.Location = new System.Drawing.Point(53, 85);
            this.Value1TextBox.Name = "Value1TextBox";
            this.Value1TextBox.Size = new System.Drawing.Size(136, 21);
            this.Value1TextBox.TabIndex = 11;
            this.Value1TextBox.Text = "6.66";
            // 
            // Parameter2ComboBox
            // 
            this.Parameter2ComboBox.FormattingEnabled = true;
            this.Parameter2ComboBox.Items.AddRange(new object[] {
            "<随机>",
            "减少失误率",
            "增加暴击率",
            "增加最大伤害",
            "增加伤害",
            "增加闪避率",
            "增加力量",
            "增加伤害点",
            "提高经济技能",
            "提高免机票飞行概率",
            "提高减少每次连击手枪消耗概率",
            "提高获得一支手枪概率"});
            this.Parameter2ComboBox.Location = new System.Drawing.Point(53, 112);
            this.Parameter2ComboBox.Name = "Parameter2ComboBox";
            this.Parameter2ComboBox.Size = new System.Drawing.Size(202, 20);
            this.Parameter2ComboBox.TabIndex = 12;
            // 
            // Value2TextBox
            // 
            this.Value2TextBox.Location = new System.Drawing.Point(53, 138);
            this.Value2TextBox.Name = "Value2TextBox";
            this.Value2TextBox.Size = new System.Drawing.Size(136, 21);
            this.Value2TextBox.TabIndex = 13;
            this.Value2TextBox.Text = "6.66";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(175, 165);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(80, 32);
            this.CreateButton.TabIndex = 14;
            this.CreateButton.Text = "生成装备";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(9, 175);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(133, 32);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "注：指定属性或数值可能会产生不正常装备。";
            // 
            // RandomValue1CheckBox
            // 
            this.RandomValue1CheckBox.AutoSize = true;
            this.RandomValue1CheckBox.Location = new System.Drawing.Point(195, 87);
            this.RandomValue1CheckBox.Name = "RandomValue1CheckBox";
            this.RandomValue1CheckBox.Size = new System.Drawing.Size(48, 16);
            this.RandomValue1CheckBox.TabIndex = 16;
            this.RandomValue1CheckBox.Text = "随机";
            this.RandomValue1CheckBox.UseVisualStyleBackColor = true;
            this.RandomValue1CheckBox.CheckedChanged += new System.EventHandler(this.RandomValue1CheckBox_CheckedChanged);
            // 
            // RandomValue2CheckBox
            // 
            this.RandomValue2CheckBox.AutoSize = true;
            this.RandomValue2CheckBox.Location = new System.Drawing.Point(195, 140);
            this.RandomValue2CheckBox.Name = "RandomValue2CheckBox";
            this.RandomValue2CheckBox.Size = new System.Drawing.Size(48, 16);
            this.RandomValue2CheckBox.TabIndex = 17;
            this.RandomValue2CheckBox.Text = "随机";
            this.RandomValue2CheckBox.UseVisualStyleBackColor = true;
            this.RandomValue2CheckBox.CheckedChanged += new System.EventHandler(this.RandomValue2CheckBox_CheckedChanged);
            // 
            // CreateEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 206);
            this.Controls.Add(this.RandomValue2CheckBox);
            this.Controls.Add(this.RandomValue1CheckBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.Value2TextBox);
            this.Controls.Add(this.Parameter2ComboBox);
            this.Controls.Add(this.Value1TextBox);
            this.Controls.Add(this.Parameter1ComboBox);
            this.Controls.Add(this.QualityComboBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CreateEquipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义生成";
            this.Load += new System.EventHandler(this.CreateEquipment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SetComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox QualityComboBox;
        private System.Windows.Forms.ComboBox Parameter1ComboBox;
        private System.Windows.Forms.TextBox Value1TextBox;
        private System.Windows.Forms.ComboBox Parameter2ComboBox;
        private System.Windows.Forms.TextBox Value2TextBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox RandomValue1CheckBox;
        private System.Windows.Forms.CheckBox RandomValue2CheckBox;
    }
}