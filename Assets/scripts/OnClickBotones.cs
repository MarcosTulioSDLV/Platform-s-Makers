using UnityEngine;
using System.Collections;

public class OnClickBotones : MonoBehaviour {

	public bool BotonSalir;
	public bool botonSiguienteNivel;
	public bool botonReintentar;
	private string NombreEscenaActual;
	public string NombreEscenaSiguiente;

	private GameObject efectosSonidos;

	// Use this for initialization
	void Start () {
		NombreEscenaActual=Application.loadedLevelName;
		efectosSonidos=GameObject.Find("efectos sonidos");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if(BotonSalir){
			efectosSonidos.GetComponent<ScriptAudio>().Sonido1Activado=true; // ACTIVA SONIDO BOTON
			Application.LoadLevel("menuinicial");
			Time.timeScale=1;
		}
		if(botonSiguienteNivel){
			efectosSonidos.GetComponent<ScriptAudio>().Sonido1Activado=true; // ACTIVA SONIDO BOTON
			Application.LoadLevel(NombreEscenaSiguiente);
			Time.timeScale=1;
		}
		if(botonReintentar){
			efectosSonidos.GetComponent<ScriptAudio>().Sonido1Activado=true; // ACTIVA SONIDO BOTON
			Application.LoadLevel(NombreEscenaActual);
			Time.timeScale=1;
		}
	}

}
