using Godot;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public partial class player_script : CharacterBody2D
{
	
	
	[Export]
	public VelocityComponent velocityComponent {get; set;}
	[Export]
	public HealthComponent healthComponent {get;set;}
	
	
	public Projectile Ability { get; set; }
	private AnimatedSprite2D animatedSprite { get; set; }
	private Marker2D shootingPoint {  get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		healthComponent = GetNode<HealthComponent>("HealthComponent");
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
		base.Velocity = velocityComponent.Velocity;
		MoveAndSlide();
	}
	
	public void ProcessInput()
	{

		velocityComponent.Velocity = Vector2.Zero;
		if(Input.IsActionPressed("right")){
			velocityComponent.Velocity.X += 1;
		}
	   	 
		if(Input.IsActionPressed("left")){
			velocityComponent.Velocity.X -= 1;
		}
			
		if(Input.IsActionPressed("down")){
			velocityComponent.Velocity.Y += 1;
		}
			
   		if(Input.IsActionPressed("up")){
			velocityComponent.Velocity.Y -= 1;
		}
		
		if(Input.IsActionJustPressed("shoot") && Ability.CanShoot){
			Ability.PutOnCooldown();
			Shoot();		
		}	

		velocityComponent.ProcessVelocity();
		velocityComponent.ProcessKnockback();
	}	

	public void Shoot()
	{
		Fireball projectile = Ability.Instantiate();
		Owner.AddChild(projectile);
		projectile.Transform = shootingPoint.GlobalTransform;
	}

	public void ProcessAnimations()
	{
		if (velocityComponent.Velocity != Vector2.Zero)
		{
			animatedSprite.Play();
		}
		else
		{
			animatedSprite.Stop();
		}

		if (velocityComponent.Velocity.X > 0)
		{
			animatedSprite.FlipH = false;
		}
		else if (velocityComponent.Velocity.X < 0)
		{
			animatedSprite.FlipH = true;
		}
	}
}






