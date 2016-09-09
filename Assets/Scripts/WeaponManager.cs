using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WeaponManager : MonoBehaviour
{
    public GameObject weaponPrefab;

    public bool isHeld;

    public static List<GameObject> weapons;

    // Use this for initialization
    void Start()
    {
        //weapons.Add(weapon1);
        //weapons.Add(weapon2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
        if (weapons.Length < 2)
        {
            int randomX = (-3 + (int)(Random.value * 6)) * 5;
            int randomZ = (-3 + (int)(Random.value * 6)) * 5;
            GameObject weapon = (GameObject) Instantiate(weaponPrefab, new Vector3(randomX, 0.1f, randomZ), Quaternion.identity);
            weapon.AddComponent<Weapon>();
            weapon.GetComponent<Weapon>().IsHeld = false;
        }
    }
}
