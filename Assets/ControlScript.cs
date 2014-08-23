using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public float runspeed;
	private int look;
	private Vector3 escala; 
	public Animator sprite;
	// Use this for initialization
	void Start () {
		look = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("right")) {
			rigidbody2D.velocity = Vector3.right*runspeed;
			if (look==-1){
				escala=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
				transform.localScale=escala;
				look=1;
			}
			sprite.SetInteger("state", 1);
		}else if (Input.GetKey ("left")) {
			rigidbody2D.velocity = Vector3.left*runspeed;
			if (look==1){
				escala=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
				transform.localScale=escala;
				look=-1;
			}
			sprite.SetInteger("state", 1);
		}else {
			sprite.SetInteger("state", 0);
			rigidbody2D.velocity = Vector3.right*0;
			rigidbody2D.velocity = Vector3.left*0;
		}
	}
}
