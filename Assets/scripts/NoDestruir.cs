using UnityEngine;
using System.Collections;

public class NoDestruir : MonoBehaviour {


	//public static NoDestruir  Instance { get { return instance; } }  

	// COIDGO PATRON SINGLETON
	//Referencia estatica a la clase
	//Referencia estatica a la clase
	private static NoDestruir instance;
	//Podemos coger la referencia desde otras clase pero no modificarla
	public static NoDestruir  Instance { get; private set;}
	private bool PrimeraVez=true;
	
	// Use this for initialization
	void Start () {

		// COIDGO PATRON SINGLETON
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			//No existe instancia
			//Guardamos nuestra referencia
			Instance = this;
			//Le decimos a unity que no destruya el objeto entre escenas
			DontDestroyOnLoad(gameObject);	
		}	
	}

	
	// Update is called once per frame
	void Update () {

		/*if(Time.timeScale==0){
			audio.Pause();
		}*/
			
	}
}
