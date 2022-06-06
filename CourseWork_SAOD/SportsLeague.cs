using System;
using System.Xml.Linq;

namespace CourseWork_SAOD
{
    public class SportsLeague
    {   
        private string name_sportsleague;
        public string GetName() { return name_sportsleague; }
        public void SetName(string name_sportsleague) { this.name_sportsleague = name_sportsleague; }

        private ListElement pHead; 
        public ListElement GetHead() { return pHead; }
        public void SetHead(ListElement pHead) { this.pHead = pHead; }

        private int count_teams;
        public int GetCountTeams() { return count_teams; }
        public void SetCountTeams(int count_teams) { this.count_teams = count_teams; }

        public SportsLeague(string name_sportsleague)
        {
            SetName(name_sportsleague);
            Team team = null;
            pHead = new ListElement(team);
            pHead.SetNext(null);
        }

        public bool IsEmpty() { return count_teams == 0; }
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
            count_teams++;
        }
        public void PushTeamAfter(string name_new, string name_search)
        {
            ListElement pCurrent = pHead.GetNext();
            while (pCurrent.GetTeam().GetName() != name_search)
            {
                pCurrent = pCurrent.GetNext();
            }
            Team team = new Team(name_new);
            ListElement pTemp = new ListElement(team);
            pTemp.SetNext(pCurrent.GetNext());
            pCurrent.SetNext(pTemp);
            count_teams++;
        }
        public void PushTeamBefore(string name_new, string name_search)
        {
            ListElement pCurrent = pHead.GetNext();
            ListElement pPrevious = pHead;
            while (pCurrent.GetTeam().GetName() != name_search)
            {
                pPrevious = pCurrent;
                pCurrent = pCurrent.GetNext();
            }
            Team team = new Team(name_new);
            ListElement pTemp = new ListElement(team);
            pTemp.SetNext(pCurrent);
            pPrevious.SetNext(pTemp);
            count_teams++;
        }
        public void Remove(string name_search)
        {
            ListElement pCurrent = pHead.GetNext();
            ListElement pPrevious = pHead;
            while (pCurrent.GetTeam().GetName() != name_search)
            {
                pPrevious = pCurrent;
                pCurrent = pCurrent.GetNext();
            }
            pPrevious.SetNext(pCurrent.GetNext());
            pCurrent.SetNext(null);
            if(pCurrent.GetTeam() != null)
                pCurrent.GetTeam().ClearMemory();
            pCurrent = null;
        }
        public void DisplayTeams()
        {
            ListElement pCurrent = pHead.GetNext();
            Console.WriteLine($"Спортлига - {name_sportsleague}.");
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
            Console.WriteLine($"Спортлига - {name_sportsleague}.");
            while (pCurrent != null)
            {
                pCurrent.GetTeam().Display();
                pCurrent = pCurrent.GetNext();
            }
        }
        public void ReadSportsLeagueData(XElement sportsleague)
        {
            ListElement team_current = GetHead().GetNext();
            while(team_current != null)
            {
                XElement team = new XElement("team");
                XAttribute teamName = new XAttribute("name", team_current.GetTeam().GetName());
                team.Add(teamName);
                team_current.GetTeam().ReadTeamData(team);
                sportsleague.Add(team);
                team_current = team_current.GetNext();
                team = null;
                teamName = null;
            }
        }
        public void ClearMemory()
        {
            ListElement pCurrent = pHead;
            ListElement pTemp;
            while(pCurrent != null)
            {
                pTemp = pCurrent.GetNext();
                if(pCurrent.GetTeam() != null)
                    pCurrent.GetTeam().ClearMemory();
                pCurrent = null;
                pCurrent = pTemp;
            }
        }
    }
}
