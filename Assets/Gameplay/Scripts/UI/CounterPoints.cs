using System.Collections;
using UnityEngine;
using TMPro;

namespace Miautastic.Gameplay.UI {

	public class CounterPoints : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI valueCurrentText;
		[SerializeField] private TextMeshProUGUI valueMaxText;

		void Start () {
			valueCurrentText.text = 0.ToString();

			if (PlayerPrefs.GetInt ("highscore") != 0) {
				valueMaxText.text = PlayerPrefs.GetInt ("highscore").ToString ();
			}
		}

		void Update () {
			valueCurrentText.text = GameplayManager.Instance.DropHolder.GetPoints.ToString();
		}
	}

}
