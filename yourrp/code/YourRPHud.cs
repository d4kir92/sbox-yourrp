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
		public Label hptext;
		public Panel hpbackground; 
		public Panel hpbar;

		public Health()
		{
			hptext =		Add.Label( "100", "value" );
			hpbackground =	Add.Panel( "background_health" );
			hpbar =			Add.Panel( "bar_health" );
			Add.Label( "🩸", "icon" );

			hpbackground.Style.Width = Screen.Width * 0.1f;
			hpbackground.Style.Dirty();
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			float width = 0.0f;
			var text = "0";
			if ( player != null )
			{
				width = Screen.Width * 0.1f * player.Health / 100;
				text = $"{player.Health:n0}";
			}
			hptext.Text = text;
			hpbar.Style.Width = width;
			hpbar.Style.Dirty();
		}
	}

	public class Armor : Panel
	{
		public Label ARText;
		public Panel ARBar;

		public Armor()
		{
			ARText = Add.Label( "100", "value" );
			ARBar = Add.Panel( "armorbar" );
			Add.Label( "🛡", "icon" );
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
