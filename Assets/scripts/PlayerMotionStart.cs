using UnityEngine;
using System.Collections;

public class PlayerMotionStart : MonoBehaviour
{
	public bool jump = false;					
	public float jumpForce = 400f;			
	public float standardSpeed = 5f;
	private Transform comprobadorSuelo; // se usa con Physics2D.Linecast
	public float comprobadorRadio=0.1f;

	private float timePrimerFrameToca=0f;
	private bool primerFrameToca=true;
	private float timePrimerFrameToca2=0f;
	private bool primerFrameToca2=true;

	public bool EstaEsquinaD=false;
	public bool EstaEsquinaI=false;

	public bool grounded = false;
	private float move;
	
   void OnCollisionEnter2D(Collision2D hit)
	{
		/*if(hit.gameObject.tag == "suelo")
			grounded = true;*/
	}

	void Start(){
		comprobadorSuelo=transform.GetChild(0); //obtener hijo
	}

	private bool EstaTocandoPiso(){
	//grounded=Physics2D.Linecast(this.transform.position,comprobadorSuelo.position, 1<< LayerMask.NameToLayer("mascarasuelo")); //se hace verdadera cuando esta tocando el piso
	grounded=Physics2D.OverlapCircle(comprobadorSuelo.position,comprobadorRadio,1<<LayerMask.NameToLayer("mascarasuelo"));
	return grounded;
	}

	void Update()
	{	
		print ("esta en esquina derecha "+ EstaEsquinaD);
		//print (Input.GetAxisRaw("Horizontal")+" "+Input.GetAxis("Horizontal")); // GetAxis

//#if UNITY_STANDALONE || UNITY_EDITOR
		move= Input.GetAxis("Horizontal");
		move*= standardSpeed;

//#endif


		//PERMITE EMPUJAR EN EL AIRE A BLOQUES AZULES POR X TIEMPO, Y LUEGO DESHABILITA EMPUJE PARA QUE CAIGA(EVITA QUE QUEDE INFINITO TIEMPO EN EL AIRE EMPUEJANDO)
		if(Input.GetAxis("Horizontal")>0 && EstaEsquinaD){ //move>0 && !grounded && EstaEsquinaD ?
			//print("esta empujando en el aire");
			/*if(primerFrameToca==true){
				timePrimerFrameToca=Time.timeSinceLevelLoad; 
				primerFrameToca=false;
			}
			if(Time.timeSinceLevelLoad>0.6f+timePrimerFrameToca)*/ // 0.25 penultimo valor determina tiempo de empuje en aire	
			//move=0;	

			//if(Input.GetAxisRaw("Horizontal")!=1){primerFrameToca=true;}
		}
		if(move<0 && !grounded && EstaEsquinaI){
			/*
			if(primerFrameToca2==true){
				timePrimerFrameToca2=Time.timeSinceLevelLoad; 
				primerFrameToca2=false;
			}
			if(Time.timeSinceLevelLoad>0.25f+timePrimerFrameToca2) //penultimo valor determina tiempo de empuje en aire
			move=0;*/
		}

		/*if((facingRight && move < 0) ||
		   (!facingRight && move > 0))
			Flip ();*/

		//grounded=Physics2D.Linecast(this.transform.position,comprobadorSuelo.position, 1<< LayerMask.NameToLayer("mascarasuelo")); //se hace verdadera cuando esta tocando el piso
		grounded=Physics2D.OverlapCircle(comprobadorSuelo.position,comprobadorRadio,1<<LayerMask.NameToLayer("mascarasuelo"));
		
		if(grounded){primerFrameToca=true; primerFrameToca2=true;}
		//if(Input.GetAxisRaw("Horizontal")!=1){primerFrameToca=true;}
		
		
		if(Input.GetButtonDown("Jump") && grounded == true)
		{		
			jump = true;
			//grounded = false;
		}

	}



	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2( move , GetComponent<Rigidbody2D>().velocity.y  );

		if(jump == true)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

			jump = false;
		}
	}

	/*void Flip ()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}*/
}
