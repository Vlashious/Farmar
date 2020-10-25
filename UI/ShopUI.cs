using Godot;
using System;
using System.Collections.Generic;

public class ShopUI : Control
{
    [Signal] delegate void ItemSelected(string path);
    private TabContainer _tab;
    private Godot.Collections.Array _plants;
    private Godot.Collections.Array _ground;

    public override void _Ready()
    {
        _plants = GetNode<GridContainer>("TabContainer/Plants").GetChildren();
        _ground = GetNode<GridContainer>("TabContainer/Ground").GetChildren();
        SubscribeTiles(_plants);
        SubscribeTiles(_ground);

        _tab = GetNode<TabContainer>("TabContainer");
        _tab.Connect("tab_changed", this, "OnTabChanged");
    }

    private void OnItemSelected(string scene)
    {
        EmitSignal("ItemSelected", scene);
    }

    private void SubscribeTiles(Godot.Collections.Array tiles)
    {
        foreach (ShopTile tile in tiles)
        {
            tile.Connect("TileSelected", this, "OnTileSelected");
        }
    }

    private void OnTabChanged(int tab)
    {
        // TODO: Unselect mechanic.
    }

    private void OnTileSelected(string scene, int cost)
    {
        EmitSignal("ItemSelected", scene, cost);
    }
}
