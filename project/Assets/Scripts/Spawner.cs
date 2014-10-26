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
        SpriteRenderer srend = ob.GetComponentInChildren<SpriteRenderer>();
		//Color c = srend.material.color;
		//c = colors[num];
        srend.material.color = Player.playerColors[num];
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
