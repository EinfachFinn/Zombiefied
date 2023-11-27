using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class JobManager : MonoBehaviour
{
	[Header("Human")]
	public int HumanCount;
	public int HumanBedCount;
	public int HumanBedCountMultiplikator;
	[Header("Farmer")]
	public int FarmerCount;
	public int FarmerBuildingCount;
	public int FarmerBuildingMultiplikator;

	[Header("Medic")]
	public int MedicCount;
	public int MedicBuildingCount;
	public int MedicBuildingMultiplikator;

	[Header("Guard")]
	public int GuardCount;
	public int GuardBuildingCount;
	public int GuardBuildingMultiplikator;

	[Header("Soldier")]
	public int SoldierCount;
	public int SoldierBuildingCount;
	public int SoldierBuildingMultiplikator;

	[Header("Sniper")]
	public int SniperCount;
	public int SniperBuildingCount;
	public int SniperBuildingMultiplikator;

	
	[Space]
	[Space]
	[Space]
	[Space]
	
	[Header("UI")]
	
	[Header("Human")]
	[SerializeField]
	private TMP_Text UIHumanCount;
	[SerializeField]
	private TMP_Text UIHumanBedCount;
	
	[Header("Farmer")]
	[SerializeField]
	private TMP_Text UIFarmerCount;
	[SerializeField]
	private TMP_Text UIFarmerBuildingCount;


	[Header("Medic")]
	[SerializeField]
	private TMP_Text UIMedicCount;
	[SerializeField]
	private TMP_Text UIMedicBuildingCount;


	[Header("Guard")]
	[SerializeField]
	private TMP_Text UIGuardCount;
	[SerializeField]
	private TMP_Text UIGuardBuildingCount;


	[Header("Soldier")]
	[SerializeField]
	private TMP_Text UISoldierCount;
	[SerializeField]
	private TMP_Text UISoldierBuildingCount;


	[Header("Sniper")]
	[SerializeField]
	private TMP_Text UISniperCount;
	[SerializeField]
	private TMP_Text UISniperBuildingCount;


	public void UpdateCount()
	{
		

		GameObject[] HumanList = GameObject.FindGameObjectsWithTag("UnassignedHuman");
		HumanCount = HumanList.Length;
		UIHumanCount.text = HumanCount.ToString();
		GameObject[] HumanBedCountList = GameObject.FindGameObjectsWithTag("HumanBedBuilding");
		HumanBedCount = HumanBedCountList.Length*HumanBedCountMultiplikator;
		UIHumanBedCount.text = HumanBedCount.ToString();
		
		
		
		
		
		
		GameObject[] FarmerList = GameObject.FindGameObjectsWithTag("Farmer");
		FarmerCount = FarmerList.Length;
		UIFarmerCount.text = FarmerCount.ToString();
		GameObject[] FarmerBuildingList = GameObject.FindGameObjectsWithTag("FarmerBuilding");
		FarmerBuildingCount = FarmerBuildingList.Length*FarmerBuildingMultiplikator;
		UIFarmerBuildingCount.text =  FarmerBuildingCount.ToString();

		
		GameObject[] MedicList = GameObject.FindGameObjectsWithTag("Medic");
		MedicCount = MedicList.Length;
		UIMedicCount.text = MedicCount.ToString();
		GameObject[] MedicBuildingList = GameObject.FindGameObjectsWithTag("MedicBuilding");
		MedicBuildingCount = MedicBuildingList.Length*MedicBuildingMultiplikator;
		UIMedicBuildingCount.text =MedicBuildingCount.ToString();
		
		GameObject[] GuardList = GameObject.FindGameObjectsWithTag("Guard");
		GuardCount = GuardList.Length;
		UIGuardCount.text = GuardCount.ToString();
		GameObject[] GuardBuildingList = GameObject.FindGameObjectsWithTag("GuardBuilding");
		GuardBuildingCount = GuardBuildingList.Length*GuardBuildingMultiplikator;
		UIGuardBuildingCount.text = GuardBuildingCount.ToString();
		
		
		GameObject[] SoldierList = GameObject.FindGameObjectsWithTag("Soldier");
		SoldierCount = SoldierList.Length;
		UISoldierCount.text = SoldierCount.ToString();
		GameObject[] SoldierBuildingList = GameObject.FindGameObjectsWithTag("SoldierBuilding");
		SoldierBuildingCount = SoldierBuildingList.Length*SoldierBuildingMultiplikator;
		UISoldierBuildingCount.text =SoldierBuildingCount.ToString();
		
		
		GameObject[] SniperList = GameObject.FindGameObjectsWithTag("Sniper");
		SniperCount = SniperList.Length;
		UISniperCount.text = SniperCount.ToString();
		GameObject[] SniperBuildingList = GameObject.FindGameObjectsWithTag("SniperBuilding");
		SniperBuildingCount = SniperBuildingList.Length*SniperBuildingMultiplikator;
		UISniperBuildingCount.text = SniperBuildingCount.ToString();
	}
}
