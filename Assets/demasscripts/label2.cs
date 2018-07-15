using UnityEngine;
using System.Collections;

public class label2 : MonoBehaviour {

	// Use this for initialization
	float virtualWidth = 1024f; 
	
	float virtualHeight = 768f; 
	public GUIStyle estilo;
	private Matrix4x4 matrizinicial;
	private Matrix4x4 matriz;
	
	void Start () { 
		matrizinicial=GUI.matrix;
		//print (GUI.matrix);
		//estilo=new GUIStyle(){};
	} 
	
	void OnGUI () 
		
	{ 

		matriz = Matrix4x4 . TRS ( Vector3.zero , Quaternion.identity , new Vector3( Screen.width /virtualWidth, Screen.height /virtualHeight, 1.0f ) ) ; 
		GUI.matrix=matriz ; 

		GUI.Label(new Rect(512,384,30,50),"esto es una prueba",estilo);

		/*
		GUI.matrix=matrizinicial;
		GUI.Label(new Rect(Screen.width/2,Screen.height*0.1f,Screen.height*0.3f,Screen.height*0.4f),"esto es una prueba 2");
		//GUI.Label(new Rect(Screen.width/2, Screen.height/2,0,0),"BLAH",estilo);
		GUI.Label (new Rect (Screen.width/2-50, Screen.height/2-25, 100,50), "BLAH",estilo); 
		//GUILayout.Label("hola mundo esto es una prueba"); 


        */

	} 
}
