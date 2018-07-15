using UnityEngine;
using System.Collections;

public class ScriptAudio : MonoBehaviour {

	private AudioSource Miaudio;
	public AudioClip Sonido1;
	public AudioClip Sonido2;
	public AudioClip Sonido3;
	public AudioClip Sonido4;
	public AudioClip Sonido5;
	public bool Sonido1Activado,Sonido2Activado,Sonido3Activado,Sonido4Activado,Sonido5Activado;

	// COIDGO PATRON SINGLETON
	//Referencia estatica a la clase
	private static ScriptAudio instance;
	//Podemos coger la referencia desde otras clase pero no modificarla
	public static ScriptAudio  Instance { get; private set;}
	

	// Use this for initialization
	void Start () {
		Miaudio=gameObject.GetComponent<AudioSource>(); 
	
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
	
		if(Sonido1Activado){
			PlaySonido(Sonido1,ref Sonido1Activado);
		}
		else if(Sonido2Activado){
			PlaySonido(Sonido2,ref Sonido2Activado);
		}
		else if(Sonido3Activado){
			PlaySonido(Sonido3,ref Sonido3Activado);
		}
		else if(Sonido4Activado){
			PlaySonido(Sonido4,ref Sonido4Activado);
		}
		else if(Sonido5Activado){
			PlaySonido(Sonido5,ref Sonido5Activado);
		}
	}

	private void PlaySonido(AudioClip sonido,ref bool sonidoActivado){
		Miaudio.PlayOneShot(sonido);
		sonidoActivado=false; 
	}
}
