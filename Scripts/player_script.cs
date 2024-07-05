using Godot;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public partial class player_script : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 400;
	
	[Export]
	public float Health { get; set; } = 100;
	
	public Projectile Ability { get; set; }
	private AnimatedSprite2D animatedSprite { get; set; }
	private Marker2D shootingPoint {  get; set; }
	private Vector2 velocity = Vector2.Zero;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Ability = new SparkRes();
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		shootingPoint = GetNode<Marker2D>("Marker2D").GetNode<Marker2D>("Marker2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Ability.ManageTime(delta);
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
		
		if(Input.IsActionJustPressed("shoot") && Ability.CanShoot){
			Ability.PutOnCooldown();
			Shoot();		
		}	

		velocity = velocity.Normalized() * Speed;
	}

	public void Shoot()
	{
		Ability.Instantiate();
		Fireball projectile = Ability.Spell;
		Owner.AddChild(projectile);
		projectile.Transform = shootingPoint.GlobalTransform;
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
	private void _on_area_2d_area_entered(Area2D area)
	{
		 if (area.IsInGroup("enemy"))
		{
			Health -= 10;
			animatedSprite.FlipH = true;
		}
	}
}






