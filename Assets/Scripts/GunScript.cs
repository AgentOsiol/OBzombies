using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera fpsCam;

    public int damage = 10;
    public float range = 100f;

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
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.DrawRay(fpsCam.ScreenPointToRay(Input.mousePosition).origin, fpsCam.ScreenPointToRay(Input.mousePosition).direction * 20, Color.yellow, 10);
        if (Physics.Raycast(origin, direction, out hit, range, layerMask))
        {
            
            aIscript = hit.collider.GetComponent<AIscript>();
            aIscript.health -= damage;
        }
    }
}
