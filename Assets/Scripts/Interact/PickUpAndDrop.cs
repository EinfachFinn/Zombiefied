using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
	
	[Header("Current Weapon")]
	public Camera cam;
	public float distance = 3f;
	
	[Header("ThisSlot")]
	public bool isfull;
	
	[Header("Current Weapon")]
	private GameObject currentWeapon;
	private Rigidbody rigidbody;
	
	
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.E))
	    {
		    PickUp();
	    }   
	    else if (Input.GetKeyDown(KeyCode.Q))
	    {
		    Drop();
	    }  
    }
    
	void PickUp()
	{
		//checks if slot is full if(yes) do Drop() and ask again. if(no) do the PickUpStuff
		if (isfull == true)
		{
			Drop();
			PickUp();
		}
		else
		{
			//Shoot Ray to detect
			Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        
			RaycastHit hitInfo; //What came out
			//if in reach distance
			if (Physics.Raycast(ray, out hitInfo, distance))
			{
				//if the object is Weapon
				if (hitInfo.transform.gameObject.GetComponent<Weapon>() != null)
				{
					//make the currentWeaponVariable the Weapon
					currentWeapon = hitInfo.transform.gameObject;
					//Disable Physics
					currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
					currentWeapon.GetComponent<BoxCollider>().enabled = false;
					
					//Make Child of Slot
					currentWeapon.transform.SetParent(this.gameObject.transform);
					//transform 
					currentWeapon.transform.position = this.gameObject.transform.position;
					currentWeapon.transform.rotation = this.gameObject.transform.rotation;
					isfull = true;

				}
			}
		}
	}
	
	void Drop()
	{
	
	}

	
}
