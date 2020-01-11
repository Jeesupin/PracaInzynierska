using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] int health;
	//public int armor;
	[SerializeField] int lives;

    [SerializeField] Rigidbody rb;


	// Use this for initialization
	private void Start () {
		health = 100;
		//armor = 100;
		lives = 3;
        rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(this);
        }
    }

    public int RecieveDamage(int damage){
        health -= damage;
        return health;

    }
	public int SetHealth(int amount){
		health = health + amount;
		return health;
	}

    public int GetHealth(){
        return this.health;
    }
}
