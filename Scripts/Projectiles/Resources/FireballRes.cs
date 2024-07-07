using Godot;
using System;

public partial class FireballRes : Projectile
{
	public FireballRes() : base(){
		spellNode = (PackedScene)GD.Load("res://Scenes/Nodes/FireballProjectile.tscn");
		Spell = spellNode.Instantiate<Fireball>();
		Cooldown = 0.3f;
	}

	public override Fireball Instantiate()
	{
		return base.Instantiate<Fireball>();
	}
}
