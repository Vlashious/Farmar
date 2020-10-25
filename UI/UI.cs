using Godot;
using System;
using System.Collections.Generic;

public class UI : Control
{
    [Signal] private delegate void ItemSelected(string pathToScene);

    private Panel _inv;
    private ShopUI _shop;
    private int _money = 0;
    public override void _Ready()
    {
        _inv = GetNode<Panel>("Inventory");
        _shop = GetNode<ShopUI>("ShopUI");
        _shop.Connect("ItemSelected", this, "OnItemSelected");
        GetNode<Button>("VBoxContainer/InventoryButton").Connect("pressed", this, "OnInvPressed");
        GetNode<Button>("VBoxContainer/ShopButton").Connect("pressed", this, "OnShopPressed");
        SubscribeTiles();
    }

    private void SubscribeTiles()
    {
        foreach (ItemTile tile in _inv.GetNode<GridContainer>("Items").GetChildren())
        {
            tile.Connect("ItemSold", this, "OnItemSold");
        }
    }

    private void OnItemSelected(string pathToScene, int cost)
    {
        EmitSignal("ItemSelected", pathToScene, cost);
    }

    private void OnItemGathered(string itemScene)
    {
        foreach (ItemTile tile in _inv.GetNode<GridContainer>("Items").GetChildren())
        {
            if (tile.Scene?.ResourcePath == itemScene)
            {
                tile.SetTile(tile.Scene);
                return;
            }
            if (tile.IsEmpty)
            {
                tile.Scene = GD.Load<PackedScene>(itemScene);
                tile.SetTile(tile.Scene);
                return;
            }
        }
    }

    private void OnItemSold(string path, int amount)
    {
        GD.Print($"Sold {amount} items {path}.");
    }

    private void OnInvPressed()
    {
        if (_inv.Visible) _inv.Hide();
        else _inv.Show();
    }

    private void OnShopPressed()
    {
        if (_shop.Visible)
        {
            _shop.Hide();
            EmitSignal("ItemSelected", "");
        }
        else _shop.Show();
    }
}
