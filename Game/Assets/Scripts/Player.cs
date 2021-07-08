using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Player : MonoBehaviour
{
	public Slider questsprogress;
	public float moveSpeed;
	public Projectile bullet;
	public Projectilesp spatk;
	public int damageToGive;
	private Rigidbody2D myRigidBody;
	private Vector2 currentMoveDirection;
	private Vector2 facingDirection;
	private bool 	inDialogueZone;
	private Vector2 lastmove;
	public bool canMovee;
	//public GameObject Trees;
	public float timer;
	private UIManager theUI;
	private Animator anim;
	private Animator animMel;
	//public AudioClip fireSound;
	//private AudioSource source;

	public float downTime, upTime, pressTime = 0;
	public float countDown = 1.0f;
	public bool ready = false;
	public int enemykilled;
	public GameObject wall;
	public int questsCompleted;
	public GameObject nboss;
	public GameObject npcbt;
	public GameObject portal;
	public int bossd;
	private BossHealthManager BHM;
	void Start()
	{
		//source = GetComponent<AudioSource>();
		theUI = FindObjectOfType<UIManager> (); 
		currentMoveDirection = new Vector2();
		facingDirection = Vector2.right;
		inDialogueZone = false;
		canMovee = true;
		anim = GetComponent<Animator> ();
		animMel = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
		BHM = GetComponent<BossHealthManager> ();

		enemykilled = 0;
		questsCompleted = 0;
		bossd = 0;

	}


	void FixedUpdate () 
	{

		if (questsCompleted == 2) {
			nboss.SetActive (true);
			npcbt.SetActive (true);
		}
		if (bossd == 1) {
			portal.SetActive (true);
		}


		if (enemykilled == 0) {
			wall.SetActive (true);
		}
		if (enemykilled == 1) {
			wall.SetActive (false);
		}
		
		if (!canMovee) {
			moveSpeed = 0;
			return;
		}
		if (canMovee) {
			moveSpeed = 100;

		}

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			//transform.Translate ( new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidBody.velocity.y);
			lastmove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			//BHM.remove = 0;
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
			//transform.Translate ( new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical")* moveSpeed);
			lastmove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			//BHM.remove = 0;
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
			//transform.Translate ( new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidBody.velocity = new Vector2(0f,myRigidBody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
			//transform.Translate ( new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
		}


		//currentMoveDirection.x = Input.GetAxisRaw ("Horizontal");
		//currentMoveDirection.y = Input.GetAxisRaw ("Vertical");

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		animMel.SetFloat("MoveXmel", Input.GetAxisRaw("Horizontal"));
		animMel.SetFloat ("MoveYmel", Input.GetAxisRaw ("Vertical"));
		//transform.Translate(currentMoveDirection * moveSpeed * Time.deltaTime);

		if (currentMoveDirection.magnitude > 0)
			facingDirection = currentMoveDirection;

		if (Input.GetKeyDown(KeyCode.Z) && !inDialogueZone && ready == false)
		{
			AudioSource shoot = GetComponent<AudioSource> ();
			shoot.Play ();
			downTime = Time.time;
			pressTime = downTime + countDown;
			ready = true;
			Projectile projectile = Instantiate (bullet) as Projectile;
			projectile.Init (transform.position, lastmove);

		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			ready = false;
		}
		if (Time.time >= pressTime && ready == true && theUI.enemiesKilled == 50) {
			ready = false;
			theUI.enemiesKilled = 0;
			Projectilesp projectilesp = Instantiate (spatk) as Projectilesp;
			projectilesp.Init (transform.position, lastmove);
			//Trees.SetActive (true);

		}
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("DialogZone"))
			inDialogueZone = true;
	}
		
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("DialogZone"))
			inDialogueZone = false;
	}
			

}