using UnityEngine;
using System.Collections;

public class ScriptSonido : MonoBehaviour {

	public AudioClip audio1,audio2,audio3,audio4,audio5,audio6; 
	public static bool activarsonido1;
	public static bool activarsonido2;
	public static bool activarsonido3;
	public static bool activarsonido4;
	public static bool activarsonido5;
	public static bool activarsonido6;
	private static ScriptSonido  instance = null;//para lo de la instancia
	public static ScriptSonido  Instance { get { return instance; } } 
	
	void Awake(){
		DontDestroyOnLoad(this.transform);
		if (instance != null && instance != this) { Destroy(this.gameObject); return; }
		else { instance = this; }
		DontDestroyOnLoad(this.gameObject);
	}
	
	// sonidos 
	public void PlaySonido(AudioClip sonido,ref bool condicion){
		GetComponent<AudioSource>().PlayOneShot(sonido);
		condicion=false;	
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(activarsonido1){
			PlaySonido(audio1,ref activarsonido1);
		}
		else if(activarsonido2){
			PlaySonido(audio2,ref activarsonido2);
		}else if(activarsonido3){
			PlaySonido(audio3,ref activarsonido3);
		}
		else if(activarsonido4){
			PlaySonido(audio4,ref activarsonido4);
		}
		else if(activarsonido5){
			PlaySonido(audio5,ref activarsonido5);
		}
		else if(activarsonido6){
			PlaySonido(audio6,ref activarsonido6);
		}

	}

}



