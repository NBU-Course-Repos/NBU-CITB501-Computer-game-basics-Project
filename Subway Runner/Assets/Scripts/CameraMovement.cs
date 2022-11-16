using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _mThrust = 9f;
    Rigidbody _mRigidbody;
    
    void Awake()
    {
         _mRigidbody = GetComponent<Rigidbody>();
    }

    private void MoveForward(){
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x > -3.1)
        {
           transform.Translate(new Vector3(-3.2f,0,0));
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))  && transform.position.x < 3)
        {
            transform.Translate(new Vector3(3.2f,0,0));
        }
        if ( Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.Space)){
            _mRigidbody.AddForce(transform.up * _mThrust, ForceMode.Impulse);
        }
    }
}
