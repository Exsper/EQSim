using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EQSim
{
    class LoadSave
    {
        private static string settingIni = Environment.CurrentDirectory + "\\Settings.eqs";

        private static string wearedEquipmentChar = "W";
        private static string storageChar = "S";
        private static string strengthChar = "T";
        private static string militaryRankCountChar = "M";


        private static string EQ2S(Equipment eq)
        {
            return eq.Set + "," + eq.Type + "," + eq.Quality + "," + eq.Parameter1 + "," + eq.Value1 + "," + eq.Parameter2 + "," + eq.Value2;
        }

        public static void SaveFile(int strength, int militaryRankCount)
        {
            try
            {
                StreamWriter sw = new StreamWriter(settingIni);

                for (int i = 0; i <= GlobalSpace.maxType; i++)
                {
                    if (GlobalSpace.wearedEquipment[i] != null)
                    {
                        sw.WriteLine(wearedEquipmentChar + "," + EQ2S(GlobalSpace.wearedEquipment[i]));
                    }
                }

                foreach (Equipment eq in GlobalSpace.storage)
                {
                    sw.WriteLine(storageChar + "," + EQ2S(eq));
                }

                sw.WriteLine(strengthChar + "," + strength.ToString());
                sw.WriteLine(militaryRankCountChar + "," + militaryRankCount.ToString());

                Log.LogInfo("保存成功");
                sw.Close();
            }
            catch
            {
                Log.LogBug("保存失败");
            }
        }


        public static void ReadFile()
        {
            try
            {
                if (File.Exists(settingIni) == false)
                {
                    Log.LogInfo("找不到存档");
                    return;
                }

                GlobalSpace.storage.Clear();
                for (int i = 0; i <= GlobalSpace.maxType; i++)
                {
                    GlobalSpace.wearedEquipment[i] = null;
                }

                StreamReader sr = new StreamReader(settingIni);
                string nextLine;
                string[] eqcode;
                while ((nextLine = sr.ReadLine()) != null)
                {
                    eqcode = nextLine.Split(',');
                    if (eqcode[0] == wearedEquipmentChar)
                    {
                        EquipmentOperation.CreateWearedRandomEquipment(Convert.ToInt32(eqcode[1]), Convert.ToInt32(eqcode[2]), Convert.ToInt32(eqcode[3]), Convert.ToInt32(eqcode[4]), Convert.ToInt32(eqcode[5]), Convert.ToInt32(eqcode[6]), Convert.ToInt32(eqcode[7]));
                    }
                    else if (eqcode[0] == storageChar)
                    {
                        EquipmentOperation.CreateRandomEquipment(Convert.ToInt32(eqcode[1]), Convert.ToInt32(eqcode[2]), Convert.ToInt32(eqcode[3]), Convert.ToInt32(eqcode[4]), Convert.ToInt32(eqcode[5]), Convert.ToInt32(eqcode[6]), Convert.ToInt32(eqcode[7]));
                    }
                    else if (eqcode[0] == strengthChar)
                    {
                        Form1.f.StrengthNumericUpDown.Value = Convert.ToInt32(eqcode[1]);
                    }
                    else if (eqcode[0] == militaryRankCountChar)
                    {
                        Form1.f.MilitaryRankComboBox.SelectedIndex = Convert.ToInt32(eqcode[1]);
                    }
                    else
                    {
                        Log.LogBug("未知标识字符："+ eqcode[0]);
                    }
                }

                sr.Close();
                Log.LogInfo("读取成功");
            }
            catch
            {
                Log.LogBug("读取失败");
            }
        }
    }
}
