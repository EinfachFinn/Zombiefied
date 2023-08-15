using UnityEngine.Events;
using UnityEngine;
using UnityEngine.AI;
using cowsins;

public class HumanInteraction : Interactable
{
	private HumanType human;
	private NavMeshAgent NavMesh;
	
	
	public GameObject Player;
	
	[Space]
	[Header("Debug")]
	[SerializeField]
	private int talkcounter = 0;
	
	[SerializeField]
	private bool follow;
	
	void Start()
	{
		follow = false;
		human = GetComponent<HumanType>();
		NavMesh = GetComponent<NavMeshAgent>();
		Player = GameObject.FindGameObjectWithTag("MainCamera");
	
	}

	public override void Interact()
	{
		talkcounter += 1;
		
		if(talkcounter == 1)
		{
			follow = true;
		}
		else
		{
			follow = false;
			talkcounter = 0;
		}
		
	}
	
	void Update()
	{
		if(follow == true)
		{
			NavMesh.SetDestination(Player.transform.position);
			NavMesh.stoppingDistance = 4.0f;
			interactText = "Unfollow";
				
		}
		else
		{
			NavMesh.stoppingDistance = 0.0f;
			interactText = "Assign position";
		}
		
	}
}