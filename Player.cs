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
    Vector2 moveDir = new Vector2();
  
    if (Input.IsActionPressed("ui_left"))
    {
      moveDir.x = -1;
    } 
    if (Input.IsActionPressed("ui_right"))
    {
      moveDir.x = 1;
        
    }if (Input.IsActionPressed("ui_up"))
    {
      moveDir.y = -1;
    }
    if (Input.IsActionPressed("ui_down"))
    {
      moveDir.y = 1;
    }

    velocity = velocity.MoveToward(maxVelocity * moveDir.Normalized(), acceleration * delta); 


    Position += velocity * delta;
  }
}
