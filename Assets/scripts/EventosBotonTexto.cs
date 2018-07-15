using UnityEngine;
using System.Collections;

public class EventosBotonTexto : MonoBehaviour {


	private Color colorPorDefecto;
	private Vector3 tamañoPorDefecto;
	public int FactorTamañoTexto=10;
	private TextMesh mitextMesh;
	private bool primerFrame=true;


	private GameObject efectosSonidos;
 
	void Start(){
		mitextMesh=gameObject.GetComponent<TextMesh>();
		colorPorDefecto=mitextMesh.color;
		tamañoPorDefecto=mitextMesh.transform.localScale;
		//tamañoPorDefecto=mitextMesh.fontSize;
		efectosSonidos=GameObject.Find("efectos sonidos");
	}

	void OnMouseOver(){
		//print ("puntero esta encima");
		PonerEfectosBotonTexto();
	}

	void OnMouseExit(){
		//print ("puntero salio");
		QuitarEfectosBotonTexto();
	}

	private void PonerEfectosBotonTexto(){
		if(primerFrame){
			efectosSonidos.GetComponent<ScriptAudio>().Sonido2Activado=true; // ACTIVA SONIDO BOTON
			
			mitextMesh.color=Color.black;
			mitextMesh.transform.localScale=tamañoPorDefecto*1.2f;
			//mitextMesh.fontSize+=FactorTamañoTexto;
			primerFrame=false;
		}
	} 

	public void QuitarEfectosBotonTexto(){
		mitextMesh.color=colorPorDefecto;
		mitextMesh.transform.localScale=tamañoPorDefecto;
		//mitextMesh.fontSize=tamañoPorDefecto;
		primerFrame=true;
	}


}
