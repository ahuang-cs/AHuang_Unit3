using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float loopPos;
    private Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        loopPos = GetComponent<BoxCollider>().size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - loopPos)
        {
            transform.position = startPos;
        }
    }
}
