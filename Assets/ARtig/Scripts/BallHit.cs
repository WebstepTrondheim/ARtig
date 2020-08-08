using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    //public GameObject score; //reference to the ScoreText gameobject, set in editor
    //public AudioClip basket; //reference to the basket sound

    public TextMesh score;
    private int _hitCount = 0;

    void OnCollisionEnter() //if ball hits board
    {
        //audio.Play(); //plays the hit board sound
    }

    void OnTriggerEnter() //if ball hits basket collider
    {
        //int currentScore = int.Parse(score.GetComponent().text) + 1; //add 1 to the score
        //score.GetComponent().text = currentScore.ToString();
        //AudioSource.PlayClipAtPoint(basket, transform.position); //play basket sound
        
        
        _hitCount++;
        //score.text = "Score: " + _hitCount;
    }
}
