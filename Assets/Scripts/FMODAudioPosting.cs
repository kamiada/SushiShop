using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODAudioPosting : MonoBehaviour
{
   
    public FMODUnity.EventReference sound;

    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(sound);    }


}
