using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegShot : MonoBehaviour
{
	private LegShotManager LegShotManager;
	void Start()
	{
		LegShotManager = GetComponentInParent<LegShotManager>();
	}
	
	
	public void LegHasBeenShot()
	{
		string legName = gameObject.name;
		
		
		// Set the corresponding legWasShot variable to true
		if (legName == "UpperLeg_L")
		{
			LegShotManager.LegShotLowerL = true;
			transform.localScale *= 0.001f;
			LegShotManager.LegShotUpdate();
		
		}
		else if (legName == "UpperLeg_R")
		{
			LegShotManager.LegShotUpperR = true;
			transform.localScale *= 0.001f;
			LegShotManager.LegShotUpdate();
		
		}
		
		//i dont want the lower leg to count, they are just turned small
		else if (legName == "LowerLeg_R")
		{
			LegShotManager.LegShotLowerR = true;
			transform.localScale *= 0.001f;
			LegShotManager.LegShotUpdate();

		}
		else if (legName == "LowerLeg_L")
		{
			LegShotManager.LegShotLowerL = true;
			transform.localScale *= 0.001f;
			LegShotManager.LegShotUpdate();
		}
	}
	
		
   

}
