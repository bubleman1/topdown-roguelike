using Godot;
using System;

public partial class WindSlashRes : Projectile
{
	public WindSlashRes() : base(){
		Spell = (PackedScene)GD.Load("res://Scenes/Nodes/WindSlashProjectile.tscn");
	}
}
