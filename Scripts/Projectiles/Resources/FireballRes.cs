using Godot;
using System;

public partial class FireballRes : Projectile
{
	public FireballRes() : base(){
		spellNode = (PackedScene)GD.Load("res://Scenes/Nodes/FireballProjectile.tscn");
		Spell = spellNode.Instantiate<Fireball>();
	}

	public override void Instantiate()
	{
		base.Instantiate<Fireball>();
	}
}
