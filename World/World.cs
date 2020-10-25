using Godot;
using System;
using Farmar;
public class World : Node2D
{
    private enum STATE
    {
        GroundAdd,
        GroundRemove,
        PlantAdd,
        PlantRemove
    }
    private STATE _state;
    private TileMap _ground;
    private UI _ui;
    private int _index = 0;
    private string _pathToItem;
    public override void _Ready()
    {
        _ground = GetNode<TileMap>("Ground");
        _ui = GetNode<UI>("CanvasLayer/UI");
        SubscribeUI();
        _state = STATE.PlantRemove;
    }

    private void SubscribeUI()
    {
        _ui.Connect("ItemSelected", this, "OnItemSelected");
        _ui.Connect("ShopOpened", this, "OnShopOpened");
        _ui.Connect("ShopClosed", this, "OnShopClosed");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        var mouse = GetGlobalMousePosition();
        if (@event.IsActionPressed("lclick") && _state == STATE.GroundAdd)
        {
            GroundMode.EditGround(_ground, mouse, _pathToItem);
        }
        if (@event.IsActionPressed("rclick") && _state == STATE.GroundRemove)
        {
            GroundMode.EditGround(_ground, mouse);
        }
        if (@event.IsActionPressed("lclick") && _state == STATE.PlantAdd)
        {
            Plant(mouse);
        }
        if (@event.IsActionPressed("rclick") && _state == STATE.PlantRemove)
        {
            return;
        }
    }

    private void Plant(Vector2 pos)
    {
        PlantMode.Plant(_ground, pos, _pathToItem)?.Connect("PlantGathered", _ui, "OnItemGathered");
    }

    private void OnItemSelected(string path, int cost)
    {
        _pathToItem = path;
        GD.Print(cost);
    }

    private void OnShopOpened()
    {
        _state = STATE.GroundAdd;
    }

    private void OnShopClosed()
    {
        _state = STATE.PlantRemove;
    }

}
