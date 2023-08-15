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

	
}
