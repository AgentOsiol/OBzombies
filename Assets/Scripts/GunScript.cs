using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunScript : MonoBehaviour
{
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public int damage = 20;
    public int range = 100;

    public float fireRate = 10.0f;
    private float nextTimeToFire = 0f;

    Vector3 origin;
    Vector3 direction;

    public LayerMask layerMask;
    RaycastHit hit;

    private AIscript aIscript;
    

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = fpsCam.ScreenPointToRay(Input.mousePosition).direction;
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 2f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        Debug.DrawRay(fpsCam.ScreenPointToRay(Input.mousePosition).origin, fpsCam.ScreenPointToRay(Input.mousePosition).direction * range, Color.yellow, 10);
        if (Physics.Raycast(origin, direction, out hit, range, layerMask))
        {
            aIscript = hit.collider.GetComponent<AIscript>();
            aIscript.health -= damage;
        }
    }
}
