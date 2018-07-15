using UnityEngine;
using System.Collections;

public class SinRotacion : MonoBehaviour {
	
	private Quaternion rotacionInicial;
	// Use this for initialization
	void Start () {
		rotacionInicial=transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation=rotacionInicial;
	}


}
