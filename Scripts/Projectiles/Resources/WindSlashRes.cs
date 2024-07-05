using Godot;
using System;

public partial class WindSlashRes : Projectile
{
	public WindSlashRes() : base(){
		spellNode = (PackedScene)GD.Load("res://Scenes/Nodes/WindSlashProjectile.tscn");
		Spell = spellNode.Instantiate<Fireball>();
		Cooldown = 0.5f;
	}

	public override void Instantiate()
	{
		base.Instantiate<Fireball>();
	}
}
