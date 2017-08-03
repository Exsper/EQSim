using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace EQSim
{
    /// <summary>
    /// 从profile页面获取装备信息
    /// 基于HtmlAgilityPack 1.5.1
    /// 安装（从NuGet）： PM> Install-Package HtmlAgilityPack -Version 1.5.1
    /// </summary>
    class GetEquipmentsFormWebsite
    {
        private static int[] GetEquipmentParameterValue(string s)
        {
            //-Increase critical chance by 3.45 %
            string[] sp = s.Split(new string[] { "by" }, 2, StringSplitOptions.RemoveEmptyEntries);
            string param = sp[0].Trim();
            if (param.StartsWith("-") || param.StartsWith("+"))
            {
                param = param.Substring(1).Trim();
            }
            string value = sp[1].Trim();
            if (value.EndsWith("%"))
            {
                value = value.Substring(0, value.Length - 1).Trim();
            }
            int[] pv = new int[] { 0, 0 };
            for (int i = 0; i < GlobalSpace.htmlParameter.Length; i++)
            {
                if (param == GlobalSpace.htmlParameter[i])
                {
                    pv[0] = i;
                    break;
                }
            }
            try
            {
                pv[1] = Convert.ToInt32(Convert.ToDouble(value) * 100);
            }
            catch
            {
                pv[1] = -1;
                Log.LogInfo("属性的值获取错误");
            }
            return pv;
        }

        private static int[] GetEquipmentSetTypeQuality(string s)
        {
            //equipmentImage future_weapon4
            //去除"equipmentImage "
            s = s.Substring(15);
            int[] result = new int[3];
            string[] sp = s.Split('_');
            string tq;

            //set
            if (sp.Length == 1)
            {
                result[0] = 0;
                tq = s;
            }
            else if(sp.Length == 2)
            {
                for(int i =0;i< GlobalSpace.htmlSpecialSet.Length;i++)
                {
                    if (sp[0] == GlobalSpace.htmlSpecialSet[i])
                    {
                        result[0] = i + 1;
                        break;
                    }
                }
                tq = sp[1];
            }
            else
            {
                Log.LogBug("获取到未知装备类型：" + s);
                return new int[] { 0, 0, 0 };
            }

            //type

            string type = tq.Substring(0, tq.Length - 1);
            for (int i = 0; i < GlobalSpace.htmlType.Length; i++)
            {
                if (type == GlobalSpace.htmlType[i])
                {
                    result[1] = i;
                    break;
                }
            }

            result[2] = Convert.ToInt32(tq.Substring(tq.Length - 1)) - 1;

            return result;
        }


        private static string GetGeneralContent(string strUrl)
        {
            string strMsg = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(strUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                strMsg = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch (Exception ex)
            {
                Log.LogBug(ex.Message);
            }
            return strMsg;
        }

        public static void GetEquipment(string url)
        {
            string s = GetGeneralContent(url);
            string eqtitle;
            string[] eqs =new string[8];
            int i = 0;
            //Log.LogInfo(s);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(s);
            HtmlNode node = doc.GetElementbyId("profileEquipmentNew");
            foreach (HtmlNode eqBox in node.ChildNodes)
            {
                foreach (HtmlNode eqBack in eqBox.ChildNodes)
                {
                    foreach (HtmlNode eqNode in eqBack.ChildNodes)
                    {
                        try
                        {
                            eqtitle = eqNode.Attributes["title"].Value;
                        }
                        catch
                        {
                            eqtitle = null;
                        }
                        if (eqtitle != null)
                        {
                            eqs[i] = eqtitle;
                            i = i + 1;
                        }
                    }
                }
            }

            if (i!=8)
            {
                Log.LogBug("获取的装备信息有误");
            }



            foreach(string eqhtml in eqs)
            {
                if(eqhtml != "No item")
                {
                    /*  eqhtml内容：
                     *  div class="equipmentBack q4（品质）"
                     *      └div class="equipmentImage (future_)weapon4（(set_)类型简称+品质）"
                     *  div class="equipmentBlueBox"
                     *      └<b>Q4 Weapon upgrade（品质+类型）</b>
                     *      
                     *  -------------------------------特殊set时-------------------------------
                     *  div class="equipmentBlueBox"
                     *      └<b>Q5 Vision（品质+类型）</b>
                     *      └<span class="smallEqFnt"><br>Future Set（set类型）</span>
                     *  -----------------------------------------------------------------------
                     *  
                     *  div class="tooltipDiv" style="height:auto !important;"
                     *      └<b>
                     *          └<bdo>Laser aiming module (#3197657)（名称和ID）</bdo>
                     *      └</b>
                     *      └div
                     *  div class="miniEquipmentRedCap"
                     *      └<i class="icon-lightning2" style="margin-top:8px!important;"></i>
                     *  <p class="miniStatsName">- Increase maximum damage by 7.88%</p>（属性+ by +数值）
                     *  div
                     *  div class="miniEquipmentRedCap"
                     *      └<i class="icon-danger" style="margin-top:8px!important;"></i>
                     *  <p class="miniStatsName">- Increase critical chance by 3.45%</p>（属性+ by +数值）
                     */

                    HtmlDocument eqdoc = new HtmlDocument();
                    eqdoc.LoadHtml(eqhtml);
                    string nodeClass;
                    string infoString;
                    int[] setTypeQuality = new int[3];
                    int[] pv1 = new int[2];
                    int[] pv2 = new int[2];
                    bool existpv1 = false;
                    foreach (HtmlNode eqInfoNode in eqdoc.DocumentNode.ChildNodes)
                    {
                        try
                        {
                            nodeClass = eqInfoNode.Attributes["class"].Value;
                        }
                        catch
                        {
                            nodeClass = null;
                        }
                        if (nodeClass != null)
                        {
                            if (nodeClass.StartsWith("equipmentBack") == true)
                            {
                                infoString= eqInfoNode.ChildNodes[1].Attributes["class"].Value;
                                setTypeQuality = GetEquipmentSetTypeQuality(infoString);
                            }
                            if (nodeClass == "miniStatsName")
                            {
                                infoString = eqInfoNode.InnerText;
                                if (existpv1 == false)
                                {
                                    pv1 = GetEquipmentParameterValue(infoString);
                                    existpv1 = true;
                                }
                                else
                                {
                                    pv2 = GetEquipmentParameterValue(infoString);
                                }
                            }
                        }
                    }
                    EquipmentOperation.CreateWearedRandomEquipment(setTypeQuality[0], setTypeQuality[1], setTypeQuality[2], pv1[0], pv1[1], pv2[0], pv2[1]);
                }

            }

        }
    }
}
