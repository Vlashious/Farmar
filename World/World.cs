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
    private UI _ui;
    private int _index = 0;
    private string _pathToPlant;
    public override void _Ready()
    {
        _ground = GetNode<TileMap>("Ground");
        _ui = GetNode<UI>("CanvasLayer/UI");
        _ui.Connect("ItemSelected", this, "OnPlantSelected");
        _state = STATE.PlantEditing;
    }

    public override void _UnhandledInput(InputEvent @event)
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
            PackedScene plant = GD.Load(_pathToPlant) as PackedScene;
            PlantMode.Plant(_ground, mouse, plant)?.Connect("PlantGathered", _ui, "OnItemGathered");
        }
        if (@event.IsActionPressed("rclick") && _state == STATE.PlantEditing)
        {
            return;
        }
    }

    private void OnPlantSelected(string path)
    {
        _pathToPlant = path;
    }

}
