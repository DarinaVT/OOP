using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace AnimalFight
{
    public partial class Game
    {
        private Map _gameMap;
        private Player _player;
        private Animal _currentEnemy = null;
        private Position _enemyPosition;
        private GameManager _inputManager;
        private readonly Queue<string> _combatLogList = new Queue<string>();
        private DateTime? _lastMessageTime;
        private DateTime? _nextRound;
        private int _moves = 0;
        private string _currentMessage = string.Empty;
        private bool _inCombat = false;
        private bool _isPlayerTurn = true;
        public bool QuitGame { get; set; } = false;
        public bool InCombat => _inCombat;

        public void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            ShowTitle();
            Animal playerAnimal = SelectAnimal();
            if (playerAnimal == null)
            {
                return;
            }

            Console.Clear();
            _player = new Player(playerAnimal);
            _gameMap = new Map(15, 15, playerAnimal.Environment, _player);

            Commands();
            GameLoop();
        }

        private void Commands()
        {
            var move = new MoveCommand();
            var quit = new QuitCommand();

            move.SetNext(quit);

            _inputManager = move;
        }

        private void GameLoop()
        {
            while (!_player.IsDead && !QuitGame)
            {
                _gameMap.DrawMap();
                DisplayStats();
                FightInfo();
                UpdateMessages();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    _inputManager.Manage(key, this);
                }

                Thread.Sleep(50);
            }

            GameOver();
            Console.CursorVisible = true;
        }

        public void Move(Direction direction)
        {
            Position newPosition = _player.Animal.Position.NextMove(direction);

            if (!_gameMap.AbleToMove(newPosition)) return;

            object tile = _gameMap.Tile(newPosition);

            if (tile is Animal enemy)
            {
                _enemyPosition = newPosition;
                Combat(enemy);
            }
            else if (tile is Booster booster)
            {
                _gameMap.MovePlayer(newPosition);
                booster.ApplyBoost(_player);
                _currentMessage = $"{booster.Emoji} boost applied";
                _lastMessageTime = DateTime.Now;
            }
            else
            {
                _gameMap.MovePlayer(newPosition);
            }

            _moves++;
            if (_moves % 15 == 0)
            {
                _gameMap.SpawnItems();
                _currentMessage = "New items appeared on the map";
                _lastMessageTime = DateTime.Now;
            }
        }

        private void Combat(Animal enemy)
        {
            _inCombat = true;
            _currentEnemy = enemy;
            _combatLogList.Clear();
            _isPlayerTurn = true;
            _nextRound = DateTime.Now.AddSeconds(1.5);
            _combatLogList.Enqueue($"Fight with {enemy.Name} begins");
        }

        private void FightInfo()
        {
            if (!_inCombat || _currentEnemy == null || _nextRound == null)
            {
                return;
            }

            if (DateTime.Now < _nextRound.Value)
            { 
                return;
            }

            if (_isPlayerTurn)
            {
                _currentEnemy.Life -= _player.Animal.Power;
                _combatLogList.Enqueue($"You attacked {_currentEnemy.Name}: {_currentEnemy.Life} HP left");

                if (_currentEnemy.Life <= 0)
                {
                    _combatLogList.Enqueue($"{_currentEnemy.Name} was defeated");
                    _player.Kills++;
                    _gameMap.RemoveEnemy(_enemyPosition);
                    _inCombat = false;
                    return;
                }
            }
            else
            {
                _player.Animal.Life -= _currentEnemy.Power;
                _combatLogList.Enqueue($"{_currentEnemy.Name} counterattacked you: -{_currentEnemy.Power} HP");

                if (_player.IsDead)
                {
                    _combatLogList.Enqueue($"{_player.Animal.Name} has been defeated");
                    _inCombat = false;
                    return;
                }
            }

            _isPlayerTurn = !_isPlayerTurn;
            _nextRound = DateTime.Now.AddSeconds(1.5);

            if (_combatLogList.Count > 0)
            {
                _currentMessage = _combatLogList.Dequeue();
                _lastMessageTime = DateTime.Now;
            }
        }

        private void UpdateMessages()
        {
            Console.SetCursorPosition(0, _gameMap.Height + 1);

            if (_inCombat && _combatLogList.Count > 0)
            {
                _currentMessage = _combatLogList.Dequeue();
                _lastMessageTime = DateTime.Now;
            }
            else if (!_inCombat && (DateTime.Now - _lastMessageTime)?.TotalSeconds > 1.5)
            {
                _currentMessage = string.Empty;
            }

            Console.Write(_currentMessage.PadRight(Console.WindowWidth));
        }

        private void DisplayStats()
        {
            Console.SetCursorPosition(0, _gameMap.Height);
            Console.Write($"{_player.PlayerEmoji} {_player.Animal.Name} ");
            Console.Write($"❤️{_player.Animal.Life} ");
            Console.Write($"⚡{_player.Animal.Power} ");
            Console.Write(new string(' ', Console.WindowWidth - Console.CursorLeft));
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over");
            Console.WriteLine($"You died");
            Console.WriteLine($"\nScore");
            Console.WriteLine($"Defeated: {_player.Kills}");
            Console.WriteLine("\nPress any key to leave the game...");
            Console.ReadKey();
        }

        private void ShowTitle()
        {
            Console.WriteLine("Animal Fight");
            Console.WriteLine("Explore the wild life by becoming a part of it");
            Console.WriteLine("Choose your own continent and habitat and rule the kingdom by choosing the most powerful animal");
            Console.WriteLine("Or become one of the weakest creatures to prove they can survive");
            Console.WriteLine("Use arrow keys for navigation and Esc key to leave the game\n");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private Animal SelectAnimal()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"{i + 1}. {(ContinentType)i}");
            }

            Console.Write("Choose a continent: ");
            int continentChoice = ValidateNumber(1, 7);
            ContinentType continent = (ContinentType)(continentChoice - 1);

            Console.WriteLine("\n1. Land 🟫");
            Console.WriteLine("2. Water 🟦");
            Console.Write("Choose a habitat: ");
            int habitatChoice = ValidateNumber(1, 2);
            EnvironmentType habitat = (EnvironmentType)(habitatChoice - 1);

            var animals = AnimalDivision.AnimalList(continent, habitat)?.Animals;
            for (int i = 0; i < animals.Count; i++)
            {
                var animal = animals[i];
                if(i == 0)
                {
                    Console.WriteLine($"\n{i + 1}. {animal.Name} {animal.Emoji} (Power: {animal.Power}, Health: {animal.Life})");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {animal.Name} {animal.Emoji} (Power: {animal.Power}, Health: {animal.Life})");
                }
            }

            Console.Write("Choose your animal: ");
            return animals[ValidateNumber(1, animals.Count) - 1];
        }

        private int ValidateNumber(int min, int max)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Console.Write($"Enter a number {min}-{max}: ");
            }
            return input;
        }

        public Direction GetDirectionFromKey(ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => Direction.None
            };
        }
    }
}
