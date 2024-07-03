using Godot;
using System;

public partial class fireball : Area2D
{

	[Export]
	public float Speed { get; set; } = 900;




	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += Transform.X * Speed * (float)delta;

	}

	public void OnBulletBodyEntered(Area2D body)
	{
		if (body.IsInGroup("enemy"))
		{
			body.QueueFree();
		}
		QueueFree();
	}
}
