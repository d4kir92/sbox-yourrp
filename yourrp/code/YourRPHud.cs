using Sandbox.UI;

namespace YourRPExample
{
	public partial class YourRPHudEntity : Sandbox.Hud
	{
		public YourRPHudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "/YourRPHud.html" );
			}
		}
	}

}
