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
			hpbackground =	Add.Panel( "background_armor" );
			hpbar =			Add.Panel( "bar_armor" );
			Add.Label( "🩸", "icon" );
			hptext = Add.Label( "100", "value" );

			hpbackground.Style.Width = Screen.Width * 0.1f;
			hpbackground.Style.Dirty();
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			float width = 0.0f;
			float height = Screen.Height * 0.02f; 
			float barwidth = Screen.Width * 0.1f - (2 * height);
			var text = "0";
			width = height;
			if ( player != null)
			{
				width = height + barwidth * player.Health / 100 + height;
				text = $"{player.Health:n0}";
			}
			hptext.Text = text;
			hpbar.Style.Width = width;
			hpbar.Style.Dirty();
		}
	}

	public class Armor : Panel
	{
		public Label artext;
		public Panel arbackground;
		public Panel arbar;

		public Armor()
		{
			arbackground = Add.Panel( "background_armor" );
			arbar = Add.Panel( "bar_armor" );
			Add.Label( "🛡", "icon" );
			artext = Add.Label( "100", "value" );

			arbackground.Style.Width = Screen.Width * 0.1f;
			arbackground.Style.Dirty();
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			float width = 0.0f;
			float height = Screen.Height * 0.02f;
			float barwidth = Screen.Width * 0.1f - (2 * height);
			var text = "0";
			width = height;
			if ( player != null )
			{
				var rpplayer = (RPPlayer)player;
				if ( rpplayer != null )
				{
					width = height + barwidth * rpplayer.Armor / 100 + height;
					text = $"{rpplayer.Armor:n0}";
				}
			}
			artext.Text = text;
			arbar.Style.Width = width;
			arbar.Style.Dirty();
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
