using UnityEngine;
using System.Collections;
using System;//permite usar el string de aqui: String.Format("{0:00}:{1:00}", minutos, segundos);



public class Interfaz : MonoBehaviour {


	public TextMesh TextoTiempo;
	private float tiempo;
	private float timeStart;
	private float tiempoCronometro;
	private int tiempoMinutos;
	private int tiempoSegundos;
	public bool pausarTiempo;
	public bool EstaJugando=true;// truer cuando no se ha acado el tiempo , CODIDO DE PAUSAR 
	private GameObject FondoNubes;// CODIGO DE PAUSAR

	public int TiempoJuego=10;

	public GameObject TextoMensaje;
	public TextMesh TextoReintentar;
	public TextMesh TextoSiguienteNivel;
	public TextMesh TextoSalir;
	public TextMesh TextoContinuar;// CODIGO DE PAUSAR


	private GameObject personaje;//referencia para poder eliminarlo cuando termine el tiempo
	private GameObject manazana;//referencia para poder eliminarla cuando termine el tiempo
	private GameObject[] bloquesAzules;

	private GameObject efectosSonidos;
	private GameObject musica;
	private GameObject[] VectorBotonesTexto;
	private bool primeraVezDespausado=true;

	// Use this for initialization
	void Start () {

		personaje=GameObject.Find("personaje");
		manazana=GameObject.Find("manzana");
		bloquesAzules=GameObject.FindGameObjectsWithTag("bloque azul");	
		FondoNubes=GameObject.Find("fondo nuves");// CODIGO DE PAUSAR

		efectosSonidos=GameObject.Find("efectos sonidos");
		musica=GameObject.Find("musica");

	}

	private void DestruirBloquesAzules(){
				foreach (var item in bloquesAzules) {
			       Destroy(item);
				}
	}
	
	// Update is called once per frame
	void Update () {
		 	 
		if(!pausarTiempo){ // CODIGO DE TIEMPO

		string textoDeTiempo="";

	    tiempo=Time.timeSinceLevelLoad-timeStart;
	    tiempoCronometro=1+TiempoJuego-tiempo; //tiempo juego en segundos
	    tiempoMinutos=Mathf.FloorToInt(tiempoCronometro/60);
	    tiempoSegundos=Mathf.FloorToInt(tiempoCronometro%60);
	    //textoDeTiempo= String.Format("{0:00}:{1:00}", tiempoMinutos, tiempoSegundos); //tiempo en formato relog 0:0
		textoDeTiempo=tiempoSegundos.ToString();// tiempo en formato, solo segundos	

	    TextoTiempo.text=textoDeTiempo;

		if(tiempoMinutos==0 && tiempoSegundos<10){
			TextoTiempo.color=Color.red;
			if(tiempoSegundos==0){// CODIGO CUANDO SE TERMINA EL TIEMPO
					//Debug.Log("you lost");

					efectosSonidos.GetComponent<ScriptAudio>().Sonido5Activado=true;

					//codigo para que no se pueda pausar al finalizar el tiempo
					EstaJugando=false;

					//destruye personaje,manzana,bloques azules y texto del tiempo
					Destroy(manazana);
					Destroy(personaje);
					Destroy(TextoTiempo.gameObject);
					DestruirBloquesAzules();
					//activar texto3d mensaje y asignar texto perdiste
					TextoMensaje.GetComponent<MeshRenderer>().enabled=true;
					TextoMensaje.GetComponent<TextMesh>().color=Color.red;
					TextoMensaje.GetComponent<TextMesh>().text="Level failed";
					//activar boton salir y reintentar
					if(Application.loadedLevelName!="nivel3facil" && Application.loadedLevelName!="nivel3medio" && Application.loadedLevelName!="nivel3dificil")
					TextoSiguienteNivel.gameObject.SetActive(true);
					TextoReintentar.gameObject.SetActive(true);
					TextoSalir.gameObject.SetActive(true);
				    /*BotonSalir.SetActive(true);
					BotonReintentar.SetActive(true);*/
					//pausa juego cuando ganes para parar relog, es una alternativa a hacer verdadera la variable pausar tiempo de la clase interfaz con diferencia de que pausa todo el juego
					Time.timeScale=0; 

				pausarTiempo=true;//CUIDADO: SIEMPRE NECESARIO PARA EVITAR QUE SE SIGA EJECUTANDO EL CODIGO DE RELOG Y PUEDA DAR PROBLEMAS Y COMPORTAMIENTOS ESTRAÑOS			
			   }	
		   }

		}


		// CODIGO DE PAUSAR EL JUEGO
		if(EstaJugando){
			if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)){
				//print ("undio estar");

				efectosSonidos.GetComponent<ScriptAudio>().Sonido1Activado=true; // ACTIVA SONIDO BOTON

				if(Time.timeScale!=0){
					//print ("pausado");
			

					//musica.audio.Pause(); //pausar musica

					//FondoNubes.transform.position.z=3; // no funciona en c# hacer lo de abajo
					Vector3 vectorTemporal=FondoNubes.transform.position;
					vectorTemporal.z=-3;
					FondoNubes.transform.position=vectorTemporal;
					//activar los textos
					if(Application.loadedLevelName!="nivel3facil" && Application.loadedLevelName!="nivel3medio" && Application.loadedLevelName!="nivel3dificil")
					TextoSiguienteNivel.gameObject.SetActive(true);
					TextoReintentar.gameObject.SetActive(true);
					TextoSalir.gameObject.SetActive(true);
					TextoContinuar.gameObject.SetActive(true);
					Time.timeScale=0;
				}else{ 
					//print ("despausado");

					//musica.audio.Play(); //despausar musica
					/*for(int i=0;i<4;i++){
					VectorBotonesTexto[i].GetComponent<EventosBotonTexto>().QuitarEfectosBotonTexto(); 
				    }*/
					if(primeraVezDespausado){
					VectorBotonesTexto=GameObject.FindGameObjectsWithTag("botontexto");
					primeraVezDespausado=false;
					}
                    foreach (var item in VectorBotonesTexto) {
						item.GetComponent<EventosBotonTexto>().QuitarEfectosBotonTexto();
                    }

					Vector3 vectorTemporal=transform.position;
					vectorTemporal.z=3;
					FondoNubes.transform.position=vectorTemporal;
					//FondoNubes.transform.position.z=3;

					//desactivar los textos
					if(Application.loadedLevelName!="nivel3facil" && Application.loadedLevelName!="nivel3medio" && Application.loadedLevelName!="nivel3dificil")
					TextoSiguienteNivel.gameObject.SetActive(false);
					TextoReintentar.gameObject.SetActive(false);
					TextoSalir.gameObject.SetActive(false);
					TextoContinuar.gameObject.SetActive(false);
					Time.timeScale=1;
				}
			}

		}



	}
	
	void OnMouseDown(){
	

		Debug.Log("toco el boto");
	}

}
