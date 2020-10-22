using Godot;
using System;

public class Plant : Node2D
{
    private AnimatedSprite _sprite;
    private bool _isGrown = false;
    public override void _Ready()
    {
        _sprite = GetNode<AnimatedSprite>("AnimatedSprite");
        GetNode<Area2D>("Area2D").Connect("input_event", this, "OnClick");

        _sprite.Play("default");
        _sprite.Connect("animation_finished", this, "Grown");
    }

    private void Grown()
    {
        _isGrown = true;
    }

    private void OnClick(Node viewport, InputEvent inputEvent, int shapeIdx)
    {
        if (inputEvent.IsActionPressed("rclick") && _isGrown) QueueFree();
    }
}
