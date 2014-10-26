using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        handleCollision(other.gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        handleCollision(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        handleCollision(other.gameObject);
    }

    void handleCollision(GameObject obj)
    {
        if (obj.tag == "Player")
        {
            Player player = obj.GetComponent<Player>();
            if (player != null)
            {
                SoundManager.PlayTrapKill();
                player.respawn();
            }
        }
    }
}
