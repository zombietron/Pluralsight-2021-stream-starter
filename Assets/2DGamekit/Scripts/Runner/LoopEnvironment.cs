using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEnvironment : MonoBehaviour
{
    public float maxXDistance;
    Vector3 initialPos;
    // Start is called before the first frame update
    private void Awake()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= maxXDistance)
        {
            transform.position = initialPos;
        }
        
    }
}
