using UnityEngine;
using System.Collections;

public class MeleeEnemy : MonoBehaviour {

	public Transform target;//set target from inspector instead of looking in Update
	public float speed;
	public float chaseRange;
	//public int damageToGive;
	//public Projectile bullet;
	//public Transform Projectile;
	private float timer = 5f;
	private Vector2 currentMoveDirection;
	private Vector2 facingDirection;
	private SpriteRenderer SR;

	public float oldPosition = 0.0f;
	public float newPosition = 0.0f;




	void Start () {
		oldPosition = transform.position.x;
		SR = GetComponent<SpriteRenderer>();
	}



	void Update(){
		oldPosition = transform.position.x;
		newPosition = target.position.x;

		float distanceToTarget = Vector3.Distance (transform.position, target.position);
		if (distanceToTarget < chaseRange) {
			Vector3 targetDir = target.position - transform.position;
			transform.Translate (targetDir.normalized * Time.deltaTime * speed);
		}
		if (newPosition>oldPosition) {
			SR.flipX = false;
		}
		if (newPosition<oldPosition) {
			SR.flipX = true;
		}


	}
}


