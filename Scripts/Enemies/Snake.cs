using Godot;
using System;

public partial class Snake : CharacterBody2D
{
	[Export]
	public VelocityComponent velocityComponent {get;set;}
	[Export]
	public HurtboxComponent hurtboxComponent {get;set;}
	[Export]
	public DetectionComponent detectionComponent {get;set;}
	[Export]
	public AnimatedSprite2D animatedSprite {get;set;}
	
	public override void _Ready(){
		hurtboxComponent.Dead+= OnDead;
	}
	
	public override void _Process(double delta){
		velocityComponent.Velocity = Vector2.Zero;
		if(detectionComponent.Player!=null){
			animatedSprite.Play("Snake Move");
			velocityComponent.GoTo(detectionComponent.Player.Position);
		}
		else
		{
			velocityComponent.Stop();
			animatedSprite.Play("Snake Idle");
		}
		velocityComponent.ProcessVelocity();
		if(velocityComponent.Velocity.X - velocityComponent.Knockback.X > 0){
			animatedSprite.FlipH = false;
		}
		else if(velocityComponent.Velocity.X - velocityComponent.Knockback.X < 0){
			animatedSprite.FlipH = true;
		}
		velocityComponent.ProcessKnockback();
		GD.Print(velocityComponent.Knockback);
		MoveAndCollide(velocityComponent.Velocity * (float)delta);
	}
	public void OnDead(){
		QueueFree();
	}
}
