using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EQSim
{
    /// <summary>
    /// 装备信息
    /// </summary>
    public class Equipment
    {

        public int Set { get; set; }    //0=Standard, 1=Pirate, 2=Post Apocalyptic, 3=Future, 4=Funny

        public int Type { get; set; }   //0=Helmet 头盔
                                        //1=Vision 护目镜
                                        //2=Personal Armor 盔甲
                                        //3=Pants 作战裤
                                        //4=Shoes 作战靴
                                        //5=Weapon upgrade 武器配件
                                        //6=Offhand 副手
                                        //7=Lucky charm 幸运符

        public int Quality { get; set; }    //0=Q1, ..., 5=Q6

        public int Parameter1 { get; set; } //0=Reduce miss chance 减少失误率 x100
                                            //1=Increase critical chance 增加暴击率 x100
                                            //2=Increase maximum damage 增加最大伤害 x100
                                            //3=Increase damage 增加伤害 x100
                                            //4=Increase chance to avoid damage 增加闪避率 x100
                                            //5=Increase strength 增加力量  x1
                                            //6=Increase hit 增加伤害点 x1
                                            //7=Economic skill increase 提高经济技能 x100
                                            //8=Increase chance for free flight 提高免机票飞行概率 x100
                                            //9=Less weapons per berserk 提高减少每次连击手枪消耗概率 x100
                                            //10=Chance to find a weapon 提高获得一支手枪概率 x100

        public int Value1 { get; set; }

        public int Parameter2 { get; set; }

        public int Value2 { get; set; }

        public Equipment(int set, int type, int quality, int parameter1, int value1, int parameter2, int value2)
        {
            if (set > GlobalSpace.maxSet || set < 0) { Log.LogBug("新建装备时Set越界：" + set.ToString()); set = 0; }
            if (type > GlobalSpace.maxType || type < 0) { Log.LogBug("新建装备时Type越界：" + type.ToString()); type = 0; }
            if (quality > GlobalSpace.maxQuality || quality < 0) { Log.LogBug("新建装备时Quality越界：" + quality.ToString()); quality = 0; }
            if (parameter1 > GlobalSpace.maxParameter || parameter1 < 0) { Log.LogBug("新建装备时Parameter1越界：" + parameter1.ToString()); parameter1 = 0; }
            if (value1 < 0) { Log.LogBug("新建装备时Value1越界：" + value1.ToString()); value1 = 0; }
            if (parameter2 > GlobalSpace.maxParameter || parameter2 < 0) { Log.LogBug("新建装备时Parameter2越界：" + parameter2.ToString()); parameter2 = 0; }
            if (value2 < 0) { Log.LogBug("新建装备时Value2越界：" + value2.ToString()); value2 = 0; }
            Set = set;
            Type = type;
            Quality = quality;
            Parameter1 = parameter1;
            Value1 = value1;
            Parameter2 = parameter2;
            Value2 = value2;
        }

        public override string ToString()
        {
            return EquipmentOperation.GetEquipmentLineInfo(Set, Type, Quality, Parameter1, Value1, Parameter2, Value2);
        }
    }


    class EquipmentOperation
    {

        /// <summary>
        /// 获取指定属性指定等级的数值范围
        /// </summary>
        /// <param name="parameter">属性类型</param>
        /// <param name="quality">装备等级</param>
        /// <returns>[最小值, 最大值]</returns>
        private static int[] GetValueRange(int parameter, int quality)
        {
            int[] range = new int[2];
            switch (parameter)
            {
                //miss
                case 0:
                    {
                        range[0] = GlobalSpace.missMin[quality];
                        range[1] = GlobalSpace.missMax[quality];
                        return range;
                    }
                //暴击
                case 1:
                    {
                        range[0] = GlobalSpace.criticalMin[quality];
                        range[1] = GlobalSpace.criticalMax[quality];
                        return range;
                    }
                //大伤
                case 2:
                    {
                        range[0] = GlobalSpace.maxdamageMin[quality];
                        range[1] = GlobalSpace.maxdamageMax[quality];
                        return range;
                    }
                //小伤
                case 3:
                    {
                        range[0] = GlobalSpace.damageMin[quality];
                        range[1] = GlobalSpace.damageMax[quality];
                        return range;
                    }
                //闪避
                case 4:
                    {
                        range[0] = GlobalSpace.avoidMin[quality];
                        range[1] = GlobalSpace.avoidMax[quality];
                        return range;
                    }
                //力量
                case 5:
                    {
                        range[0] = GlobalSpace.strengthMin[quality];
                        range[1] = GlobalSpace.strengthMax[quality];
                        return range;
                    }
                //伤害点
                case 6:
                    {
                        range[0] = GlobalSpace.hitMin[quality];
                        range[1] = GlobalSpace.hitMax[quality];
                        return range;
                    }
                //经济技能
                case 7:
                    {
                        range[0] = GlobalSpace.economicMin[quality];
                        range[1] = GlobalSpace.economicMax[quality];
                        return range;
                    }
                //飞行
                case 8:
                    {
                        range[0] = GlobalSpace.flightMin[quality];
                        range[1] = GlobalSpace.flightMax[quality];
                        return range;
                    }
                //连击消耗
                case 9:
                    {
                        range[0] = GlobalSpace.berserkMin[quality];
                        range[1] = GlobalSpace.berserkMax[quality];
                        return range;
                    }
                //捡枪
                case 10:
                    {
                        range[0] = GlobalSpace.findMin[quality];
                        range[1] = GlobalSpace.findMax[quality];
                        return range;
                    }
                default:
                    {
                        Log.LogBug("获取装备属性数值范围时parameter越界：" + parameter.ToString());
                        range[0] = 0;
                        range[1] = 0;
                        return range;
                    }
            }
        }


        private static int[] GetEquipmentParameterList(int set, int type)
        {
            if(set==0)
            {
                if (type == 0) return GlobalSpace.standardHelmet;
                if (type == 1) return GlobalSpace.standardVision;
                if (type == 2) return GlobalSpace.standardArmor;
                if (type == 3) return GlobalSpace.standardPants;
                if (type == 4) return GlobalSpace.standardShoes;
                if (type == 5) return GlobalSpace.standardWeapon;
                if (type == 6) return GlobalSpace.standardOffhand;
                if (type == 7) return GlobalSpace.standardLuckycharm;
                Log.LogBug("获取set " + set.ToString() + "属性列表时未知type：" + type.ToString());
                return GlobalSpace.standardHelmet;
            }
            if (set == 1)
            {
                if (type == 0) return GlobalSpace.pirateHelmet;
                if (type == 1) return GlobalSpace.pirateVision;
                if (type == 2) return GlobalSpace.pirateArmor;
                if (type == 3) return GlobalSpace.piratePants;
                if (type == 4) return GlobalSpace.pirateShoes;
                if (type == 5) return GlobalSpace.pirateWeapon;
                if (type == 6) return GlobalSpace.pirateOffhand;
                if (type == 7) return GlobalSpace.pirateLuckycharm;
                Log.LogBug("获取set " + set.ToString() + "属性列表时未知type：" + type.ToString());
                return GlobalSpace.pirateHelmet;
            }
            if (set == 2)
            {
                if (type == 0) return GlobalSpace.postapocalypticHelmet;
                if (type == 1) return GlobalSpace.postapocalypticVision;
                if (type == 2) return GlobalSpace.postapocalypticArmor;
                if (type == 3) return GlobalSpace.postapocalypticPants;
                if (type == 4) return GlobalSpace.postapocalypticShoes;
                if (type == 5) return GlobalSpace.postapocalypticWeapon;
                if (type == 6) return GlobalSpace.postapocalypticOffhand;
                if (type == 7) return GlobalSpace.postapocalypticLuckycharm;
                Log.LogBug("获取set " + set.ToString() + "属性列表时未知type：" + type.ToString());
                return GlobalSpace.postapocalypticHelmet;
            }
            if (set == 3)
            {
                if (type == 0) return GlobalSpace.futureHelmet;
                if (type == 1) return GlobalSpace.futureVision;
                if (type == 2) return GlobalSpace.futureArmor;
                if (type == 3) return GlobalSpace.futurePants;
                if (type == 4) return GlobalSpace.futureShoes;
                if (type == 5) return GlobalSpace.futureWeapon;
                if (type == 6) return GlobalSpace.futureOffhand;
                if (type == 7) return GlobalSpace.futureLuckycharm;
                Log.LogBug("获取set " + set.ToString() + "属性列表时未知type：" + type.ToString());
                return GlobalSpace.futureHelmet;
            }
            if (set == 4)
            {
                if (type == 0) return GlobalSpace.funnyHelmet;
                if (type == 1) return GlobalSpace.funnyVision;
                if (type == 2) return GlobalSpace.funnyArmor;
                if (type == 3) return GlobalSpace.funnyPants;
                if (type == 4) return GlobalSpace.funnyShoes;
                if (type == 5) return GlobalSpace.funnyWeapon;
                if (type == 6) return GlobalSpace.funnyOffhand;
                if (type == 7) return GlobalSpace.funnyLuckycharm;
                Log.LogBug("获取set " + set.ToString() + "属性列表时未知type：" + type.ToString());
                return GlobalSpace.funnyHelmet;
            }
            Log.LogBug("获取set " + set.ToString() + "属性列表时未知set");
            return GlobalSpace.standardHelmet;
        }

        /// <summary>
        /// 生成随机装备
        /// </summary>
        /// <param name="set">装备set，为负则随机</param>
        /// <param name="type">装备类型，为负则随机</param>
        /// <param name="quality">装备等级，为负则随机</param>
        /// <param name="sp1">属性1，为负则随机</param>
        /// <param name="sv1">数值1，为负则随机</param>
        /// <param name="sp2">属性2，为负则随机</param>
        /// <param name="sv2">数值2，为负则随机</param>
        /// <returns>新建装备</returns>
        private static Equipment GetRandomEquipment(int set, int type, int quality, int sp1, int sv1, int sp2, int sv2)
        {
            Random r = new Random();
            if (set < 0)
            {
                if (r.Next(0, 100) < GlobalSpace.specialSetRate)
                {
                    set = r.Next(1, GlobalSpace.maxSet + 1);
                }
                else
                {
                    set = 0;
                }
            }
            if (type <0) type = r.Next(0, GlobalSpace.maxType + 1);
            if (quality <0) quality = r.Next(0, GlobalSpace.maxQuality + 1);

            int[] ip = GetEquipmentParameterList(set, type);
            int max = 0;
            foreach (int i in ip)
            {
                if (i == 1)
                {
                    max = max + 1;
                }
            }

            //给定属性或数值时可能会生成不正常的装备

            int count;
            int j;

            //属性1
            int p1;
            if (sp1 < 0)
            {
                count = r.Next(1, max + 1);//第几个1
                j = 0;
                while (count > 0)
                {
                    if (ip[j] == 1)
                    {
                        count = count - 1;
                    }
                    j = j + 1;
                }
                p1 = j - 1;
            }
            else
            {
                p1 = sp1;
            }

            //属性2
            int p2;
            if (sp2 < 0)
            {
                count = r.Next(1, max + 1);//第几个1
                j = 0;
                while (count > 0)
                {
                    if (ip[j] == 1)
                    {
                        count = count - 1;
                    }
                    j = j + 1;
                }
                p2 = j - 1;
            }
            else
            {
                p2 = sp2;
            }

            int[] range = new int[2];

            //数值1
            int v1;
            if (sv1 < 0)
            {
                range = GetValueRange(p1, quality);
                v1 = r.Next(range[0], range[1] + 1);
            }
            else
            {
                if (p1 != 5 && p1 != 6)
                {
                    v1 = sv1;
                }
                else //力量或伤害点在给定时
                {
                    v1 = sv1 / 100;
                }
            }

            //数值2
            int v2;
            if (sv2 < 0)
            {
                range = GetValueRange(p2, quality);
                v2 = r.Next(range[0], range[1] + 1);
            }
            else
            {
                if (p2 != 5 && p2 != 6)
                {
                    v2 = sv2;
                }
                else //力量或伤害点在给定时
                {
                    v2 = sv2 / 100;
                }
            }

            return new Equipment(set, type, quality, p1, v1, p2, v2);
        }


        /// <summary>
        /// 装备合成
        /// </summary>
        /// <param name="eq">三件材料装备数组</param>
        /// <returns>合成后的新装备</returns>
        private static Equipment GetMergeEquipment(Equipment[] eq)
        {
            Random r = new Random();
            int set, type, quality;
            int i;

            //确认set
            i = r.Next(0, 4);//25%
            if(i<3)
            {
                set = eq[i].Set;
            }
            else
            {
                set = 0;
            }

            //确认类型
            i = r.Next(0, 3);//33%
            type = eq[i].Type;

            //确认等级
            //无特殊情况应该三件装备等级相同
            quality = (eq[0].Quality + eq[1].Quality + eq[2].Quality) / 3 + 1;

            //随机装备
            return GetRandomEquipment(set, type, quality, -1, -1, -1, -1);
        }


        /// <summary>
        /// 获得拆分装备（第二个装备）的类型
        /// </summary>
        /// <param name="ortype">原装备类型</param>
        /// <returns>拆分获得装备类型</returns>
        private static int GetSplitEquipmentType(int ortype)
        {
            //由于分解具体几率未公示，只能靠猜测
            /*
                分解装备	高概率	            中概率	                低概率		    猜测的几率		
                    0	    0, 1	            5, 6                    4           30x2	15x2	10
                    1	    1	                0, 5, 6	                3		    30	    20x3	10
                    2		                    1, 2, 3, 5, 6	        0, 7			    16x5	10x2
                    3	    1, 5, 6	            3	                    2, 7		25x3	15	    5x2
                    4	    4	                3, 5, 6	                0		    30	    20x3	10
                    5	    1, 5	            0, 6			                    30x2	20x2	
                    6	    6	                1, 3, 5	                0, 4, 7		31	    15x3	8x3
                    7		                    0, 1, 2, 3, 4, 5, 6, 7				        12.5x8	
            */

            Random r = new Random();
            int i = r.Next(0, 100);
            switch(ortype)
            {
                case 0:
                    {
                        if (i < 30) return 0;
                        if (i < 60) return 1;
                        if (i < 75) return 5;
                        if (i < 90) return 6;
                        return 4;
                    }
                case 1:
                    {
                        if (i < 30) return 1;
                        if (i < 50) return 0;
                        if (i < 70) return 5;
                        if (i < 90) return 6;
                        return 3;
                    }
                case 2:
                    {
                        if (i < 16) return 1;
                        if (i < 32) return 2;
                        if (i < 48) return 3;
                        if (i < 64) return 5;
                        if (i < 80) return 6;
                        if (i < 90) return 0;
                        return 7;
                    }
                case 3:
                    {
                        if (i < 25) return 1;
                        if (i < 50) return 5;
                        if (i < 75) return 6;
                        if (i < 90) return 3;
                        if (i < 95) return 2;
                        return 7;
                    }
                case 4:
                    {
                        if (i < 30) return 4;
                        if (i < 50) return 3;
                        if (i < 70) return 5;
                        if (i < 90) return 6;
                        return 0;
                    }
                case 5:
                    {
                        if (i < 30) return 1;
                        if (i < 60) return 5;
                        if (i < 80) return 0;
                        return 6;
                    }
                case 6:
                    {
                        if (i < 31) return 6;
                        if (i < 46) return 1;
                        if (i < 61) return 3;
                        if (i < 76) return 5;
                        if (i < 84) return 0;
                        if (i < 92) return 4;
                        return 7;
                    }
                case 7:
                    {
                        i = r.Next(0, 8);
                        return i;
                    }
                default:
                    {
                        Log.LogBug("获取拆分装备类型时ortype越界："+ ortype.ToString());
                        return ortype;
                    }
            }
        }


        /// <summary>
        /// 装备分解
        /// </summary>
        /// <param name="eq">原装备</param>
        /// <returns>分解后的装备数组</returns>
        private static Equipment[] GetSplitEquipment(Equipment eq)
        {
            Equipment[] se = new Equipment[2];
            Random r = new Random();
            int set, type, quality;
            int i;

            //第一件装备

            //确认set
            i = r.Next(0, 4);//75%
            if(i<3)
            {
                set = eq.Set;
            }
            else
            {
                set = 0;
            }

            //确认类型
            type = eq.Type;

            //确认等级
            quality = eq.Quality - 1;

            se[0] = GetRandomEquipment(set, type, quality, -1, -1, -1, -1);

            //第二件装备

            //确认set
            i = r.Next(0, 4);//25%
            if (i < 1)
            {
                set = eq.Set;
            }
            else
            {
                set = 0;
            }

            //确认类型
            type = GetSplitEquipmentType(eq.Type);

            //确认等级
            quality = eq.Quality - 1;

            se[1] = GetRandomEquipment(set, type, quality, -1, -1, -1, -1);

            return se;
        }


        private static int StorageSortMethod(Equipment e1, Equipment e2)
        {
            if (e1.Quality.CompareTo(e2.Quality) != 0)
            {
                return -e1.Quality.CompareTo(e2.Quality);
            }
            else if (e1.Type.CompareTo(e2.Type) != 0)
            {
                return e1.Type.CompareTo(e2.Type);
            }
            else if (e1.Parameter1.CompareTo(e2.Parameter1) != 0)
            {
                return e1.Parameter1.CompareTo(e2.Parameter1);
            }
            else
            {
                return -e1.Value1.CompareTo(e2.Value1);
            }
        }


        /// <summary>
        /// 对仓库中的装备排序
        /// </summary>
        private static void StorageSort()
        {
            GlobalSpace.storage.Sort(StorageSortMethod);
        }


        private static string EquipmentType2String(int type)
        {
            switch (type)
            {
                case 0: return "头盔";
                case 1: return "护目镜";
                case 2: return "盔甲";
                case 3: return "作战裤";
                case 4: return "作战靴";
                case 5: return "武器配件";
                case 6: return "副手";
                case 7: return "幸运符";
                default: return "[未知类型]";
            }
        }

        private static string EquipmentSet2String(int set)
        {
            switch (set)
            {
                case 0: return "";
                case 1: return "(Pirate Set)";
                case 2: return "(Post Apocalyptic Set)";
                case 3: return "(Future Set)";
                case 4: return "(Funny Set)";
                default: return "(未知Set)";
            }
        }

        private static string EquipmentParameter2String(int parameter)
        {
            switch (parameter)
            {
                case 0: return "miss";
                case 1: return "暴击";
                case 2: return "大伤";
                case 3: return "小伤";
                case 4: return "免体";
                case 5: return "力量";
                case 6: return "伤害点";
                case 7: return "经济技能";
                case 8: return "飞行";
                case 9: return "连击消耗";
                case 10: return "捡到手枪";
                default: return "[未知属性]";
            }
        }

        private static string EquipmentValue2String(int parameter, int value)
        {
            double v = value;
            switch (parameter)
            {
                case 0: 
                case 1: 
                case 2: 
                case 3:
                case 4:
                case 8:
                case 9:
                case 10: return (v / 100).ToString("F2")+"%";
                case 5: 
                case 6: return value.ToString();
                case 7: return (v / 100).ToString("F2");
                default: return "[未知数值]";
            }
        }


        public static string GetEquipmentTitle(Equipment eq)
        {
            return "Q" + (eq.Quality + 1).ToString() + " " + EquipmentType2String(eq.Type) + EquipmentSet2String(eq.Set);
        }


        public static string GetEquipmentInfo(Equipment eq)
        {
            return "Q" + (eq.Quality + 1).ToString() + " " + EquipmentType2String(eq.Type) + EquipmentSet2String(eq.Set) + "\r\n" + EquipmentParameter2String(eq.Parameter1) + " " + EquipmentValue2String(eq.Parameter1, eq.Value1) + "\r\n" + EquipmentParameter2String(eq.Parameter2) + " " + EquipmentValue2String(eq.Parameter2, eq.Value2);
        }


        public static string GetEquipmentLineInfo(Equipment eq)
        {
            return "Q" + (eq.Quality + 1).ToString() + " " + EquipmentType2String(eq.Type) + EquipmentSet2String(eq.Set) + " (" + EquipmentParameter2String(eq.Parameter1) + " " + EquipmentValue2String(eq.Parameter1, eq.Value1) + " / " + EquipmentParameter2String(eq.Parameter2) + " " + EquipmentValue2String(eq.Parameter2, eq.Value2)+")";
        }

        public static string GetEquipmentLineInfo(int set, int type, int quality, int p1, int v1, int p2, int v2)
        {
            return "Q" + (quality + 1).ToString() + " " + EquipmentType2String(type) + EquipmentSet2String(set) + " (" + EquipmentParameter2String(p1) + " " + EquipmentValue2String(p1, v1) + " / " + EquipmentParameter2String(p2) + " " + EquipmentValue2String(p2, v2) + ")";
        }


        public static void LogEquipment(Equipment eq)
        {
            string s = GetEquipmentLineInfo(eq);
            int start = Form1.f.LogRichTextBox.Text.Length;
            Form1.f.LogRichTextBox.AppendText(GetEquipmentLineInfo(eq));
            Form1.f.LogRichTextBox.Select(start, s.Length);
            Form1.f.LogRichTextBox.SelectionColor = GlobalSpace.qualityColor[eq.Quality];
            Form1.f.LogRichTextBox.ScrollToCaret();
        }

        public static void LogString(string s)
        {
            int start = Form1.f.LogRichTextBox.Text.Length;
            Form1.f.LogRichTextBox.AppendText(s);
            Form1.f.LogRichTextBox.Select(start, s.Length);
            Form1.f.LogRichTextBox.SelectionColor = Color.Black;
            Form1.f.LogRichTextBox.ScrollToCaret();
        }

        /// <summary>
        /// 新建随机装备，并刷新仓库
        /// </summary>
        /// <param name="set">装备set，为负则随机</param>
        /// <param name="type">装备类型，为负则随机</param>
        /// <param name="quality">装备等级，为负则随机</param>
        /// <param name="sp1">属性1，为负则随机</param>
        /// <param name="sv1">数值1，为负则随机</param>
        /// <param name="sp2">属性2，为负则随机</param>
        /// <param name="sv2">数值2，为负则随机</param>
        public static void CreateRandomEquipment(int set, int type, int quality, int sp1, int sv1, int sp2, int sv2)
        {
            Equipment eq = GetRandomEquipment(set, type, quality, sp1, sv1, sp2, sv2);
            GlobalSpace.storage.Add(eq);
            StorageSort();

            LogString("你获得了 ");
            LogEquipment(eq);
            LogString("\r\n");
        }


        /// <summary>
        /// 新建随机装备，穿上并刷新仓库
        /// </summary>
        /// <param name="set">装备set，为负则随机</param>
        /// <param name="type">装备类型，为负则随机</param>
        /// <param name="quality">装备等级，为负则随机</param>
        /// <param name="sp1">属性1，为负则随机</param>
        /// <param name="sv1">数值1，为负则随机</param>
        /// <param name="sp2">属性2，为负则随机</param>
        /// <param name="sv2">数值2，为负则随机</param>
        public static void CreateWearedRandomEquipment(int set, int type, int quality, int sp1, int sv1, int sp2, int sv2)
        {
            Equipment eq = GetRandomEquipment(set, type, quality, sp1, sv1, sp2, sv2);
            GlobalSpace.storage.Add(eq);
            WearEquipment(eq);
            StorageSort();

            LogString("你穿上了 ");
            LogEquipment(eq);
            LogString("\r\n");
        }

        public delegate void CWREInvoke(int set, int type, int quality, int sp1, int sv1, int sp2, int sv2);


        /// <summary>
        /// 分解装备，并刷新仓库
        /// </summary>
        /// <param name="eq">被分解装备</param>
        public static void SplitEquipment(Equipment eq)
        {
            Equipment[] neweq = GetSplitEquipment(eq);
            GlobalSpace.storage.Remove(eq);
            GlobalSpace.storage.Add(neweq[0]);
            GlobalSpace.storage.Add(neweq[1]);
            StorageSort();

            LogString("你分解了 ");
            LogEquipment(eq);
            LogString(" ，获得了 ");
            LogEquipment(neweq[0]);
            LogString(" 和 ");
            LogEquipment(neweq[1]);
            LogString("\r\n");
        }


        /// <summary>
        /// 合成装备，并刷新仓库
        /// </summary>
        /// <param name="eq">合成装备数组</param>
        public static void MergeEquipment(Equipment[] eq)
        {
            Equipment neweq = GetMergeEquipment(eq);
            GlobalSpace.storage.Remove(eq[0]);
            GlobalSpace.storage.Remove(eq[1]);
            GlobalSpace.storage.Remove(eq[2]);
            GlobalSpace.storage.Add(neweq);
            StorageSort();

            LogString("你将装备 ");
            LogEquipment(eq[0]);
            LogString(" 、 ");
            LogEquipment(eq[1]);
            LogString(" 、 ");
            LogEquipment(eq[2]);
            LogString(" 合成为 ");
            LogEquipment(neweq);
            LogString("\r\n");
        }


        /// <summary>
        /// 出售装备，并刷新仓库
        /// </summary>
        /// <param name="eq">出售的装备</param>
        public static void SellEquipment(Equipment eq)
        {
            GlobalSpace.storage.Remove(eq);
            StorageSort();

            LogString("你出售了 ");
            LogEquipment(eq);
            LogString("\r\n");
        }


        /// <summary>
        /// 穿上装备，并刷新仓库
        /// </summary>
        /// <param name="eq">穿上的装备</param>
        public static void WearEquipment(Equipment eq)
        {
            if (GlobalSpace.wearedEquipment[eq.Type] != null)
            {
                GlobalSpace.storage.Add(GlobalSpace.wearedEquipment[eq.Type]);
            }
            GlobalSpace.wearedEquipment[eq.Type] = eq;
            GlobalSpace.storage.Remove(eq);

            StorageSort();
        }


        /// <summary>
        /// 脱下装备，并刷新仓库
        /// </summary>
        /// <param name="type">脱下装备的类型</param>
        public static void UnwearEquipment(int type)
        {

            GlobalSpace.storage.Add(GlobalSpace.wearedEquipment[type]);
            GlobalSpace.wearedEquipment[type] = null;
            StorageSort();
        }


        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="strength">力量数值</param>
        /// <param name="militaryRankCount">军衔索引</param>
        /// <returns>信息字符串</returns>
        public static string UpdateState(int strength, int militaryRankCount)
        {
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
            for(int i = 0;i<= GlobalSpace.maxParameter; i++)
            {
                state[i] = sum[i] + GlobalSpace.stateInitialValue[i];
                if (state[i] > GlobalSpace.stateMaxValue[i] && GlobalSpace.stateMaxValue[i]>=0)
                {
                    state[i] = GlobalSpace.stateMaxValue[i];
                }
            }

            //计算伤害
            double baseDmg;
            if (militaryRankCount<0 || militaryRankCount> GlobalSpace.militaryRankBonus.Length)
            {
                Log.LogBug("军衔索引越界："+ militaryRankCount.ToString());
                militaryRankCount = 0;
            }
            double militaryRank = GlobalSpace.militaryRankBonus[militaryRankCount];
            if (strength <= 0)
            {
                Log.LogBug("力量非正数：" + strength.ToString());
                strength = 1;
            }
            
            double miss = -(double)state[0] / 10000;
            double critical = (double)state[1] / 10000;
            double maxDamage = (double)state[2] / 10000;
            double minDamage = (double)state[3] / 10000;
            double avoid = (double)state[4] / 10000;
            double strengthq = strength + state[5];
            double increaseHit = state[6];

            baseDmg= (militaryRank * strengthq * 0.8 * (1 + minDamage) + militaryRank * strengthq * 1.2 * (1 + maxDamage + minDamage)) / 2 + increaseHit;

            int avgQ1 = (int)Math.Round(baseDmg * 5 * (1 + 0.2 * 1));
            int avgCQ1 = (int)Math.Round(baseDmg * 10 * (1 + 0.2 * 1));
            int avgQ5 = (int)Math.Round(baseDmg * 5 * (1 + 0.2 * 5));
            int avgCQ5 = (int)Math.Round(baseDmg * 10 * (1 + 0.2 * 5));

            //计算伤害和爆发比率
            double score2 = ((double)avgQ1 / 1.2 / 5) * (1 + critical) * (1 - miss) / (strengthq * militaryRank * 1.125 * 0.875);
            if (score2 < 1) score2 = 1;
            double score1 = score2 * 0.95 / (1 - avoid);

            string s = "";
            s += "Q1连击平均伤害/暴击伤害： " + avgQ1 + " / " + avgCQ1 + "\r\n";
            s += "Q5连击平均伤害/暴击伤害： " + avgQ5 + " / " + avgCQ5 + "\r\n";
            s += "\r\n";
            s += "总伤害： " + ((score1 - 1) * 100).ToString("F2") + " %" + "     ";
            s += "爆发力： " + ((score2 - 1) * 100).ToString("F2") + " %" + "  （未考虑其他加成）\r\n";
            s += "\r\n";
            s += "暴击率： " + EquipmentValue2String(1, state[1]) + "     ";
            s += "打空率： " + EquipmentValue2String(0, -state[0]) + "     ";
            s += "免伤率： " + EquipmentValue2String(4, state[4]) + "\r\n";
            s += "\r\n";
            s += "提高减少每次连击手枪消耗概率： " + EquipmentValue2String(9, state[9]) + "\r\n";
            s += "提高获得一支手枪概率：         " + EquipmentValue2String(10, state[10]) + "\r\n";
            s += "提高免机票飞行概率：           " + EquipmentValue2String(8, state[8]) + "\r\n";
            s += "提高经济技能：                 " + EquipmentValue2String(7, state[7]);

            return s;
        }
    }


}
