using System;
using UnityEngine;
using Zenject;

namespace Miautastic.Gameplay {

	public class CustomDropFactory : IFactory<Vector2, Drop> {

		DiContainer container;

		public CustomDropFactory(DiContainer container) {
			this.container = container;
		}

		public Drop Create(Vector2 position) {
			
			Drop drop = container.InstantiatePrefabResourceForComponent<Drop> ("Prefabs/DropNormal", new object[] {position});

			drop.GetComponent<RectTransform> ().SetParent (GameObject.Find("DropHolder").transform, true);
			drop.GetComponent<RectTransform> ().anchoredPosition = position;
			drop.GetComponent<RectTransform> ().localScale = new Vector3 (4f, 4f);

			return drop;
		}

	}

}
