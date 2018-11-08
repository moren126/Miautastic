using System.Collections;
using UnityEngine;
using TMPro;

namespace Miautastic.Gameplay.UI {

	public class CounterMice : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI titleText;
		[SerializeField] private TextMeshProUGUI valueCurrentText;
		[SerializeField] private TextMeshProUGUI valueMaxText;

		private Color normalColor = new Color32(255, 255, 255, 255);
		private Color warningColor = new Color32(199, 0, 57, 255);

		private int criticalValue;

		void Start () {
			valueCurrentText.text = 0.ToString();
			valueMaxText.text = GameplayManager.Instance.GameOverValue.ToString();

			criticalValue = (int) (0.8 * GameplayManager.Instance.GameOverValue); 

			//protection, because this text element is escaping its position for some reason
			titleText.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-120f, -40f);
		}

		void Update () {
			if (GameplayManager.Instance.DropHolder.GetDropCount >= criticalValue) {
				titleText.color = warningColor;
				valueCurrentText.color = warningColor;
				valueMaxText.color = warningColor;
			} else {
				titleText.color = normalColor;
				valueCurrentText.color = normalColor;
				valueMaxText.color = normalColor;
			}

			valueCurrentText.text = GameplayManager.Instance.DropHolder.GetDropCount.ToString();
		}
	}

}
