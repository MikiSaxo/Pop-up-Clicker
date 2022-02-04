using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Script : MonoBehaviour
{
    public AudioSource Click;
    public AudioSource Achat;
    public AudioSource Destruction_PopUp;

    public static Sound_Script Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayClick()
    {
        Click.Play();
    }

    public void PlayAchat()
    {
        Achat.Play();
    }

    public void PlayDestruction_PopUp()
    {
        Destruction_PopUp.Play();
    }
}
