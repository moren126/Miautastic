using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayManager : MonoBehaviour {

	//[SerializeField] private GameObject normalShitPrefab;

	private GameplayPrefabs gameplayPrefabs;
	private ShitHolder shitHolder;

	[Inject]
	private void Construct (GameplayPrefabs _gameplayPrefabs, ShitHolder _shitHolder) {
		gameplayPrefabs = _gameplayPrefabs;
		shitHolder = _shitHolder;
	}

	private void Start() {

	}

	private Vector2 DrawPosition() {
		return Vector2.zero;
	}

	public void CreateShit(Vector2 position) {
		GameObject shit = (GameObject)Instantiate (gameplayPrefabs.NormalShitPrefab, transform.position, Quaternion.identity);
		shit.transform.SetParent (shitHolder.transform, true);
		shit.GetComponent<RectTransform> ().anchoredPosition = position;
		shit.transform.localScale = new Vector3(0.3f, 0.3f);
	}
}
