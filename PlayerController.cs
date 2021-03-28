using Godot;
using System;

public class PlayerController : Node2D
{
    [Export]
    public float chainLength;    

    Player player;
    Ball ball;
    
    public override void _Ready()
    {
        player = GetNode<Player>("Player");
        ball = GetNode<Ball>("Ball");
    }

    public override void _Process(float delta)
    {
        Update();
    }

    public override void _Draw()
    {
        DebugDraw();
    }

    public void DebugDraw()
    {
        // Temp chain
        DrawLine(player.Position, ball.Position, Colors.White, 2, false);

        // Forces
        DrawLine(player.Position, player.Position + player.velocity, Colors.Red, 1, false);
        DrawLine(ball.Position, ball.Position + ball.velocity, Colors.Red, 1, false);
    }
}
