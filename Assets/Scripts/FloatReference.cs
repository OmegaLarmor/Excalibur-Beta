using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatReference : ScriptableObject {

	public bool useConstant = true;
	public float constantValue;

	public bool resetOnPlay = true;
	public float resetValue = 0;

	public FloatVariable variable;

	public float value
	{
		get
		{
			return useConstant ? constantValue : variable.value;
		}

		set
		{

		}
	}

	// The 2000-IQ big brain play.
	// Allows stuff like:
	// float myNewFloat = myFloatReference
	// and AVOIDS having to write myFloatReference.value :D
	public static implicit operator float(FloatReference rhs)
	{
		return rhs.value;
	}

	
	public static implicit operator FloatReference(float rhs)
	{ 
		FloatReference var = new FloatReference();
		var.value = rhs;

		return var;

	}
}
