using Godot;
using System;

public partial class SparkRes : Projectile
{
	public SparkRes() : base(){
		spellNode = (PackedScene)GD.Load("res://Scenes/Nodes/SparkProjectile.tscn");
		Spell = spellNode.Instantiate<Spark>();
		Cooldown = 0.3f;	
	}

	public override Spark Instantiate()
	{
		return base.Instantiate<Spark>();
	}
}
