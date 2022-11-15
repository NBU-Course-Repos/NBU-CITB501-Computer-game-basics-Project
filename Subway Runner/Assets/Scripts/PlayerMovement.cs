using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 5;
    Rigidbody m_Rigidbody;
    private float m_Thrust = 9f;

    // Start is called before the first frame update
    void Awake()
    {
         m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void MoveForward(){
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
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
            m_Rigidbody.AddForce(transform.up * m_Thrust, ForceMode.VelocityChange);
        }
    }
}
