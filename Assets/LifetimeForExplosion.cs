using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeForExplosion : MonoBehaviour
{
    public float lifeTime = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        DestroyObject(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
