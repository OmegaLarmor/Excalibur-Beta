
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{

    Color color;
	

    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorizer");
    }


    void OnGUI()
    {

        GUILayout.Label("Color the selected objects", EditorStyles.boldLabel);
        
		color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("Colorize"))
        {
			ColorSelection(color);
        }

    }

	void ColorSelection(Color color)
	{

		foreach (GameObject go in Selection.gameObjects)
		{

			Renderer renderer = go.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.sharedMaterial.color = color;
			}

		}
			
	}

}
