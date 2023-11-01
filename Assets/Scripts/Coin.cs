using System.Collections;
using System.Collections.Generic;
using UnityEngine;
     
public class Coin: MonoBehaviour
{
    public TextManager textManager;
    public int value;

    public AudioSource apljud;

    private void OnTriggerEnter(Collider collision)
    {
        apljud.Play();
        textManager.AddCoins(value);
        Destroy(gameObject);
    }

    
   
}
