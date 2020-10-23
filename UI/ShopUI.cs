using Godot;
using System;
using System.Collections.Generic;

public class ShopUI : Control
{
    [Signal] delegate void ItemSelected(string path);
    private ItemList _itemList;
    private List<string> _items = new List<string>()
    {
        "res://Plants/Daisy.tscn",
        "res://Plants/Violet.tscn",
        "res://Plants/Devil.tscn",
    };
    public override void _Ready()
    {
        _itemList = GetNode<ItemList>("ItemList");
        _itemList.Connect("item_selected", this, "OnItemSelected");
    }

    private void OnItemSelected(int id)
    {
        EmitSignal("ItemSelected", _items[id]);
    }
}
