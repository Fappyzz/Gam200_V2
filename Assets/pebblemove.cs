using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pebblemove : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x > -11)
        {
            this.gameObject.transform.position += new Vector3(-10f, 0, 0)*Time.deltaTime;
        }
        else
        {
            this.gameObject.transform.position = startPos;
        }
        
    }
}
