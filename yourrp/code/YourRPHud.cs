using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace YourRPExample
{
	public partial class YourRPHudEntity : Sandbox.HudEntity<RootPanel>
	{
		public YourRPHudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "/YourRPHud.html" );

				RootPanel.AddChild<Health>();
				RootPanel.AddChild<Armor>();
			}
		}
	}

	public class Health : Panel
	{
		public Label Label;

		public Health()
		{
			Add.Label( "🩸", "icon" );
			Label = Add.Label( "100", "value" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;

			Label.Text = $"{player.Health:n0}";
		}
	}

	public class Armor : Panel
	{
		public Label Label;

		public Armor()
		{
			Add.Label( "🛡", "icon" );
			Label = Add.Label( "100", "value" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;

			var rpplayer = (RPPlayer)player; // Cast to RPPlayer
			if ( player == null ) return;

			Label.Text = $"{rpplayer.Armor:n0}";
		}
	}
}
