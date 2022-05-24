using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public bool IsEmpty() { return countTeams == 0; }
        public ListElement Search(string name_search)
        {
            ListElement pCurrent = pHead;
            while (pCurrent != null && pCurrent.GetTeam().GetName() != name_search)
            {
                pCurrent = pCurrent.GetNext();
            }
            return pCurrent;
        }
        public void PushTeamAfter(string name_new, string name_search)
        {
            ListElement pCurrent = pHead;
            while (pCurrent != null && pCurrent.GetTeam().GetName() != name_search)
            {
                pCurrent = pCurrent.GetNext();
            }
            if (pCurrent != null)
            {
                Team team = new Team(name_new);
                ListElement newElement = new ListElement(team);
                newElement.SetNext(pCurrent.GetNext());
                pCurrent.SetNext(newElement);
                countTeams++;
            }
        }
        public void PushTeamBefore(string name_new, string name_search)
        {
            ListElement pCurrent = pHead;
            ListElement pPrevious = null;
            while (pCurrent.GetTeam().GetName() != name_search || pCurrent != null)
            {
                pPrevious = pCurrent;
                pCurrent = pCurrent.GetNext();
            }
            if (pCurrent != null) // элемент найден
            {
                Team team = new Team(name_new);
                ListElement newElement = new ListElement(team);
                if(pPrevious == null) // добавляем перед первым
                {
                    newElement.SetNext(pCurrent);
                }
                else
                {
                    newElement.SetNext(pCurrent);
                    pPrevious.SetNext(newElement);
                }
            }
        }
        public void Remove(string name_search)
        {
            ListElement pCurrent = pHead;
            ListElement pPrevious = null;
            while (pCurrent.GetTeam().GetName() != name_search || pCurrent != null)
            {
                pPrevious = pCurrent;
                pCurrent = pCurrent.GetNext();
            }
            if (pCurrent != null) // элемент найден
            {
                if(pPrevious == null)
                {
                    pHead.GetTeam().ClearMemory();
                    pHead = null;
                }
                else
                {
                    pPrevious.SetNext(pCurrent.GetNext());
                    pCurrent.SetNext(null);
                    pCurrent.GetTeam().ClearMemory();
                    pCurrent = null;
                }
            }
        }
        public void DisplayTeams()
        {
            ListElement pCurrent = pHead;
            Console.WriteLine($"Название Спортлиги: {name}");
            while (pCurrent != null)
            {
                Console.WriteLine($"Название команды - {pCurrent.GetTeam().GetName()}.");
                pCurrent = pCurrent.GetNext();
            }
            Console.WriteLine();
        }
        public void DisplayTeamsAndPlayers()
        {
            ListElement pCurrent = pHead;
            Console.WriteLine($"Название Спортлиги: {name}.");
            while (pCurrent != null)
            {
                pCurrent.GetTeam().Display();
                pCurrent = pCurrent.GetNext();
            }
        }
    }
}
