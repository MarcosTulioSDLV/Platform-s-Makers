using UnityEngine;
using System.Collections;

public class Script2 : MonoBehaviour {

	public float Speed=2;


	public bool IsGrounded;
	public float Force=200;
	public float JumpTime=0.4f;
	public float JumpDelay=0.4f;
	public bool Jumped;
	public Transform Ground;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Mover();
	}

	void Mover(){
		IsGrounded=Physics2D.Linecast(this.transform.position,Ground.position, 1<< LayerMask.NameToLayer("mascarasuelo"));

		if(Input.GetAxisRaw("Horizontal")>0){
			transform.Translate(Vector3.right*Speed*Time.deltaTime);
		}

		if(Input.GetAxisRaw("Horizontal")<0){
			transform.Translate(Vector3.left*Speed*Time.deltaTime);
		}

		if(Input.GetButtonDown("Jump") && IsGrounded && !Jumped){
			JumpTime=JumpDelay;
			Jumped=true;
			GetComponent<Rigidbody2D>().AddForce(transform.up*Force);

		}

		JumpTime-=Time.deltaTime;

		if(JumpTime <=0 && IsGrounded && Jumped){
			Jumped=false;
		}

	}
}
