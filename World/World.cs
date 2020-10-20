using Godot;
using System;

public class World : Node2D
{
    private TileMap _ground;
    public override void _Ready()
    {
        _ground = GetNode<TileMap>("Ground");
    }

    public override void _Input(InputEvent @event)
    {
        var mouse = GetGlobalMousePosition();
        if (@event.IsActionPressed("lclick"))
        {
            _ground.SetCellv(_ground.WorldToMap(mouse), 0);
            return;
        }
        if (@event.IsActionPressed("rclick"))
        {
            _ground.SetCellv(_ground.WorldToMap(mouse), -1);
            return;
        }
    }

}
