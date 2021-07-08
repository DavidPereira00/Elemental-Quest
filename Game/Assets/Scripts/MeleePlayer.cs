using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePlayer : MonoBehaviour
{

	public float moveSpeed;
	public int damageToGive;
	private Rigidbody2D myRigidBody;
	private Vector2 currentMoveDirection;
	private Vector2 facingDirection;
	private Vector2 lastmove;
	private bool 	inDialogueZone;
	public bool canMove;
	public GameObject Trees;
	public float timer;
	private UIManager theUI;
	private Animator anim;
	private Animator animMel;
	private bool PlayerMoving;
	public bool attacking;
	public float attacktime;
	private float attacktimecounter;
	private HurtEnemy HM;
	public int isattacking;

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
	public GameObject sword;



	void Start()
	{
		theUI = FindObjectOfType<UIManager> (); 
		currentMoveDirection = new Vector2();
		anim = GetComponent<Animator> ();
		animMel = GetComponent<Animator> ();
		facingDirection = Vector2.right;
		inDialogueZone = false;
		canMove = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		enemykilled = 0;
		questsCompleted = 0;
		bossd = 0;
		attacktime = 1f;
		HM = GetComponent<HurtEnemy> ();
		isattacking = 0;

	}


	void FixedUpdate () 
	{
		PlayerMoving = false;
		if (questsCompleted == 2) {
			nboss.SetActive (true);
			npcbt.SetActive (true);
		}
		if (bossd == 1) {
			portal.SetActive (true);
		}

		if (attacking==true)
		{
			sword.GetComponent<BoxCollider2D> ().enabled = true;
		}
		if (attacking==false)
		{
			sword.GetComponent<BoxCollider2D> ().enabled = false;
		}



		if (enemykilled == 0) {
			wall.SetActive (true);
		}
		if (enemykilled == 1) {
			wall.SetActive (false);
		}

		if (!canMove) {
			moveSpeed = 0;
			return;
		}
		if (canMove) {
			moveSpeed = 100;

		}
		if (!attacking) {

		
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				//transform.Translate ( new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, myRigidBody.velocity.y);
				PlayerMoving = true;
				lastmove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate ( new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
				PlayerMoving = true;
				lastmove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				//transform.Translate ( new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidBody.velocity = new Vector2 (0f, myRigidBody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				//transform.Translate ( new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, 0f);
			}

			if (Input.GetKeyDown (KeyCode.Z)) {
				attacktimecounter = attacktime;
				attacking = true;
				myRigidBody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);
				isattacking = 1;
			}
		}
		if (attacktimecounter > 0) {
			attacktimecounter -= Time.deltaTime;
		}
		if (attacktimecounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
			isattacking = 0;
		}


		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool("PlayerMoving", PlayerMoving);
		anim.SetFloat ("LastMoveX", lastmove.x);
		anim.SetFloat ("LastMoveY", lastmove.y);


		if (currentMoveDirection.magnitude > 0)
			facingDirection = currentMoveDirection;

		if (Input.GetKeyDown(KeyCode.Z) && !inDialogueZone && ready == false)
		{
			downTime = Time.time;
			pressTime = downTime + countDown;
			ready = true;
			//Projectile projectile = Instantiate (bullet) as Projectile;
			//projectile.Init (transform.position, facingDirection);
			Trees.SetActive (false);
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			ready = false;
		}
		if (Time.time >= pressTime && ready == true && theUI.enemiesKilled == 50) {
			ready = false;
			theUI.enemiesKilled = 0;
			//Projectilesp projectilesp = Instantiate (spatk) as Projectilesp;
			//projectilesp.Init (transform.position, facingDirection);
			Trees.SetActive (true);
			anim.SetBool ("Spattack", true);

		}
		if (Input.GetKey (KeyCode.Z)) {
			timer += 1.0f * Time.deltaTime;
		}
		if (!Input.GetKey (KeyCode.Z)) {
			timer = 0f;
		}
		if (timer >= 4) {
			Trees.SetActive (false);
			anim.SetBool ("Spattack", false);
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
