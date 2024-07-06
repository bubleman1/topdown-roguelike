using Godot;
using System;

public partial class Fireball : Area2D
{

	[Export]
	public float Speed { get; set; } = 900;
	[Export]
	public float Damage { get; set; } = 10;

	[Signal]
	public delegate void HasHitEnemyEventHandler(CharacterBody2D body);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += _on_body_entered;
		AreaEntered += Fireball_AreaEntered;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProcessMovement(delta);
	}

	public virtual void ProcessMovement(double delta)
	{
		Position += Transform.X * Speed * (float)delta;
	}
	
	private void _on_body_entered(Node2D body)
	{
		if(!body.IsInGroup("player"))
		{
			GD.Print("hit wall");
			QueueFree();
		}
	}
	private void Fireball_AreaEntered(Area2D area)
	{
		if (area.IsInGroup("enemy"))
		{
			GDScript slime = GD.Load<GDScript>("res://Scripts/Enemies/Slime/Slime.gd");
			GodotObject SlimeGD = (GodotObject)slime.New();
			Signal HasBeenHit = (Signal)SlimeGD.Get("has_been_hit");
			SlimeGD.EmitSignal(HasBeenHit.Name, Damage, area);
			GD.Print("hit");
			QueueFree();
		}
	}
}









