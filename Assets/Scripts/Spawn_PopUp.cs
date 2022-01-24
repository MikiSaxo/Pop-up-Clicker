using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Spawn_PopUp : MonoBehaviour
{
    public GameObject PopUp;
    public List<GameObject> SpawnPlace;
    public PopUp_Script PopUp_Script;
    //public int money;
    //public Text moneyText;
    public int _lifeOfPopUp;
    public int damageOnClick;
    public List<Sprite> popUpSprites;
    private float _timerAutoDamage = 0;
    public List<GameObject> _listPopUp;

    public int whichWave;
    public int howManyDied;
    public bool isBoss;


    public static Spawn_PopUp Instance;

    private void Awake()
    {
        Instance = this;
        //GameObject go = GameObject.Instantiate(PopUp, SpawnPlace.transform, false);
        //go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 3;
        //StartCoroutine(SpawnNewPopUp());
        //StartCoroutine(SpawnNewPopUp());
        //StartSpawnNewPopUp();
        StartSpawnNewPopUp();
        StartSpawnNewPopUp();
    }

    public void Start()
    {
        
    }

    private void Update()
    {
        MainGame.Instance.MyMoney.text = "" + MainGame.Instance.myMoney + "$";

        _timerAutoDamage += Time.deltaTime * 3;

        if (_timerAutoDamage >= 1.0f)
        {
            _timerAutoDamage = 0;
            foreach (var upgrade in MainGame.Instance._unlockedUpgrades)
            {
                if (_listPopUp[0] != null)
                {
                    _listPopUp[0].GetComponent<PopUp_Script>().Hit(damageOnClick);
                    _listPopUp[0].transform.DOMoveZ(-1, 0.1f);

                }
                //PopUp_Script.Instance.Hit(MainGame.Instance.damageClic);
            }
        }
    }


    public void LanceSpawn()
    {
        howManyDied++;
        if (howManyDied % 10 == 0)
        {
            whichWave++;
            _lifeOfPopUp += 10;
            UpdateWave();
            StartCoroutine(SpawnNewPopUp());
        }
        else if (howManyDied % 5 == 0)
        {
            isBoss = true;
            _lifeOfPopUp += 100;
            Debug.Log("allo le boss " + PopUp_Script.Instance.isBoss);
            StartCoroutine(SpawnNewPopUp());
            //_lifeOfPopUp -= 100;
        }
        else
            StartCoroutine(SpawnNewPopUp());
    }

    public void UpdateWave()
    {
        damageOnClick++;
    }

    public void StartSpawnNewPopUp()
    {
        Debug.Log("Spawn New PopUp Start");
        MainGame.Instance.myMoney += 10;
        var i = Random.Range(0, SpawnPlace.Count);
        GameObject go = GameObject.Instantiate(PopUp, SpawnPlace[i].transform, false);
        go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;
        _listPopUp.Add(go);
    }
    public IEnumerator SpawnNewPopUp()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("Lance Spawn New PopUp");
        MainGame.Instance.myMoney += 10;
        var i = Random.Range(0, SpawnPlace.Count);
        GameObject go = GameObject.Instantiate(PopUp, SpawnPlace[i].transform, false);
        go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;

        if(_listPopUp[0] == null)
            _listPopUp.RemoveAt(0);
        else if (_listPopUp[1] == null)
            _listPopUp.RemoveAt(1);

        _listPopUp.Add(go);

        if (isBoss)
        {
            go.GetComponent<PopUp_Script>().isBoss = true;
        }
          
        
    }
}
