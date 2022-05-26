using System;
using System.Xml;

namespace CourseWork_SAOD
{

    public class ConsoleApp
    {
        public static SportsLeague InputStructure()
        {
            XMLReadSave xmlFile;
            SportsLeague sportsLeague;
            int input;
            string name, file_path;
            while (true)
            {
                Console.Write("1) Создать спортлигу.\n2) Загрузить структуру спортлиги из XML-файла\nВвод: ");
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.Write("Введите название спортлиги: ");
                    name = Console.ReadLine();
                    sportsLeague = new SportsLeague(name);
                    Console.WriteLine("Спортлига создана.\n");
                    break;
                }
                else if (input == 2)
                {
                    Console.Write("Введите путь к файлу(Enter - путь по умолчанию): ");
                    file_path = Console.ReadLine();
                    if (file_path.Length == 0)
                        file_path = "D:\\Visual studio projects\\input.xml";
                    xmlFile = new XMLReadSave(file_path);
                    sportsLeague = xmlFile.OpenFile();
                    xmlFile = null;
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод.");
                }
            }
            return sportsLeague;
        }
        public static void RunMenu()
        {
            SportsLeague sportsLeague = InputStructure();
            ListElement searchedElement, listElement;
            Team team;
            Player player;
            XMLReadSave xmlFile;
            bool menu = true;
            int choicemenu, choicepush, player_num, input;
            string name_search, name, file_path;
            while (menu)
            {
                Console.WriteLine("Выбор действия:\n" +
                                  "1) Переименовать спортлигу\n" +
                                  "2) Добавить команду\n" +
                                  "3) Добавить игрока в команду\n" +
                                  "4) Удалить команду\n" +
                                  "5) Удалить игрока из команды\n" +
                                  "6) Поиск команды\n" +
                                  "7) Показать состав команды\n" +
                                  "8) Показать команды\n" +
                                  "9) Показать команды с их составами\n" +
                                  "10) Сохранить структуру спортлиги в XML-файл\n" +
                                  "11) Очистить структуру\n");
                Console.Write("Ввод: ");
                choicemenu = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choicemenu)
                {
                    case 1:
                        Console.Write("Введите название спортлиги: ");
                        name = Console.ReadLine();
                        sportsLeague.SetName(name);
                        Console.WriteLine();
                        break;
                    case 2:
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
                        break;
                    case 3:
                        if(sportsLeague.IsEmpty())
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
                                if(searchedElement.GetTeam().IsFull())
                                {

                                }
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
                        if (sportsLeague.IsEmpty())
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
                        if (sportsLeague.IsEmpty())
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
                                    player = searchedElement.GetTeam().Pop();
                                    Console.WriteLine($"Удаленный игрок: {player.GetPlayerSurname()} - {player.GetPlayerNum()}");
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
                        if (sportsLeague.IsEmpty())
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
                                Console.Write("Команда есть в спортлиге. ");
                                Console.WriteLine($"Количество игроков: {searchedElement.GetTeam().GetCountPlayers()}");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 7:
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
                            sportsLeague.DisplayTeams();
                        }
                        Console.WriteLine();
                        break;
                    case 9:
                        if (sportsLeague.IsEmpty())
                        {
                            Console.WriteLine("Не найдено ни одной команды.");
                        }
                        else
                        {
                            sportsLeague.DisplayTeamsAndPlayers();
                        }
                        Console.WriteLine();
                        break;
                    case 10:
                        Console.Write("Введите путь к файлу(Enter - путь по умолчанию): ");
                        file_path = Console.ReadLine();
                        if (file_path.Length == 0)
                            file_path = "D:\\Visual studio projects\\output.xml";
                        xmlFile = new XMLReadSave(file_path);
                        xmlFile.Save(sportsLeague);
                        xmlFile = null;
                        Console.WriteLine();
                        break;
                    case 11:
                        if (!sportsLeague.IsEmpty())
                        {
                            sportsLeague.ClearMemory();
                            sportsLeague = null;
                            Console.WriteLine("Структура удалена.");
                        }
                        else
                        {
                            sportsLeague = null;
                            Console.WriteLine("Структура удалена.");
                        }
                        Console.WriteLine();
                        Console.Write("Добавить новую структуру(0) или выход(1): ");
                        input = int.Parse(Console.ReadLine());
                        if (input == 0)
                        {
                            sportsLeague = InputStructure();
                        }
                        else
                        {
                            menu = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.\n");
                        break;
                }
            }
        }
    }
}
