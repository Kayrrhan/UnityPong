using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 50;
    [SerializeField] private KeyCode _upDirection;
    [SerializeField] private KeyCode _downDirection;
    // private bool _hasForce = false;
    // [SerializeField] private KeyCode _switchMode;
    void Update()
    {
        // if (Input.GetKeyDown(_switchMode)){
        //     _hasForce = !_hasForce;
        //     if (_hasForce)
        //         transform.GetComponent<Rigidbody>().mass = 1;
        //     else
        //         transform.GetComponent<Rigidbody>().mass = 100;
        // }
        // if (_hasForce){
            if (Input.GetKey(_upDirection)){
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,_movementSpeed), ForceMode.Force);
            }
            if (Input.GetKey(_downDirection)){
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-_movementSpeed),ForceMode.Force);
            }
            if (!Input.GetKey(_upDirection) && !Input.GetKey(_downDirection)){
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        // }
        // else{
        //     if (Input.GetKey(_upDirection)){
        //         transform.position+= Vector3.forward*_movementSpeed*Time.deltaTime;
        //     }
        //     if (Input.GetKey(_downDirection)){
        //         transform.position-= Vector3.forward*_movementSpeed*Time.deltaTime;
        //     }
        // }

    }
}
