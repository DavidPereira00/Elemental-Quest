using UnityEngine;
using System.Collections;

public class BossProjectile : MonoBehaviour {

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
	public BossHealthManager BH;






	void Start () {
		InvokeRepeating("LaunchProjectile", 0f, 5f);
	}



	void Update(){
	}
	void LaunchProjectile(){
		float distanceToTarget = Vector3.Distance (transform.position, target.position);
		if (distanceToTarget < projectileRange && BH.enemyCurrentHealth > 30  ) { 
			EnemyProjectile enemyprojectile = Instantiate (bullet) as EnemyProjectile;
			enemyprojectile.Init (transform.position, target.position - transform.position);

			//Instantiate (Projectile, transform.position + (target.position - transform.position).normalized, 
			//Quaternion.LookRotation (target.position - transform.position));
		}
		if (distanceToTarget < projectileRange && BH.enemyCurrentHealth <=30  ) { 
			EnemyProjectile enemyprojectile = Instantiate (bullet2) as EnemyProjectile;
			enemyprojectile.Init (transform.position, target.position - transform.position);

			//Instantiate (Projectile, transform.position + (target.position - transform.position).normalized, 
			//Quaternion.LookRotation (target.position - transform.position));
		}
	}
}


