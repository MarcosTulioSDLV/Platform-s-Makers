using UnityEngine;
using System.Collections;

public class OnClickSalir : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print("salio");
		Application.Quit();
	}
}
