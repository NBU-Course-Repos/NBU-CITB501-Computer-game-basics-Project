using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("m_Speed")] public float mSpeed = 5;
    Rigidbody _mRigidbody;
    private float _mThrust = 9f;

    // Start is called before the first frame update
    void Awake()
    {
         _mRigidbody = GetComponent<Rigidbody>();
    }

    private void MoveForward(){
        transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x > -3.1)
        {
           transform.Translate(new Vector3(-3.5f,0,0));
            //m_Rigidbody.AddForce(-m_Speed* Time.deltaTime,0,0, ForceMode.Acceleration);
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))  && transform.position.x < 3)
        {
            transform.Translate(new Vector3(3.5f,0,0));
                       //m_Rigidbody.AddForce(m_Speed* Time.deltaTime,0,0, ForceMode.Acceleration);
        }
        if ( Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.Space)){
            _mRigidbody.AddForce(transform.up * _mThrust, ForceMode.VelocityChange);
        }
    }
}
