using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;

    Rigidbody body; // skapa en variabel som hämtar 
    float horizontal;
    float vertical;



    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // kollar ad gör til -1, 0, 1
        vertical = Input.GetAxisRaw("Vertical"); // kollar ws tangenter och ger värde -1, 0, 1 
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right; // behöver bara ha right för att jämföra med på horizontalaxeln, 
                                               // om vi går left så är det motsatt right. 

        forward.y = 0; // skippa kamerans rotation på karaktären i dessa riktningar
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal; // lagrar dessa siffror i ett array vilket inte var lät att fatta

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed; // använder ovan array

        body.MovePosition(movement);

        if ( direction != Vector3.zero) // rotera inte om ingen kanpp tryckt - ingen förädring på ngn axis i arrayet    
        {
            transform.rotation = Quaternion.LookRotation(direction); // annars gör detta: min foraward (objektets forward) vill titta i riktiningen som finns direction arrayet
        }

    }

}
