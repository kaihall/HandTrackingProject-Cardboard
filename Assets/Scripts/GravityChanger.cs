using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public void SetGravity(float strength) {
		Physics.gravity = new Vector3(0, strength, 0);
	}
}
