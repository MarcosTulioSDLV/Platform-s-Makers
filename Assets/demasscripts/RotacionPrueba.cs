using UnityEngine;
using System.Collections;

public class RotacionPrueba : MonoBehaviour {

	private float anguloGradosComun;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			transform.Rotate(new Vector3(0,0,1f)*Time.deltaTime*30);
		}

		//print("local r: "+transform.localRotation.z+" rotation: "+transform.rotation.z+" euler"+ transform.eulerAngles.z);

		/*anguloGradosComun=transform.eulerAngles.z;
		if(transform.eulerAngles.z>=360){
			anguloGradosComun=transform.eulerAngles.z-360;

		}*/

		print (anguloGradosComun);
		//transform.localRotation=Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,Mathf.Clamp(transform.localRotation.z,0,360));
	
	}
}
