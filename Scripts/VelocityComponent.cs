using Godot;
using System;

public partial class VelocityComponent : Node
{
	[Export]
	public float Speed { get; set; } = 400;
	[Export]
	public float SelfKnockbackCoeff {get; set;} = 5;
	public Vector2 Velocity = Vector2.Zero;
	public Vector2 Knockback {get; set; } = Vector2.Zero;
	
	public void ProcessVelocity()
	{
		Velocity = Velocity.Normalized() * Speed + Knockback;
	}
	
	public void ProcessKnockback()
	{
		Knockback  = Knockback.Lerp(Vector2.Zero, 0.1f);
	}
	
	public void GoTo(Vector2 pos)
	{
		Node2D Owner2D = (Node2D)Owner;
		Velocity.X = pos.X - Owner2D.Position.X;
		Velocity.Y = pos.Y - Owner2D.Position.Y;
	}
	
	public void KnockbackSelf(){
		Knockback = -Velocity*SelfKnockbackCoeff;
	}
}
