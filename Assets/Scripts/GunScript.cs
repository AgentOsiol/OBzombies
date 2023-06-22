using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera fpsCam;

    public float damage;
    public float range;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

    }
}
