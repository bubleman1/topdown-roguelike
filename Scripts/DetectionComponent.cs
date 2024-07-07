using Godot;
using System;

public partial class DetectionComponent : Area2D
{
	public Node2D Player {get; set;}
	private void _on_body_entered(Node2D body)
	{
		if(body.IsInGroup("player")){
			Player = body;
		}
		
	}
	private void _on_body_exited(Node2D body)
	{
		if(body.IsInGroup("player")){
			Player = null;
		}
		
	}
}







