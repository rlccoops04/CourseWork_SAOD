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
            Menu menu = new Menu();
            menu.RunMenu();
/*            SportsLeague sportleague = new SportsLeague("КВН");
            Team team = new Team("ПРИКОЛИСТЫ");
            for (int i = 0; i < 11; i++)
            {
                StackElement player = new StackElement($"{i}", i);
                team.Push(player);
            }
            ListElement listelement = new ListElement(team);
            sportleague.GetHead().SetNext(listelement);
            sportleague.PushTeamAfter($"УГАРАТОРЫ", $"ПРИКОЛИСТЫ");
            Team team1 = sportleague.Search("УГАРАТОРЫ").GetTeam();
            ListElement listelement1 = new ListElement(team1);
            for (int i = 0; i < 11; i++)
            {
                StackElement player = new StackElement($"{i}", i);
                team1.Push(player);
            }
            sportleague.DisplayTeamsAndPlayers();*/
            Console.ReadKey();
        }
    }
}
