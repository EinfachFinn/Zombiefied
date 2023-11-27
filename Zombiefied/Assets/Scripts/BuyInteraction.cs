using UnityEngine.Events;
using UnityEngine;
using cowsins;

public class BuyInteraction : Interactable
{
	
	public UnityEvent triggerEvent;
	private MoneyManager MoneyManager;
	private HumanManager HumanManager;

	public enum BuildingType
	{
		Bed,
		Farm,
		Medic,
		Guard,
		Soldier,
		Sniper
	}
	
	public BuildingType buildingType;
	private int Prize;

	void Start()
	{
		Interactable interactable;
		interactable = GetComponent<BuyInteraction>();
		//		interactable.interactText = Prize.ToString();
		MoneyManager = FindObjectOfType<MoneyManager>();
		HumanManager = FindObjectOfType<HumanManager>();
		
		if(buildingType == BuildingType.Bed)
		{
			Prize = MoneyManager.BedBuilding;
		}
		else if (buildingType == BuildingType.Farm)
		{
			Prize = MoneyManager.FarmerBuilding;
		}
		
		else if (buildingType == BuildingType.Medic)
		{
			Prize = MoneyManager.MedicBuilding;
		}
		
		else if (buildingType == BuildingType.Guard)
		{
			Prize = MoneyManager.GuardBuilding;
		}
		else if (buildingType == BuildingType.Soldier)
		{
			Prize = MoneyManager.SoldierBuilding;
		}
		else if (buildingType == BuildingType.Sniper)
		{
			Prize = MoneyManager.SniperBuilding;
		}
	}
	

	
	public override void Interact()
	{
		if(buildingType == BuildingType.Bed)
		{
			if(MoneyManager.Cash >= MoneyManager.BedBuilding)
			{
				MoneyManager.SubtractMoney(MoneyManager.BedBuilding);
				triggerEvent.Invoke();

				
			}
		}
		else if (buildingType == BuildingType.Farm)
		{
			if(MoneyManager.Cash >= MoneyManager.FarmerBuilding)
			{
				MoneyManager.SubtractMoney(MoneyManager.FarmerBuilding);

				triggerEvent.Invoke();

			}
		}
		else if (buildingType == BuildingType.Medic)
		{
			if(MoneyManager.Cash >= MoneyManager.MedicBuilding)
			{
				MoneyManager.SubtractMoney(MoneyManager.MedicBuilding);

				triggerEvent.Invoke();

			}
		}
		else if (buildingType == BuildingType.Guard)
		{
			if(MoneyManager.Cash >= MoneyManager.GuardBuilding)
			{
				MoneyManager.SubtractMoney(MoneyManager.GuardBuilding);
				triggerEvent.Invoke();

			}
		}
		else if (buildingType == BuildingType.Soldier)
		{
			if(MoneyManager.Cash >= MoneyManager.SoldierBuilding)
			{
				MoneyManager.SubtractMoney(MoneyManager.SoldierBuilding);
				triggerEvent.Invoke();

			}
		}
		else if (buildingType == BuildingType.Sniper)
		{
			if(MoneyManager.Cash >= MoneyManager.SniperBuilding)
			{
				MoneyManager.SubtractMoney(MoneyManager.SniperBuilding);
				triggerEvent.Invoke();

			}
		}
		
		// Trigger the UnityEvent
		triggerEvent.Invoke();
	}
}