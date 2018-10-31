using UnityEngine;
using Zenject;
using TMPro;
using Miautastic.Menu;

namespace Miautastic.Menu.UI {

	public class StateChangeManager : MonoBehaviour {

		[SerializeField] private GameObject buttons;
		[SerializeField] private GameObject texts; 
		[SerializeField] private TextMeshProUGUI fakeText;

		[Inject]
		readonly GameManager gameManager;


		//activate == true (activate buttons), activate == false (deactivate buttons)
		private void ActivateButtons(bool activate) {
			buttons.SetActive (activate);
		}

		private void ActivateTexts(bool activate) {
			texts.SetActive (activate);
		}

		private void ShowText(string msg) {
			ActivateTexts(true);
			ActivateButtons (false);

			texts.GetComponentInChildren<TextMeshProUGUI> ().text = msg;
		}

		private void HideText() {
			ActivateTexts(false);
			ActivateButtons (true);

			texts.GetComponentInChildren<TextMeshProUGUI> ().text = string.Empty;
		}

		#region Public Methods
		public void ChangeToPlay() {
			gameManager.ChangeState (MenuState.PLAY, true);
		}

		public void ChangeToHelp() {
			ShowText("Remove dead mice by left mouse button. Make sure there are not too many of them. You can also click cats to change their course.");
			gameManager.ChangeState (MenuState.HELP);
		}

		public void ChangeToCredits() {
			ShowText ("Music used:\n'Tropical Nature of Tiaso' by Umanzuki licensed under\nCC BY-NC-ND 4.0"); 
			gameManager.ChangeState (MenuState.CREDITS);
		}

		public void ChangeToExit() {
			gameManager.ChangeState (MenuState.EXIT, true);
		}

		public void OKButton() {
			gameManager.ChangeState (MenuState.PLAY);
			HideText ();
		}

		public void FakeText(bool show) {
			if (show)
				fakeText.gameObject.SetActive (true);
			else 
				fakeText.gameObject.SetActive (false);
		}
		#endregion
	}

}
