using UnityEngine;
using System.Collections;

public class EventosBotonesMenu1 : MonoBehaviour {

	private SpriteRenderer miSprite;
	private Vector3 tamañoInicial;
	private bool primerFrame=true;
	private Sprite spriteOriginal;
	public Sprite SpriteNuevo;

	private GameObject efectosSonidos;

	// Use this for initialization
	void Start () {
		miSprite=gameObject.GetComponent<SpriteRenderer>();
		tamañoInicial=transform.localScale;
		spriteOriginal=gameObject.GetComponent<SpriteRenderer>().sprite;
	
		efectosSonidos=GameObject.Find("efectos sonidos");
	}
	
	// Update is called once per frame
	void Update () {
     
	}

	void OnMouseOver(){
	
		if(primerFrame){	
		efectosSonidos.GetComponent<ScriptAudio>().Sonido2Activado=true; // ACTIVA SONIDO BOTON

		transform.localScale=transform.localScale*1.2f;
			/*Vector3 nuevoTamaño=transform.localScale;
			nuevoTamaño.x+=0.2f;
			nuevoTamaño.y+=0.2f;
			transform.localScale=nuevoTamaño;*/

		//miSprite.color=Color.blue;
			miSprite.sprite=SpriteNuevo;
			primerFrame=false;
		}
	}

	void OnMouseExit(){
	    transform.localScale=transform.localScale/1.2f;
		miSprite.sprite=spriteOriginal;
	//transform.localScale=tamañoInicial;
		//miSprite.color=Color.white;
	    primerFrame=true;
	}
}
