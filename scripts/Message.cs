using Godot;
using System;

public partial class Message : Sprite2D {
	#region Variables
	#endregion

	#region Godot Methods
		// Called when the node enters the scene tree for the first time.
		public override void _Ready() {
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta) {
		}


		public override void _Input(InputEvent @event) {
			if(Input.IsActionJustPressed("ui_accept") && GetTree().Paused) {
				GetTree().Paused = false;
				GetTree().ReloadCurrentScene();
			}
		}
	#endregion

	#region Events
	#endregion
}
