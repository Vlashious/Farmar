using Godot;
using System;
using Farmar;
public class World : Node2D
{
    private TileMap _ground;
    private Mode _editMode;
    private int _index = 0;
    public override void _Ready()
    {
        _ground = GetNode<TileMap>("Ground");
        _editMode = new GroundMode(_ground);
    }

    public override void _Input(InputEvent @event)
    {
        var mouse = GetGlobalMousePosition();
        if (@event.IsActionPressed("lclick"))
        {
            _editMode.EditGround(mouse, _index);
        }
        if (@event.IsActionPressed("rclick"))
        {
            _editMode.EditGround(mouse);
        }
    }

}
