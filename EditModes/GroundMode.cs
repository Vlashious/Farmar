using Godot;

namespace Farmar
{
    public class GroundMode : Mode
    {
        public GroundMode(TileMap ground) : base(ground)
        {
        }

        public override void EditGround(Vector2 pos, int index)
        {
            _ground.SetCellv(_ground.WorldToMap(pos), index);
        }
    }
}