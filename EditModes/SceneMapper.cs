using System.Collections.Generic;

namespace Farmar
{
    class SceneMapper
    {
        public static Dictionary<string, int> Ground { get; private set; } = new Dictionary<string, int>()
        {
            {"res://Ground/Grass.tscn", 0},
            {"res://Ground/Soil.tscn", 1},
            {"res://Ground/Water.tscn", 2},
        };
        public static Dictionary<string, int> Plants { get; private set; } = new Dictionary<string, int>()
        {
            {"res://Plants/Daisy.tscn", 0},
            {"res://Plants/Violet.tscn", 1},
            {"res://Plants/Devil.tscn", 2},
        };
    }
}