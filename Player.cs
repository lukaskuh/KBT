using Godot;
using System;

public class Player : Node2D
{
  [Export]
  public Vector2 velocity;

  private bool isMoving;
  [Export]
  public float acceleration;
  [Export]
  public float maxVelocity;
  [Export]
  public float deacceleration;


    public override void _Ready()
    {
        
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

    velocity.MoveToward(maxVelocity * moveDir.Normalized(), acceleration * delta); 

    // isMoving = (Input.IsActionPressed("ui_left") || Input.IsActionPressed("ui_right") || Input.IsActionPressed("ui_up") ||Input.IsActionPressed("ui_down")); 
    
    // if (!isMoving) {
    //   velocity.MoveToward(Vector2.Zero, deacceleration);
    // }

    GD.Print(velocity);


    Position += velocity * delta;
  }


  
}
