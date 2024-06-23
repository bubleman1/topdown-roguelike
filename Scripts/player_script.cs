using Godot;
using System;
using System.Reflection.Metadata.Ecma335;

public partial class player_script : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 200;
	private AnimatedSprite2D animatedSprite { get; set; }
	private Vector2 velocity = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		ProcessInput();
		ProcessAnimations();
		base.Velocity = velocity;
		MoveAndSlide();
	}
	
	public void ProcessInput()
	{
		velocity = Vector2.Zero;
		if(Input.IsActionPressed("right")){
			velocity.X += 1;
		}
	   	 
		if(Input.IsActionPressed("left")){
			velocity.X -= 1;
		}
			
		if(Input.IsActionPressed("down")){
			velocity.Y += 1;
		}
			
   		if(Input.IsActionPressed("up")){
			velocity.Y -= 1;
		}	
		velocity = velocity.Normalized() * Speed;
		
	}

	public void ProcessAnimations()
	{
		if (velocity != Vector2.Zero)
		{
			animatedSprite.Play();
		}
		else
		{
			animatedSprite.Stop();
		}

		if (velocity.X > 0)
		{
			animatedSprite.FlipH = false;
		}
		else if (velocity.X < 0)
		{
			animatedSprite.FlipH = true;
		}
	}
}