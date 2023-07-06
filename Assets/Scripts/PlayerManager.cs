using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int pHealth = 200;

    // Start is called before the first frame update
    void Start()
    {
        pHealth = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealth <= 0)
        {
            
        }
    }
}
