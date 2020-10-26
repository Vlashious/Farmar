using Godot;
using System;

public class Camera2D : Godot.Camera2D
{
    public override void _UnhandledInput(InputEvent @event)
    {
        var mouseCaptured = false;
        if (@event is InputEventMouseButton e)
        {
            if (e.IsActionPressed("zoom_in")) Zoom /= 1 + 0.05f;
            if (e.IsActionPressed("zoom_out")) Zoom *= 1 + 0.05f;
        }

        if (Input.IsActionPressed("view_pan")) mouseCaptured = true;
        else mouseCaptured = false;

        if (mouseCaptured && @event is InputEventMouseMotion ev)
        {
            Position -= ev.Relative * Zoom;
        }
    }
}
