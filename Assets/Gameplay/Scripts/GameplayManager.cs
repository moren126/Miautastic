using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayManager : MonoBehaviour {

	//[SerializeField] private GameObject normalShitPrefab;

	[SerializeField] private int gameOverValue = 10;
	[SerializeField] private AudioSource audioSource;

	private GameplayPrefabs gameplayPrefabs;
	private DropHolder dropHolder;

	private State gState;

	public State GState {
		get { return gState; }
	}

	[Inject]
	private void Construct (GameplayPrefabs _gameplayPrefabs, DropHolder _dropHolder) {
		gameplayPrefabs = _gameplayPrefabs;
		dropHolder = _dropHolder;
	}

	private void Start() {
		gState = State.PLAY;
	}

	private Vector2 DrawPosition() {
		return Vector2.zero;
	}

	public void CreateDrop(Vector2 position) {

		if (gState == State.PLAY) {

			GameObject drop = (GameObject)Instantiate (gameplayPrefabs.NormalDropPrefab, transform.position, Quaternion.identity);
			drop.GetComponent<RectTransform> ().SetParent (dropHolder.transform, true);
			drop.GetComponent<RectTransform> ().anchoredPosition = position;
			drop.GetComponent<RectTransform> ().localScale = new Vector3 (4f, 4f);//(0.3f, 0.3f);

			dropHolder.AddDrop (drop);

			if (dropHolder.GetDropCount >= gameOverValue) {
				Debug.Log (dropHolder.GetDropCount);

				gState = State.GAMEOVER;

				dropHolder.ActivateDrops ();

				audioSource.pitch = -0.8f;
				//audioSource.Stop ();
			}

		}
	}

}
