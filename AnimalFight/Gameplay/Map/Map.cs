using System.Text;

namespace AnimalFight
{
    public class Map
    {
        private readonly object[,] _grid;
        private readonly Player _player;
        private readonly List<Animal> _loadedList;
        private readonly Random _random = new Random();
        private readonly string baseTile;
        private readonly string[] decorations;
        private readonly MapManager _commandChain;

        public int Width { get; }
        public int Height { get; }

        public Map(int width, int height, EnvironmentType habitat, Player player)
        {
            Width = width;
            Height = height;
            this._player = player;
            _grid = new object[Width, Height];

            switch (habitat)
            {
                case EnvironmentType.Land:
                    baseTile = "🟫";
                    break;
                default:
                    baseTile = "🟦";
                    break;
            }

            switch (habitat)
            {
                case EnvironmentType.Land:
                    decorations = new[] { "🪨", "🌲", "🌵", "🗻", "🏔️" };
                    break;
                default:
                    decorations = new[] { "🐚", "🌊", "🌱", "🪸", "⛵" };
                    break;
            }

            var group = AnimalDivision.AnimalList(player.Animal.Continent, habitat);
            _loadedList = new List<Animal>();
            foreach (var animal in group.Animals)
            {
                if (animal.Name != player.Animal.Name)
                {
                    _loadedList.Add(animal);
                }
            }

            var tile = new TileManager();
            var spawnItems = new SpawnItemsManager();
            var removeEnemy = new RemoveEnemyManager();
            var movePlayer = new MovePlayerManager();
            var drawMap = new DrawMapManager();
            var ableToMove = new AbleToMoveManager();

            tile.SetNext(spawnItems);
            spawnItems.SetNext(removeEnemy);
            removeEnemy.SetNext(movePlayer);
            movePlayer.SetNext(drawMap);
            drawMap.SetNext(ableToMove);

            _commandChain = tile;

            GenerateMap();
        }

        private void GenerateMap()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _grid[x, y] = baseTile;
                }
            }

            _player.Animal.Position = new Position(Width / 2, Height / 2);
            AddDecorations();
            InitalObjects();
        }

        private void AddDecorations()
        {
            for (int i = 0; i < 15; i++)
            {
                Position position = RandomEmptyPosition();
                if (_grid[position.X, position.Y] as string == baseTile)
                {
                    _grid[position.X, position.Y] = decorations[_random.Next(decorations.Length)];
                }
            }
        }

        private void InitalObjects()
        {
            for (int i = 0; i < _random.Next(5, 9); i++)
            {
                Position position = RandomEmptyPosition();
                Animal enemy = _loadedList[_random.Next(_loadedList.Count)].AddAnimal(position);
                _grid[position.X, position.Y] = enemy;
            }

            for (int i = 0; i < _random.Next(3, 6); i++)
            {
                Position position = RandomEmptyPosition();
                if (_random.Next(2) == 0)
                {
                    _grid[position.X, position.Y] = new HealthBooster(position);
                }
                else
                {
                    _grid[position.X, position.Y] = new PowerBooster(position);
                }
            }
        }

        public void SpawnItems() => _commandChain.Manage(new SpawnItemsCommand(), this);

        public void DrawMap() => _commandChain.Manage(new DrawMapCommand(), this);

        public bool AbleToMove(Position position)
        {
            var command = new AbleToMoveCommand(position);
            _commandChain.Manage(command, this);
            return command.CanMove;
        }

        public object Tile(Position position)
        {
            var command = new TileCommand(position);
            _commandChain.Manage(command, this);
            return command.Result;
        }

        public void RemoveEnemy(Position position) => _commandChain.Manage(new RemoveEnemyCommand(position), this);
        public void MovePlayer(Position newPosition) => _commandChain.Manage(new MovePlayerCommand(newPosition), this);

        internal void InnerSpawnItems()
        {
            for (int i = 0; i < _random.Next(1, 3); i++)
            {
                Position position = RandomEmptyPosition();
                Animal enemy = _loadedList[_random.Next(_loadedList.Count)].AddAnimal(position);
                _grid[position.X, position.Y] = enemy;
            }

            Position boosterPosition = RandomEmptyPosition();
            if (_player.NeedsHealth && _random.Next(2) == 0)
            {
                _grid[boosterPosition.X, boosterPosition.Y] = new HealthBooster(boosterPosition);
            }
            else if (_player.NeedsPower && _random.Next(2) == 0)
            {
                _grid[boosterPosition.X, boosterPosition.Y] = new PowerBooster(boosterPosition);
            }
        }

        internal void InnerDrawMap()
        {
            Console.SetCursorPosition(0, 0);
            var location = new StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_player.Animal.Position.X == x && _player.Animal.Position.Y == y)
                    {
                        location.Append(_player.PlayerEmoji);
                        continue;
                    }

                    object tileContent = _grid[x, y];
                    if (tileContent is Animal)
                    {
                        location.Append(((Animal)tileContent).Emoji);
                    }
                    else if (tileContent is Booster)
                    {
                        location.Append(((Booster)tileContent).Emoji);
                    }
                    else if (tileContent is string)
                    {
                        location.Append((string)tileContent);
                    }
                    else
                    {
                        location.Append(" ");
                    }
                }
                location.AppendLine();
            }

            Console.Write(location.ToString());
        }

        internal bool InnerAbleToMove(Position position)
        {
            if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height)
            {
                return false;
            }

            var tile = _grid[position.X, position.Y] as string;
            if (tile == null)
            {
                return true;
            }
            else
            {
                return tile == baseTile;
            }
        }

        internal object InnerTile(Position position)
        {
            return _grid[position.X, position.Y];
        }

        internal void InnerRemoveEnemy(Position position)
        {
            _grid[position.X, position.Y] = baseTile;
        }

        internal void InnerMovePlayer(Position newPosition)
        {
            var oldPosition = _player.Animal.Position;
            if (_grid[oldPosition.X, oldPosition.Y] is Booster)
            {
                _grid[oldPosition.X, oldPosition.Y] = baseTile;
            }
            _player.Animal.Position = newPosition;
        }

        private Position RandomEmptyPosition()
        {
            Position position;
            int attempts = 0;
            do
            {
                position = new Position(_random.Next(Width), _random.Next(Height));
                attempts++;
            }
            while ((_grid[position.X, position.Y] is not string || _grid[position.X, position.Y] as string != baseTile) && attempts < 100);

            if (attempts < 100)
            {
                return position;
            }
            else
            {
                return FindFirstEmptyPosition();
            }
        }

        private Position FindFirstEmptyPosition()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (_grid[x, y] as string == baseTile && !new Position(x, y).Equals(_player.Animal.Position))
                    {
                        return new Position(x, y);
                    }
                }
            }
            return new Position(0, 0);
        }
    }
}