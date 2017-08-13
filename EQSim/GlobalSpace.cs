using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EQSim
{
    /// <summary>
    /// 公共常量、公共变量
    /// </summary>
    public class GlobalSpace
    {

        #region 系统

        //装备属性上限
        public const int maxSet = 4;
        public const int maxType = 7;
        public const int maxQuality = 5;
        public const int maxParameter = 10;


        //装备数值范围
        public static int[] economicMin = { 10, 20, 40, 60, 80, 110 };
        public static int[] economicMax = { 20, 40, 60, 80, 110, 140 };

        public static int[] flightMin = { 50, 100, 150, 200, 300, 400 };
        public static int[] flightMax = { 100, 150, 200, 300, 400, 550 };

        public static int[] missMin = { 0, 150, 300, 450, 600, 750 };
        public static int[] missMax = { 150, 300, 450, 600, 750, 900 };

        public static int[] criticalMin = { 0, 100, 200, 300, 400, 600 };
        public static int[] criticalMax = { 100, 200, 300, 400, 600, 800 };

        public static int[] avoidMin = { 0, 100, 200, 300, 400, 600 };
        public static int[] avoidMax = { 100, 200, 300, 400, 600, 800 };

        public static int[] damageMin = { 0, 100, 200, 300, 400, 600 };
        public static int[] damageMax = { 100, 200, 300, 400, 600, 800 };

        public static int[] maxdamageMin = { 0, 200, 400, 600, 800, 1200 };
        public static int[] maxdamageMax = { 200, 400, 600, 800, 1200, 1600 };

        public static int[] strengthMin = { 10, 16, 20, 24, 28, 40 };
        public static int[] strengthMax = { 16, 20, 24, 28, 40, 60 };

        public static int[] hitMin = { 20, 40, 50, 60, 70, 90 };
        public static int[] hitMax = { 40, 50, 60, 70, 90, 130 };

        public static int[] berserkMin = { 300, 400, 500, 600, 700, 800 };
        public static int[] berserkMax = { 400, 500, 600, 700, 800, 1000 };

        public static int[] findMin = { 200, 250, 300, 350, 400, 450 };
        public static int[] findMax = { 250, 300, 350, 400, 450, 500 };


        //装备随机属性列表
        public static int[] standardHelmet = { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
        public static int[] standardVision = { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
        public static int[] standardArmor = { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
        public static int[] standardPants = { 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0 };
        public static int[] standardShoes = { 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0 };
        public static int[] standardWeapon = { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
        public static int[] standardOffhand = { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
        public static int[] standardLuckycharm = { 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0 };

        public static int[] pirateHelmet = { 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0 };
        public static int[] pirateVision = { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
        public static int[] pirateArmor = { 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0 };
        public static int[] piratePants = { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
        public static int[] pirateShoes = { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
        public static int[] pirateWeapon = { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
        public static int[] pirateOffhand = { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
        public static int[] pirateLuckycharm = { 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0 };

        public static int[] postapocalypticHelmet = { 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1 };
        public static int[] postapocalypticVision = { 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1 };
        public static int[] postapocalypticArmor = { 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1 };
        public static int[] postapocalypticPants = { 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1 };
        public static int[] postapocalypticShoes = { 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1 };
        public static int[] postapocalypticWeapon = { 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1 };
        public static int[] postapocalypticOffhand = { 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1 };
        public static int[] postapocalypticLuckycharm = { 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0 };

        public static int[] futureHelmet = { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0 };
        public static int[] futureVision = { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0 };
        public static int[] futureArmor = { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0 };
        public static int[] futurePants = { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0 };
        public static int[] futureShoes = { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0 };
        public static int[] futureWeapon = { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0 };
        public static int[] futureOffhand = { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0 };
        public static int[] futureLuckycharm = { 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0 };

        public static int[] funnyHelmet = { 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1 };
        public static int[] funnyVision = { 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1 };
        public static int[] funnyArmor = { 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1 };
        public static int[] funnyPants = { 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1 };
        public static int[] funnyShoes = { 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1 };
        public static int[] funnyWeapon = { 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1 };
        public static int[] funnyOffhand = { 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1 };
        public static int[] funnyLuckycharm = { 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0 };


        //属性初始值
        public static int[] stateInitialValue = { -1250, 1250, 0, 0, 500, 0, 0, 0, 0, 0, 0 };

        //属性最大值
        public static int[] stateMaxValue = { 0, 4000, -1, -1, 4000, -1, -1, 1000, 2500, 4000, 4000 };


        //军衔名称
        public static string[] militaryRankName = { "新兵 Rookie (1.0)", "二等兵 Private (1.1)", "一等兵 Private First Class (1.2)", "下士 Corporal (1.3)", "中士 Sergeant (1.4)", "上士 Staff Sergeant (1.5)", "一等军士 Sergeant First Class (1.6)", "军士长 Master Sergeant (1.65)", "第一军士长 First Sergeant (1.7)", "主任军士长 Sergeant Major (1.75)", "参谋军士长 Command Sergeant Major (1.8)", "总军士长 Sergeant Major of the Army (1.85)", "少尉 Second Lieutenant (1.9)", "中尉 First Lieutenant (1.93)", "上尉 Captain (1.96)", "少校 Major (2.0)", "中校 Lieutenant Colonel (2.03)", "上校 Colonel (2.06)", "准将 Brigadier General (2.1)", "少将 Major General (2.13)", "中将 Lieutenant General (2.16)", "上将 General (2.19)", "五星上将 General of the Army (2.21)", "元帅 Marshall (2.24)", "陆军元帅 Field Marshall (2.27)", "特级元帅 Supreme Marshall (2.3)", "大元帅 Generalissimus (2.33)", "特级大元帅 Supreme Generalissimuss (2.36)", "帝国大元帅 Imperial Generalissimus (2.4)", "传奇大元帅 Legendary Generalissimuss (2.42)", "最高统治者 Imperator (2.44)", "最高统治者 凯撒 Imperator Caesar (2.46)", "半神 Deus Dimidiam (2.48)", "神 Deus (2.5)", "至高之神 Summi Deus (2.52)", "众神之王 Deus Imperialis (2.54)", "传奇之神 Deus Fabuloso (2.56)", "终极之神 Deus Ultimum (2.58)" };

        //军衔加成
        public static double[] militaryRankBonus = { 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.65, 1.7, 1.75, 1.8, 1.85, 1.9, 1.93, 1.96, 2, 2.03, 2.06, 2.1, 2.13, 2.16, 2.19, 2.21, 2.24, 2.27, 2.3, 2.33, 2.36, 2.4, 2.42, 2.44, 2.46, 2.48, 2.5, 2.52, 2.54, 2.56, 2.58 };


        //自动生成相关
        //特殊set出现几率
        public static int specialSetRate = 10;


        //装备品质颜色
        public static Color[] qualityColor = { Color.Red, Color.OrangeRed, Color.Goldenrod, Color.Green, Color.Purple, Color.DodgerBlue };


        //Html分析相关
        public static string[] htmlSpecialSet = { "pirate", "postapo", "future", "ee" };
        public static string[] htmlType = { "helmet", "vision", "armor", "pants", "shoes", "weapon", "offhand", "charm" };
        public static string[] htmlParameter = { "Reduce miss chance", "Increase critical chance", "Increase maximum damage", "Increase damage", "Increase chance to avoid damage", "Increase strength", "Increase hit", "Economic skill increase", "Increase chance for free flight", "Less weapons per berserk", "Chance to find a weapon" };

        #endregion

        #region 个人信息

        //穿着的装备
        public static Equipment[] wearedEquipment = new Equipment[8];


        //背包中的装备
        public static List<Equipment> storage = new List<Equipment>();

        #endregion

    }
}
