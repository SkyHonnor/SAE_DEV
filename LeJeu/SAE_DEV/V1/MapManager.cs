using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TheGame
{
    internal class MapManager
    {
        private Dictionary<string, Map> _maps;
        private Map _currentMap;

        public MapManager(Game game)
        {
            _maps = new Dictionary<string, Map>();

            Map defaultMap = new Map(game, "default");
            AddMap(defaultMap);
        }

        public Map CurrentMap
        {
            get => _currentMap;
        }

        public void AddMap(Map map)
        {
            _maps.Add(map.Name, map);
        }

        public void RemoveMap(string name)
        {
            _maps.Remove(name);
        }

        public void SelectMap(string name)
        {
            _currentMap = _maps[name];
        }

        public void Update(GameTime gameTime)
        {
            if (_currentMap != null)
                _currentMap.Update(gameTime);
        }

        public void Draw()
        {
            if (_currentMap != null)
                _currentMap.Draw();
        }
    }
}
