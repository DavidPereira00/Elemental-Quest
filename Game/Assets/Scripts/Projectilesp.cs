using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectilesp : MonoBehaviour
{
	public static Projectilesp _instance;
	public float speed;
	public Vector2 spriteDirection;

	private Vector2 direction;
	//public bool bulletA;
	public int damageToGive;

	private Rigidbody2D rb;
	private Player thePlayer;
	public float timer;
	private int bcol;

	public DamageObject[] weapons;
	public int currentWeapon = 0;

	void Awake(){
		_instance = this;
	}
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<Player>();
		bcol = 0;
	}

	void Update(){
		timer += 1.0f * Time.deltaTime;

		if (timer >= 4) {
			Destroy (this.gameObject);
		}
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
			Projectilesp._instance.collided ();
			//Destroy (this.gameObject);
			//thePlayer.canMove = false;
		}
		if (bcol >= 2) {
			Destroy (this.gameObject);
		}
	}

	public void collided(){
		bcol = bcol + 1;

	}

	void FixedUpdate()
	{
		rb.AddForce(direction * speed * Time.deltaTime);
	}
}

