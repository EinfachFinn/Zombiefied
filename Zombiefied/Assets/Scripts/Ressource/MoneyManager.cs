using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

	public int Cash = 0;
	
	[Header("Prices")]
	public int Farmer = 100;
	public int Medic = 500;
	public int Guard = 1000;
	public int Soldier = 2000;
	public int Sniper = 5000;

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
