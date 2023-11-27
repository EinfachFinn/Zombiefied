using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanType : MonoBehaviour
{
	public string Name;
	public Sprite Image;
	[Tooltip("1 = Male, 2 = Female")]
	public int Gender; //1=M 2=f
	public int Health = 100;
	public float Energy;
	public bool Working;
	public Transform Jobpoint;
	
	public string Job;
	public bool Farmer;
	public bool Medic;	
	public bool Guard;
	public bool Soldier;	
	public bool Sniper;
	public bool BoomBoy;	

	public RandomInformationGiver RandomInf;
	
	void Start()
	{
		
		Health = Random.Range(45, 100);
		Gender = Random.Range(1,3);
	
	
		if(Gender == 1)
		{
			
			int randomIndexMa = Random.Range(0, RandomInf.MaleNames.Count);
			string MaleName = RandomInf.MaleNames[randomIndexMa];
			
			
			int randomIndexSu = Random.Range(0, RandomInf.SuNames.Count);
			string SuName = RandomInf.SuNames[randomIndexSu];
			
			
			Name = (MaleName + " " + SuName);
		}
		else
		{
			int randomIndexFe = Random.Range(0, RandomInf.FemaleNames.Count);
			string FemaleName = RandomInf.FemaleNames[randomIndexFe];
			
			
			int randomIndexSu = Random.Range(0, RandomInf.SuNames.Count);
			string SuName = RandomInf.SuNames[randomIndexSu];
			
			
			Name = (FemaleName + " " + SuName);
		}
		
		GetComponentsInParent<HumanInteraction>()[1].Player = GameObject.Find("Head");
		
	}
}
