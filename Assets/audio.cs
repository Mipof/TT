using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    AudioSource audiomusica;

    private void Awake()
    {
        audiomusica = GetComponent<AudioSource>();
    }
    public void reproducir ()
    {
        audiomusica.Play();
    }
}
