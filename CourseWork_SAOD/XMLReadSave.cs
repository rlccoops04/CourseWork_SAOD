using System;
using System.Xml;
using System.Xml.Linq;

namespace CourseWork_SAOD
{
    public class XMLReadSave
    {
        private string file_path;
        public string GetFilePath() { return file_path; }
        public void SetFilePath(string file_path) { this.file_path = file_path; }
        public XMLReadSave(string file_path)
        {
            SetFilePath(file_path);
        }
        public SportsLeague OpenFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            SportsLeague sportsLeague = null;
            try
            {
                xmlDoc.Load(file_path);
                XmlElement Root = xmlDoc.DocumentElement;
                sportsLeague = new SportsLeague(Root.GetAttribute("name").ToString());
                foreach (XmlElement node in Root)
                {
                    string teamName = node.Attributes.GetNamedItem("name").Value;
                    Team team = new Team(teamName);
                    ListElement listElement = new ListElement(team);
                    sportsLeague.PushTeamEnd(listElement);
                    foreach (XmlNode childnode in node.ChildNodes)
                    {
                        string player_surname = null;
                        int player_Num = 0;

                        foreach (XmlNode ch in childnode.ChildNodes)
                        {
                            if (ch.Name == "surname")
                            {
                                player_surname = ch.InnerText;
                            }
                            else if (ch.Name == "playernumber")
                            {
                                player_Num = Convert.ToInt32(ch.InnerText);
                            }
                        }
                        listElement.GetTeam().Push(player_surname, player_Num);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            xmlDoc = null;
            return sportsLeague;
        }
        public void Save(SportsLeague sportsleague)
        {
            try
            {
                XDocument xmlDoc = new XDocument();
                XElement sptleague = new XElement("SportsLeague");
                XAttribute sptleague_name = new XAttribute("name", sportsleague.GetName());
                sptleague.Add(sptleague_name);
                sportsleague.ReadSportsLeagueData(sptleague);
                xmlDoc.Add(sptleague);
                xmlDoc.Save(file_path);
                xmlDoc = null;
                sptleague = null;
                sptleague_name = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
