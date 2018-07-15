using UnityEngine;
using System.Collections;

public class TriggerLados : MonoBehaviour {

	public bool TriggerIzquierda; // MARCAR ESTA OPCION EN EL INSPECTOR PARA CUANDO EL SCRIPT TRABAJE AL LADO IZQUIERDO
	public bool TriggerDerecha; // MARCAR ESTA OPCION EN EL INSPECTOR PARA CUANDO EL SCRIPT TRABAJE AL LADO DERECHO
	private GameObject Personaje;

	// Use this for initialization
	void Start () {
		Personaje=GameObject.Find("personaje");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D hit){

		if(TriggerDerecha){
			if(hit.tag=="suelo"){
				//print ("esta tocando el trigger derecho");
				Personaje.GetComponent<PlayerMotionStart>().EstaEsquinaD=true;
			}
		}

		if(TriggerIzquierda){
			if(hit.tag=="suelo"){
				//print ("esta tocando el trigger izquierdo");
				Personaje.GetComponent<PlayerMotionStart>().EstaEsquinaI=true;
			}
		}

	}

	void OnTriggerExit2D(Collider2D hit){

		if(TriggerDerecha){
			if(hit.tag=="suelo"){
				//print ("esta tocando el trigger derecho");
				Personaje.GetComponent<PlayerMotionStart>().EstaEsquinaD=false;
			}
		}
		
		if(TriggerIzquierda){
			if(hit.tag=="suelo"){
				//print ("esta tocando el trigger izquierdo");
				Personaje.GetComponent<PlayerMotionStart>().EstaEsquinaI=false;
			}
		}


	}

}
