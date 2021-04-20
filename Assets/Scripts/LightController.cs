using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    public float startAngle = 30f;
	public float endAngle = 180f;
	public float dayLength = 60f;
	
	private float startTime;
	
	// Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * ((endAngle - startAngle) / dayLength) * Time.deltaTime);
		
		if (Time.time - startTime >= dayLength) {
			SceneManager.LoadScene("EndScreen");
		}
    }
}
