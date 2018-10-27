using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Miautastic.Menu.States {

	public class PlayState : MenuStateEntity {

		public override void Initialize() {

		}

		public override void Start() {
			SceneManager.LoadScene ("gameplay");
		}

		public override void Tick() {
			
		}

		public override void Dispose() {
			
		}

		public class Factory : Factory<PlayState> {}

	}

}
