using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
	public static Projectile _instance;
	public float speed;
	public Vector2 spriteDirection;

	private Vector2 direction;
	//public bool bulletA;
	public int damageToGive;

	private Rigidbody2D rb;
	private Player thePlayer;
	public float timer;
	private int bcol;
	private BossHealthManager BHM;


	public DamageObject[] weapons;
	public int currentWeapon;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<Player>();
		BHM = FindObjectOfType<BossHealthManager> ();

	}

	void Update(){
		timer += 1.0f * Time.deltaTime;

		/*if (timer >= 4) {
			Destroy (this.gameObject);
		}*/
	}

	public void Init(Vector2 position, Vector2 direction)
	{
		transform.position = position;

		transform.Rotate (0f, 0f, Vector2.SignedAngle (spriteDirection, direction));

		this.direction = direction;
	}
		
	void OnTriggerEnter2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (other.gameObject.tag == "Enemy") 
		{
			//bulletA = true;
			other.gameObject.GetComponent<EnemyHealthManager> ().Projectile (weapons[currentWeapon].damage);
			Destroy (this.gameObject);
			//thePlayer.canMove = false;
			}
		if (other.gameObject.tag == "boss") 
		{
			//bulletA = true;
			other.gameObject.GetComponent<MiniBossHealthManager> ().Projectile (weapons[currentWeapon].damage);
			Destroy (this.gameObject);
			//thePlayer.canMove = false;
		}
		if (other.gameObject.tag == "boss2") 
		{
			//bulletA = true;
			other.gameObject.GetComponent<MiniBoss2HealthManager> ().Projectile (weapons[currentWeapon].damage);
			Destroy (this.gameObject);
			//thePlayer.canMove = false;
		}
		if (other.gameObject.tag == "Fboss") 
		{
			//bulletA = true;
			other.gameObject.GetComponent<BossHealthManager> ().Projectile (weapons[currentWeapon].damage);
			Destroy (this.gameObject);
			//thePlayer.canMove = false;
		}
		if (other.gameObject.tag == "Fboss2") 
		{
			//bulletA = true;
			other.gameObject.GetComponent<BossHealthManager> ().Projectile (weapons[currentWeapon].damage);
			BHM.remove=1;
			thePlayer.enemykilled = 0;
			Destroy (this.gameObject);
			//thePlayer.canMove = false;
		}
		if (other.gameObject.tag == "wall") 
		{
			//bulletA = true;
			Destroy (this.gameObject);
			//thePlayer.canMove = false;
		}

	}

	void FixedUpdate()
	{
		rb.AddForce(direction * speed * Time.deltaTime);
	}
}
