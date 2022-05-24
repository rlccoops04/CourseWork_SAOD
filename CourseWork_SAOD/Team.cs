using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public StackElement Search(string playerSurname, int playerNum)
        {
            for(int i = 0; i < playerNum; i++)
            {
                if(players[i].GetPlayerNum() == playerNum && players[i].GetPlayerSurname() == playerSurname ) { return players[i]; }
            }
            return null;
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
