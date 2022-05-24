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
        public StackElement[] Players() { return players; }

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
        public bool IsFull() { return (countPlayers == players.Length); }
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
            Console.WriteLine($"Название команды - {name}.\nСостав игроков:");
            while (count < countPlayers)
            {
                Console.WriteLine($"Фамилия - {players[count].GetPlayerSurname()}, номер - {players[count].GetPlayerNum()}");
                count++;
            }
            Console.WriteLine();
        }
        public void ClearMemory()
        {
            while(countPlayers != 0)
            {
                players[countPlayers - 1] = null;
                players = null;
                countPlayers--;
            }
        }
    }
}
