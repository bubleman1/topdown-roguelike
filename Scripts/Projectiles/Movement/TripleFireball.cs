using Godot;
using System;

public partial class TripleFireball : Fireball
{

	[Export]
	public int NumberOfProjectiles { get; set; } = 3;
	public TripleFireball() : base()
	{
		
		Node2D Base = new Node2D();
		for (int i = 0; i < NumberOfProjectiles; i++)
		{
			Fireball fireball = new FireballRes().Instantiate();
			fireball.Position = PolarToCartesian(0, i * 30);
			Base.AddChild(fireball);
		}
	}
	public Vector2 PolarToCartesian(float x, float th)
	{
		Vector2 result = new Vector2();
		result.X = x * (float)Math.Cos(th);
		result.Y = x * (float)Math.Sin(th);
		return result;
	}
}
