using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float speed;

	public float xMin = -5;
	public float xMax = 5;

	public float padding = 1f;

	public GameObject projectile;

	public float projectileSpeed;

	public float firingRate = 0.2f;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distance));

		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;

		speed = 15.0f;
		projectileSpeed = 5.0f;
	}

	void Fire(){
			GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
			beam.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);
	}

	// Update is called once per frame
	void Update () {
		//fire projectile
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("Fire",0.000001f, firingRate);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp (transform.position.x,xMin,xMax);

		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}
}
