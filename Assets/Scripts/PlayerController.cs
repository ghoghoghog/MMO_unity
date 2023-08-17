using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 10.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
        transform.Rotate(0f,1.5f,0f);
        if (Input.anyKey)
        {
            transform.Rotate(0f,1.5f*_speed,0f);
        }
        
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward*Time.deltaTime*_speed);
    
        if (Input.GetKey(KeyCode.S))
            transform.position +=  transform.TransformDirection(Vector3.back*Time.deltaTime*_speed);
    
        if (Input.GetKey(KeyCode.D))
            transform.position +=  transform.TransformDirection(Vector3.right*Time.deltaTime*_speed);

        if (Input.GetKey(KeyCode.A))
            transform.position +=  transform.TransformDirection(Vector3.left*Time.deltaTime*_speed);
    }
}
