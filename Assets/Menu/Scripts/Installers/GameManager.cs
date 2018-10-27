using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Miautastic.Menu.States;

namespace Miautastic.Menu {

	public class GameManager : MonoBehaviour {

		[SerializeField]
		private MenuState currentGameState;
		[SerializeField]
		private MenuState previousGameState;

		private GameStateFactory gameStateFactory;
		private MenuStateEntity gameStateEntity = null;

		[Inject]
		public void Construct(GameStateFactory gameStateFactory) {
			this.gameStateFactory = gameStateFactory;
		}
			
		private void Start () {
			ChangeState (MenuState.PLAY);
		}
		
		internal void ChangeState(MenuState gameState, bool wasClick = false) {

			if (wasClick) {

				if (gameStateEntity != null) {
					gameStateEntity.Dispose ();
					gameStateEntity = null;
				}

				previousGameState = currentGameState;
				currentGameState = gameState;

				gameStateEntity = gameStateFactory.CreateState (gameState);
				gameStateEntity.Start ();

			}
		}
	}

}
