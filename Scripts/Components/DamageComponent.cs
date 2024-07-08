using Godot;
using System;

public partial class DamageComponent : Node2D
{
	[Export]
	public float Damage {get; set;} = 15;
	
	[Export]
	public float KnockbackCoeff {get;set;} = 5;
}
