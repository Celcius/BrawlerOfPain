using UnityEngine;
using System.Collections;

public delegate void ImpactDelegate ();

[RequireComponent (typeof (Player))]
public class ImpactReceiver : MonoBehaviour {

	float mass = 3.0F; // defines the character mass
	Vector3 impact = Vector3.zero;
	private CharacterController character;
	private Player player;
	
	public GameObject targetBlink;
	private SpriteRenderer renderer;
	
	public ImpactDelegate OnImpact;
	
	public bool invincible = false;

    private bool waitForImpact = false;
	
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
		
		player = GetComponent<Player>();
		renderer = targetBlink.GetComponent<SpriteRenderer>();
		player.OnSpawnEvent += OnSpawn;
	}
	
	// Update is called once per frame
	void Update () {
		// apply the impact force:
		if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
		// consumes the impact energy each cycle:
		impact = Vector3.Lerp(impact, Vector3.zero, 5*Time.deltaTime);
	}
	// call this function to add an impact force:
	public void AddImpact(Vector3 dir, float force){
        if (invincible || waitForImpact) return;
		
		dir.Normalize();
		if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
		impact += dir.normalized * force / mass;

        waitForImpact = true;
        StartCoroutine(WaitForImpact(0.1f));
		OnImpact();
	}


    IEnumerator SpawnTimer(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        invincible = false;
    }

    IEnumerator WaitForImpact(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        waitForImpact = false;
    }

    IEnumerator BlinkPlayer(float duration)
	{
		Color c;
		float counter = 0;
		while(counter < duration){
			counter += Time.deltaTime;
			c = renderer.material.color;
			c.a = Mathf.Sin (counter*10)/2 + 0.5f;
			renderer.material.color = c;
			yield return null;
		}
		c = renderer.material.color;
		c.a = 1f;
		renderer.material.color = c;
	}
	
	private void OnSpawn(Player p){
		invincible = true;
		StartCoroutine(SpawnTimer(2));
		StartCoroutine(BlinkPlayer(2));
	}
	
}