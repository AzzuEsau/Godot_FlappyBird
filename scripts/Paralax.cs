using Godot;
using System;

public partial class Paralax : ParallaxBackground {
	#region Variables
		private float paralaxVelocity = 100;
	#endregion

	#region Godot Functions
		// Called when the node enters the scene tree for the first time.
		public override void _Ready() {

		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta) {
			ScrollBaseOffset = new Vector2((float)(ScrollBaseOffset.X - paralaxVelocity * delta), ScrollBaseOffset.Y);
		}
	#endregion

}
