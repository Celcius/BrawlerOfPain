using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
              player.respawn();
        }
    }


    void OnCollisionStay(Collision other)
    {
        OnCollisionEnter(other);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponentInParent<Player>();
            if(player!= null)
                player.respawn();
        }
    }
}
