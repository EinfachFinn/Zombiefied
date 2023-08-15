using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegShotManager : MonoBehaviour
{

	public bool LegShotUpperL;
	public bool LegShotUpperR;
	
	public bool LegShotLowerL;
	public bool LegShotLowerR;
	
	private ZombieAI ZombieAi;
	
	void Start()
	{
		ZombieAi = GetComponent<ZombieAI>();
	}
	public void LegShotUpdate()
	{
		if(LegShotLowerL == true & LegShotLowerR == true )
		{
			Debug.Log("Crawl");
			ZombieAi.RunnerType = false;
			ZombieAi.WalkerType = false;
			ZombieAi.CrawlerType = true;
			ZombieAi.CheckMoveType();
			Debug.Log("Crawl");
		}
		else if(LegShotUpperL == true & LegShotUpperR == true)
		{
			Debug.Log("Crawl");
			ZombieAi.RunnerType = false;
			ZombieAi.WalkerType = false;
			ZombieAi.CrawlerType = true;
			ZombieAi.CheckMoveType();
			Debug.Log("Crawl");
		}
		else if(LegShotUpperL == true & LegShotLowerR == true)
		{
			ZombieAi.RunnerType = false;
			ZombieAi.WalkerType = false;
			ZombieAi.CrawlerType = true;
			ZombieAi.CheckMoveType();
			Debug.Log("Crawl");
		}
		else if (LegShotUpperR == true & LegShotLowerL == true)
		{
			ZombieAi.RunnerType = false;
			ZombieAi.WalkerType = false;
			ZombieAi.CrawlerType = true;
			ZombieAi.CheckMoveType();
			Debug.Log("Crawl");
		}
	}

}
