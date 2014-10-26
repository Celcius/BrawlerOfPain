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
            if (player == null)
                player = obj.GetComponentInParent<Player>();
            if (player != null && !player.GetComponent<ImpactReceiver>().invincible)
            {
                GameObject ob = Instantiate(Resources.Load("Prefabs/BloodParticlesFinal")) as GameObject;
                ob.transform.position = transform.position;
                GameManager.instance.bloodElementsAtWorldPosition(player.transform.position.x, player.transform.position.z);
                SoundManager.PlayTrapDeath();
                player.respawn();
            }
        }
    }
}
