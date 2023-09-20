using Godot;
using System;

public partial class Player : RigidBody2D {
	#region Variables
		private int speed = -350;
		private int score = 0;
		AnimatedSprite2D animator;
		Area2D collisionArea;
	#endregion

	#region Godot Functions
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()  {
			animator = GetNode<AnimatedSprite2D>("AnimatedPlayer");
			collisionArea = GetNode<Area2D>("Area2D");
			collisionArea.BodyEntered += CollisionArea_BodyEntered;
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

	#region Player Life
		private void CollisionArea_BodyEntered(Node2D body) {
			if(body.IsInGroup("Obstacle")) {
				Death();
			}
		}

		public void Death() {
			GetTree().Paused = true;
			GetParent().GetNode<Sprite2D>("Message").Show();
			// GetTree().ReloadCurrentScene();
		}

		public void IncreaseScore() {
			score++;
			GetParent().GetChild<Label>(0).Text = score.ToString();
		}
	#endregion
}