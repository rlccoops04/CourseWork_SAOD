using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace CourseWork_SAOD
{

    public class Menu
    {
        public static void RunMenu()
        {
            Console.WriteLine("Динамический неупорядоченный список статических стеков.\nСпортлига(название) - композиция команд(названия), команда - композиция игроков(фамилия, номер).\n");
            bool menu = true;
            int choicemenu, choicepush, player_num;
            string name, name_search, file_path;
            SportsLeague sportsLeague = null;
            Team team;
            ListElement searchedElement;
            ListElement listElement;
            XMLReadSave xmlFile;
            while (menu)
            {
                Console.WriteLine("Выбор действия:\n" +
                                  "1) Создать спортлигу\n" +
                                  "2) Добавить команду\n" +
                                  "3) Добавить игрока в команду\n" +
                                  "4) Удалить команду\n" +
                                  "5) Удалить игрока из команды\n" +
                                  "6) Поиск команды\n" +
                                  "7) Поиск игрока(?)\n" +
                                  "8) Показать состав команды\n" +
                                  "9) Показать команды\n" +
                                  "10) Показать команды с их составами\n" +
                                  "11) Загрузить структуру спортлиги из TXT-файла\n" +
                                  "12) Сохранить структуру спортлиги в TXT-файл\n" +
                                  "13) Очистить структуру\n" +
                                  "14) Выход\n");
                Console.Write("Ввод: ");
                choicemenu = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choicemenu)
                {
                    case 1:
                        if(sportsLeague == null)
                        {
                            Console.Write("Введите название спортлиги: ");
                            name = Console.ReadLine();
                            sportsLeague = new SportsLeague(name);
                            Console.WriteLine("Спортлига создана.\n");
                        }
                        else
                        {
                            Console.WriteLine("Спортлига уже создана.\n");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!\n");
                        }
                        else
                        {
                            Console.Write("Введите название команды: ");
                            name = Console.ReadLine();
                            if (sportsLeague.IsEmpty())
                            {
                                team = new Team(name);
                                listElement = new ListElement(team);
                                sportsLeague.GetHead().SetNext(listElement);
                                sportsLeague.SetCountTeams(1);
                            }
                            else
                            {
                                Console.Write("Введите название команды перед или после которой надо добавить новую: ");
                                name_search = Console.ReadLine();
                                searchedElement = sportsLeague.Search(name_search);
                                if (searchedElement == null)
                                {
                                    Console.WriteLine("Команда не найдена.\n");
                                }
                                else
                                {
                                    Console.Write("Добавить до(0) или после(1) другой команды в список: ");
                                    choicepush = int.Parse(Console.ReadLine());
                                    if (choicepush == 0)
                                    {
                                        sportsLeague.PushTeamBefore(name, name_search);
                                    }
                                    else if (choicepush == 1)
                                    {
                                        sportsLeague.PushTeamAfter(name, name_search);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный ввод.");
                                    }
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else if(sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            Console.Write("Введите название команды, куда необходимо добавить игрока: ");
                            name_search = Console.ReadLine();
                            searchedElement = sportsLeague.Search(name_search);
                            if (searchedElement == null)
                            {
                                Console.WriteLine("Команда не найдена.");
                            }
                            else
                            {
                                Console.Write("Введите фамилию нового игрока: ");
                                name = Console.ReadLine();
                                Console.Write("Введите номер нового игрока: ");
                                player_num = int.Parse(Console.ReadLine());
                                searchedElement.GetTeam().Push(name, player_num);
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else if (sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            Console.Write("Введите название команды для удаления: ");
                            name_search = Console.ReadLine();
                            searchedElement = sportsLeague.Search(name_search);
                            if (searchedElement == null)
                            {
                                Console.WriteLine("Команда не найдена.");
                            }
                            else
                            {
                                sportsLeague.Remove(name_search);
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else if (sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            Console.Write("Введите название команды игрока: ");
                            name_search = Console.ReadLine();
                            searchedElement = sportsLeague.Search(name_search);
                            if (searchedElement == null)
                            {
                                Console.WriteLine("Команда не найдена.");
                            }
                            else
                            {
                                if(!searchedElement.GetTeam().IsEmpty())
                                {
                                    searchedElement.GetTeam().Pop();
                                }
                                else
                                {
                                    Console.WriteLine("Команда пустая.");
                                }
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 6:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else if (sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            Console.Write("Введите название команды: ");
                            name_search = Console.ReadLine();
                            searchedElement = sportsLeague.Search(name_search);
                            if (searchedElement == null)
                            {
                                Console.WriteLine("Команда не найдена.");
                            }
                            else
                            {
                                Console.WriteLine("Команда есть в спортлиге.");
                                searchedElement.GetTeam().Display();
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 8:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else if (sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            Console.Write("Введите название команды: ");
                            name_search = Console.ReadLine();
                            searchedElement = sportsLeague.Search(name_search);
                            if (searchedElement == null)
                            {
                                Console.WriteLine("Команда не найдена.");
                            }
                            else
                            {
                                searchedElement.GetTeam().Display();
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 9:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else if (sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            sportsLeague.DisplayTeams();
                        }
                        Console.WriteLine();
                        break;
                    case 10:
                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else if (sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            sportsLeague.DisplayTeamsAndPlayers();
                        }
                        Console.WriteLine();
                        break;
                    case 11:
                        Console.Write("Введите путь к файлу(Enter - путь по умолчанию): ");
                        file_path = Console.ReadLine();
                        file_path = "D:\\Visual studio projects\\input.xml";
                        xmlFile = new XMLReadSave(file_path);
                        sportsLeague = xmlFile.OpenFile();
                        Console.WriteLine();
                        break;
                    case 12:
                        file_path = "D:\\Visual studio projects\\output.xml";
                        xmlFile = new XMLReadSave(file_path);
                        xmlFile.Save(sportsLeague);
                        Console.WriteLine();
                        break;
                    case 13:
                        try
                        {
                            sportsLeague.ClearMemory();
                            sportsLeague = null;
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Ошибка: " + e.Message);
                        }

/*                        if (sportsLeague == null)
                        {
                            Console.WriteLine("Спортлига не создана!");
                        }
                        else
                        {
                            sportsLeague.ClearMemory();
                            sportsLeague = null;
                        }*/
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.\n");
                        break;
                }
            }
        }
    }
}
