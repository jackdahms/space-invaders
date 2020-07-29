using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

	public GravityAttractor attractor;
	private Transform my_transform;

    void Start() {
    	GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    	GetComponent<Rigidbody>().useGravity = false;
        my_transform = transform;
    }

    void Update() {
        attractor.Attract(my_transform);   
    }
}
