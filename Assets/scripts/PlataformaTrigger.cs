using UnityEngine;
using System.Collections;

public class PlataformaTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		print ("algo entro al trigger");
		if(col.transform.tag=="personaje"){
			col.transform.parent=transform;
	       }
	}

	void OnTriggerExit2D(Collider2D col){
		print ("algo salio del trigger");
		if(col.transform.tag=="personaje"){
			col.transform.parent=null;
		}
	}
}
