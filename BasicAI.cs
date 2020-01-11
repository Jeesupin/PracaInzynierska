using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour {

    private float radius = 10f;
    [SerializeField] Transform target;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float rotateSpeed = 5f;

    private float distance;
    private bool provoked = false;

	private RaycastHit hit;
    private void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
	}
    
    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, target.position);
        
        if(provoked)
        {
            EngageTarget();
        }
        else if(distance <= radius){
            provoked = true;
        }
        
    }
    public void OnDamageTaken(){
        provoked = true;
    }

    private void EngageTarget(){
        FaceTarget();
        if(distance >= agent.stoppingDistance){
            ChaseTarget();
        }
        if(distance <= agent.stoppingDistance){
            AttackTarget();
        }
    }
    private void ChaseTarget(){

        agent.SetDestination(target.position);
    }
    private void AttackTarget(){
        
    }
    private void FaceTarget(){
        //transform.rotation = where the target is , we need to rotate at certain speed
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * rotateSpeed);
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.tag.Equals("Player"))
        {
            Vector3 dir = other.transform.position - transform.position;
            if (Physics.Raycast(transform.position, dir, out hit, radius))
            {   
                
                if(hit.collider != null)
                {
                    if(hit.collider.tag.Equals("Player"))
                    {
                        provoked = true;
                    }
                }           
            }
            if(Physics.Raycast(transform.position, dir, out hit, radius/2))
            {
                if(hit.collider != null)
                {
                    if(hit.collider.tag.Equals("Player"))
                    {
                        target.gameObject.GetComponent<Player>().RecieveDamage(transform.gameObject.GetComponent<Enemy>().Damage);
                    }
                }
            }    

        }
        
    }

}  
