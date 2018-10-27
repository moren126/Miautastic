using ModestTree;
using Miautastic.Menu.States;

namespace Miautastic.Menu {

	internal enum MenuState { PLAY, HELP, CREDITS, EXIT }

	public class GameStateFactory {

		readonly PlayState.Factory playFactory;
		readonly HelpState.Factory helpFactory;
		readonly CreditsState.Factory creditsFactory;
		readonly ExitState.Factory exitFactory;

		public GameStateFactory(PlayState.Factory playFactory, 
			HelpState.Factory helpFactory,
			CreditsState.Factory creditsFactory,
			ExitState.Factory exitFactory) {

			this.playFactory = playFactory;
			this.helpFactory = helpFactory;
			this.creditsFactory = creditsFactory;
			this.exitFactory = exitFactory;
		}

		internal MenuStateEntity CreateState(MenuState gameState) {
			switch (gameState) {
			case MenuState.PLAY:
				return playFactory.Create ();
			case MenuState.HELP:
				return helpFactory.Create ();
			case MenuState.CREDITS:
				return creditsFactory.Create ();
			case MenuState.EXIT:
				return exitFactory.Create ();
			}

			throw Assert.CreateException ("Code should not be reached");
		}

	}

}
