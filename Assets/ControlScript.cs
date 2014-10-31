using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public float runspeed;
	private int look;
	private Vector3 escala; 
	public Animator sprite;
	public Vector3 gravity;
	public int jumpTime;
	// Use this for initialization
	void Start () {
		look = 1;
		gravity = new Vector3 (0.0f, 0.0f, -9.8f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("right")) {
			rigidbody2D.velocity = new Vector2(runspeed, rigidbody2D.velocity.y);
			if (look==-1){
				escala=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
				transform.localScale=escala;
				look=1;
			}
			sprite.SetInteger("state", 1);
		}else if (Input.GetKey ("left")) {
			rigidbody2D.velocity = new Vector2(-runspeed, rigidbody2D.velocity.y);
			if (look==1){
				escala=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
				transform.localScale=escala;
				look=-1;
			}
			sprite.SetInteger("state", 1);
		}else {
			sprite.SetInteger("state", 0);
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
		}


		if (Input.GetKey("z") && jumpTime<7) {
			rigidbody2D.AddForce(new Vector2(0, 5000));
			jumpTime++;
		}
		if (rigidbody2D.velocity.y > 1) {
			sprite.SetInteger("state", 2);
		}
		if (rigidbody2D.velocity.y < -1) {
			sprite.SetInteger("state", 3);
		}

		if (Input.GetKey("x") && rigidbody2D.velocity.x==0 && rigidbody2D.velocity.y==0){

		}
	}

	void OnCollisionEnter2D(Collision2D colInfo){
		if (colInfo.collider.tag == "platform") {
			jumpTime=0;
		}
	}

}
