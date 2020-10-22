using Godot;
using System;
using Farmar;
public class World : Node2D
{
    private enum STATE
    {
        GroundEditing,
        PlantEditing
    }
    private STATE _state;
    private TileMap _ground;
    private int _index = 0;
    public override void _Ready()
    {
        _ground = GetNode<TileMap>("Ground");
        _state = STATE.PlantEditing;
    }

    public override void _Input(InputEvent @event)
    {
        var mouse = GetGlobalMousePosition();
        if (@event.IsActionPressed("lclick") && _state == STATE.GroundEditing)
        {
            GroundMode.EditGround(_ground, mouse, _index);
        }
        if (@event.IsActionPressed("rclick") && _state == STATE.GroundEditing)
        {
            GroundMode.EditGround(_ground, mouse);
        }
        if (@event.IsActionPressed("lclick") && _state == STATE.PlantEditing)
        {
            PackedScene plant = GD.Load("res://Plants/Daisy.tscn") as PackedScene;
            PlantMode.Plant(_ground, mouse, plant);
        }
        if (@event.IsActionPressed("rclick") && _state == STATE.PlantEditing)
        {
            return;
        }
    }

}
