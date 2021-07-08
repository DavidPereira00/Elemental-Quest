using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	public float speed;
	public Vector2 spriteDirection;

	private Vector2 direction;
	//public bool bulletA;
	public int damageToGive;

	private Rigidbody2D rb;
	private Player thePlayer;
	public float timer;


	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<Player>();
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
		if (other.gameObject.name == "Player") 
		{
			//bulletA = true;
			other.gameObject.GetComponent<PlayerHealthManager> ().EnemyProjectile(damageToGive);
			Destroy (this.gameObject);
			//thePlayer.canMove = false;
		}
	}

	void FixedUpdate()
	{
		rb.AddForce(direction * speed * Time.deltaTime);
	}
}
