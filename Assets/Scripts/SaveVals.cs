using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class SaveVals : MonoBehaviour {

public InputField nameField;
public InputField aweField;

[System.Serializable]
public struct fancyStruct {
	public string name;
	public string awesomeness;
}

//////////  Saving  ///////////////
	public void saveInPrefs(string key, string val) {

		PlayerPrefs.SetString(key, val);
	}

	public void saveInPrefs(string key, int val) {

		PlayerPrefs.SetInt(key,val);
	}

	public void saveInPrefs(string key, float val) {

		PlayerPrefs.SetFloat(key,val);
	}


	public void saveAll() {
		
		saveInPrefs("name", nameField.text);
		saveInPrefs("awesomeness", aweField.text);
	}


	public void saveTurbo() {

		fancyStruct toSave;
		toSave.name = nameField.text;
		toSave.awesomeness = aweField.text;

		string FullFilePath = Application.persistentDataPath + "/" + "turboSave" + ".bin";

		// We must create a new Formattwr to Serialize with.
		BinaryFormatter Formatter = new BinaryFormatter();
		// Create a streaming path to our new file location.
		FileStream fileStream = new FileStream(FullFilePath, FileMode.Create);
		// Serialize the object to the File Stream
		Formatter.Serialize(fileStream, toSave);
		// FInally Close the FileStream and let the rest wrap itself up.
		fileStream.Close();


	}

/////////// Loading /////////////
	public string loadInPrefs(string key) {

		return PlayerPrefs.GetString(key,"None");

	}


	public void loadAll() {
		
		nameField.text = loadInPrefs("name");
		aweField.text = loadInPrefs("awesomeness");

	}


	public void loadTurbo() {

		string FullFilePath = Application.persistentDataPath + "/" + "turboSave" + ".bin";
		fancyStruct result;

		// Check if our file exists, if it does not, just return a null object.
		if (File.Exists(FullFilePath))
		{
			BinaryFormatter Formatter = new BinaryFormatter();
			FileStream fileStream = new FileStream(FullFilePath, FileMode.Open);
			object obj = Formatter.Deserialize(fileStream);
			fileStream.Close();
			// Return the uncast untyped object.
			result =  (fancyStruct) obj;
		}
		else
		{
			Debug.Log("Error...");
			return;
		}

		nameField.text = result.name;
		aweField.text = result.awesomeness;

	}


	void Start() {

		loadAll();
	}
}
