using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float followDistance = 8f;
    public float cameraSpeed = 3f;
    private void LateUpdate() // bra att anv till cameran, motverkar att det hackar  
    {
        // Kan läsa av Musen 
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * cameraSpeed;
        // local = bara i förhållande till sig själv, bara rot på y axeln, dvs rot runt uppsnöret i Unity, 
        // detta ger oss ett nytt rotationsvärde för y axeln på objektet. 

        //float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * cameraSpeed;
        // Detta gör samma sak fast för upp ner med musen. Jag kommenterade ut för tyckte det var lite rörigt med upp/ner funktionen. 

        //Vector3 desiredRotation = new Vector3(newRotationY, newRotationX, 0);
        //transform.localEulerAngles = desiredRotation;
        //// ta floaterna oavn och bygg ny vektor array av. Jag kommenterade ut newRotationY nedan för tyckte det var lite rörigt med upp/ner funktionen. 

        Vector3 desiredRotation = new Vector3(0, newRotationX, 0);
        transform.localEulerAngles = desiredRotation;
        









        Vector3 desiredPosition = target.position - transform.forward * followDistance;
        transform.position = desiredPosition; // kameran ska följa spelaren 

        



    }
}
