using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourseWork_SAOD
{

    public class Menu
    {
        public void RunMenu()
        {
            Console.WriteLine("Динамический неупорядоченный список статических стеков.\nСпортлига(название) - композиция команд(названия), команда - композиция игроков(фамилия, номер).\n");
            bool menu = true;
            int choicemenu, choicepush, playerNum;
            string name_sportsleague, name_team, name_search, name_player;
            SportsLeague sportsLeague = null;
            Team team = null;
            ListElement listelement = null;
            StackElement stackElement = null;
            while(menu)
            {
                Console.WriteLine("Выбор действия:\n" +
                                  "1) Создать спортлигу\n" +
                                  "2) Добавить команду" +
                                  "3) Добавить игрока в команду" +
                                  "4) Удалить команду" +
                                  "5) Удалить игрока из команды" +
                                  "6) Поиск команды" +
                                  "7) Поиск игрока" +
                                  "8) Показать состав команды" +
                                  "9) Показать команды" +
                                  "10) Показать команды с их составами" +
                                  "11) Загрузить структуру спортлиги из TXT-файла" +
                                  "12) Сохранить структуру спортлиги в TXT-файл" +
                                  "13) Очистить структуру" +
                                  "14) Выход");
                Console.WriteLine("Ввод: ");
                choicemenu = int.Parse(Console.ReadLine());
                switch (choicemenu)
                {
                    case 1:
                        Console.Write("Введите название спортлиги: ");
                        name_sportsleague = Console.ReadLine();
                        sportsLeague = new SportsLeague(name_sportsleague);
                        Console.WriteLine("Спортлига создана.");
                        break;
                    case 2:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!\n");
                        }
                        else
                        {
                            Console.Write("Введите название команды: ");
                            name_team = Console.ReadLine();
                            if (sportsLeague.IsEmpty())
                            {
                                team = new Team(name_team);
                                listelement = new ListElement(team);
                                sportsLeague.SetHead(listelement);
                            }
                            else
                            {
                                Console.Write("Введите название команды перед или после которой надо добавить новую: ");
                                name_search = Console.ReadLine();
                                if(sportsLeague.Search(name_search) == null)
                                {
                                    Console.WriteLine("Команда не найдена.");
                                }
                                else
                                {
                                    Console.Write("Добавить до(0) или после(1) другой команды в список: ");
                                    choicepush = int.Parse(Console.ReadLine());
                                    if (choicepush == 0)
                                    {
                                        sportsLeague.PushTeamBefore(name_team, name_search);
                                    }
                                    else if (choicepush == 1)
                                    {
                                        sportsLeague.PushTeamAfter(name_team, name_search);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный ввод.");
                                    }
                                }
                            }
                        }
                        break;
                    case 3:

                        break;
                }
            }
        }
    }
}
