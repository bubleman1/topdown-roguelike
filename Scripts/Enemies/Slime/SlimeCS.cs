using Godot;
using System;

public partial class SlimeCS : CharacterBody2D
{
	private GodotObject SlimeGD {get; set;}
	public float Health
	{
		get{
			return SlimeGD.Get("Health").As<float>();
		}
		set{
			SlimeGD.Set("Health", value);
		}	
	}
	
	public bool PlayerChase
	{
		get{
			return SlimeGD.Get("player_chase").AsBool();
		}
		set{
			SlimeGD.Set("player_chase", value);
		}	
	}
	
	public float Speed
	{
		get{
			return SlimeGD.Get("speed").As<float>();
		}
		set{
			SlimeGD.Set("speed", value);
		}	
	}
	
	public Node2D Player
	{
		get{
			return SlimeGD.Get("player").As<Node2D>();
		}
		set{
			SlimeGD.Set("player", value);
		}	
	}

	private Area2D DetectionArea { get; set; }

	public override void _Ready()
	{
		GDScript SlimeScript = GD.Load<GDScript>("res://Scripts/Enemies/Slime/Slime.gd");
		DetectionArea = GetNode<Area2D>("detection_area");
		DetectionArea.BodyEntered += OnDetectionAreaEntered;
		DetectionArea.BodyExited += OnDetectionAreaExited;
		SlimeGD = (GodotObject)SlimeScript.New();
		SlimeGD.Set("animatedSprite2D", GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
		SlimeGD.Call("_ready");

	}
	
	public override void _PhysicsProcess(double delta)
	{
		SlimeGD.Call("_physics_process", delta);
		Vector2 SlimeVelocity = new Vector2();
		SlimeVelocity.X = SlimeGD.Get("velocity").As<Vector2>().X;
		SlimeVelocity.Y = SlimeGD.Get("velocity").As<Vector2>().Y;
		Velocity = SlimeVelocity.Normalized() * Speed;
		MoveAndCollide(Velocity * (float)delta);
		GD.Print(Velocity);
	}

	private void OnDetectionAreaEntered(Node2D body)
	{
		SlimeGD.Call("_on_detection_area_body_entered", body);
		
	}

	private void OnDetectionAreaExited(Node2D body)
	{
		SlimeGD.Call("_on_detection_area_body_exited", body);
	}
}
