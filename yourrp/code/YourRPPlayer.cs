using Sandbox;
using System;
using System.Linq;

namespace YourRPExample
{
	partial class RPPlayer : Player
	{
		[Net, Predicted]
		public float Armor { get; set; }
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new WalkController();

			Animator = new StandardPlayerAnimator();

			Camera = new YourRPCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
			
			base.Respawn();

			Health = 100;
			Armor = 50;
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			SimulateActiveChild( cl, ActiveChild );

			if ( IsServer && Input.Pressed( InputButton.Attack1 ) )
			{
				var ragdoll = new ModelEntity();
				ragdoll.SetModel( "models/citizen/citizen.vmdl" );  
				ragdoll.Position = EyePos + EyeRot.Forward * 40;
				ragdoll.Rotation = Rotation.LookAt( Vector3.Random.Normal );
				ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
				ragdoll.PhysicsGroup.Velocity = EyeRot.Forward * 1000;
			}
		}

		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}
	}

}
