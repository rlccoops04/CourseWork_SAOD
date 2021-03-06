using System;

namespace CourseWork_SAOD
{
    public class ListElement
    {
        private ListElement pNext;
        public ListElement GetNext() { return pNext; }
        public void SetNext(ListElement pNext) { this.pNext = pNext; }

        private Team team;
        public Team GetTeam() { return team; }
        public void SetTeam(Team team) { this.team = team; }

        public ListElement(Team team)
        {
            SetTeam(team);
        }
    }
}
