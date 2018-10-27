using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Miautastic.Gameplay {

	public class CatHolder : MonoBehaviour {

		private static List<GameObject> catsList = new List<GameObject> ();

		public static int GetCatsList {
			get { return catsList.Count; }
		}

		void Start () {
			int cats = transform.childCount;
			for (int i = 0; i < cats; i++) {
				catsList.Add (transform.GetChild(i).gameObject);
			}
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

		//temporary
		public static GameObject DCP(int number) {
			return CatHolder.catsList [number];
		}

	}

}
