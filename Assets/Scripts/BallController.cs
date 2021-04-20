using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	public Transform startPosition;
	public float lifetime = 10f;
	public GameObject ballPrefab;
	public BallCounter ballCounter;
	public Material selectMaterial;
	public Material deselectMaterial;
	public SFXPlayer sfxplayer;
	
	private Rigidbody rb;
	
	public bool computerTesting = true;
	public float throwOffset = 0f;
	private float lastThrowTime;
	private bool throwing = false;
	private bool hasThrown = false;
	
	// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		lastThrowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if (computerTesting && !hasThrown) {
			if (!throwing && Time.time - lastThrowTime >= throwOffset) {
				throwing = true;
				lastThrowTime = Time.time;
			}
			
			if (throwing && Time.time - lastThrowTime >= 3) {
				Throw();
				lastThrowTime = Time.time;
				hasThrown = true;
			}
		}
    }
	
	public void Select() {
		if (!hasThrown)
			GetComponent<MeshRenderer>().material = selectMaterial;;
	}
	
	public void Deselect() {
		GetComponent<MeshRenderer>().material = deselectMaterial;
	}
	
	public void Throw() {
		if (!hasThrown) {
			sfxplayer.PlaySound("Woosh");
			
			hasThrown = true;
			ballCounter.ballCount += 1;
			Deselect();
			
			rb.useGravity = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(0, 250, 100));
			GetComponent<Collider>().isTrigger = false;
			
			Respawn();
			Despawn();
		}
	}
	
	public void Respawn() {
		GameObject newBall = Instantiate(ballPrefab, startPosition.position, Quaternion.identity);
		
		BallController bc = newBall.GetComponent<BallController>();
		bc.startPosition = startPosition;
		bc.lifetime = lifetime;
		bc.ballPrefab = ballPrefab;
		bc.ballCounter = ballCounter;
		bc.sfxplayer = sfxplayer;
	}
	
	public void Despawn() {
		Destroy(gameObject, lifetime);
	}
}
