using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateClic : MonoBehaviour
{

    public Text TextDamageClic;
    //public MainGame mainGame;

    public void Update()
    {
        TextDamageClic.text = "" + MainGame.Instance.damageClic;
    }

}
