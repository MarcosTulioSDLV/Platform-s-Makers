using UnityEngine;
using System.Collections;

public class OnClickBotonesMenu : MonoBehaviour {

	private GameObject efectosSonidos;

	void Start () {
		efectosSonidos=GameObject.Find("efectos sonidos");
	}

	public string NombreEscena;
			
	void OnMouseDown(){
		//Debug.Log ("undio el boton reintentar");
		efectosSonidos.GetComponent<ScriptAudio>().Sonido1Activado=true; // ACTIVA SONIDO BOTON
		Application.LoadLevel(NombreEscena);
		//Time.timeScale=1;
	}
}
