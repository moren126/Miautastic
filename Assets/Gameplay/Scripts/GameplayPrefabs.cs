using UnityEngine;

public class GameplayPrefabs : MonoBehaviour {

	[SerializeField] private GameObject catPrefab;
	[SerializeField] private GameObject normalDropPrefab;

	public GameObject CatPrefab {
		get { return catPrefab; }
	}

	public GameObject NormalDropPrefab {
		get { return normalDropPrefab; }
	}
}
