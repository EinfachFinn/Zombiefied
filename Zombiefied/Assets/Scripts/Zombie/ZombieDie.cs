using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using cowsins;
public class ZombieDie : MonoBehaviour
{
	private Animator anim;
    // Update is called once per frame
	
	
	public void StartRemoveProcess()
    {
	    anim = GetComponentInChildren<Animator>();
	    int randomValue = Random.Range(1, 4);
        
	    // Set the integer parameter of the animator
	    anim.SetInteger("DeadAnim", randomValue);
	    anim.SetTrigger("Dead");
	    DestroyImmediate(this.gameObject.GetComponent<ZombieAI>());
		DestroyImmediate(this.gameObject.GetComponent<NavMeshAgent>());
		DestroyImmediate(this.gameObject.GetComponent<EnemyHealth>());
	    DestroyImmediate(this.gameObject.GetComponent<LegShotManager>());
	    DestroyImmediate(this.gameObject.GetComponent<ZombieDie>());
		
		

    }
    
	
	
}