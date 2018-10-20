using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHolder : MonoBehaviour {

	private static List<GameObject> catsList = new List<GameObject> ();

	public static int GetCatsList {
		get { return catsList.Count; }
	}

	//private static int iterator;

	void Start () {
		int cats = transform.childCount;
		for (int i = 0; i < cats; i++) {
			catsList.Add (transform.GetChild(i).gameObject);
		}

		//iterator = -1;
	}

	void Update () {
		
	}


	public List<Vector2> GetCatsPositions() {

		List<Vector2> catsPositions = new List<Vector2> ();
		foreach (var c in catsList)
			catsPositions.Add (c.GetComponent<Rigidbody2D>().position);

		return catsPositions;
	}

	public Vector2 DrawCatsPosition() {
		int number = Random.Range (0, catsList.Count);

		return catsList [number].GetComponent<Rigidbody2D> ().position;
	}

	//temp
	public static GameObject DCP(int number) {
		//int number = Random.Range (0, CatHolder.catsList.Count);

		//iterator++;
		//if (iterator >= CatHolder.catsList.Count) {
		//	iterator = 0;
		//}

		return CatHolder.catsList [number];
	}

}
