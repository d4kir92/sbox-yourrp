using Sandbox;
using System;
using System.Linq;

namespace YourRPExample
{
	public class YourRPCamera : Camera
	{
		[ConVar.Replicated]
		public static bool thirdperson_orbit { get; set; } = false;

		[ConVar.Replicated]
		public static bool thirdperson_collision { get; set; } = true;

		private Angles orbitAngles;
		private float orbitDistance = 1000;

		public override void Update()
		{
			var pawn = Local.Pawn as AnimEntity;
			var client = Local.Client;

			if ( pawn == null )
				return;

			Position = pawn.Position;
			Vector3 targetPos;

			var center = pawn.Position + Vector3.Up * 64;

			if ( thirdperson_orbit )
			{
				Position += Vector3.Up * (pawn.CollisionBounds.Center.z * pawn.Scale);
				Rotation = Rotation.From( orbitAngles );

				targetPos = Position + Rotation.Backward * orbitDistance;
			}
			else
			{
				Position = center;
				Rotation = Input.Rotation; // Rotation.FromAxis( Vector3.Up, 0 ) * Input.Rotation

				float distance = 150.0f * pawn.Scale;
				targetPos = Position; //+ Input.Rotation.Right * ((pawn.CollisionBounds.Maxs.x + 15) * pawn.Scale);
				targetPos += Input.Rotation.Forward * -distance;
			}

			if ( thirdperson_collision )
			{
				var tr = Trace.Ray(Position, targetPos )
					.Ignore( pawn )
					.Radius( 8 )
					.Run();

				Position = tr.EndPos;
			}
			else
			{
				Position = targetPos;
			}

			FieldOfView = 90;

			Viewer = null;
		}

		public override void BuildInput( InputBuilder input )
		{
			if ( thirdperson_orbit && input.Down( InputButton.Walk ) )
			{
				if ( input.Down( InputButton.Attack1 ) )
				{
					orbitDistance += input.AnalogLook.pitch;
					orbitDistance = orbitDistance.Clamp( 0, 1000 );
				}
				else
				{
					orbitAngles.yaw += input.AnalogLook.yaw;
					orbitAngles.pitch += input.AnalogLook.pitch;
					orbitAngles = orbitAngles.Normal;
					//orbitAngles.pitch = orbitAngles.pitch.Clamp( -89, 89 );
				}

				input.AnalogLook = Angles.Zero;

				input.Clear();
				input.StopProcessing = true;
			}

			base.BuildInput( input );
		}
	}
}
