using Godot;
using System;

public class ShopTile : VBoxContainer
{
    [Signal] private delegate void TileSelected(string scene, int cost);
    [Export] private PackedScene _scene { get; set; }
    [Export] private Texture _emptyTileTexture;
    [Export] private int _cost;
    private Label _costLabel;
    private TextureRect _rect;

    public override void _Ready()
    {
        _costLabel = GetNode<Label>("Cost");
        _rect = GetNode<TextureRect>("TextureRect");

        _rect.Texture = _scene?.Instance().GetNode<Sprite>("ItemSprite").Texture ?? _emptyTileTexture;
        _costLabel.Text = _cost == 0 ? "" : _cost.ToString();

        Connect("gui_input", this, "OnInput");
    }

    private void OnInput(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("lclick") && inputEvent is InputEventMouseButton)
        {
            EmitSignal("TileSelected", _scene?.ResourcePath, _cost);
        }
    }
}
