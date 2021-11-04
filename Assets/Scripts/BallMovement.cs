using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _impulseForce = 20;
    [SerializeField] private float _collisionForce = 40;
    private float _firstPlayer = 0; // Set the direction of the impulsion
    
    public Rigidbody _ballRigidBody;

    private Vector3 _previousPosition;

    [SerializeField] private float _delay = 3;
    [SerializeField] private Text _countdownUI;
   
    IEnumerator WaitBeforeLaunch(float delay){
        float timePassed = 0f;
        _countdownUI.enabled = true;
        while(_delay - timePassed > 0){
            if (_delay-timePassed != _delay)
                _countdownUI.text = ((int)(_delay-timePassed)+1).ToString();
            timePassed += Time.deltaTime;
            yield return null;
        }
        Launch();
        _countdownUI.enabled = false;
    }

    void Launch(){
        _ballRigidBody.AddForce(new Vector3(Mathf.Pow(-1,_firstPlayer)*_impulseForce,0,Random.Range(-20,20)),ForceMode.Impulse);
    }

    void Start()
    {
        StartCoroutine(WaitBeforeLaunch(_delay));
    }
    void Update()
    {
        _previousPosition = _ballRigidBody.position;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag != "Ground"){
            if (collisionInfo.gameObject.tag == "Player")
                _collisionForce *= 1.05f;
            Vector3 pos = collisionInfo.contacts[0].point-_previousPosition;
            Vector3 newDirection = (pos - 2*(Vector3.Dot(pos,collisionInfo.contacts[0].normal))*collisionInfo.contacts[0].normal).normalized * _collisionForce;
            _ballRigidBody.AddForce(newDirection*_collisionForce,ForceMode.Force);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Limit"){
            _firstPlayer = 1-_firstPlayer;
            _ballRigidBody.position = new Vector3(0,1,0);
            _ballRigidBody.velocity = Vector3.zero;
            _ballRigidBody.angularVelocity = Vector3.zero;
            _collisionForce = 40;
            StartCoroutine(WaitBeforeLaunch(_delay));
        }
    }
}
