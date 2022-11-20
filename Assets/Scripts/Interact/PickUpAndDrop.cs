using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
	
	[Header("Current Weapon")]
	public Camera cam;
	public float distance = 3f;
	
	
	
	
	[Header("Debug")]
	public GameObject CurrentSlot;
	public bool CurrentSlotIsfull;
	
	[Header("Current Weapon")]
	private GameObject currentWeapon;
	private Rigidbody rigidbody;
	



	
	public void PickUp()
	{
		//checks if slot is full if(yes) do Drop() and ask again. if(no) do the PickUpStuff
		if(CurrentSlot.transform.childCount > 0)
		{
			Debug.Log("CurrentSlot is full");
			Drop();
			PickUpProcess();
		}
		else
		{
			PickUpProcess();
		}
		
	}
	
	
	
	
	
	public void PickUpProcess()
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
					currentWeapon.GetComponent<ProjectileGun>().enabled = true;
					
					//Make Child of Slot
					currentWeapon.transform.SetParent(CurrentSlot.gameObject.transform);
					//transform 
					currentWeapon.transform.position = CurrentSlot.gameObject.transform.position;
					currentWeapon.transform.rotation = CurrentSlot.gameObject.transform.rotation;
					CurrentSlotIsfull = true;
				}
			}
	}
	
	
	public void Drop()
	{
		CurrentSlot.transform.DetachChildren();
		currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
		currentWeapon.GetComponent<BoxCollider>().enabled = true;
		currentWeapon.GetComponent<ProjectileGun>().enabled = false;
	}

	
}
