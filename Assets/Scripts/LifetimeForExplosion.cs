using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LifetimeForExplosion : MonoBehaviour
{
    [SerializeField] Light2D explosionFlash;
    public float lifeTime = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        DestroyObject(gameObject, lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        explosionFlash.intensity = Mathf.Lerp(1, 10, 0);
        explosionFlash.pointLightOuterRadius = Mathf.Lerp(0.6f, 1, 0);
    }
}
