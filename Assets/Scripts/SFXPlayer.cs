using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public void PlaySound(string source) {
		transform.Find(source).GetComponent<AudioSource>().Play();
	}
}
