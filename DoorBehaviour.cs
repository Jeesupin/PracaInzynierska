using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {

    

    [SerializeField] Animator animator;

    private bool doorIsOpen = false;
    private Vector3 dir;
    private RaycastHit hit;    


	
	void Start ()
    {

        animator = GetComponent<Animator>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (IsDoorOpen() == true)
        {

            //doorObject.transform.position = endPosition;
            animator.SetBool("isOpen", true);
           
        }
        if (IsDoorOpen() == false)
        {
            // doorObject.transform.position = basePosition;
            animator.SetBool("isOpen", false);
        }
        
    }
    
    private bool IsDoorOpen()
    {
        return this.doorIsOpen;
    }

    private void OnTriggerExit(Collider other)
    {
        this.doorIsOpen = false;

    }

    private void OnTriggerStay(Collider other) 
    {
        dir = other.transform.position - transform.position;
        //Raycast powinien wykrywać obiekty na podstawie dystansu, w ten sposób zniknie problem zbyt wielkiego collidera u przeciwnika aktywującego drzwi.
        // dzięki temu przeciwnicy i gracz wymagać będzie tej samej odległości od drzwi nim te się otworzą, prawdopodobnie trzeba będzie powiększyć collider drzwi.

        if(other.tag.Equals("Player") || other.tag.Equals("Enemy")){
            if(Physics.Raycast(transform.position,dir,out hit, 5.0f)){
                if(hit.collider != null){
                    if(hit.collider.tag.Equals("Player") || other.tag.Equals("Enemy")){
                        this.doorIsOpen = true;
                    }
                }
            }
        }
        /*
        if(other.tag.Equals("Enemy")){
            if(Physics.Raycast(transform.position, dir, out hit, 5.0f)){
                if(hit.collider != null){
                    if(hit.collider.tag.Equals("Enemy")){
                        this.doorIsOpen = true;
                    }
                }
            }
        }*/
    }

}
