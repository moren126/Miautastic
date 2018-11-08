using UnityEngine;

public class GameplayPrefabs : MonoBehaviour {

	[SerializeField] private GameObject dropPrefab;

	public GameObject DropPrefab {
		get { return dropPrefab; }
	}

}
