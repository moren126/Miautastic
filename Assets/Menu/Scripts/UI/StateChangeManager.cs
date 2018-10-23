using UnityEngine;
using Zenject;
using TMPro;
using FSM.GameManager;

namespace UI {

	public class StateChangeManager : MonoBehaviour {

		[SerializeField] private GameObject buttons;
		[SerializeField] private GameObject texts; 

		[Inject]
		readonly GameManager _gameManager;


		//activate == true (activate buttons), activate == false (deactivate buttons)
		private void ActivateButtons(bool activate) {
			buttons.SetActive (activate);
		}

		private void ActivateTexts(bool activate) {
			texts.SetActive (activate);
		}

		public void ShowText(string msg) {
			ActivateTexts(true);
			ActivateButtons (false);

			texts.GetComponentInChildren<TextMeshProUGUI> ().text = msg;
		}

		public void HideText() {
			ActivateTexts(false);
			ActivateButtons (true);

			texts.GetComponentInChildren<TextMeshProUGUI> ().text = string.Empty;
		}

		public void OKButton() {
			_gameManager.ChangeState (GameState.Menu);
			HideText ();
		}


		public void ChangeToMenu() {
			_gameManager.ChangeState (GameState.Menu, true);
		}

		public void ChangeToGameplay() {
			ShowText("Remove dead mice by left mouse button. Make sure there are not too many of them.");
			_gameManager.ChangeState (GameState.Gameplay);
		}

		public void ChangeToGameOver() {
			ShowText ("Music used:\n'Tropical Nature of Tiaso' by Umanzuki licensed under\nCC BY-NC-ND 4.0"); 
			_gameManager.ChangeState (GameState.GameOver);
		}

		public void ChangeToVictory() {
			Application.Quit ();
			//_gameManager.ChangeState (GameState.Victory);
		}

	}

}
