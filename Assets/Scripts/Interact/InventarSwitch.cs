using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarSwitch : MonoBehaviour
{
	public PickUpAndDrop PickUpAndDrop;
	public int SlotNumber;
	public GameObject Slot1;
	public GameObject Slot2;
	public GameObject Slot3;
	
	
	
	void Start()
	{
		PickUpAndDrop.CurrentSlot = Slot1;
		SlotNumber = 1;
		Changed();
	}
   
   
   
	public void Left()
	{
		SlotNumber -= 1;
		if (SlotNumber < 1)
		{
			SlotNumber = 3;
		} 
		Changed();
		
	}
	
	
	public void Right()
	{
		SlotNumber += 1;
		if (SlotNumber > 3)
		{
			SlotNumber = 1;
		}
		Changed();

	}
	
	
    void Changed()
	{
    	
	    if (SlotNumber == 1)
	    {
		    PickUpAndDrop.CurrentSlot = Slot1;
	    	Slot1.SetActive(true);
		    Slot2.SetActive(false);
		    Slot3.SetActive(false);
		    if(PickUpAndDrop.CurrentSlot.transform.childCount > 0) {PickUpAndDrop.CurrentSlotIsfull = true;}
		    else{PickUpAndDrop.CurrentSlotIsfull = false;}
	    }
	    else if (SlotNumber == 2)
	    {
		    PickUpAndDrop.CurrentSlot = Slot2;
	    	Slot1.SetActive(false);
		    Slot2.SetActive(true);
		    Slot3.SetActive(false);
		    if(PickUpAndDrop.CurrentSlot.transform.childCount > 0) {PickUpAndDrop.CurrentSlotIsfull = true;}
		    else{PickUpAndDrop.CurrentSlotIsfull = false;}
	    }
	    else if (SlotNumber == 3)
	    {
		    PickUpAndDrop.CurrentSlot = Slot3;
		    Slot1.SetActive(false);
		    Slot2.SetActive(false);
		    Slot3.SetActive(true);
		    if(PickUpAndDrop.CurrentSlot.transform.childCount > 0) {PickUpAndDrop.CurrentSlotIsfull = true;}
		    else{PickUpAndDrop.CurrentSlotIsfull = false;}
	    }
    }
}
