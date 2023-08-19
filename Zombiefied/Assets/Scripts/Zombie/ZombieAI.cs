using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class ZombieAI : MonoBehaviour
{
	private Animator anim;
	public ZombieState currentState = ZombieState.Idle;
	private HumanType targetHuman = null;
	private NavMeshAgent NavAgent;
	
	[SerializeField]
	private Transform HouseTarget;
	[SerializeField]
	private float AttackRange;
	
	[Header("Debug")]
	public Transform target;
	
	[Space]
	[Space]
	[Space]
	
	[SerializeField]
	public float minDistance;
	[SerializeField]
	private float minDistancePlayer;
	
	[SerializeField]
	private Transform Player;
	
	[SerializeField]
	private float RunnerSpeed;
	[SerializeField]
	private float WalkerSpeed;
	[SerializeField]
	private float CrawlerSpeed;
	public bool RunnerType;
	public bool WalkerType;
	public bool CrawlerType;
	
	public UnityEvent Dead;
	void Start()
	{
		NavAgent = GetComponent<NavMeshAgent>();
		anim = GetComponentInChildren<Animator>();
		target = HouseTarget;
		SetState(ZombieState.Running);
		Player = GameObject.FindGameObjectWithTag("MainCamera").transform;
		HouseTarget = GameObject.FindGameObjectWithTag("HouseTarget").transform;
		CheckMoveType();
		
}

	public void CheckMoveType()
	{
		if(WalkerType==true){NavAgent.speed = WalkerSpeed;anim.SetBool("WalkerType",true);anim.SetBool("CrawlerType", false);anim.SetBool("RunnerType", false);}
		else if(CrawlerType==true){NavAgent.speed = CrawlerSpeed;anim.SetBool("WalkerType",false);anim.SetBool("CrawlerType", true);anim.SetBool("RunnerType", false);}
		else if(RunnerType==true){NavAgent.speed = RunnerSpeed;anim.SetBool("WalkerType",false);anim.SetBool("CrawlerType", false);anim.SetBool("RunnerType", true);}
	
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, AttackRange);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, minDistance);
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, minDistancePlayer);
		
	}
	
	
	public enum ZombieState
	{
		Idle,
		Attacking,
		Running,
		Screaming,
	}

	
	
	private void Update()
	{
		
		CheckForTarget();
		
		if (Vector3.Distance(transform.position, target.position) < AttackRange)
		{
			SetState(ZombieState.Attacking);
		}
		else
		{
			SetState(ZombieState.Running);
		}
		
		
		
		
		
		
		
		
		
		
		
		NavAgent.SetDestination(target.position);

		switch (currentState)
		{
		case ZombieState.Idle:
			// Implement idle behavior
			anim.SetBool("IsAttacking", false);
			anim.SetBool("IsMoving", false);
			
			break;

		case ZombieState.Attacking:
			// Implement attacking behavior
			anim.SetBool("IsAttacking", true);
			anim.SetBool("IsMoving", false);
			NavAgent.speed = 0;
			
			break;

			// ...

		case ZombieState.Running:
			CheckMoveType();
			anim.SetBool("IsAttacking", false);
			anim.SetBool("IsMoving", true);
			

			break;

		case ZombieState.Screaming:
			anim.SetBool("IsAttacking", false);
			anim.SetBool("IsMoving", false);
			
			// Implement screaming behavior
			break;
		}
	}
	
	
	
	

	private void CheckForTarget()
	{
		HumanType nearestHumanType = null;
		float nearestHumanDistance = float.MaxValue;
		// Check if player is near
		if (Vector3.Distance(transform.position, Player.position) < minDistancePlayer)
		{
			target = Player;
		}
		else
		{
			// Check if anything with a HumanType script is near
			HumanType[] humanTypeObjects = FindObjectsOfType<HumanType>();

			foreach (HumanType humanTypeObject in humanTypeObjects)
			{
				float distanceToHumanType = Vector3.Distance(transform.position, humanTypeObject.transform.position);

				if (distanceToHumanType < minDistance && distanceToHumanType < nearestHumanDistance)
				{
					nearestHumanType = humanTypeObject;
					nearestHumanDistance = distanceToHumanType;
				}
			}

			target = nearestHumanType ? nearestHumanType.transform : null;
		}

		// If no target has been found, run towards anotherTransform
		if (target == null)
		{
			target = HouseTarget;
		}
    
	}
	
	
	
	
	
	public void SetState(ZombieState newState)
	{
		currentState = newState;
	}

}
