using Godot;
using System;

public class ItemTile : VBoxContainer
{
    [Signal] private delegate void ItemSold(string scene, int amount);
    public PackedScene Scene { get; set; }
    [Export] private Texture _emptyTileTexture;
    private TextureRect _textRect;
    private int _count;
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
            if (_count <= 1) GetNode<Label>("Count").Text = "";
        }
    }
    public bool IsEmpty { get; private set; } = true;
    public override void _Ready()
    {
        Count = 0;
        _textRect = GetNode<TextureRect>("CenterContainer/TextureRect");
        _textRect.Connect("gui_input", this, "OnInput");
        ResetTile();
        Connect("gui_input", this, "OnInput");
    }

    private void ResetTile()
    {
        Count = 0;
        Scene = null;
        _textRect.Texture = _emptyTileTexture;
        IsEmpty = true;
    }

    public void SetTile(PackedScene scene)
    {
        if (!IsEmpty)
        {
            Count++;
            return;
        }
        var texture = Scene.Instance().GetNode<Sprite>("ItemSprite").Texture;
        _textRect.Texture = texture;
        IsEmpty = false;
        Count++;
    }

    private void OnInput(InputEvent @event)
    {
        if (@event.IsActionPressed("lclick") && !IsEmpty && @event is InputEventMouseButton e && e.Doubleclick)
        {
            EmitSignal("ItemSold", Scene.ResourcePath, Count);
            ResetTile();
        }
    }

}
