using Godot;
using System;

public partial class HitboxComponent : Node2D
{
	[Signal]
	public delegate void HasHitEventHandler();
	public virtual void _on_body_entered(Node2D body)
	{
		if(!body.IsInGroup("player"))
		{
			EmitSignal(SignalName.HasHit);
		}
	}
	public virtual void _on_area_entered(Area2D area)
	{
		if (area.IsInGroup("enemy"))
		{
			EmitSignal(SignalName.HasHit);
		}
	}
}
