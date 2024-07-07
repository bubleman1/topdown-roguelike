using Godot;
using System;

public partial class Fireball : Area2D
{

	[Export]
	public float Speed { get; set; } = 900;
	[Export]
	public float Damage { get; set; } = 50;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		BodyEntered += _on_body_entered;
		AreaEntered += _on_area_entered;

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
	
	protected virtual void _on_body_entered(Node2D body)
	{

		if(!body.IsInGroup("player"))
		{
			QueueFree();
		}
	}
	protected virtual void _on_area_entered(Area2D area)
	{
		if (area.IsInGroup("enemy"))
		{
			QueueFree();
		}
	}
}









