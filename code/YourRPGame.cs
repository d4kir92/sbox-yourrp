
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

namespace YourRPExample
{
	[Library( "yourrp", Title = "YourRP" )]
	public partial class YourRPGame : Sandbox.Game
	{
		public YourRPGame()
		{
			if ( IsServer )
			{
				Log.Info( "[SV] YourRP Loaded!" );

				new YourRPHudEntity();
			}

			if ( IsClient )
			{
				Log.Info( "[CL] YourRP Loaded!" );
			}
		}

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new RPPlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}
}
