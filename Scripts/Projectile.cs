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

	protected PackedScene spellNode { get; set; }
	public Area2D Spell {get;set;}

	[Export]
	public float Cooldown { get; set; }
	public float TimeLeft { get; set; } 
	public bool CanShoot { get; set; }

	protected virtual T Instantiate<T>() where T : Area2D
	{
		Spell = spellNode.Instantiate<T>();
		return spellNode.Instantiate<T>();
	}

	public virtual Area2D Instantiate()
	{
		return Instantiate<Fireball>();
	}

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
