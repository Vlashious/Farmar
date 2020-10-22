using Godot;
using System;
using System.Collections.Generic;

public class UI : Control
{
    [Signal] private delegate void PlantSelected(string pathToScene);
    public static ItemList List { get; private set; }
    private List<string> _items = new List<string>()
    {
        "res://Plants/Daisy.tscn",
        "res://Plants/Violet.tscn",
        "res://Plants/Devil.tscn",
    };
    public override void _Ready()
    {
        List = GetNode<ItemList>("VBoxContainer/ItemList");

        List.Connect("item_selected", this, "OnItemSelected");

        List.FixedIconSize = new Vector2(64, 64);
        List.MaxColumns = 9;
        foreach (var itemPath in _items)
        {
            var item = GD.Load<PackedScene>(itemPath).Instance() as Plant;
            List.AddIconItem(item.GetNode<Sprite>("ItemSprite").Texture);
        }
    }

    private void OnItemSelected(int id)
    {
        GD.Print(_items[id]);
        EmitSignal("PlantSelected", _items[id]);
    }
}
