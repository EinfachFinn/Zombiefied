using UnityEngine;
using System.Collections.Generic;

public class Job_Guard : MonoBehaviour
{
	public float attackInterval = 3f; // Time interval between attacks.
	public float detectionRange = 10f; // Range within which zombies are detected.

	[SerializeField]
	private List<ZombieAI> zombies = new List<ZombieAI>();
	[SerializeField]
	private Transform currentTarget; // The nearest zombie to attack.
	[SerializeField]
	private float lastAttackTime;
	

	private void Start()
	{
		// Initialize the attack timer.
		lastAttackTime = Time.time;
	}

	private void Update()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, detectionRange);
		// Check if it's time to attack.
		if (Time.time - lastAttackTime >= attackInterval)
		{
			FindNearestZombie();
			if (currentTarget != null)
			{
				// Attack the nearest zombie.
				Attack();
			}
			lastAttackTime = Time.time;
		}
	}

	private void FindNearestZombie()
	{
		zombies.RemoveAll(zombie => zombie == null); // Remove null references.

		float nearestDistance = float.MaxValue;
		Transform nearestZombie = null;

		foreach (ZombieAI zombie in zombies)
		{
			if (zombie != null)
			{
				float distance = Vector3.Distance(transform.position, zombie.transform.position);
				if (distance < nearestDistance)
				{
					nearestDistance = distance;
					nearestZombie = zombie.transform;
				}
			}
		}

		currentTarget = nearestZombie;
	}

	private void Attack()
	{
		if (currentTarget != null)
		{
			// Replace this with your attack logic (e.g., reduce zombie's health).
			Debug.Log("Attacking zombie: " + currentTarget.name);
		}
	}

	// This method is called by other scripts to update the list of zombies.
	public void UpdateZombiesList(List<ZombieAI> updatedZombies)
	{
		zombies = updatedZombies;
		FindNearestZombie(); // Find the new nearest zombie.
	}
}
