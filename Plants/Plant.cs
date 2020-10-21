using Godot;
using System;

public class Plant : Node2D
{
    private AnimatedSprite _sprite;
    private bool _isGrown = false;
    public override void _Ready()
    {
        _sprite = GetNode<AnimatedSprite>("AnimatedSprite");

        _sprite.Play("default");
        _sprite.Connect("animation_finished", this, "Grown");
    }

    private void Grown()
    {
        _isGrown = true;
        QueueFree();
    }
}
