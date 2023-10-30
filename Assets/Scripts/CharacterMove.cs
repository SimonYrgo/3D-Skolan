using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;

    Rigidbody body;
    float horizontal;
    float vertical;



    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // kollar ad g�r til -1, 0, 1
        vertical = Input.GetAxisRaw("Vertical"); // kollar ws 
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right; // beh�ver bara ha right f�r att j�mf�ra med p� horizontalaxeln

        forward.y = 0; // skippa koameran s rotation p� karakt�ren i dessa riktiningar
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal; // lagrar dessa siffror i ett array vilket inte var l�t att fatta

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed; // anv�nder ovan array

        body.MovePosition(movement);

        if ( direction != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

    }

}
