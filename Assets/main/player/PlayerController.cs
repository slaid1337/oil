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

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        
        
        Vector3 move = new Vector3(movement.Horizontal, 0, movement.Vertical);
        rigidBody.velocity = move * Time.deltaTime * playerSpeed;

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

}
