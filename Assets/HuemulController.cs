using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HuemulController : MonoBehaviour
{
    public Rigidbody2D rb; 
    public float JUMPING_FORCE = 7f;
    public float MOVING_SPEED = 5f;

    private bool jumping = false;
    
    void Start() 
    {
	    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
	    //float horizontal = Input.GetAxisRaw("Horizontal");
	    //rb.velocity = new Vector2(horizontal * MOVING_SPEED, rb.velocity.y);

	    if (Input.GetKey("space") && !jumping) {
		    rb.velocity = new Vector3(0, JUMPING_FORCE);
		    jumping = true;
	    }

	    if (Input.GetKey("down")) {
		    rb.velocity = new Vector3(0, -JUMPING_FORCE);
	    }
    }

    void OnCollisionEnter2D(Collision2D collision) {
	    // Touched something
	    switch(collision.gameObject.tag) {
		    case "Ground":
			    jumping = false;
			    break;
		    case "Enemy":
			    SceneManager.LoadScene("MainScene");
			    break;
		    default:
			    break;
	    }
    }
}
