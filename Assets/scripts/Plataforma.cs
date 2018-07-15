using UnityEngine;
using System.Collections;

public class Plataforma : MonoBehaviour {

	public float Speed=0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right*Speed*Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D col){
		//print ("entro");
		/*if(col.transform.name=="personaje" || col.transform.name=="personaje box"){
			col.transform.parent=gameObject.transform;
		}*/
	}

	void OnCollisionExit2D(Collision2D col){
		//print ("salio");	
		/*if(col.transform.name=="personaje" || col.transform.name=="personaje box"){
			transform.DetachChildren();
		}*/
	}
}
