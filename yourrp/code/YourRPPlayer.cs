using Sandbox;
using System;
using System.Linq;

namespace YourRPExample
{
	partial class YourRPPlayer : BasePlayer
	{
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new WalkController();

			Animator = new StandardPlayerAnimator();

			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		protected override void Tick()
		{
			base.Tick();
		}
	}
}
