using System;

namespace CourseWork_SAOD
{
    public class Player
    {
        private string player_surname;
        public string GetPlayerSurname() { return player_surname; }
        public void SetPlayerSurname(string player_surname) { this.player_surname = player_surname; }

        private int player_num;
        public int GetPlayerNum() { return player_num; }
        public void SetPlayerNum(int player_num) { this.player_num = player_num; }
        public Player(string player_surname, int player_num)
        {
            SetPlayerSurname(player_surname);
            SetPlayerNum(player_num);
        }
    }
}
