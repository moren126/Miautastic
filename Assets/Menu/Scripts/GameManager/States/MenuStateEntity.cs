using System;
using Zenject;

namespace Miautastic.Menu.States {

	public abstract class MenuStateEntity : IInitializable, ITickable, IDisposable {

		public virtual void Initialize() {

		}

		public virtual void Start() {

		}

		public virtual void Tick() {

		}

		public virtual void Dispose() {

		}
	}

}
