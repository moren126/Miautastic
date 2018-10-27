using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Miautastic.Gameplay {

	public class DropHolder : MonoBehaviour {

		[SerializeField] private const int pointValue = 5;
		private int points;

		private List<GameObject> dropList = new List<GameObject>();
		private List<GameObject> dropClickedList = new List<GameObject> ();

		#region Properties
		public int GetPoints {
			get { return points; }
		}

		public int GetDropCount {
			get { return dropList.Count; }
		}

		public int GetDropClickedCount {
			get { return dropClickedList.Count; }
		}
		#endregion

		void Start() {
			points = 0;
		}

		#region Public Methods 
		public void AddDrop(GameObject drop) {
			dropList.Add (drop);
		}

		public void AddDropPooling(Vector2 position) {
			if (dropClickedList.Count != 0) {
				dropClickedList [0].SetActive (true);
				dropClickedList [0].GetComponent<RectTransform> ().anchoredPosition = position;

				dropList.Add (dropClickedList [0]);

				dropClickedList.RemoveAt (0);
			} else
				Debug.Log ("dropClickedList is empty, it shouldn't be");
		}

		public void RemoveDrop(GameObject drop) {
			dropList.Remove (drop);
			dropClickedList.Add (drop);

			points += pointValue;
		}

		public void ActivateDrops() {
			foreach (var g in dropList)
				g.GetComponent<Drop> ().IsActivated = true;
		}
		#endregion

	}

}
