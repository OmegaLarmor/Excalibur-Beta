using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResetAllVars : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Variables");
        FileInfo[] info = dir.GetFiles("*.asset");
        
        foreach (FileInfo f in info) 
        { 
			string splitName = f.Name.Split('.')[0];
			//Debug.Log(f.Name.Split('.')[0]);
			//Debug.Log(Resources.Load("Variables/Square"));
         	FloatReference myvar = Resources.Load("Variables/"+splitName) as FloatReference;
			Debug.Log(myvar);

			 if (myvar.resetOnPlay) {
				 Debug.Log(myvar.value);
				 myvar = myvar.resetValue;
			 }
        }
	}
	

}
