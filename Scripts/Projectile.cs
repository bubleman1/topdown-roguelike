using Godot;
using System;

public partial class Projectile : Resource
{
	public Projectile()
	{
		Cooldown = 1;
		TimeLeft = 0;
		CanShoot = false;
	}
	[Export]
	public PackedScene Spell {get;set;}
	public Area2D Area { get;set;}
	[Export]
	public float Cooldown { get; set; }
	public float TimeLeft { get; set; } 
	public bool CanShoot { get; set; }
	public void ManageTime(double delta)
	{
		TimeLeft -= (float)delta;
		if (TimeLeft <= 0)
		{
			CanShoot = true;
		}
	}

	public void PutOnCooldown()
	{
		TimeLeft = Cooldown;
		CanShoot = false;
	}
}
