using UnityEngine;

public class GameplayPrefabs : MonoBehaviour {

	[SerializeField] private GameObject catPrefab;
	[SerializeField] private GameObject normalShitPrefab;

	public GameObject CatPrefab {
		get { return catPrefab; }
	}

	public GameObject NormalShitPrefab {
		get { return normalShitPrefab; }
	}
}
