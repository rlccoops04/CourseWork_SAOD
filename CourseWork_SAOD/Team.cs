using System;
using System.Xml.Linq;

namespace CourseWork_SAOD
{
    public class Team
    {
        private Player[] players = new Player[11];
        public int GetMaxPlayers() { return players.Length; }

        private int count_players;
        public int GetCountPlayers() { return count_players; }
        public void SetCountPlayers(int countplayers) { this.count_players = countplayers; }

        private string name_team;
        public string GetName() { return name_team; }
        public void SetName(string name_team) { this.name_team = name_team; }

        public Team(string name_team)
        {
            SetName(name_team);
        }

        public bool IsEmpty() { return (count_players == 0); }
        public bool IsFull() { return (count_players == GetMaxPlayers()); }
        public void Push(Player player)
        {
            players[count_players] = player;
            count_players++;
        }
        public void Push(string playerSurname, int playerNum)
        {
            Player player = new Player(playerSurname, playerNum);
            players[count_players] = player;
            count_players++;
        }
        public Player Pop()
        {
            Player temp = players[count_players - 1];
            players[count_players - 1] = null;
            count_players--;
            return temp;
        }
        public void Display()
        {
            int count = 0;
            Console.WriteLine($"Команда - {name_team}.\nСостав игроков:");
            if (IsEmpty())
            {
                Console.WriteLine("Игроки отсутствуют");
            }
            else
            {
                while (count < count_players)
                {
                    Console.WriteLine($"{players[count].GetPlayerSurname()} - {players[count].GetPlayerNum()}");
                    count++;
                }
            }
            Console.WriteLine();
        }
        public void ReadTeamData(XElement sportsleague)
        {
            int count = 0;
            Player player_current = players[count];
            while (count < count_players)
            {
                XElement player = new XElement("player");
                XElement player_name = new XElement("surname", player_current.GetPlayerSurname());
                XElement player_number = new XElement("playernumber", player_current.GetPlayerNum());
                player.Add(player_name); 
                player.Add(player_number);
                sportsleague.Add(player);
                count++;
                player_current = players[count];
            }
        }
        public void ClearMemory()
        {
            while(count_players != 0)
            {
                players[count_players - 1] = null;
                count_players--;
            }
            players = null;
        }
    }
}
