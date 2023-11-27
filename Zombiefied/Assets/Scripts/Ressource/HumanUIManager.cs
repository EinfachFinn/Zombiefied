using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HumanUIManager : MonoBehaviour
{
	public HumanType Human;
	public TMP_Text Name;
	public TMP_Text Job;
	public Slider Health;
	public Slider Energy;
	public Image Image;
	
	private MoneyManager MoneyManager;
	private HumanManager HumanManager;
	
	
	[Header("Buttons")]
	public GameObject Farmer;
	public GameObject Medic;
	public GameObject Guard;
	public GameObject Soldier;
	public GameObject Sniper;
	
	void Start()
	{
		
		MoneyManager = FindObjectsOfType<MoneyManager>()[0];
		HumanManager = FindObjectsOfType<HumanManager>()[0];
	}
	
	public void LearnFarmer() //Food
	{
		if(MoneyManager.Cash > MoneyManager.Farmer)
		{	
			MoneyManager.Cash -= MoneyManager.Farmer;
			Human.Farmer = true;
			Human.Medic = false;
			Human.Guard = false;
			Human.Soldier = false;
			Human.Sniper = false;
			Human.Job = "Farmer";
			Debug.Log("Farmer learned");
			Human.gameObject.tag ="Farmer";

			Human.transform.GetComponent<Job_Farmer>().enabled = true;
			Human.transform.GetComponent<Job_Guard>().enabled = false;
			Human.transform.GetComponent<Job_Medic>().enabled = false;
			Human.transform.GetComponent<Job_Sniper>().enabled = false;
			Human.transform.GetComponent<Job_Soldier>().enabled = false;
			HumanManager.FindAndStoreHumans();

		}
		else
		{
			Debug.Log("Not enough Money");
		}
		
		
	}
	
	
	
	public void LearnMedic() //Heal Guards (not Energy just health)
	{
		if(MoneyManager.Cash > MoneyManager.Medic)
		{	
			MoneyManager.Cash -= MoneyManager.Medic;
			Human.Farmer = false;
			Human.Medic = true;
			Human.Guard = false;
			Human.Soldier = false;
			Human.Sniper = false;
			Human.Job = "Medic";
			Human.gameObject.tag ="Medic";
			Human.transform.GetComponent<Job_Farmer>().enabled = false;
			Human.transform.GetComponent<Job_Guard>().enabled = false;
			Human.transform.GetComponent<Job_Medic>().enabled = true;
			Human.transform.GetComponent<Job_Sniper>().enabled = false;
			Human.transform.GetComponent<Job_Soldier>().enabled = false;
			HumanManager.FindAndStoreHumans();

		}
		else
		{
			Debug.Log("Not enough Money");
		}
	}
	
	
	
	public void LearnGuard() //Melee defending
	{
		if(MoneyManager.Cash > MoneyManager.Guard)
		{	
			MoneyManager.Cash -= MoneyManager.Guard;
			Human.Farmer = false;
			Human.Medic = false;
			Human.Guard = true;
			Human.Soldier = false;
			Human.Sniper = false;
			Human.Job = "Guard";
			Human.gameObject.tag="Guard";
			Human.transform.GetComponent<Job_Farmer>().enabled = false;
			Human.transform.GetComponent<Job_Guard>().enabled = true;
			Human.transform.GetComponent<Job_Medic>().enabled = false;
			Human.transform.GetComponent<Job_Sniper>().enabled = false;
			Human.transform.GetComponent<Job_Soldier>().enabled = false;
			HumanManager.FindAndStoreHumans();
		}
		else
		{
			Debug.Log("Not enough Money");
		}
	}
	
	
	
	public void LearnSoldier() //Rifle defending
	{
		if(MoneyManager.Cash > MoneyManager.Soldier)
		{	
			MoneyManager.Cash -= MoneyManager.Soldier;
			Human.Farmer = false;
			Human.Medic = false;
			Human.Guard = false;
			Human.Soldier = true;
			Human.Sniper = false;
			Human.Job = "Soldier";
			Human.gameObject.tag="Soldier";
			Human.transform.GetComponent<Job_Farmer>().enabled = false;
			Human.transform.GetComponent<Job_Guard>().enabled = false;
			Human.transform.GetComponent<Job_Medic>().enabled = false;
			Human.transform.GetComponent<Job_Sniper>().enabled = false;
			Human.transform.GetComponent<Job_Soldier>().enabled = true;
			HumanManager.FindAndStoreHumans();
		}
		else
		{
			Debug.Log("Not enough Money");
		}
		
	}
	
	
	

	public void LearnSniper() //Sniper defending
	{
		if(MoneyManager.Cash > MoneyManager.Sniper)
		{	
			MoneyManager.Cash -= MoneyManager.Sniper;
			Human.Farmer = false;
			Human.Medic = false;
			Human.Guard = false;
			Human.Soldier = false;
			Human.Sniper = true;
			Human.Job = "Sniper";
			Human.gameObject.tag="Sniper";
			Human.transform.GetComponent<Job_Farmer>().enabled = false;
			Human.transform.GetComponent<Job_Guard>().enabled = false;
			Human.transform.GetComponent<Job_Medic>().enabled = false;
			Human.transform.GetComponent<Job_Sniper>().enabled = true;
			Human.transform.GetComponent<Job_Soldier>().enabled = false;
			HumanManager.FindAndStoreHumans();
		}
		else
		{
			Debug.Log("Not enough Money");
		}
	}
	
	
	
}
