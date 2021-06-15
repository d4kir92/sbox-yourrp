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
				RootPanel.AddChild<Role>();
			}
		}
	}

	public class Health : Panel
	{
		public Label HPText;
		public Panel HPBar;

		public Health()
		{
			Add.Label( "🩸", "icon" );
			HPText = Add.Label( "100", "value" );
			HPBar = Add.Panel( "healthbar" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;

			HPText.Text = $"{player.Health:n0}";

			var width = 200 * player.Health / 100;
			HPBar.Style.Width = width;
			HPBar.Style.Dirty();
		}
	}

	public class Armor : Panel
	{
		public Label ARText;
		public Panel ARBar;

		public Armor()
		{
			Add.Label( "🛡", "icon" );
			ARText = Add.Label( "100", "value" );
			ARBar = Add.Panel( "armorbar" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;

			var rpplayer = (RPPlayer)player; // Cast to RPPlayer
			if ( player == null ) return;

			ARText.Text = $"{rpplayer.Armor:n0}";

			var width = 200 * rpplayer.Armor / 100;
			ARBar.Style.Width = width;
			ARBar.Style.Dirty();
		}
	}

	public class Role : Panel
	{
		public Label ROText;
		public Panel ROBar;

		public Role()
		{
			Add.Label( "🎭", "icon" );
			ROText = Add.Label( "Citizen", "value" );
			ROBar = Add.Panel( "rolebar" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;

			var rpplayer = (RPPlayer)player; // Cast to RPPlayer
			if ( player == null ) return;

			ROText.Text = $"{rpplayer.Role}";

			var width = 200;
			ROBar.Style.Width = width;
			ROBar.Style.Dirty();
		}
	}
}
