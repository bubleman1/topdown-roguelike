using Godot;
using System;

public partial class HealthComponent : Node2D
{
	[Export]
	public float Health { get; set; } = 100;
	
	public void TakeDamage(float damage){
		Health-=damage;
	}
}
