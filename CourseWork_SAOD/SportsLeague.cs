using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseWork_SAOD
{
    public class SportsLeague
    {
        private string name;
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }

        private ListElement pHead; 
        public ListElement GetHead() { return pHead; }
        public void SetHead(ListElement pHead) { this.pHead = pHead; }

        private int countTeams;
        public int GetCountTeams() { return countTeams; }
        public void SetCountTeams(int countTeams) { this.countTeams = countTeams; }

        private int countPlayers;
        public int GetCountPlayers() 
        {
            ListElement pCurrent = pHead;
            while(pCurrent != null)
            {
                countPlayers += pCurrent.GetTeam().GetCountPlayers();
                pCurrent = pCurrent.GetNext();
            }
            return countPlayers; 
        }
        public void SetCountPlayers(int countPlayers) { this.countPlayers = countPlayers; }

        public SportsLeague(string name)
        {
            SetName(name);
            Team team = null;
            pHead = new ListElement(team);
        }

        public bool IsEmpty() { return countTeams == 0; }
        public ListElement Search(string name_search)
        {
            ListElement pCurrent = pHead.GetNext();
            while (pCurrent != null && pCurrent.GetTeam().GetName() != name_search)
            {
                pCurrent = pCurrent.GetNext();
            }
            return pCurrent;
        }
        public void PushTeamEnd(ListElement newlistElement)
        {
            ListElement pCurrent = GetHead();
            while (pCurrent.GetNext() != null)
            {
                pCurrent = pCurrent.GetNext();
            }
            pCurrent.SetNext(newlistElement);
            countTeams++;
        }
        public void PushTeamAfter(string name_new, string name_search)
        {
            ListElement pCurrent = pHead.GetNext();
            while (pCurrent != null && pCurrent.GetTeam().GetName() != name_search)
            {
                pCurrent = pCurrent.GetNext();
            }
            Team team = new Team(name_new);
            ListElement newElement = new ListElement(team);
            newElement.SetNext(pCurrent.GetNext());
            pCurrent.SetNext(newElement);
            countTeams++;
        }
        public void PushTeamBefore(string name_new, string name_search)
        {
            ListElement pCurrent = pHead.GetNext();
            ListElement pPrevious = pHead;
            while (pCurrent != null && pCurrent.GetTeam().GetName() != name_search)
            {
                pPrevious = pCurrent;
                pCurrent = pCurrent.GetNext();
            }
            Team team = new Team(name_new);
            ListElement newElement = new ListElement(team);
            newElement.SetNext(pCurrent);
            pPrevious.SetNext(newElement);
            countTeams++;
        }
        public void Remove(string name_search)
        {
            ListElement pCurrent = pHead.GetNext();
            ListElement pPrevious = pHead;
            while (pCurrent != null && pCurrent.GetTeam().GetName() != name_search)
            {
                pPrevious = pCurrent;
                pCurrent = pCurrent.GetNext();
            }
            pPrevious.SetNext(pCurrent.GetNext());
            pCurrent.SetNext(null);
            pCurrent.GetTeam().ClearMemory();
            pCurrent = null;
        }
        public void ReadFile(StreamReader sr)
        {

        }
        public void DisplayTeams()
        {
            ListElement pCurrent = pHead.GetNext();
            Console.WriteLine($"Спортлига - {name}.");
            while (pCurrent != null)
            {
                Console.WriteLine($"Команда - {pCurrent.GetTeam().GetName()}.");
                pCurrent = pCurrent.GetNext();
            }
            Console.WriteLine();
        }
        public void DisplayTeamsAndPlayers()
        {
            ListElement pCurrent = pHead.GetNext();
            Console.WriteLine($"Спортлига - {name}.");
            while (pCurrent != null)
            {
                pCurrent.GetTeam().Display();
                pCurrent = pCurrent.GetNext();
            }
        }
        public void ReadSportsLeagueData(XElement sportsleague)
        {
            var dprt_curr = GetHead().GetNext();
            while(dprt_curr != null)
            {
                XElement dprt_ = new XElement("team");

                XAttribute dprtNameAttr = new XAttribute("name", dprt_curr.GetTeam().GetName());

                dprt_.Add(dprtNameAttr);

                dprt_curr.GetTeam().ReadTeamData(dprt_);

                sportsleague.Add(dprt_);

                dprt_curr = dprt_curr.GetNext();
            }
        }
        public void ClearMemory()
        {
            ListElement pCurrent = pHead;
            ListElement pTemp;
            while(pCurrent != null)
            {
                pTemp = pCurrent.GetNext();
                pCurrent.GetTeam().ClearMemory();
                pCurrent = null;
                pCurrent = pTemp;
            }
        }
    }
}
