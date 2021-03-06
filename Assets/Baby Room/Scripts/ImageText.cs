using UnityEngine;
using System.Collections;

public class ImageText : MonoBehaviour
{
	bool triggered = false;
	public Texture2D crosshair;
	private Rect position;


	void OnTriggerHover()
	{
		triggered = true;
	}

	void OnTriggerExit()
	{
		triggered = false;
	}
	void OnGUI() {
		if(triggered){
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2-50,400,400),"Click on mouse");
		GUI.DrawTexture (position, crosshair);
		position = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) /2, crosshair.width, crosshair.height);

	}
	}
}