using Godot;
using System;

public class Plant : Node2D
{
    [Signal] private delegate void PlantGathered(string scene);
    private AnimatedSprite _animSprite;
    private Sprite _sprite;
    private bool _isGrown = false;
    public override void _Ready()
    {
        _animSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        _sprite = GetNode<Sprite>("ItemSprite");
        GetNode<Area2D>("Area2D").Connect("input_event", this, "OnClick");

        _animSprite.Play("default");
        _animSprite.Connect("animation_finished", this, "Grown");
    }

    private void Grown()
    {
        _isGrown = true;
    }

    private void OnClick(Node viewport, InputEvent inputEvent, int shapeIdx)
    {
        if (inputEvent.IsActionPressed("rclick") && _isGrown)
        {
            EmitSignal("PlantGathered", this.Filename);
            QueueFree();
        }
    }
}
