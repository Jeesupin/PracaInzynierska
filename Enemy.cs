using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int health;
    [SerializeField] int damage;
    [SerializeField] int armor;
    
    public int Damage{
        get{ return this.damage;}
        set{this.damage = value;}
    }
    public int Health{
        get{return this.health;}
        set{this.health = value;}
    }
    public int Armor{
        get{return this.armor;}
        set{this.armor = value;}
    }

    public void RecieveDamage(int val) {
        BroadcastMessage("OnDamageTaken");
        if (armor > 0) {
            armor -= val;
            if (armor < 0) {
                health = health + armor;
                armor = 0;
            }
        }

        if (health > 0) {
            health -= val;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   

}
