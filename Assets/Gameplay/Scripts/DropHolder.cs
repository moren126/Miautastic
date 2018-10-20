using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class DropHolder : MonoBehaviour {

	//private GameplayPrefabs gameplayPrefabs;

	private List<GameObject> dropList = new List<GameObject>();

	#region Properties
	public int GetDropCount {
		get { return dropList.Count; }
	}
	#endregion

	#region Public Methods 
	public void AddDrop(GameObject drop) {
		dropList.Add (drop);
	}

	public void ActivateDrops() {
		foreach (var g in dropList)
			g.GetComponent<MovementDrop> ().IsActivated = true;
	}
	#endregion



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
