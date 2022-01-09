using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class crosshairRaycast : MonoBehaviour 
{
	public Texture2D hoverCrosshair;
	bool triggered = false;
	public Rect position;
	public InputActionReference triggerReference;
	public GameObject rayOrigin;
	void Start()
	{
		triggered = false;
		triggerReference.action.performed += TriggerActivate;
	}
	void Update()
    {		
		triggered = false;
		checkHover();
	}
	void OnGUI() {
		position = new Rect((Screen.width - hoverCrosshair.width) / 2, (Screen.height - hoverCrosshair.height) / 2, hoverCrosshair.width, hoverCrosshair.height);
		if (triggered)
		{
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 400, 400), "press trigger");
			GUI.DrawTexture(position, hoverCrosshair);
		}
	}
	private void checkHover()
    {
		RaycastHit hit;
		if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hit, Mathf.Infinity))
		{
			InteractiveObject hitObj = hit.collider.GetComponent<InteractiveObject>();
			if (hitObj)
			{
				triggered = true;
			}
		}
	}
	public void TriggerActivate(InputAction.CallbackContext obj)
	{
		RaycastHit hit;

		if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hit, Mathf.Infinity))
		{
			InteractiveObject hitObj = hit.collider.GetComponent<InteractiveObject>();
			if (hitObj)
			{
				hitObj.TrigegrInteraction();
			}
		}
	}
	
}