using UnityEngine;
using System.Collections;

public class PickItems : MonoBehaviour {

	private PickableItem currentItem;
	private Player player;
	private ImpactReceiver impactReceiver;
	// Use this for initialization
	void Start () {
		player = GetComponent<Player>();
		impactReceiver = GetComponent<ImpactReceiver>();
		
		player.OnCollision += HandleCollision;
		impactReceiver.OnImpact += HandleImpact;
	}

    public bool hasItem()
    {
        return currentItem != null;
    }
	
	private void HandleCollision(Collider other)
	{
		Debug.Log ("Collision Delegate works" + other.name);
		PickableItem item = other.GetComponent<PickableItem>();
		if (item && currentItem == null){
			currentItem = item;
			item.collider.enabled = false;
			item.rigidbody.isKinematic = true;
            GameManager.instance.vipHolder = this.GetComponent<Player>();
		}
	}


	private void HandleImpact()
	{
        if(currentItem != null)
        { 
	    	currentItem.collider.enabled = true;
		    currentItem.rigidbody.isKinematic = false;
	    	currentItem = null;
            GameManager.instance.vipHolder = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (currentItem){
			currentItem.transform.position = player.transform.position + new Vector3(0,3,0);
		}

	}

    
    public void LoseItem()
    {
        HandleImpact();
    }
}
