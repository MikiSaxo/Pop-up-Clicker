using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Spawn_PopUp : MonoBehaviour
{
    public Upgrade _upgrade;
    public GameObject PopUp;
    public GameObject PopUpBoss;
    public List<GameObject> SpawnPlace;
    public PopUp_Script PopUp_Script;
    //public int money;
    //public Text moneyText;
    public int _lifeOfPopUp;
    public int damageOnClick;
    public List<Sprite> popUpSprites;
    private float _timerAutoDamage = 0;
    public List<GameObject> _listPopUp;
    public List<GameObject> _listSpecialPopUp;
    public int addMoney = 1;
    //public int addDPS;

    public int whichWave;
    public int howManyDied;
    public bool isBoss;
    public int addWeightWave;


    public static Spawn_PopUp Instance;

    private void Awake()
    {
        Instance = this;
        //GameObject go = GameObject.Instantiate(PopUp, SpawnPlace.transform, false);
        //go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 3;
        //StartCoroutine(SpawnNewPopUp());
        //StartCoroutine(SpawnNewPopUp());
        //StartSpawnNewPopUp();
        //StartSpawnNewPopUp();
        StartSpawnNewPopUp();
    }

    public void Start()
    {
        
    }

    private void Update()
    {

        //addDPS = UpgradeUI.Instance.addDPS;
        //Debug.Log("allez addDPS " + addDPS);
        //else if (_listPopUp[2] == null)
        // _listPopUp.RemoveAt(2);

        MainGame.Instance.MyMoney.text = "" + MainGame.Instance.myMoney;// "$";

        _timerAutoDamage += Time.deltaTime;

        if (_timerAutoDamage >= 1.0f)
        {
            _timerAutoDamage = 0;
            //foreach (var upgrade in MainGame.Instance._unlockedUpgrades)
            //{
            if (MainGame.Instance._unlockedUpgrades.Count != 0)
            {


                if (_listSpecialPopUp[0] != null)
                {
                    _listSpecialPopUp[0].GetComponent<PopUp_Boss>().Hit(MainGame.Instance.totalDPS);
                }
                else if (_listPopUp[0] != null)
                {
                    Debug.Log("click auto");
                    //foreach (var i in MainGame.Instance._unlockedUpgrades)
                    //{
                    _listPopUp[0].GetComponent<PopUp_Script>().Hit(MainGame.Instance.totalDPS);
                    Debug.Log("UpgradeUI.Instance.initUpgrade" + UpgradeUI.Instance.initUpgrade);
                    //}
                    _listPopUp[0].transform.DOMoveZ(-1, 0.1f);
                    //Debug.Log(UpgradeUI.Instance.addDPS);
                    //}

                }
            }
        }
    }


    public void LanceSpawn()
    {
        howManyDied++;
        if (howManyDied % (10 + addWeightWave) == 0)
        {
            _lifeOfPopUp += 10;
            _lifeOfPopUp += _lifeOfPopUp;
            
            StartCoroutine(SpawnNewPopUp());
        }
        else if (howManyDied % (15 + addWeightWave) == 0)
        {
            isBoss = true;
            //_lifeOfPopUp += 100;
            //Debug.Log("allo le boss " + PopUp_Script.Instance.isBoss);
            StartCoroutine(SpawnNewPopUp());
            //_lifeOfPopUp -= 100;
            addWeightWave += 5;
            whichWave++;
            UpdateWave();
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
        
        var i = Random.Range(0, SpawnPlace.Count);
        GameObject go = GameObject.Instantiate(PopUp, SpawnPlace[i].transform, false);
        go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;
        _listPopUp.Add(go);
    }
    public IEnumerator SpawnNewPopUp()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("Lance Spawn New PopUp");

        if (_listPopUp[0] == null)
            _listPopUp.RemoveAt(0);
        else if (_listPopUp[1] == null)
            _listPopUp.RemoveAt(1);

        var i = Random.Range(0, SpawnPlace.Count);
        if (isBoss)
        {
            if (_listSpecialPopUp[0] == null)
                _listSpecialPopUp.RemoveAt(0);
            else if (_listSpecialPopUp[1] == null)
                _listSpecialPopUp.RemoveAt(1);

            GameObject go = GameObject.Instantiate(PopUpBoss, SpawnPlace[i].transform, false);
            go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;
            _listSpecialPopUp.Add(go);
            isBoss = false;
        }
        //else
        //{
        GameObject go2 = GameObject.Instantiate(PopUp, SpawnPlace[i].transform, false);
        go2.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;
        _listPopUp.Add(go2);
        //}



        /*if (isBoss)
        {
            go.GetComponent<PopUp_Script>().isBoss = true;
        }*/
    }

    /*public void SpawnPopUpBoss()
    {

    }*/
}
