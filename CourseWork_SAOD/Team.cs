using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseWork_SAOD
{
    public class Team
    {
        private StackElement[] players = new StackElement[11];
        public int GetMaxPlayers() { return players.Length; }

        private int countPlayers;
        public int GetCountPlayers() { return countPlayers; }
        public void SetCountPlayers(int countplayers) { this.countPlayers = countplayers; }

        private string name;
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }

        public Team(string name)
        {
            SetName(name);
        }

        public bool IsEmpty() { return (countPlayers == 0); }
        public bool IsFull() { return (countPlayers == GetMaxPlayers()); }
        public void Push(StackElement player)
        {
            if(!IsFull())
            {
                players[countPlayers] = player;
                countPlayers++;
            }
        }
        public void Push(string playerSurname, int playerNum)
        {
            StackElement player = new StackElement(playerSurname, playerNum);
            players[countPlayers] = player;
            countPlayers++;
        }
        public StackElement Pop()
        {
            StackElement temp = players[countPlayers - 1];
            players[countPlayers - 1] = null;
            countPlayers--;
            return temp;
        }
        public void Display()
        {
            int count = 0;
            Console.WriteLine($"Команда - {name}.\nСостав игроков:");
            if (IsEmpty())
            {
                Console.WriteLine("Игроки отсутствуют");
            }
            else
            {
                while (count < countPlayers)
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
            var emp_curr = players[count];
            while (count < countPlayers)
            {
                XElement emp_ = new XElement("player");
                XElement emp_name = new XElement("surname", emp_curr.GetPlayerSurname());
                XElement emp_surname = new XElement("playernumber", emp_curr.GetPlayerNum());
                emp_.Add(emp_name); emp_.Add(emp_surname);
                sportsleague.Add(emp_);
                count++;
                emp_curr = players[count];
            }
        }
        public void ClearMemory()
        {
            while(countPlayers != 0)
            {
                players[countPlayers - 1] = null;
                countPlayers--;
            }
            players = null;
        }
    }
}
