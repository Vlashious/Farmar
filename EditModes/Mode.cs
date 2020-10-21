using Godot;

namespace Farmar
{
    abstract public class Mode
    {
        protected TileMap _ground;
        public Mode(TileMap ground)
        {
            _ground = ground;
        }
        abstract public void EditGround(Vector2 pos, int index = -1);
    }
}