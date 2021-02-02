using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class BallThrower : MonoBehaviour, IMixedRealityGestureHandler<Vector3>
{
    public GameObject ballPrefab;
    public TextMesh ballsThrownText;
    public TextMesh scoreText;

    private int _ballsThrown = 0;
    private int _ballsCount = 30;

    private GameObject _balls;


    private void OnEnable()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
        //CoreServices.InputSystem?.RegisterHandler<IMixedRealitySpeechHandler>(this);
    }

    private void OnDisable()
    {
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
        //CoreServices.InputSystem?.UnregisterHandler<IMixedRealitySpeechHandler>(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _balls = new GameObject("Balls");
        _balls.transform.parent = gameObject.transform;
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
        if (action == "Select")
        {
            ThrowBall();
        }
    }

    public void ThrowBall()
    {
        if (_ballsThrown >= _ballsCount)
            return;

        var ball = createBall();
        ball.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.85f;
        var rigidBody = ball.GetComponent<Rigidbody>();
        rigidBody.velocity = Camera.main.transform.forward * 10;
        
        _ballsThrown++;
        updateScore();
    }

    public void Restart()
    {
        foreach (Transform child in _balls.transform)
            Destroy(child.gameObject);

        _ballsThrown = 0;
        updateScore();
        scoreText.text = "Score: " + 0;
    }

    private GameObject createBall()
    {
        GameObject ball = Instantiate(ballPrefab) as GameObject;
        setRandomColor(ball);
        ball.transform.parent = _balls.transform;
        return ball;
    }

    private void updateScore()
    {
        ballsThrownText.text = $"Balls thrown: { _ballsThrown} of {_ballsCount}";
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
