using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_SAOD
{
    public class StackElement
    {
        private string playerSurname;
        public string GetPlayerSurname() { return playerSurname; }
        public void SetPlayerSurname(string playerSurname) { this.playerSurname = playerSurname; }

        private int playerNum;
        public int GetPlayerNum() { return playerNum; }
        public void SetPlayerNum(int playerNum) { this.playerNum = playerNum; }
        public StackElement(string playerSurname, int playerNum)
        {
            SetPlayerSurname(playerSurname);
            SetPlayerNum(playerNum);
        }
    }
}
