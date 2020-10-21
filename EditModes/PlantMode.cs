using Godot;

namespace Farmar
{
    class PlantMode : Mode
    {
        private PackedScene _plant;
        public PlantMode(TileMap ground, PackedScene plant) : base(ground)
        {
            _plant = plant;
        }

        public override void EditGround(Vector2 pos, int index = -1)
        {
            var newPlant = _plant.Instance() as Plant;
            var plantPos = _ground.MapToWorld(_ground.WorldToMap(pos));
            newPlant.Position = plantPos;
            _ground.GetParent().AddChild(newPlant);
        }
    }
}