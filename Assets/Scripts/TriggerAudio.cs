using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public FMODUnity.EventReference Event;
    public bool PlayOnAwake;
    FMOD.Studio.EventInstance e;

    private void Start()
    {

        e = FMODUnity.RuntimeManager.CreateInstance(Event);

    }

    public void PlayOneShot()
    {
        e.start();
        e.release();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Stop", 0);

    }

    public void StopPlayOneShot()
    {

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Stop", 1);
    }
}


