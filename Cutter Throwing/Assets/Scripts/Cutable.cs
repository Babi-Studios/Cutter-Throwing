using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime*5f;
        Die();
    }

    public void Die()
    {
        if(transform.position.x<=-10)
            Destroy(gameObject);
    }
}
