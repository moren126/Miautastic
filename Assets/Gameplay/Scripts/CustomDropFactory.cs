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
			return container.InstantiatePrefabResourceForComponent<Drop> ("Prefabs/DropNormal", new object[] {position});
		}

	}

}
