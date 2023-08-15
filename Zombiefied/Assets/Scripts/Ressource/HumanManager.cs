using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class HumanManager : MonoBehaviour
{
	[System.Serializable]
	public class HumanInfo
	{
		public HumanType humanScript;
		public string Name;
		public Sprite Image;
		public int Gender; //1=M 2=f
		public int Health = 100;
		public float Energy;
		public bool Working;
		
		public string Job;
		public bool Farmer;
		public bool Medic;	
		public bool Guard;
		public bool Soldier;	
		public bool Sniper;
		public bool BoomBoy;
	}

	public List<HumanInfo> humansList = new List<HumanInfo>();
	
	[SerializeField]
	private GameObject humanEntryPrefab; //HumanUI PRefab
	[SerializeField]
	private Transform humanEntryList; //Content Scrollview
	[SerializeField]
	private float entryHeight = 100f; //Distance betweeen HumanUI Prefabs
	
	
	private void Start()
	{

		FindAndStoreHumans();
	}

	public void FindAndStoreHumans()
	{
		//Clear List so it doesnt add the same things 2 time
		humansList.Clear();
		
		//clear UI list
		foreach (Transform humanEntryPrefab in humanEntryList) 
		{
			Destroy(humanEntryPrefab.gameObject);
		}
		
		
		//add human to list
		
		HumanType[] humans = FindObjectsOfType<HumanType>();

		foreach (HumanType human in humans)
		{
			//Human List
			HumanInfo humanInfo = new HumanInfo
			{
				humanScript = human,
				Name = human.Name,
				Image = human.Image,
				Gender = human.Gender,
				Health = human.Health,
				Working = human.Working,
				Energy = human.Energy,
				Job = human.Job,
				
				Farmer = human.Farmer,
				Medic = human.Medic,
				Guard = human.Guard,
				Soldier = human.Soldier,
				Sniper = human.Sniper,
				BoomBoy = human.BoomBoy
            };
			humansList.Add(humanInfo);
			
			
			
			
			//Instantiate HumanUI with distance
			GameObject entry = Instantiate(humanEntryPrefab, humanEntryList);
			//copy values
			entry.GetComponent<HumanUIManager>().Name.text = human.Name;
			entry.GetComponent<HumanUIManager>().Health.value = human.Health;
			entry.GetComponent<HumanUIManager>().Energy.value = human.Energy;
			entry.GetComponent<HumanUIManager>().Job.text = human.Job;
			entry.GetComponent<HumanUIManager>().Human = human;
			RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
			entryRectTransform.anchoredPosition = new Vector2(0f, -entryHeight * humanEntryList.childCount);
			
			
			
		}
	}
	

}
