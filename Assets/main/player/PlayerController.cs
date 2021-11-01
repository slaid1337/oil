using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public GameObject joyStick;

    public float playerSpeed;
    private Vector2 JoyPosition;
    public JoystickView movement;

    public float bankVolume;

    private GameObject[] wheels;
    private GameObject wheel1;
    private GameObject wheel2;




    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        wheels = GameObject.FindGameObjectsWithTag("wheel");
        wheel1 = wheels[0];
        wheel2 = wheels[1];
    }

    private void FixedUpdate()
    {
        
        
        Vector3 move = new Vector3(movement.Horizontal, 0, movement.Vertical);
        rigidBody.velocity = move * Time.deltaTime * playerSpeed;

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            wheel1.transform.Rotate(new Vector3(0, -move.magnitude * 10f, 0));
            wheel2.transform.Rotate(new Vector3(0, -move.magnitude * 10f, 0));
        }

    }

}
