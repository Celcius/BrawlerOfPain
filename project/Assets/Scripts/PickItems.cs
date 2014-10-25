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
	
	private void HandleCollision(Collider other)
	{
		Debug.Log ("Collision Delegate works" + other.name);
		PickableItem item = other.GetComponent<PickableItem>();
		if (item && currentItem == null){
			currentItem = item;
			item.collider.enabled = false;
			item.rigidbody.isKinematic = true;
		}
	}
	
	
	private void HandleImpact()
	{
		currentItem.collider.enabled = true;
		currentItem.rigidbody.isKinematic = false;
		currentItem = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentItem){
			currentItem.transform.position = player.transform.position + new Vector3(0,3,0);
		}
	}
}
