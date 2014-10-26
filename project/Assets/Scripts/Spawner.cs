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
        SpriteRenderer []renderers = ob.GetComponentsInChildren<SpriteRenderer>();
		//Color c = srend.material.color;
		//c = colors[num];
		renderers[1].material.color = Player.playerColors[num];
		TrailRenderer trender = ob.GetComponent<TrailRenderer>();
		trender.material.SetColor ("_TintColor", Player.playerColors[num]);
		/*foreach(SpriteRenderer srend in renderers){
			srend.material.color = colors[num];
		}*/
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
