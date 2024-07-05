using Godot;
using System;

public partial class SparkRes : Projectile
{
	public SparkRes() : base(){
		spellNode = (PackedScene)GD.Load("res://Scenes/Nodes/SparkProjectile.tscn");
		Spell = spellNode.Instantiate<Spark>();
		Cooldown = 0.3f;	
	}

	public override void Instantiate()
	{
		base.Instantiate<Spark>();
	}
}
