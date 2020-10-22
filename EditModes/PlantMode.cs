using Godot;

namespace Farmar
{
    class PlantMode
    {
        public static void Plant(TileMap ground, Vector2 pos, PackedScene plant)
        {
            var newPlant = plant.Instance() as Plant;
            var plantPos = ground.MapToWorld(ground.WorldToMap(pos));
            newPlant.Position = plantPos;
            ground.GetParent().AddChild(newPlant);
        }
    }
}