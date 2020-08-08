using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private float _startTime;
    private float _duration = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.fixedTime;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - _startTime > _duration)
        {
            //Destroy(this.gameObject);
        }
    }
}
