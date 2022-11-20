using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour
{
    [Tooltip("Camera a Raycast is being Shot from")]
    public Camera cam;

    [Header("Raycast")]

    [Tooltip("From how far interaction is working")]
    public float distance = 3f;

	/*
	blue NormalRaycast
	green Interactable
	
	
	*/
	
	
	
    private Interactable currentInteractable;

    // Update is called once per frame
	public void Update()
    { 
        //Shoot ray from Cam forward
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        
        RaycastHit hitInfo; //What came out
	    
	    //Draw NormalRay
	    Debug.DrawRay(ray.origin, ray.direction * distance, Color.blue);
        
	    
	    //if its in Range
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
	        //if the object is interactable
	        if (hitInfo.transform.gameObject.GetComponent<Interactable>() != null)
	        {
		        //assign currentInteractable script
		        currentInteractable = hitInfo.transform.gameObject.GetComponent<Interactable>();
		        //Draw InteractableRay
		        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
		        currentInteractable.OnLook();
		    	

	        }
	        else
	        {
		        currentInteractable.OffLook();
	        }
          
        }
        else
        {
	    	currentInteractable.OffLook();
        }
        

    }
    
	public void Interact()
	{
		currentInteractable.Interact();
	}

    
}
