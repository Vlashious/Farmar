using Godot;
using System;

public class Plant : Node2D
{
    private AnimatedSprite _sprite;
    private Area2D _area;
    private bool _isGrown = false;
    public override void _Ready()
    {
        _sprite = GetNode<AnimatedSprite>("AnimatedSprite");
        _area = GetNode<Area2D>("Area2D");

        _sprite.Play("default");
        _sprite.Connect("animation_finished", this, "Grown");

        _area.Connect("input_event", this, "Input");
    }

    private void Grown()
    {
        _isGrown = true;
    }

    private void Input(Node viewport, InputEvent inputEvent, int idx)
    {
        if (inputEvent.IsActionPressed("lclick") && _isGrown) QueueFree();
    }
}
