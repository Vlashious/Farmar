using Godot;

namespace Farmar
{
    class PlantMode
    {
        public static Plant Plant(TileMap ground, Vector2 pos, string scene)
        {
            var plant = GD.Load<PackedScene>(scene).Instance() as Plant;
            var newPos = ground.MapToWorld(ground.WorldToMap(pos));
            newPos.y += 4;
            plant.Position = newPos;
            ground.GetParent().AddChild(plant);
            return plant;
        }
    }
}