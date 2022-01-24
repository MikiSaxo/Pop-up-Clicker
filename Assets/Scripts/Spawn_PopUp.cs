using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_PopUp : MonoBehaviour
{
    public GameObject PopUp;
    public GameObject SpawnPlace;
    public PopUp_Script PopUp_Script;
    //public int money;
    //public Text moneyText;
    public int _lifeOfPopUp;
    public int damageOnClick;
    public List<Sprite> popUpSprites;


    public static Spawn_PopUp Instance;

    private void Awake()
    {
        Instance = this;
        //GameObject go = GameObject.Instantiate(PopUp, SpawnPlace.transform, false);
        //go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 3;
        SpawnNewPopUp();
    }

    private void Update()
    {
        MainGame.Instance.MyMoney.text = "" + MainGame.Instance.myMoney + "$";
    }

    public void HasClickCroix()
    {
        Debug.Log("a cliqué");
        Hits(damageOnClick);//, PopUp_Script);
        MainGame.Instance.myMoney++;
    }

    public void Hits(int damage)//, PopUp_Script popUp_Script)
    {
        Debug.Log("Lance le Hit dans le script popup_script");
        PopUp_Script.Instance.Hit(damage);
        //popUp_Script.Hit(damage);
        MainGame.Instance.myMoney++;
    }

    public void SpawnNewPopUp()
    {
        Debug.Log("Spawn New PopUp");
        MainGame.Instance.myMoney += 10;
        GameObject go = GameObject.Instantiate(PopUp, SpawnPlace.transform, false);
        go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;
        //go.transform.localScale = new Vector3(30, 30, 30);
    }
}
