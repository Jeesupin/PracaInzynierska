using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    [SerializeField] int damage;
    [SerializeField] float RPM;


    [SerializeField] int maxAmmo;
    [SerializeField] int ammo;

	[SerializeField] GameObject barrel;
	[SerializeField] AudioClip shootSound;
    [SerializeField] ParticleSystem flash;

    
    [SerializeField] AudioSource source;
    private float volumeLowRange = 0.25f;
	private float volumeMaxRange = 0.3f;

    private float nextShot = 0f;
	private bool ableToShoot = true;

    private void FixedUpdate(){

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if (ammo > 0)
		{
			ableToShoot = true;
		}
	}

    private void Shoot()
    {
        
        RaycastHit hit;
        //Debuging
        Vector3 forward = barrel.transform.TransformDirection(Vector3.forward) * 10;
        if (Time.time > nextShot && ableToShoot)
        {

            //Shooting speed settings
            nextShot = Time.time + RPM;

            //Make volume variation
            float volume = Random.Range(volumeLowRange, volumeMaxRange);
           
            source.PlayOneShot(shootSound, volume);
            //Single shot sound
            

            if (Physics.Raycast(barrel.transform.position, forward, out hit))
            {
                Enemy en = hit.transform.GetComponent<Enemy>();
                if (hit.collider.tag == "Enemy")
                {
                    en.RecieveDamage(damage);
                    Debug.Log("Hitted something at distance: " + hit.distance);
                }
            }
            AmmoCount();

            //18.05.2019 sprawdzić czemu nie widać na ekranie gry efektów świetlnych.
            flash.Play();
        }
    }

    void AmmoCount()
    {
        //Ammo wasting if ammo set above 0 (-1 is for basic weapon and it means it have infinite ammo)
        if (GetAmmo() > 0)
        {
            ammo--;
            //If ammo is above zero, decresase that number, if it hits 0 do not allow player to use weapon
            if (GetAmmo() == 0)
            {
                ableToShoot = false;
            }
            if (GetAmmo() == -1 && GetAmmo() > 0)
            {
                ableToShoot = true;
            }
        }

    }

    public int GetAmmo(){
        return this.ammo;
    }
    public void AddAmmo(int value){
        this.ammo = this.ammo + value;
    }

}
