using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_VariableDisplay : MonoBehaviour {

	private Text uiText;

	public FloatReference variable;

	// Use this for initialization
	void Start ()
	{
		uiText  = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		float value = variable; //not necessary to do ".value". Here it's trivial, but it might come in handy later?
		uiText.text = value.ToString();
	}
}
