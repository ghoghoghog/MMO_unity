using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 1.0f;

    public float _yAngle = 0f;
    void Start()
    {
        Manager.Input.KeyAction += Onkeyboard;
    }

    void Update()
    {
      
    }

    void Onkeyboard()
    {
        _yAngle += Time.deltaTime * 100f;
        // transform.eulerAngles = new Vector3(0, _yAngle, 0);


        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward),0.05f );
            transform.position+=(Vector3.forward*Time.deltaTime*_speed); 
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back),0.05f );
            transform.position+=(Vector3.back * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right),0.05f );
            transform.position+=(Vector3.right * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left),0.05f );
            transform.position+=(Vector3.left * Time.deltaTime * _speed);
        }
    }
}
