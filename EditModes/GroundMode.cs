using Godot;

namespace Farmar
{
    public class GroundMode
    {
        public static void EditGround(TileMap ground, Vector2 pos, string scene = null)
        {
            int id = scene == null ? -1 : SceneMapper.Ground[scene];
            ground.SetCellv(ground.WorldToMap(pos), id);
        }
    }
}