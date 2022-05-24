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

        private int countplayers;
        public int GetCountPlayers() { return countplayers; }
        public void SetCountPlayers(int countplayers) { this.countplayers = countplayers; }

        private string name;
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }

        public Team(string name)
        {
            SetName(name);
        }

        public bool IsEmpty() { return (countplayers == 0); }
        public bool IsFull() { return (countplayers == players.Length); }
        public void Push(StackElement player)
        {
            if(!IsFull())
            {
                players[countplayers] = player;
                countplayers++;
            }
        }
        public void Push(string playerSurname, int playerNum)
        {
            StackElement player = new StackElement(playerSurname, playerNum);
            players[countplayers] = player;
            countplayers++;
        }
        public StackElement Pop()
        {
            StackElement temp = players[countplayers - 1];
            players[countplayers - 1] = null;
            countplayers--;
            return temp;
        }
        public void Display()
        {
            int count = 0;
            Console.WriteLine($"Название команды - {name}.\nСостав игроков:");
            while (count < countplayers)
            {
                Console.WriteLine($"Фамилия - {players[count].GetPlayerSurname()}, номер - {players[count].GetPlayerNum()}");
                count++;
            }
            Console.WriteLine();
        }
        public void ClearMemory()
        {
            while(countplayers != 0)
            {
                players[countplayers - 1] = null;
                players = null;
                countplayers--;
            }
        }
    }
}
