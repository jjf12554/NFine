using HtmlAgilityPack;
using NFine.Application.Config;
using NFine.Code;
using NFine.Domain._03_Entity.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NFine.Web.Controllers
{
    public class jjfController : ApiController
    {
        private RecruitApp recruitApp = new RecruitApp();
        [HttpGet]
        public string Test()
        {
            if (!WriteRecruit(@"http://www.shiyebian.net/zhejiang/jiaxing/"))
            {
                return "false";
            }
            string str = HttpHelp.DownLoadString(@"http://www.shiyebian.net/zhejiang/jiaxing/");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(str);

            if (htmlDoc.DocumentNode.SelectSingleNode("//div[@class='fenye']") == null)
            {
                return "false";
            }
            HtmlNodeCollection liNodes2 = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='fenye']").SelectNodes("a");
            if (liNodes2 != null && liNodes2.Count > 0)
            {
                for (int i = 0; i < liNodes2.Count; i++)
                {
                    if (string.IsNullOrEmpty(liNodes2[i].GetAttributeValue("href", "")))
                    {
                        continue;
                    }
                    string href = liNodes2[i].GetAttributeValue("href", "").Trim();
                    WriteRecruit(href);
                }
            }
            
            return "true";
        }

        private bool WriteRecruit(string url)
        {
            string str = HttpHelp.DownLoadString(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(str);

            if (htmlDoc.DocumentNode.SelectSingleNode("//div[@class='listlie']") == null)
            {
                return false;
            }
            HtmlNodeCollection liNodes = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='listlie']").SelectSingleNode("ul[1]").SelectNodes("li");
            if (liNodes != null && liNodes.Count > 0)
            {
                for (int i = 0; i < liNodes.Count; i++)
                {
                    string date = liNodes[i].SelectSingleNode("em").InnerText.Trim();
                    string title = liNodes[i].SelectSingleNode("a[1]").InnerText.Trim();
                    string href = liNodes[i].SelectSingleNode("a[1]").GetAttributeValue("href", "").Trim();
                    if (recruitApp.IsRecruitExit(href))
                    {
                        continue;
                    }
                    RecruitEntity recruitEntity = new RecruitEntity()
                    {
                        Recruit_Title = title,
                        Recruit_Url = href,
                        Recruit_Date = date
                    };
                    recruitApp.SubmitForm(recruitEntity);
                    Console.WriteLine("新闻标题：" + title + ",链接：" + href);
                }
            }
            return true;
        }
    }
}
