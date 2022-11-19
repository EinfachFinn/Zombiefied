using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public UnityEvent InteractEvent;
    public UnityEvent OnLookEvent;
    public UnityEvent OfLookEvent;
    //message displayed when looking at interactable

    public void Interact()
     {
        InteractEvent.Invoke();
        Debug.Log(gameObject.name + "Interactable Component");

     }

    public void OnLook()
    {
        OnLookEvent.Invoke();
    }
    
	public void OffLook()
    {
        OfLookEvent.Invoke();
    }
}
