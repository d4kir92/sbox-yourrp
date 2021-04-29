
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

namespace YourRP
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

		public override Player CreatePlayer()
		{
			return new YourRPPlayer();
		}
	}

}
