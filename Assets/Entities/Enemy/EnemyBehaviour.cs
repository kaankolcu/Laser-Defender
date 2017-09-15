using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	//public GameObject enemyProjectile;

	public float health = 150;



	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Destroy(gameObject);
			}
		}
	}

	void Fire(){
	//	GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
	//	beam.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);
	}

	void Update(){

	}
}
