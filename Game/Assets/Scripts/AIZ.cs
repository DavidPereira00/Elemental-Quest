using UnityEngine;
using System.Collections;

public class AIZ : MonoBehaviour {

	public Transform target;//set target from inspector instead of looking in Update
	public float speed;
	public float chaseRange;
	//public int damageToGive;
	//public Projectile bullet;
	//public Transform Projectile;
	public EnemyProjectile bullet;
	public EnemyProjectile bullet2;
	public Transform bulletspawn;
	private float timer = 5f;
	private Vector2 currentMoveDirection;
	private Vector2 facingDirection;
	public float projectileRange;
	public EnemyHealthManager EH;
	public GameObject act;
	private SpriteRenderer SR;

	public Vector2 pos1;
	public Vector2 pos2;

	public float oldPosition = 0.0f;
	public float newPosition = 0.0f;






	void Start () {
		InvokeRepeating("LaunchProjectile", 0f, 5f);
		oldPosition = transform.position.x;
		SR = GetComponent<SpriteRenderer>();
	}



	void Update(){
		oldPosition = transform.position.x;
		newPosition = target.position.x;
		float distanceToTarget = Vector3.Distance (transform.position, target.position);

		if (distanceToTarget < chaseRange) {
			//Start the chase to the target
			Vector3 targetDir = target.position - transform.position;
			transform.Translate (targetDir.normalized * Time.deltaTime * speed);
		}
		if (newPosition<oldPosition) {
			SR.flipX = false;
		}
		if (newPosition>oldPosition) {
			SR.flipX = true;
		}

	}
	void LaunchProjectile(){
		float distanceToTarget = Vector3.Distance (transform.position, target.position);
		if (distanceToTarget < projectileRange && gameObject.active) { 
			EnemyProjectile enemyprojectile = Instantiate (bullet) as EnemyProjectile;
			enemyprojectile.Init (transform.position, target.position - transform.position);

			//Instantiate (Projectile, transform.position + (target.position - transform.position).normalized, 
			//Quaternion.LookRotation (target.position - transform.position));
	}
	}
}

