namespace EQSim
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.StorageCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.WearButton = new System.Windows.Forms.Button();
            this.MergeButton = new System.Windows.Forms.Button();
            this.SplitButton = new System.Windows.Forms.Button();
            this.EquipedCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.UnwearButton = new System.Windows.Forms.Button();
            this.SellButton = new System.Windows.Forms.Button();
            this.RandomCreateEQButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.StateTextBox = new System.Windows.Forms.TextBox();
            this.StrengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.MilitaryRankComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateEQButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.EmptyStorageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StorageCheckedListBox
            // 
            this.StorageCheckedListBox.FormattingEnabled = true;
            this.StorageCheckedListBox.Location = new System.Drawing.Point(403, 12);
            this.StorageCheckedListBox.Name = "StorageCheckedListBox";
            this.StorageCheckedListBox.Size = new System.Drawing.Size(385, 292);
            this.StorageCheckedListBox.TabIndex = 0;
            // 
            // WearButton
            // 
            this.WearButton.Location = new System.Drawing.Point(794, 12);
            this.WearButton.Name = "WearButton";
            this.WearButton.Size = new System.Drawing.Size(100, 36);
            this.WearButton.TabIndex = 1;
            this.WearButton.Text = "装备";
            this.WearButton.UseVisualStyleBackColor = true;
            this.WearButton.Click += new System.EventHandler(this.WearButton_Click);
            // 
            // MergeButton
            // 
            this.MergeButton.Location = new System.Drawing.Point(794, 54);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(100, 36);
            this.MergeButton.TabIndex = 2;
            this.MergeButton.Text = "合成";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // SplitButton
            // 
            this.SplitButton.Location = new System.Drawing.Point(794, 96);
            this.SplitButton.Name = "SplitButton";
            this.SplitButton.Size = new System.Drawing.Size(100, 36);
            this.SplitButton.TabIndex = 3;
            this.SplitButton.Text = "分解";
            this.SplitButton.UseVisualStyleBackColor = true;
            this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
            // 
            // EquipedCheckedListBox
            // 
            this.EquipedCheckedListBox.FormattingEnabled = true;
            this.EquipedCheckedListBox.Location = new System.Drawing.Point(12, 12);
            this.EquipedCheckedListBox.Name = "EquipedCheckedListBox";
            this.EquipedCheckedListBox.Size = new System.Drawing.Size(385, 132);
            this.EquipedCheckedListBox.TabIndex = 4;
            // 
            // UnwearButton
            // 
            this.UnwearButton.Location = new System.Drawing.Point(297, 148);
            this.UnwearButton.Name = "UnwearButton";
            this.UnwearButton.Size = new System.Drawing.Size(100, 36);
            this.UnwearButton.TabIndex = 5;
            this.UnwearButton.Text = "脱掉装备";
            this.UnwearButton.UseVisualStyleBackColor = true;
            this.UnwearButton.Click += new System.EventHandler(this.UnwearButton_Click);
            // 
            // SellButton
            // 
            this.SellButton.Location = new System.Drawing.Point(794, 138);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(100, 36);
            this.SellButton.TabIndex = 6;
            this.SellButton.Text = "出售";
            this.SellButton.UseVisualStyleBackColor = true;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // RandomCreateEQButton
            // 
            this.RandomCreateEQButton.Location = new System.Drawing.Point(794, 267);
            this.RandomCreateEQButton.Name = "RandomCreateEQButton";
            this.RandomCreateEQButton.Size = new System.Drawing.Size(100, 36);
            this.RandomCreateEQButton.TabIndex = 7;
            this.RandomCreateEQButton.Text = "随机生成";
            this.RandomCreateEQButton.UseVisualStyleBackColor = true;
            this.RandomCreateEQButton.Click += new System.EventHandler(this.RandomCreateEQButtonButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogTextBox.Location = new System.Drawing.Point(403, 309);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(491, 161);
            this.LogTextBox.TabIndex = 8;
            // 
            // StateTextBox
            // 
            this.StateTextBox.Location = new System.Drawing.Point(12, 199);
            this.StateTextBox.Multiline = true;
            this.StateTextBox.Name = "StateTextBox";
            this.StateTextBox.ReadOnly = true;
            this.StateTextBox.Size = new System.Drawing.Size(385, 229);
            this.StateTextBox.TabIndex = 9;
            // 
            // StrengthNumericUpDown
            // 
            this.StrengthNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.StrengthNumericUpDown.Location = new System.Drawing.Point(59, 148);
            this.StrengthNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.StrengthNumericUpDown.Name = "StrengthNumericUpDown";
            this.StrengthNumericUpDown.Size = new System.Drawing.Size(66, 21);
            this.StrengthNumericUpDown.TabIndex = 10;
            this.StrengthNumericUpDown.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.StrengthNumericUpDown.ValueChanged += new System.EventHandler(this.StrengthNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "力量：";
            // 
            // MilitaryRankComboBox
            // 
            this.MilitaryRankComboBox.FormattingEnabled = true;
            this.MilitaryRankComboBox.Location = new System.Drawing.Point(59, 173);
            this.MilitaryRankComboBox.Name = "MilitaryRankComboBox";
            this.MilitaryRankComboBox.Size = new System.Drawing.Size(143, 20);
            this.MilitaryRankComboBox.TabIndex = 12;
            this.MilitaryRankComboBox.SelectedIndexChanged += new System.EventHandler(this.MilitaryRankComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "军衔：";
            // 
            // CreateEQButton
            // 
            this.CreateEQButton.Location = new System.Drawing.Point(794, 225);
            this.CreateEQButton.Name = "CreateEQButton";
            this.CreateEQButton.Size = new System.Drawing.Size(100, 36);
            this.CreateEQButton.TabIndex = 14;
            this.CreateEQButton.Text = "自定义生成";
            this.CreateEQButton.UseVisualStyleBackColor = true;
            this.CreateEQButton.Click += new System.EventHandler(this.CreateEQButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(120, 434);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 36);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(14, 434);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(100, 36);
            this.LoadButton.TabIndex = 16;
            this.LoadButton.Text = "读取";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // EmptyStorageButton
            // 
            this.EmptyStorageButton.Location = new System.Drawing.Point(297, 434);
            this.EmptyStorageButton.Name = "EmptyStorageButton";
            this.EmptyStorageButton.Size = new System.Drawing.Size(100, 36);
            this.EmptyStorageButton.TabIndex = 17;
            this.EmptyStorageButton.Text = "清空仓库";
            this.EmptyStorageButton.UseVisualStyleBackColor = true;
            this.EmptyStorageButton.Click += new System.EventHandler(this.EmptyStorageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 482);
            this.Controls.Add(this.EmptyStorageButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CreateEQButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MilitaryRankComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StrengthNumericUpDown);
            this.Controls.Add(this.StateTextBox);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.RandomCreateEQButton);
            this.Controls.Add(this.SellButton);
            this.Controls.Add(this.UnwearButton);
            this.Controls.Add(this.EquipedCheckedListBox);
            this.Controls.Add(this.SplitButton);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.WearButton);
            this.Controls.Add(this.StorageCheckedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EQSim (demo)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StrengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox StorageCheckedListBox;
        private System.Windows.Forms.Button WearButton;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.Button SplitButton;
        private System.Windows.Forms.CheckedListBox EquipedCheckedListBox;
        private System.Windows.Forms.Button UnwearButton;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Button RandomCreateEQButton;
        public System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TextBox StateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateEQButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button EmptyStorageButton;
        public System.Windows.Forms.NumericUpDown StrengthNumericUpDown;
        public System.Windows.Forms.ComboBox MilitaryRankComboBox;
    }
}

