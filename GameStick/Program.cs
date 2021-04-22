using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStick
{
    class Program
    {
        class GameMaster
        {
            public int gameNumber;
            public int userTry;

            public GameMaster()
            {
                Random rand = new Random();
                gameNumber = rand.Next(12, 120);
                userTry = 4;
            }
            /// <summary>
            /// устанавливание кастомных правил игры 
            /// </summary>
            /// <param name="gameNumber">Должен быть больше 11 и userTry</param>
            /// <param name="userTry">должен быть больше 0 и меньше gameNumber</param>
            /// <returns></returns>
            public bool SetRulesOfTheGame(int gameNumber, int userTry)
            {
                if (gameNumber < 12)
                {
                    Console.WriteLine("gameNumber должен быть больше либо равно 12");
                    return false;
                }
                if (userTry < 1)
                {
                    Console.WriteLine("userTry должен быть больше 0");
                    return false;
                }
                if (gameNumber < userTry)
                {
                    Console.WriteLine("gameNumber должен быть больше чем userTry");
                    return false;
                }

                this.gameNumber = gameNumber;
                this.userTry = userTry;
                return true;
            }
            /// <summary>
            /// Отслеживание шага игрока
            /// </summary>
            /// <param name="step"></param>
            /// <returns></returns>
            public bool StepPlayers(int step)
            {
                if ((gameNumber - step) < 0)
                {
                    Console.WriteLine("Число слишком большое, попробуйте снова");
                    return false;
                }
                gameNumber -= step;
                return true;
            }
            /// <summary>
            /// Выводит консольное отображение gameNumber в виде палочек
            /// </summary>
            public void OutStick()
            {
                for (int i = 0; i < gameNumber; i++)
                    Console.Write("|");
                Console.Write("\n");
            }

        }
        public static void PrintCenterString(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
        static int Main(string[] args)
        {
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В ИГРУ...ЭМ.........\nВОТ ВАМ ПРАВИЛА:\n");
            Console.WriteLine(" 1.Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.");
            Console.WriteLine(" 2.Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.");
            Console.WriteLine(" 3.userTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.");
            Console.WriteLine(" 4.Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.");
            Console.Write("Продолжить...");
            Console.ReadKey();
            Console.Clear();

            string inputConsole;
            int inputNumber;
            GameMaster GM;
            int raund;
            List<string> players;
            Random random = new Random();
            while (true)
            {

                Console.WriteLine("Выберите режим игры:\n");
                Console.WriteLine(" 1.Обычная игра");
                Console.WriteLine(" 2.Тест.Пример игры по обычным правилам(все значения выбираются случайным оброзом)");
                Console.WriteLine(" 3.Кастомная игра. Играй по своим правилам ;)");
                Console.WriteLine(" 4.Одиночная игра с ботом");
                Console.WriteLine(" 5.Посмотреть правила");
                Console.WriteLine(" 6.Выход");
                //Выбор режима игры 
                inputConsole = Console.ReadLine();
                int.TryParse(inputConsole, out inputNumber);
                switch (inputNumber)
                {
                    //1.Обычная игра
                    #region 
                    case 1:
                        Console.Clear();
                        //Создание правил игры (Гейм мастера)
                        GM = new GameMaster();

                        Console.Write("Введите кол-во игроков: ");
                        while (true)
                        {
                            inputConsole = Console.ReadLine();
                            if (int.TryParse(inputConsole, out inputNumber) && inputNumber >= 2)
                                break;
                        }
                        //ввод имен игроков
                        players = new List<string>();
                        for (int i = 0; i < inputNumber; i++)
                        {
                            Console.Write($"Введите имя игрока {i + 1}: ");
                            inputConsole = Console.ReadLine();
                            players.Add(inputConsole);
                        }

                        raund = 1;
                        while (GM.gameNumber != 0)
                        {
                            for (int i = 0; i < players.Count(); i++)
                            {
                                Console.Clear();

                                Console.WriteLine($"Раунд: {raund}");
                                PrintCenterString($"{GM.gameNumber}");
                                GM.OutStick();
                                Console.WriteLine($"Игрок: {players[i]}");
                                Console.Write($" Выберите число от 1 - {GM.userTry}: ");
                                while (true)
                                {
                                    inputConsole = Console.ReadLine();
                                    if (int.TryParse(inputConsole, out inputNumber))
                                        if (inputNumber >= 1 && inputNumber <= GM.userTry)
                                            if (GM.StepPlayers(inputNumber))
                                                break;
                                }
                                if (GM.gameNumber == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Игрок: {players[i]} Вы ПОБЕДИТЕЛЬ!!!");
                                    Console.WriteLine("^_^ и большой молодец!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            }
                            raund++;
                        }

                        break;
                    #endregion
                    //2.Тест
                    #region
                    case 2:
                        Console.Clear();
                        //Создание правил игры (Гейм мастера)
                        GM = new GameMaster();

                        Console.Write("Введите кол-во игроков: ");
                        while (true)
                        {
                            inputConsole = Console.ReadLine();
                            if (int.TryParse(inputConsole, out inputNumber) && inputNumber >= 2)
                                break;
                        }
                        //ввод имен игроков
                        players = new List<string>();
                        for (int i = 0; i < inputNumber; i++)
                            players.Add($"Player{i + 1}");

                        raund = 1;
                        while (GM.gameNumber != 0)
                        {
                            for (int i = 0; i < players.Count(); i++)
                            {
                                Console.Clear();

                                Console.WriteLine($"Раунд: {raund}");
                                PrintCenterString($"{GM.gameNumber}");
                                GM.OutStick();
                                Console.WriteLine($"Игрок: {players[i]}");
                                Console.Write($" Выберите число от 1 - {GM.userTry}: ");
                                while (true)
                                {
                                    inputNumber = random.Next(1, GM.userTry + 1);
                                    if (inputNumber >= 1 && inputNumber <= GM.userTry)
                                        if (GM.StepPlayers(inputNumber))
                                            break;
                                }
                                Console.Write(inputNumber);
                                Console.ReadKey();
                                if (GM.gameNumber == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Игрок: {players[i]} Вы ПОБЕДИТЕЛЬ!!!");
                                    Console.WriteLine("^_^ и большой молодец!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            }
                            raund++;
                        }
                        break;
                    #endregion
                    //3.Кастомная игра
                    #region
                    case 3:
                        Console.Clear();
                        //Создание правил игры (Гейм мастера)
                        GM = new GameMaster();
                        Console.WriteLine("Введите правила игры: ");
                        while (true)
                        {
                            Console.Write("gameNumber: ");
                            inputConsole = Console.ReadLine();
                            int num1;
                            if (!int.TryParse(inputConsole, out num1))
                                continue;
                            int num2;
                            Console.Write("userTry: ");
                            inputConsole = Console.ReadLine();
                            if (!int.TryParse(inputConsole, out num2))
                                continue;
                            if (GM.SetRulesOfTheGame(num1, num2))
                                break;
                        }



                        Console.Write("Введите кол-во игроков: ");
                        while (true)
                        {
                            inputConsole = Console.ReadLine();
                            if (int.TryParse(inputConsole, out inputNumber) && inputNumber >= 2)
                                break;
                        }
                        //ввод имен игроков
                        players = new List<string>();
                        for (int i = 0; i < inputNumber; i++)
                        {
                            Console.Write($"Введите имя игрока {i + 1}: ");
                            inputConsole = Console.ReadLine();
                            players.Add(inputConsole);
                        }

                        raund = 1;
                        while (GM.gameNumber != 0)
                        {
                            for (int i = 0; i < players.Count(); i++)
                            {
                                Console.Clear();

                                Console.WriteLine($"Раунд: {raund}");
                                PrintCenterString($"{GM.gameNumber}");
                                GM.OutStick();
                                Console.WriteLine($"Игрок: {players[i]}");
                                Console.Write($" Выберите число от 1 - {GM.userTry}: ");
                                while (true)
                                {
                                    inputConsole = Console.ReadLine();
                                    if (int.TryParse(inputConsole, out inputNumber))
                                        if (inputNumber >= 1 && inputNumber <= GM.userTry)
                                            if (GM.StepPlayers(inputNumber))
                                                break;
                                }
                                if (GM.gameNumber == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Игрок: {players[i]} Вы ПОБЕДИТЕЛЬ!!!");
                                    Console.WriteLine("^_^ и большой молодец!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            }
                            raund++;
                        }
                        break;
                    #endregion
                    //4.Одиночная игра с ботом
                    #region
                    case 4:
                        Console.Clear();
                        //Создание правил игры (Гейм мастера)
                        GM = new GameMaster();

                        Console.WriteLine("Введите правила игры: ");
                        while (true)
                        {
                            Console.Write("gameNumber: ");
                            inputConsole = Console.ReadLine();
                            int num1;
                            if (!int.TryParse(inputConsole, out num1))
                                continue;
                            int num2;
                            Console.Write("userTry: ");
                            inputConsole = Console.ReadLine();
                            if (!int.TryParse(inputConsole, out num2))
                                continue;
                            if (GM.SetRulesOfTheGame(num1, num2))
                                break;
                        }

                        //ввод имен игроков
                        players = new List<string>();

                        Console.Write($"Введите имя игрока : ");
                        inputConsole = Console.ReadLine();
                        players.Add(inputConsole);

                        players.Add("Бот Аркадий");
                        Console.WriteLine($"Сложность бота: ");
                        Console.WriteLine($" 1.Валенок ");
                        Console.WriteLine($" 2.Гений ");
                        Console.Write($"выберите сложность: ");
                        int botDifficulty;

                        while (true)
                        {
                            inputConsole = Console.ReadLine();
                            if (int.TryParse(inputConsole, out botDifficulty))
                                if (botDifficulty >= 1 && botDifficulty <= 2)
                                    break;
                        }

                        raund = 1;
                        while (GM.gameNumber != 0)
                        {
                            for (int i = 0; i < players.Count(); i++)
                            {
                                Console.Clear();

                                Console.WriteLine($"Раунд: {raund}");
                                PrintCenterString($"{GM.gameNumber}");
                                GM.OutStick();
                                Console.WriteLine($"Игрок: {players[i]}");
                                Console.Write($" Выберите число от 1 - {GM.userTry}: ");
                                switch (i)
                                {
                                    case 0:
                                        while (true)
                                        {
                                            inputConsole = Console.ReadLine();
                                            if (int.TryParse(inputConsole, out inputNumber))
                                                if (inputNumber >= 1 && inputNumber <= GM.userTry)
                                                    if (GM.StepPlayers(inputNumber))
                                                        break;
                                        }
                                        break;
                                    case 1:
                                        if (botDifficulty == 1)
                                            while (true)
                                            {
                                                inputNumber = random.Next(1, GM.userTry + 1);
                                                if (inputNumber >= 1 && inputNumber <= GM.userTry)
                                                    if (GM.StepPlayers(inputNumber))
                                                        break;
                                            }
                                        if (botDifficulty == 2)
                                            while (true)
                                            {
                                                bool strategi = false;
                                                if (GM.gameNumber > (GM.userTry * 2 + 1))
                                                {
                                                    inputNumber = random.Next(1, GM.userTry + 1);
                                                    if (inputNumber >= 1 && inputNumber <= GM.userTry)
                                                        if (GM.StepPlayers(inputNumber))
                                                            break;
                                                }

                                                for (int j = 1; j <= GM.userTry; j++)
                                                {

                                                    if ((GM.gameNumber - (GM.userTry + 1 + j)) == 0)
                                                    {
                                                        inputNumber = j;
                                                        GM.StepPlayers(inputNumber);
                                                        strategi = true;
                                                        break;
                                                    }
                                                    else if ((GM.gameNumber - j) == 0)
                                                    {
                                                        inputNumber = j;
                                                        GM.StepPlayers(inputNumber);
                                                        strategi = true;
                                                        break;
                                                    }

                                                }
                                                if (strategi)
                                                    break;
                                                else
                                                {
                                                    inputNumber = random.Next(1, GM.userTry + 1);
                                                    if (inputNumber >= 1 && inputNumber <= GM.userTry)
                                                        if (GM.StepPlayers(inputNumber))
                                                            break;
                                                }

                                            }
                                        Console.Write(inputNumber);
                                        Console.ReadKey();
                                        break;
                                }

                                if (GM.gameNumber == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Игрок: {players[i]} Вы ПОБЕДИТЕЛЬ!!!");
                                    Console.WriteLine("^_^ и большой молодец!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            }
                            raund++;
                        }
                        break;
                    #endregion
                    //5.Посмотреть правила
                    #region
                    case 5:
                        Console.Clear();
                        Console.WriteLine("ПРАВИЛА:\n");
                        Console.WriteLine(" 1.Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.");
                        Console.WriteLine(" 2.Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.");
                        Console.WriteLine(" 3.userTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.");
                        Console.WriteLine(" 4.Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.");
                        Console.Write("Продолжить...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion
                    //6.Выход
                    #region
                    case 6:
                        return 0;
                        break;
                    #endregion
                    //Если число не входит в диапозон 1-6 отчистить консоль
                    default:
                        Console.Clear();
                        break;
                }

            }

        }
    }
}
