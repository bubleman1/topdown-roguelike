using Godot;
using System;

public partial class Spark : Area2D
{
[Export]
	public VelocityComponent velocityComponent {get; set;} 
	[Export]
	public DamageComponent damageComponent {get; set;} 
	[Export]
	public HitboxComponent hitboxComponent {get;set;}
	//public Godot.CPUParticles2D endParticles {get;set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		velocityComponent = GetNode<VelocityComponent>("VelocityComponent");
		velocityComponent.Speed = 1500;
		damageComponent = GetNode<DamageComponent>("DamageComponent");
		damageComponent.Damage = 20;
		//endParticles = GetNode<CPUParticles2D>("CPUParticles2D2");
		hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");
		BodyEntered += hitboxComponent._on_body_entered;
		AreaEntered += hitboxComponent._on_area_entered;
		hitboxComponent.HasHit += DoParticles;

	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProcessMovement(delta);
	}

	public virtual void ProcessMovement(double delta)
	{
		Position += Transform.X * velocityComponent.Speed * (float)delta;
	}
	
	public void DoParticles(){
		//endParticles.Emmit=true;
		//endParticles.Owner=this.Owner;
		QueueFree();
	}
}






