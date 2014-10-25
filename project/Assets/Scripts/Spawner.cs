using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    Player _player;
	
    public void spawnPlayer(int num)
    {
		GameObject ob = (GameObject)Instantiate(Resources.Load("Prefabs/GenericPlayer"));
        _player = ob.GetComponent<Player>();
        _player.setSpawner(this);
        _player.setNum(num);
        respawn();
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void respawn()
    {
        _player.gameObject.transform.position = this.transform.position;
    }
}
