using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour {

	public float gravity = -10;

	public void Attract(Transform body) {
		Vector3 gravity_up = (body.position - transform.position).normalized;
		Vector3 bodyUp = body.up;
		body.GetComponent<Rigidbody>().AddForce(gravity_up * gravity, ForceMode.Acceleration);

		Quaternion target_rotation = Quaternion.FromToRotation(bodyUp, gravity_up) * body.rotation;
		body.rotation = Quaternion.Slerp(body.rotation, target_rotation, 50 * Time.deltaTime);
	}
}
