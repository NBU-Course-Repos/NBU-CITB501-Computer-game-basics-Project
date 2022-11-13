using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    private float m_Speed = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>(); ///Fetch the Rigidbody from the GameObject with this script attached
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x > -3)
        {
           transform.Translate(Vector3.left * 3fw);
            //m_Rigidbody.AddForce(-m_Speed* Time.deltaTime,0,0, ForceMode.Acceleration);
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))  && transform.position.x < 3)
        {
            transform.Translate(Vector3.right * 3f);
                       //m_Rigidbody.AddForce(m_Speed* Time.deltaTime,0,0, ForceMode.Acceleration);
        }
    }
}
