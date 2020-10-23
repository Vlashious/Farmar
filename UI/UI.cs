using Godot;
using System;
using System.Collections.Generic;

public class UI : Control
{
    [Signal] private delegate void ItemSelected(string pathToScene);
    public static ItemList InvList { get; private set; }
    public static ItemList ShopList { get; private set; }
    public static Label MoneyLabel { get; private set; }
    private int _money = 0;
    private List<string> _items = new List<string>()
    {
        "res://Plants/Daisy.tscn",
        "res://Plants/Violet.tscn",
        "res://Plants/Devil.tscn",
    };
    public override void _Ready()
    {
        InvList = GetNode<ItemList>("InventoryList");
        ShopList = GetNode<ItemList>("ShopList");
        MoneyLabel = GetNode<Label>("VBoxContainer/MoneyLabel");

        GetNode<Button>("VBoxContainer/InventoryButton").Connect("pressed", this, "OnInvPressed");
        GetNode<Button>("VBoxContainer/ShopButton").Connect("pressed", this, "OnShopPressed");

        ShopList.Connect("item_selected", this, "OnItemSelected");
        InvList.Connect("item_activated", this, "OnItemActivated");
    }

    private void OnItemSelected(int id)
    {
        GD.Print(_items[id]);
        EmitSignal("ItemSelected", _items[id]);
    }

    private void OnPlantGathered(Plant plant)
    {
        InvList.AddItem(plant.Name, plant.GetNode<Sprite>("ItemSprite").Texture, false);
    }

    private void OnInvPressed()
    {
        if (InvList.Visible) InvList.Hide();
        else InvList.Show();
    }

    private void OnShopPressed()
    {
        if (ShopList.Visible) ShopList.Hide();
        else ShopList.Show();
    }

    private void OnItemActivated(int id)
    {
        MoneyLabel.Text = (++_money).ToString();
        InvList.RemoveItem(id);
    }
}
