using UnityEngine;
using System.Collections;

public class Script1 : MonoBehaviour {



	public float Force=300f;  
	public float Speed=10f;
	public float MaxSpeed=50f;
	public float VariableFrenar1=0.9f;
	public float VariableFrenar2=2.5f;
	private Rigidbody2D miRigidbody2D;

	public bool enSuelo=false;
	private Transform comprobadorSuelo;
	public float comprobadorRadio=0.2f;
	public LayerMask MascaraSuelo;

	// Use this for initialization
	void Start () {
		miRigidbody2D=this.GetComponent<Rigidbody2D>();
		comprobadorSuelo=transform.GetChild(0); //obtener hijo
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Input.GetAxisRaw("Horizontal"));

		//Debug.Log(comprobadorSuelo.position);


		/*if(Input.GetKey(KeyCode.RightArrow)){  //MOVERSE SIN FUERZA
			transform.Translate(Vector3.right*3f*Time.deltaTime);	
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(-Vector3.right*3f*Time.deltaTime);	
		}*/

	}

	void FixedUpdate(){

		enSuelo=Physics2D.OverlapCircle(comprobadorSuelo.position,comprobadorRadio,MascaraSuelo);

	
		/*if(Input.GetKey(KeyCode.RightArrow)){
			miRigidbody2D.AddForce(Vector3.right*Speed);	
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			miRigidbody2D.AddForce(-Vector3.right*Speed);
		}*/

		if(Input.GetKeyDown(KeyCode.UpArrow) && enSuelo==true){  // SALTAR
			miRigidbody2D.AddForce(Vector2.up*Force);
		}

		float valor=Speed*Input.GetAxis("Horizontal"); //MOVER APLICANDO FUERZA
		miRigidbody2D.AddForce(Vector3.right*valor);

	
		if(miRigidbody2D.velocity.magnitude > MaxSpeed ){  // LIMITAR ACELERACION INFINITA
			miRigidbody2D.velocity = miRigidbody2D.velocity.normalized * (MaxSpeed);
		}
	
		if(Input.GetAxisRaw("Horizontal")==0 && Input.GetAxisRaw("Vertical")==0){ // FRENAR CUANDO SE DEJA DE PULSAR
			miRigidbody2D.velocity -= (miRigidbody2D.velocity * VariableFrenar1) * (Time.deltaTime/VariableFrenar2);
		}



	}


/*

	void OnCollisionStay2D(Collision2D col){
		if(col.transform.tag=="suelo"){
			enSuelo=true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if(col.transform.tag=="suelo"){
			enSuelo=false;
		}
	}
*/


}
