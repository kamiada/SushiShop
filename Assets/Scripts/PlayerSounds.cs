using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference _Footsteps;

    private FMOD.Studio.EventInstance Footsteps;

    private void Awake()
    {
        if (!_Footsteps.IsNull)
        {
            Footsteps = FMODUnity.RuntimeManager.CreateInstance(_Footsteps);
        }
    }


    public void PlayFootsteps()

    {

        if (Footsteps.isValid())
        {
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(Footsteps, transform);
            Footsteps.start();
        }

    }

}
