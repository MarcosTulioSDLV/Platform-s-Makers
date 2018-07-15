using UnityEngine;
using System.Collections;

public class BotonReintentar : MonoBehaviour {

	void OnMouseDown(){
		Debug.Log ("undio el boton reintentar");
		Time.timeScale=1;
		Application.LoadLevel("escena1");
	}


}
