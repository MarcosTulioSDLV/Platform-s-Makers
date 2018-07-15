using UnityEngine;
using System.Collections;

public class OnClickContinuar : MonoBehaviour {

	private GameObject FondoNubes;
	private GameObject TextoReintentar;
	private GameObject TextoSiguienteNivel;
	private GameObject TextoSalir;

	private GameObject efectosSonidos;


	// Use this for initialization
	void Start () {
		FondoNubes=GameObject.Find("fondo nuves");// CODIGO DE PAUSAR
		TextoReintentar=GameObject.Find("textobotonreintentar");
		TextoSiguienteNivel=GameObject.Find("textobotonsiguiente");
		TextoSalir=GameObject.Find("textobotonsalir");

		efectosSonidos=GameObject.Find("efectos sonidos");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//print ("se undio continuar");
		efectosSonidos.GetComponent<ScriptAudio>().Sonido1Activado=true; // ACTIVA SONIDO BOTON

		Vector3 vectorTemporal=transform.position;
		vectorTemporal.z=3;
		FondoNubes.transform.position=vectorTemporal;
		
		//desactivar los textos
		if(Application.loadedLevelName!="nivel3facil" && Application.loadedLevelName!="nivel3medio" && Application.loadedLevelName!="nivel3dificil")
			TextoSiguienteNivel.gameObject.SetActive(false);
		
		TextoReintentar.SetActive(false);
		TextoSalir.SetActive(false);
		gameObject.SetActive(false);
		Time.timeScale=1;
	}
}
