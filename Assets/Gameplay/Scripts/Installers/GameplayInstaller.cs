using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller> {
    
	public override void InstallBindings() {
		Container.Bind<GameplayPrefabs> ().FromComponentInHierarchy ().AsSingle ();
		Container.Bind<GameplayManager> ().FromComponentInHierarchy ().AsSingle();
		Container.Bind<ShitHolder> ().FromComponentInHierarchy ().AsSingle ();

		//Container.Bind<Greeter> ().AsSingle().NonLazy ();
    }


}

/*
public class Greeter {
	public Greeter() {
		Debug.Log ("ELO");
	}
}
*/