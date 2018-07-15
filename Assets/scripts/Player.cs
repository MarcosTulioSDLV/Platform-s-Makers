using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	//NOTA: EL VALOR DE FRICCION DEL MATERIAL DEL PERSONAJE ES 0.0055, casi se pega al empujar 3 bloques a la vez 
	public bool jump = false;					
	public float jumpForce = 300f;	// cuando se addforce 300, cuando se usa velocity 6.2		
	public float standardSpeed = 3f;
	private Transform comprobadorSuelo; // se usa con Physics2D.Linecast
	public float comprobadorRadio=0.22f; //bien con 0.14 y y= 4.37584 

	public bool grounded = false;
	public bool colisionConBloqueAzul=false;
	private float move;
	public TextMesh TextoMensaje;
	public TextMesh TextoReintentar;
	public TextMesh TextoSiguienteNivel;
	public TextMesh TextoSalir;
	//public GameObject BotonSalir;
	//public GameObject BotonReintentar;
	public TextMesh TextoTiempo;
	private GameObject[] bloquesAzules;
	private GameObject Camara;

	private GameObject efectosSonidos;

	void Start(){
		comprobadorSuelo=transform.GetChild(0); //obtener hijo
		bloquesAzules=GameObject.FindGameObjectsWithTag("bloque azul");	
		Camara=GameObject.Find("Main Camera");
	
		efectosSonidos=GameObject.Find("efectos sonidos");
	}


	void Update()
	{	

		//print (Input.GetAxisRaw("Horizontal")+" "+Input.GetAxis("Horizontal")); // GetAxis

//#if UNITY_STANDALONE || UNITY_EDITOR
		move= Input.GetAxis("Horizontal");
		move*= standardSpeed;

//#endif


		//grounded=Physics2D.Linecast(this.transform.position,comprobadorSuelo.position, 1<< LayerMask.NameToLayer("mascarasuelo")); //se hace verdadera cuando esta tocando el piso. valor de suelo en Y=-0.4408533
		grounded=Physics2D.OverlapCircle(comprobadorSuelo.position,comprobadorRadio,1<<LayerMask.NameToLayer("mascarasuelo"));

		if(!grounded && colisionConBloqueAzul){
			print ("aqui no se puede mover");
		}

		if(Input.GetButtonDown("Jump") && grounded == true)
		{		
			if(Time.timeScale!=0)//No permite saltar cuando el juego esta pausado, ya que podria undir cuando esta pausado y el salto se ejecutaria al despausar
			jump = true;
			//grounded=false;
		}

	}



	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2( move , GetComponent<Rigidbody2D>().velocity.y  );

		if(jump == true)
		{
			efectosSonidos.GetComponent<ScriptAudio>().Sonido3Activado=true; // ACTIVA SONIDO BOTON

			//rigidbody2D.AddForce(new Vector2(0, jumpForce)); 
			GetComponent<Rigidbody2D>().velocity=new Vector3(GetComponent<Rigidbody2D>().velocity.x,jumpForce);
			jump = false;
		}
	}

	private void DestruirBloquesAzules(){
		foreach (var item in bloquesAzules) {
			       Destroy(item);
				}		
		/*for(int i=0;i<bloquesAzules.Length;i++){
			Destroy(bloquesAzules[i]);
		}*/
	}

	void OnTriggerEnter2D(Collider2D hit){
		if(hit.tag=="manzana"){
			//Debug.Log("you Win");

			efectosSonidos.GetComponent<ScriptAudio>().Sonido4Activado=true;

			//destruye personaje,manzana,bloques azules y texto del tiempo
			Destroy(hit.gameObject);
			Destroy(gameObject);
			Destroy(TextoTiempo.gameObject);
			DestruirBloquesAzules();
			//activar texto3d mensaje y asignar texto ganaste
			TextoMensaje.GetComponent<Renderer>().enabled=true;
			TextoMensaje.color=Color.blue;
			TextoMensaje.text="Level Passed";
			//activar boton salir y reintentar
			if(Application.loadedLevelName!="nivel3facil" && Application.loadedLevelName!="nivel3medio" && Application.loadedLevelName!="nivel3dificil")
			TextoSiguienteNivel.gameObject.SetActive(true);
			TextoReintentar.gameObject.SetActive(true);
			TextoSalir.gameObject.SetActive(true);
			/*BotonReintentar.SetActive(true);
			BotonSalir.SetActive(true);*/
			//pausa juego cuando ganes para parar relog, es una alternativa a hacer verdadera la variable pausar tiempo de la clase interfaz con diferencia de que pausa todo el juego
			Time.timeScale=0; //camera.GetComponent<Interfaz>().pausarTiempo=true;
			Camara.GetComponent<Interfaz>().pausarTiempo=true; // NECESARIO PARA EVITAR QUE SE SIGA EJECUTANDO EL CODIGO DE RELOG Y PUEDA DAR PROBLEMAS	
			Camara.GetComponent<Interfaz>().EstaJugando=false;
		}
	}


}
