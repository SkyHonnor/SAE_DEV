using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System.Diagnostics;

namespace TheGame
{
    internal class Map
    {
        public const string LAYER_COLLISION = "Sol";

        private string _name;

        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;

        private TiledMapTileLayer _tiledMapTileLayerCollision;

        public Map(Game game, string name)
        {
            _name = name;

            _tiledMap = game.Content.Load<TiledMap>($"maps/{name}/map_{name}");
            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);

            _tiledMapTileLayerCollision = _tiledMap.GetLayer<TiledMapTileLayer>(LAYER_COLLISION);
        }

        public string Name { 
            get => _name;
        }

        public TiledMap TiledMap
        {
            get => _tiledMap;
        }

        public TiledMapTile GetTile(ushort x, ushort y)
        {
            return _tiledMapTileLayerCollision.GetTile(x, y);
        }

        public bool EstEnCollision(ushort x, ushort y)
        {
            TiledMapTile? tile;
            if (_tiledMapTileLayerCollision.TryGetTile(x, y, out tile) == false)
                return false;

            if (!tile.Value.IsBlank)
                return true;

            return false;
        }

        public bool EstEnCollision(Vector2 vector)
        {
            return EstEnCollision((ushort)vector.X, (ushort)vector.Y);
        }

        public void Update(GameTime gameTime)
        {
            _tiledMapRenderer.Update(gameTime);
        }

        public void Draw()
        {
            _tiledMapRenderer.Draw();
        }
    }
}
