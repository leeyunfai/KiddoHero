using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
	private float input;
	public float speed;
	Rigidbody2D rb; //Keyword to GetComponent<Rigidbody2D>
	Animator anim;
	public int health;

	public Text healthDisplay;

	public GameObject losePanel;

	AudioSource source;

	public float startDashTime;
	private float dashTime;
	public float extraSpeed;
	private bool isDashing;

	public Text timerText;
	private float startTime;


    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();    
		healthDisplay.text = health.ToString();
		startTime = Time.time;
    }

	private void Update()
	{	float t = Time.time - startTime;
		string minutes = ((int)t/60).ToString();
		string seconds = (t%60).ToString("f2"); //f2 means only 2 decimals 
		timerText.text = minutes + ":" + seconds;


		if (input != 0){
			anim.SetBool("isRunning",true);
		}else{
			anim.SetBool("isRunning",false);
		}

		if (input < 0){ //Go left is normal
			transform.eulerAngles = new Vector3 (0,0,0);
		}else if (input > 0){ //Go right then mirror the player image
			transform.eulerAngles = new Vector3 (0,180,0);
		}

		if (Input.GetKeyDown(KeyCode.Space) && isDashing == false){
			speed += extraSpeed;
			isDashing = true;
			dashTime = startDashTime;

		}

		if (dashTime <= 0 && isDashing == true){
			isDashing = false;
			speed -= extraSpeed;
		}

		else{
			dashTime -= Time.deltaTime;
		}
	}

    // Update is called once per frame
    void FixedUpdate() //Because we are using Physics Engine, we must name it FixedUpdate instead of just Update
    {
        //Storing player's input.
		input = Input.GetAxisRaw("Horizontal");//H must be caps, GetAxis is smooth feeling, GetAxisRaw is not smooth but fast
		print(input);

		//Moving Player
		//rb.velocity stores 2 floats so as for player to move in x and y direction AKA Vector2
		rb.velocity = new Vector2(input*speed,rb.velocity.y);
    }

	public void TakeDamage(int damageAmount){
		source.Play(); //injury sound will play as soon as player takes damage
		health -= damageAmount;
		healthDisplay.text = health.ToString();


		if (health <= 0){
			losePanel.SetActive(true);
			Destroy(gameObject); //Refers to destroying the game object that has this script attached to it

		}
	}
}
