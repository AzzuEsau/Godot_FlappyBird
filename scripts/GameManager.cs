using Godot;
using System;

public partial class GameManager : Node {
	#region Variables
		Timer timer;
		PackedScene obstacle = (PackedScene)ResourceLoader.Load("res://resources/prefabs/environment/Obstacle.tscn");
	#endregion

	#region Godot Methods
		// Called when the node enters the scene tree for the first time.
		public override void _Ready() {
			timer = GetNode<Timer>("ObstacleTimer");
			timer.Timeout += CreateObstacleOnTimer;
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta) {
		}
	#endregion

	#region Events
		private void CreateObstacleOnTimer() {
			Node instantiate = obstacle.Instantiate();
			AddChild(instantiate);
		}
	#endregion
}
