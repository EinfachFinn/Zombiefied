using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

	public int Cash = 0;
	
	private void Start()
	{

	}

	public void AddMoney(int amount)
	{
		Cash += amount;

	}

	public void SubtractMoney(int amount)
	{
		if(Cash > amount)
		{	
			Cash -= amount;
		}
		else
		{
			Debug.Log("Not enough Money");
		}
	}
	

}
