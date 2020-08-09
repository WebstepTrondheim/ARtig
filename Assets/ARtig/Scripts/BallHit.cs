using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    public TextMesh score;
    private int _hitCount = 0;

    void OnTriggerEnter()
    {       
        _hitCount++;
        score.text = "Score: " + _hitCount;
    }
}
