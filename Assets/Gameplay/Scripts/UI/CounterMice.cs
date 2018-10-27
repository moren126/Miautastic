using System.Collections;
using UnityEngine;
using TMPro;

namespace Miautastic.Gameplay.UI {

	public class CounterMice : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI titleText;
		[SerializeField] private TextMeshProUGUI valueText;

		private Color normalColor = new Color32(255, 255, 255, 255);
		private Color warningColor = new Color32(199, 0, 57, 255);

		private int criticalValue;

		void Start () {
			valueText.text = 0.ToString();
			criticalValue = (int) (0.9 * GameplayManager.Instance.GameOverValue); 

			//protection, because this text element is escaping its position for some reason
			titleText.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-270f, -20f);
		}

		void Update () {
			if (GameplayManager.Instance.DropHolder.GetDropCount >= criticalValue) {
				titleText.color = warningColor;
				valueText.color = warningColor;
			} else {
				titleText.color = normalColor;
				valueText.color = normalColor;
			}

			valueText.text = GameplayManager.Instance.DropHolder.GetDropCount.ToString();
		}
	}

}
