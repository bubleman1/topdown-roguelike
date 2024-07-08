using Godot;
using System;

public partial class TripleFireballRes : Projectile
{
	public TripleFireballRes() : base()
	{
		spellNode = (PackedScene)GD.Load("res://Scenes/Nodes/TripleFireball.tscn");
		Spell = spellNode.Instantiate<TripleFireball>();
	}

	public override TripleFireball Instantiate()
	{
		return base.Instantiate<TripleFireball>();
	}
}
