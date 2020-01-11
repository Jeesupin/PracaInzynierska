using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowValues : MonoBehaviour
{

    [SerializeField] Text hpText;
    [SerializeField] Text ammoText;
    [SerializeField] Player playerInfo;
    [SerializeField] WeaponSwitching currentWeaponAmmo;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        hpText.text = playerInfo.GetHealth().ToString();
        ammoText.text = currentWeaponAmmo.GetWeapon().GetAmmo().ToString();

    }
}
