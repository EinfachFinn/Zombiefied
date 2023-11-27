using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using cowsins;
public class Job_Soldier : MonoBehaviour
{
	public LayerMask enemyLayer;
	public float rotationSpeed = 5f;
	public float fireRate = 1f;
	public float bulletSpeed = 100f;
	public float maxBulletDistance = 100f;
	public int Damage;

	private NavMeshAgent navMeshAgent;
	private float fireTimer;

	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		fireTimer = 0f;
	}

	void Update()
	{
		GameObject nearestEnemy = FindNearestEnemy();
		if (nearestEnemy != null)
		{
			RotateTowardsEnemy(nearestEnemy);
			ShootAtEnemy();
		}
	}

	GameObject FindNearestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject nearestEnemy = null;
		float minDistance = Mathf.Infinity;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);
			if (distance < minDistance)
			{
				minDistance = distance;
				nearestEnemy = enemy;
			}
		}

		return nearestEnemy;
	}

	void RotateTowardsEnemy(GameObject enemy)
	{
		Vector3 direction = (enemy.transform.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
	}

	void ShootAtEnemy()
	{
		fireTimer += Time.deltaTime;
		if (fireTimer >= fireRate)
		{
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, maxBulletDistance, enemyLayer))
			{
				GameObject enemy = hit.collider.gameObject;
				if (enemy.CompareTag("Enemy"))
				{
					Debug.Log(gameObject + "shoots" + enemy + ", " + Damage + "applied");
					enemy.GetComponentInParent<EnemyHealth>().Damage(Damage);
					
				}
			}
			fireTimer = 0f;
		}
	}
}
