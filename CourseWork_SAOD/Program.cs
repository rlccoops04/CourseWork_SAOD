using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_SAOD
{
    class Program
    {
        static void Main(string[] args)
        {
            SportsLeague sportleague = new SportsLeague("КВН");
            Team team = new Team("ПРИКОЛИСТЫ");
            for (int i = 0; i < 11; i++)
            {
                StackElement player = new StackElement($"{i}", i);
                team.Push(player);
            }
            ListElement listelement = new ListElement(team);
            sportleague.SetHead(listelement);
            for(int i = 0; i < 5; i++)
            {
                sportleague.PushTeamAfter($"{i + 1}", $"{i}");
            }
            sportleague.DisplayTeamsAndPlayers();
            sportleague.Search("ПРИКОЛИСТЫ").GetTeam().Pop();
            sportleague.DisplayTeamsAndPlayers();
            sportleague.Search("ПРИКОЛИСТЫ").GetTeam().Push("GGR", -1);
            sportleague.DisplayTeamsAndPlayers();
            sportleague.DisplayTeams();
            Console.ReadKey();
        }
    }
}
