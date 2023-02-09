using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PianoPlay : MonoBehaviour
{
    
    [SerializeField] 
    AudioSource audioSource;

    [SerializeField] 
    ParticleSystem musicParticles;

    static bool status = false;
    
    // void Update()
    // {
    //     if(status){
    //         audioSource.Play();
    //         musicParticles.Play();
    //     }
    //     else{
    //         audioSource.Stop();
    //         musicParticles.Stop();
    //     }
    // }

    public void ChangePlayMode()
    {
        if(status){
            audioSource.Stop();
            musicParticles.Stop();
            status = false;
        }
        else{
            status = true;
            audioSource.Play();
            musicParticles.Play();
        }

        Debug.Log("Ddd " + status);
    }
}
