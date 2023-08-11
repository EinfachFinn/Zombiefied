using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanType : MonoBehaviour
{
	public string Name;
	public Sprite Image;
	public int Gender; //1=M 2=f
	public int Health = 100;
	public float Energy;
	public bool Working;
	public Transform Jobpoint;
	
	public bool Farmer;
	public bool Medic;	
	public bool Guard;
	public bool Soldier;	
	public bool Sniper;
	public bool BoomBoy;	

	
	
	public void LearnFarmer() //Food
	{
		/*/
		Go to Farmer-School
		-100$
		/*/
		Farmer = true;
	}
	
	public void LearnMedic() //Heal Guards (not Energy just health)
	{
		/*/
		Go to Medic-School
		-500$
		/*/
		Medic = true;
	}
	
	public void LearnGuard() //Melee defending
	{
		/*/
		Go to Guard-School
		-200$
		/*/
		Guard = true;
	}
	
	public void LearnSoldier() //Rifle defending
	{
		/*/
		Go to Soldier-School
		-1000$
		/*/
		Soldier = true;
	}
	

	public void LearnSniper() //Sniper defending
	{
		/*/
		Go to Sniper-School
		-2000$		
		/*/
		Sniper = true;
	}
	public void LearnBoomBoy() //RocketLauncher defending
	{
		/*/
		Go to BoomBoom-School
		-5000$		
		/*/
		BoomBoy = true;
	}
	

	
	
	
	
	
	
	
}
