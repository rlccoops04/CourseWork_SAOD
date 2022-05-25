using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CourseWork_SAOD
{
    public class XMLReadSave
    {
        private string file_path;
        public string GetFilePath()
        {
            return file_path;
        }
        public void SetFilePath(string file_path)
        {
            this.file_path = file_path;
        }
        public XMLReadSave(string file_path)
        {
            SetFilePath(file_path);
        }
        public SportsLeague OpenFile()
        {
            XmlDocument xDoc = new XmlDocument();
            StreamReader sr = new StreamReader("D:\\Visual studio projects\\input.xml");
            try
            {
                xDoc.Load(sr);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            XmlElement xRoot = xDoc.DocumentElement;

            SportsLeague sportsLeague = new SportsLeague(xRoot.GetAttribute("name").ToString());

            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    string teamName = xnode.Attributes.GetNamedItem("name").Value;
                    Team team = new Team(teamName);
                    ListElement listElement = new ListElement(team);
                    sportsLeague.PushTeamEnd(listElement);

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        string player_surname = null;
                        int player_Num = 0;

                        foreach (XmlNode ch in childnode.ChildNodes)
                        {
                            if (ch.Name == "surname")
                            {
                                player_surname = ch.InnerText;
                            }

                            if (ch.Name == "playernumber")
                            {
                                player_Num = Convert.ToInt32(ch.InnerText);
                            }
                        }
                        listElement.GetTeam().Push(player_surname, player_Num);
                    }
                }
            }

            return sportsLeague;
        }
        public void Save(SportsLeague sportsleague)
        {
            XDocument xdoc = new XDocument();

            XElement sptleague = new XElement("SportsLeague");

            XAttribute orgNameAttr = new XAttribute("name", sportsleague.GetName());

            sptleague.Add(orgNameAttr);

            sportsleague.ReadSportsLeagueData(sptleague);

            xdoc.Add(sptleague);

            xdoc.Save("D:\\Visual studio projects\\output.xml");
        }
    }
}
