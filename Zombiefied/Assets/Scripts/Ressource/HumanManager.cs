using UnityEngine;
using System.Collections.Generic;

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
		
		public bool Farmer;
		public bool Medic;	
		public bool Guard;
		public bool Soldier;	
		public bool Sniper;
		public bool BoomBoy;
	}

	public List<HumanInfo> humansList = new List<HumanInfo>();

	private void Start()
	{

		FindAndStoreHumans();
	}

	public void FindAndStoreHumans()
	{
		humansList.Clear();
		HumanType[] humans = FindObjectsOfType<HumanType>();

		foreach (HumanType human in humans)
		{
			HumanInfo humanInfo = new HumanInfo
			{
				humanScript = human,
				Name = human.Name,
				Image = human.Image,
				Gender = human.Gender,
				Health = human.Health,
				Working = human.Working,
				Energy = human.Energy,
				Farmer = human.Farmer,
				Medic = human.Medic,
				Guard = human.Guard,
				Soldier = human.Soldier,
				Sniper = human.Sniper,
				BoomBoy = human.BoomBoy
            };

			humansList.Add(humanInfo);
		}
	}
}
