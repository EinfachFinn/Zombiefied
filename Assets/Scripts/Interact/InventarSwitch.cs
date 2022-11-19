using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarSwitch : MonoBehaviour
{
	
	public GameObject Slot1;
	public GameObject Slot2;
	public GameObject Slot3;
	
	void Start()
	{
		Slot1.SetActive(true);
		Slot2.SetActive(false);
		Slot3.SetActive(false);
	}
   
   
   
   
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	    	Slot1.SetActive(true);
		    Slot2.SetActive(false);
		    Slot3.SetActive(false);
	    }
	    else if (Input.GetKeyDown(KeyCode.Alpha2))
	    {
	    	Slot1.SetActive(false);
		    Slot2.SetActive(true);
		    Slot3.SetActive(false);
	    }
	    else if (Input.GetKeyDown(KeyCode.Alpha3))
	    {
		    Slot1.SetActive(false);
		    Slot2.SetActive(false);
		    Slot3.SetActive(true);
	    }
    }
}
