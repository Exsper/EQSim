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

        private static string wearedEquipment = "W";
        private static string Storage = "S";


        private static string EQ2S(Equipment eq)
        {
            return eq.Set + "," + eq.Type + "," + eq.Quality + "," + eq.Parameter1 + "," + eq.Value1 + "," + eq.Parameter2 + "," + eq.Value2;
        }

        public static void SaveFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(settingIni);

                if (GlobalSpace.equipedHelmet != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedHelmet));
                }
                if (GlobalSpace.equipedVision != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedVision));
                }
                if (GlobalSpace.equipedArmor != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedArmor));
                }
                if (GlobalSpace.equipedPants != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedPants));
                }
                if (GlobalSpace.equipedShoes != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedShoes));
                }
                if (GlobalSpace.equipedWeapon != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedWeapon));
                }
                if (GlobalSpace.equipedOffhand != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedOffhand));
                }
                if (GlobalSpace.equipedLuckycharm != null)
                {
                    sw.WriteLine(wearedEquipment + "," + EQ2S(GlobalSpace.equipedLuckycharm));
                }

                foreach (Equipment eq in GlobalSpace.storage)
                {
                    sw.WriteLine(Storage + "," + EQ2S(eq));
                }

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
                GlobalSpace.equipedHelmet = null;
                GlobalSpace.equipedVision = null;
                GlobalSpace.equipedArmor = null;
                GlobalSpace.equipedPants = null;
                GlobalSpace.equipedShoes = null;
                GlobalSpace.equipedWeapon = null;
                GlobalSpace.equipedOffhand = null;
                GlobalSpace.equipedLuckycharm = null;

                StreamReader sr = new StreamReader(settingIni);
                string nextLine;
                string[] eqcode;
                while ((nextLine = sr.ReadLine()) != null)
                {
                    eqcode = nextLine.Split(',');
                    if (eqcode[0] == wearedEquipment)
                    {
                        EquipmentOperation.CreateWearedRandomEquipment(Convert.ToInt32(eqcode[1]), Convert.ToInt32(eqcode[2]), Convert.ToInt32(eqcode[3]), Convert.ToInt32(eqcode[4]), Convert.ToInt32(eqcode[5]), Convert.ToInt32(eqcode[6]), Convert.ToInt32(eqcode[7]));
                    }
                    if (eqcode[0] == Storage)
                    {
                        EquipmentOperation.CreateRandomEquipment(Convert.ToInt32(eqcode[1]), Convert.ToInt32(eqcode[2]), Convert.ToInt32(eqcode[3]), Convert.ToInt32(eqcode[4]), Convert.ToInt32(eqcode[5]), Convert.ToInt32(eqcode[6]), Convert.ToInt32(eqcode[7]));
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
