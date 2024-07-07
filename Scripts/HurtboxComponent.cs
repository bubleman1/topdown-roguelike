using Godot;
using System;

public partial class HurtboxComponent : Area2D
{
	[Signal]
	public delegate void DeadEventHandler();
	
	[Export]
	public HealthComponent healthComponent {get;set;}
	
	[Export]
	public VelocityComponent velocityComponent {get; set;}
	
	public override void _Ready()
	{
		if(Owner.IsInGroup("enemy"))
		{
			AreaEntered += _enemy_on_area_entered;
		}
		else if(Owner.IsInGroup("player"))
		{	
			AreaEntered += _player_on_area_entered;
		}
	}
	
	public string DeadSignalName
	{
		get{
			return SignalName.Dead;
		}		
	}
	
	public void IsDead()
	{
		if(healthComponent.Health<=0)
		{
			EmitSignal(SignalName.Dead);
		}
	}
	private float GetEnemyDamage(Node node)
	{
		return node.GetNode<DamageComponent>("DamageComponent").Damage;
	}
	
	private Vector2 GetEnemyKnockback(Node node)
	{
		float knockbackCoeff = node.GetNode<DamageComponent>("DamageComponent").KnockbackCoeff;
		Vector2 knockbackVector = node.GetNode<VelocityComponent>("VelocityComponent").Velocity;
		return knockbackCoeff * knockbackVector;
	}
	
	public void _player_on_area_entered(Area2D area)
	{
		if(area.IsInGroup("enemy"))
		{
			healthComponent.TakeDamage(GetEnemyDamage(area.Owner));
			velocityComponent.Knockback = GetEnemyKnockback(area.Owner);
			IsDead();
		}
	}
	
	public void _enemy_on_area_entered(Area2D area)
	{
		if(area.IsInGroup("projectile"))
		{
			healthComponent.TakeDamage(GetEnemyDamage(area));
			IsDead();
		}
		if(area.IsInGroup("player"))
		{
			velocityComponent.KnockbackSelf();
		}
	}
}
