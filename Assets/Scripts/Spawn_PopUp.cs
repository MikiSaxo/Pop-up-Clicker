using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_PopUp : MonoBehaviour
{
    public GameObject PopUp;
    public PopUp_Script PopUp_Script;
    public int money;
    public Text moneyText;
    public int _lifeOfPopUp;
    public int damageOnClick;
    public List<Sprite> popUpSprites;


    public static Spawn_PopUp Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        moneyText.text = "" + money + "$";
    }

    public void HasClickCroix()
    {
        Debug.Log("a cliqué");
        Hits(damageOnClick, PopUp_Script);
    }

    public void Hits(int damage, PopUp_Script popUp_Script)
    {
        Debug.Log("Lance le Hit dans le script popup_script");
        popUp_Script.Hit(damage);
    }
}
