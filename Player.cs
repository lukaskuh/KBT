using Godot;
using System;

public class Player : Node2D
{

  [Export]
  public Vector2 velocity;

  [Export]
  public float acceleration;
  [Export]
  public float maxVelocity;
  private bool isMoving;

  PlayerController playerController;

    public override void _Ready()
    {
        playerController = GetParent<PlayerController>();
    }

  public override void _Process(float delta)
  {
    Vector2 direction = new Vector2
    (
      Convert.ToSingle(Input.IsActionPressed("ui_right")) - Convert.ToSingle(Input.IsActionPressed("ui_left")),
      Convert.ToSingle(Input.IsActionPressed("ui_down")) - Convert.ToSingle(Input.IsActionPressed("ui_up"))
    );

    velocity = velocity.MoveToward(maxVelocity * direction.Normalized(), acceleration * delta); 

    Position += velocity * delta;
  }
}
