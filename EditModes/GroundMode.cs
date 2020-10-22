using Godot;

namespace Farmar
{
    public class GroundMode
    {
        public static void EditGround(TileMap ground, Vector2 pos, int index = -1)
        {
            ground.SetCellv(ground.WorldToMap(pos), index);
        }
    }
}