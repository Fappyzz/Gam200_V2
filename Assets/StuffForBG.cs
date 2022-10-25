using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffForBG : MonoBehaviour
{
    public List<GameObject> shurbs;

    Vector3 Spawn1;
    Vector3 Spawn2;
    Vector3 Spawn3;

    private Vector3 startPos;

    public float yAxis;
    public float xAxis;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(25, 5, 0);
        Spawn1 = new Vector3(11, 3, 0);
        Spawn2 = new Vector3(11, -0.5f, 0);
        Spawn3 = new Vector3(11, -4, 0);
        spawnStuff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnStuff()
    {
        shurbs[0].transform.position = Spawn1;
        shurbs[1].transform.position = Spawn2;
        shurbs[2].transform.position = Spawn3;


    }

}
