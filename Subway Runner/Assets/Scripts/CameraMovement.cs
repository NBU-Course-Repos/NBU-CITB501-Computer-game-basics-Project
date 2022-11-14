using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float m_Thrust = 9f;
    Rigidbody m_Rigidbody;
    
    void Awake()
    {
         m_Rigidbody = GetComponent<Rigidbody>();
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
            m_Rigidbody.AddForce(transform.up * m_Thrust, ForceMode.Impulse);
        }
    }
}
