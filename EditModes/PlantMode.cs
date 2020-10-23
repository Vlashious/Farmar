using Godot;

namespace Farmar
{
    class PlantMode
    {
        public static Plant Plant(TileMap ground, Vector2 pos, PackedScene plant)
        {
            if (ground.GetCellv(ground.WorldToMap(pos)) != -1 && plant != null)
            {
                var newPlant = plant.Instance() as Plant;
                var plantPos = ground.MapToWorld(ground.WorldToMap(pos));
                plantPos.y += 4;
                newPlant.Position = plantPos;
                ground.GetParent().AddChild(newPlant);
                GD.Print("New plant added");
                return newPlant;
            }
            else GD.Print("No ground beneath!");
            return null;
        }
    }
}