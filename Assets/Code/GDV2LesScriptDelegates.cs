using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDV2LesScript : MonoBehaviour {

    public delegate void SomeFunc();

    public SomeFunc spawnDelegate;
    public static event SomeFunc OnDeathEvent;

	void Start () {
        spawnDelegate += SpawnAGoblin;
        spawnDelegate += SpawnAnOgre;
        spawnDelegate -= SpawnAGoblin;
        spawnDelegate = null;
        OnDeathEvent = null;
        spawnDelegate();

        if(OnDeathEvent != null) {
            OnDeathEvent.Invoke();
        }

	}
	

	void Update () {
		
	}

    void SpawnAGoblin() {
        Debug.Log("Spawn Goblin");
    }

    void SpawnAnOgre() {
        Debug.Log("Spawn Ogre");
    }
}

public class SomeClass {
    public SomeClass() {
        //Spawner.OnDeathEvent += PlaySoundOnDeath;

        
    }

    public object Spawner { get; private set; }

    public void PlaySoundOnDeath() {
        Debug.Log("Play death sound");
    }

}