using Godot;
using System;

public partial class Player : RigidBody2D {
	#region Variables
		private int speed = -400;
		AnimatedSprite2D animator;
	#endregion

	#region Godot Functions
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()  {
			animator = GetNode<AnimatedSprite2D>("AnimatedPlayer");
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta) {
			Jump(true);
		}	
	#endregion

	#region Player Movement
		private void Jump(bool state) {
			if(Input.IsActionJustPressed("ui_accept")) {
				LinearVelocity = Vector2.Zero;
				ApplyCentralImpulse(new Vector2(0, speed));
				animator.Play("flap");
			}
		}
	#endregion
}