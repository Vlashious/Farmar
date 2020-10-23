using Godot;
using System;

public class ItemTile : VBoxContainer
{
    public PackedScene Scene { get; set; }
    private int _count = 0;
    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            _count = value;
            GetNode<Label>("Count").Text = _count.ToString();
        }
    }
    public bool IsEmpty { get; private set; } = true;
    public override void _Ready()
    {
        GetNode<TextureRect>("CenterContainer/TextureRect").Connect("gui_input", this, "OnInput");
        Connect("gui_input", this, "OnInput");
    }

    public void SetTile(PackedScene scene)
    {
        if (!IsEmpty)
        {
            Count++;
            return;
        }
        var texture = Scene.Instance().GetNode<Sprite>("ItemSprite").Texture;
        GetNode<TextureRect>("CenterContainer/TextureRect").Texture = texture;
        IsEmpty = false;
        Count++;
    }

    private void OnInput(InputEvent @event)
    {
        if (@event.IsActionPressed("lclick") && @event is InputEventMouse e)
        {
            GD.Print("Has been clicked!");
        }
    }

}
