using Godot;
using System;

public partial class fireball : Area2D
{

	[Export]
	public float Speed { get; set; } = 900;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (!IsConnected("body_entered", new Callable(this, nameof(_on_body_entered))))
		{
			Connect("body_entered", new Callable(this, nameof(_on_body_entered)));
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += Transform.X * Speed * (float)delta;

	}

	private void _on_body_entered(Node2D body)
	{
			if (body.IsInGroup("enemy"))
			{
				GD.Print("hit");
				body.QueueFree();
				QueueFree();
			}
			if(!body.IsInGroup("player"))
			{
				QueueFree();
			}
			
	}
}






