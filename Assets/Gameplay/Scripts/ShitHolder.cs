using System.Collections;
using UnityEngine;
using Zenject;

public class ShitHolder : MonoBehaviour {

	private GameplayPrefabs gameplayPrefabs;

	/*
	[Inject]
	private void Construct (GameplayPrefabs _gameplayPrefabs) {
		gameplayPrefabs = _gameplayPrefabs;
	}

	public void CreateShit(Vector2 position) {
		GameObject shit = (GameObject)Instantiate (gameplayPrefabs.NormalShitPrefab, transform.position, Quaternion.identity);
		shit.transform.SetParent (this.transform, true);
		shit.GetComponent<RectTransform> ().anchoredPosition = position;
		shit.transform.localScale = new Vector3(1f, 1f);
	}
	*/

}
