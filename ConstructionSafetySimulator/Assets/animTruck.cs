using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animTruck : MonoBehaviour

    
{

    public Animator myanim;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            myanim.SetBool("move", true);
        }
    }
}
