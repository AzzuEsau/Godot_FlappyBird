using Godot;
using System;

public partial class Obstacle : Node2D {
	#region Variables
		RandomNumberGenerator random = new RandomNumberGenerator();
		float speed = 150;

		Area2D tuberiaTop;
		Area2D tuberiaButtom;

		Area2D scoreArea;
	#endregion

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Position = new Vector2(this.Position.X, random.RandfRange(130F, 410F));
		tuberiaTop = GetChild<Area2D>(0);
		tuberiaButtom = GetChild<Area2D>(1);
		scoreArea = GetChild<Area2D>(2);

		tuberiaTop.BodyEntered += OnCrash;
		tuberiaButtom.BodyEntered += OnCrash;

		scoreArea.BodyEntered += OnScore;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		Position = new Vector2((float)(this.Position.X - speed * delta), this.Position.Y);

		if(Position.X <= -100)
			CallDeferred("queue_free");
			// QueueFree();
	}


	#region Events
		private void OnCrash(Node2D body) {
			if(body.IsInGroup("Player")) {
				((Player)body).Death();
			}
		}

		private void OnScore(Node2D body) {
			if(body.IsInGroup("Player")) {
				((Player)body).IncreaseScore();
			}
		}
	#endregion
}
