using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class BallThrower : MonoBehaviour, IMixedRealityGestureHandler<Vector3>
{
    public GameObject ballPrefab;
    public TextMesh ballsThrownText;

    private int _ballsThrown = 0;
    private int _ballsCount = 30;

    private void OnEnable()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
    }

    private void OnDisable()
    {
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
    }

    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void OnGestureStarted(InputEventData eventData)
    {
    }
    public void OnGestureStarted(InputEventData<Vector3> eventData)
    {
    }
    public void OnGestureUpdated(InputEventData eventData)
    {
    }
    public void OnGestureUpdated(InputEventData<Vector3> eventData)
    {
    }
    public void OnGestureCanceled(InputEventData eventData)
    {
    }
    public void OnGestureCanceled(InputEventData<Vector3> eventData)
    {
    }
    public void OnGestureCompleted(InputEventData<Vector3> eventData)
    {
    }
    public void OnGestureCompleted(InputEventData eventData)
    {
        var action = eventData.MixedRealityInputAction.Description;
        if (_ballsThrown < _ballsCount &&  action == "Select")
        {
            throwBall();
        }
    }

    private void throwBall()
    {
        var ball = createBall();
        ball.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.85f;
        var rigidBody = ball.GetComponent<Rigidbody>();
        rigidBody.velocity = Camera.main.transform.forward * 10;
        
        _ballsThrown++;
        ballsThrownText.text = $"Balls thrown: { _ballsThrown} of {_ballsCount}";    
    }

    private GameObject createBall()
    {
        GameObject ball = Instantiate(ballPrefab) as GameObject;
        setRandomColor(ball);
        return ball;
    }

    private void setRandomColor(GameObject gameObject)
    {
        var meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            var material = meshRenderer.material;
            if (material != null)
            {
                material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
        }
    }
}
