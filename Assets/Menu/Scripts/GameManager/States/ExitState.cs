using UnityEngine;
using Zenject;


namespace Miautastic.Menu.States {

	public class ExitState : MenuStateEntity {

		public override void Initialize() {

		}

		public override void Start() {
			Application.Quit ();
		}

		public override void Tick() {
			
		}

		public override void Dispose() {

		}

		public class Factory : Factory<ExitState> {}

	}

}
