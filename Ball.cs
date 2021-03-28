using Godot;
using System;

public class Ball : Sprite
{
    [Export]
    public Vector2 velocity;

    [Export]
    public float acceleration;
    [Export]
    public float deacceleration;
    [Export]
    public float maxVelocity;

    PlayerController playerController;
    Player player;
    public override void _Ready()
    {
        playerController = GetParent<PlayerController>();
        player = GetParent<PlayerController>().GetNode<Player>("Player");
    }

    public override void _Process(float delta)
    {
        if (Position.DistanceTo(player.Position) >= playerController.chainLength)
        {
            velocity = player.velocity;//velocity.MoveToward(player.Position - Position, acceleration * delta);
        }
        else 
        {
            velocity = velocity.MoveToward(Vector2.Zero, deacceleration * delta);
        }

        Position += velocity * delta;
    }
}
