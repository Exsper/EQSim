using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQSim
{

    /// <summary>
    /// 模拟伤害
    /// 部分代码来源于官方模拟器
    /// </summary>
    class DamageSimulation
    {
        /// <summary>
        /// 计算每次连击的伤害加成
        /// </summary>
        /// <param name="steroids">拳头(1,-1,0)   buff=1.2    debuff=0.8  无=1</param>
        /// <param name="tank">坦克(1,-1,0)   buff&&Q5=1.2    debuff=只能Q0 无=1</param>
        /// <param name="bunker">保家卫国(1,-1,0)   buff=1.25   debuff=0.8  无=1</param>
        /// <param name="sewerGuide">起义猛士(1,-1,0)   buff=1.25   debuff=0.8  无=1</param>
        /// <param name="surendedModifier">被包围(1,0) 有=0.8 无=1</param>
        /// <param name="locationModifier">本地加成(1,0)    有=1.2   无=1</param>
        /// <param name="muQuality">军令加成(0,1,2,3,4) 无=1 其他=muQuality*0.05</param>
        /// <param name="coBonus">联盟令加成 百分数形式</param>
        /// <param name="dsQuality">防御系统(0,1,2,3,4,5)   无=1 其他=dsQuality*0.05</param>
        /// <param name="moreDmg">伤害加成  百分数形式</param>
        /// <param name="weaponQuality">武器品质(0,1,2,3,4,5)   空手=0.5  其他=1+0.2*weaponQuality</param>
        /// <returns>伤害加成</returns>
        public static double CalculateOneBerserkModifiers(int steroids, int tank, int bunker, int sewerGuide, int surendedModifier, int locationModifier, int muQuality, double coBonus, int dsQuality, int moreDmg, int weaponQuality)
        {
            double steroidsInf = 1.0;
            if (steroids == 1) { steroidsInf = 1.2; }
            if (steroids == -1) { steroidsInf = 0.8; }

            double tankInf = 1.0;
            if (tank == 1 && weaponQuality == 5) { tankInf = 1.2; }

            double bunkerInf = 1.0;
            if (bunker == 1) { bunkerInf = 1.25; }
            if (bunker == -1) { bunkerInf = 0.8; }

            double sewerGuideInf = 1.0;
            if (sewerGuide == 1) { sewerGuideInf = 1.25; }
            if (sewerGuide == -1) { sewerGuideInf = 0.8; }

            double surendedModifierInf = 1.0;
            if (surendedModifier == 1) { surendedModifierInf = 0.8; }

            double locationModifierInf = 1.0;
            if (locationModifier == 1) { locationModifierInf = 1.2; }

            double muBonusInf = 1.0;
            if (muQuality != 0) { muBonusInf = 1 + muQuality * 0.05; }

            double coBonusInf = 1.0;
            if (coBonus != 0) { coBonusInf = 1 + coBonus * 0.01; }

            double dsInf = 1.0;
            if (dsQuality != 0) { dsInf = 1 + dsQuality * 0.05; }

            double moreDmgInf = 1.0;
            if (moreDmg != 0) { moreDmgInf = 1 + moreDmg * 0.01; }

            double weaponInf = 0.5;
            if (weaponQuality != 0 && tank != -1) { weaponInf = 1 + 0.2 * weaponQuality; }

            return 1.0 * steroidsInf * tankInf * bunkerInf * sewerGuideInf * surendedModifierInf * locationModifierInf * muBonusInf * coBonusInf * dsInf * moreDmgInf * weaponInf;
        }

        /// <summary>
        /// 计算每次连击的基础伤害范围（不含武器，不含miss情况）
        /// </summary>
        /// <param name="strengthq">力量</param>
        /// <param name="militaryRank">军衔加成</param>
        /// <param name="minDamage">小伤加成</param>
        /// <param name="maxDamage">大伤加成</param>
        /// <param name="increaseHit">伤害点</param>
        /// <returns>每次连击的基础伤害范围</returns>
        public static double[] CalculateOneBerserkBaseDamage(double militaryRank, double strengthq, double minDamage, double maxDamage, double increaseHit)
        {
            double[] baseDmg = new double[2];
            baseDmg[0] = (militaryRank * strengthq * 0.8 * (1 + minDamage) + increaseHit) * 5;
            baseDmg[1] = (militaryRank * strengthq * 1.2 * (1 + maxDamage + minDamage) + increaseHit) * 5;
            return baseDmg;
        }

        /// <summary>
        /// 计算每次连击的伤害范围（不含miss情况）
        /// </summary>
        /// <param name="baseDamage">基础伤害范围（不含武器，不含miss情况）</param>
        /// <param name="berserkModifiers">伤害加成</param>
        /// <returns>每次连击伤害范围</returns>
        public static int[] CalculateOneBerserkDamage(double[] baseDamage, double berserkModifiers)
        {
            double[] berserkDamage = new double[2];
            berserkDamage[0] = baseDamage[0] * berserkModifiers;
            berserkDamage[1] = baseDamage[1] * berserkModifiers;
            int[] berserkDamageInt = new int[2];
            berserkDamageInt[0] = Convert.ToInt32(berserkDamage[0]);
            berserkDamageInt[1] = Convert.ToInt32(berserkDamage[1]);
            return berserkDamageInt;
        }

        /// <summary>
        /// 计算每次连击非miss机率（百分比）
        /// </summary>
        /// <param name="miss">miss机率</param>
        /// <returns>非miss机率（百分比）</returns>
        public static int CalculateNotMissChance(double miss)
        {
            return Convert.ToInt32((1 - miss) * 100);
        }

        /// <summary>
        /// 计算每次连击暴击机率（百分比）
        /// </summary>
        /// <param name="critical">暴击率</param>
        /// <param name="painDealer">暴击加成(1,0)    有=2倍   无=1</param>
        /// <param name="moreCritics">暴击加成  百分数形式</param>
        /// <returns>每次连击暴击机率（百分比）</returns>
        public static int CalculateCriticalChance(double critical, int painDealer, int moreCritics)
        {
            double criticalChance = critical;
            if (painDealer == 1) { criticalChance = 2 * criticalChance; }
            if (moreCritics != 0) { criticalChance = criticalChance * (1 + moreCritics * 0.01); }
            if (criticalChance > 0.8) { criticalChance = 0.8; }

            return Convert.ToInt32(criticalChance * 100);
        }

        /// <summary>
        /// 计算每次连击免伤机率（百分比）
        /// </summary>
        /// <param name="avoid">免伤率</param>
        /// <param name="hospitalQuality">医院(0,1,2,3,4,5)   无=1 其他=hospitalQuality*0.05</param>
        /// <param name="camouflageQuality">烟雾弹(0,1,2,3)    无=1 1=0.4   2=0.2   3=0.1</param>
        /// <returns>每次连击免伤机率（百分比）</returns>
        public static int CalculateAvoidChance(double avoid, int hospitalQuality, int camouflageQuality)
        {
            //！免伤算法尚待确认
            double avoidChance = avoid;
            if (camouflageQuality == 1) { avoidChance = avoidChance + 0.4; }
            if (camouflageQuality == 2) { avoidChance = avoidChance + 0.2; }
            if (camouflageQuality == 3) { avoidChance = avoidChance + 0.1; }
            avoidChance = avoidChance + hospitalQuality * 0.05 - avoidChance * hospitalQuality * 0.05;
            if (avoidChance > 0.4) avoidChance = 0.4;
            return Convert.ToInt32(avoidChance * 100);
        }


        private static void Calculate(int strength, int militaryRankCount)
        {


        }
    }
}
