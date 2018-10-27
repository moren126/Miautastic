using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Miautastic.UI {

	public class UIManagerEndScreen : UIManager {

		public void PlayAgain() {
			SceneManager.LoadScene ("gameplay");
		}

	}

}
