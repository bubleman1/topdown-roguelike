using Godot;
using System;

public partial class FireballRes : Projectile
{
	public FireballRes() : base(){
		Spell = (PackedScene)GD.Load("res://Scenes/Nodes/FireballProjectile.tscn");
	}
}
