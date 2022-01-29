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
    public GameObject PopUpMoney;
    public List<GameObject> SpawnPlace;
    //public PopUp_Script PopUp_Script;
    //public int money;
    //public Text moneyText;
    public int _lifeOfPopUp;
    public int damageOnClick;
    public List<Sprite> popUpSprites;
    private float _timerAutoDamage = 0;
    public List<GameObject> _listPopUp;
    public List<GameObject> _listMiniBossPopUp;
    public List<GameObject> _listMoneyPopUp;
    public int addMoney = 1;
    public int addNewPop;
    //public int addDPS;

    public int whichWave;
    public int howManyDied;
    public int resetDied;
    public bool isBoss;
    public bool isMoney;
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
        MainGame.Instance.MyMoney.text = "" + MainGame.Instance.myMoney;// "$";

        _timerAutoDamage += Time.deltaTime;

        if (_timerAutoDamage >= 1.0f)
        {
            int test = 0;
            _timerAutoDamage = 0;
            for (int i = 0; i < MainGame.Instance._unlockedUpgrades.Count; i++)
            {
                if (MainGame.Instance._unlockedUpgrades[i].Name != MainGame.Instance.Upgrades[0].Name)
                    test = i;
                
                
            }

                if (MainGame.Instance._unlockedUpgrades[test] != MainGame.Instance.Upgrades[0])
                {

                    if (_listMiniBossPopUp[0] != null)
                    {
                        _listMiniBossPopUp[0].GetComponent<PopUp_Boss>().Hit(MainGame.Instance.totalDPS);
                    }
                    else if (_listPopUp[0] != null)
                    {
                        Debug.Log("click auto");
                        _listPopUp[0].GetComponent<PopUp_Script>().Hit(MainGame.Instance.totalDPS);
                        _listPopUp[0].transform.DOMoveZ(-1, 0.1f);
                    }
                    if (_listMoneyPopUp[0] != null)
                    {
                        _listMoneyPopUp[0].GetComponent<Pop_Up_Money>().Hit(MainGame.Instance.totalDPS);
                    }

                }
            
            /*if (MainGame.Instance._unlockedUpgrades.Count > 1) /*a revoir car c'est eclater le != 0 est bien mais j'sais pas comment faire en sorte
                que quand on click sur le premier l'auto ce lance pas la faut juste forcer le joueur a acheter le dpc en premier/
            {
              

                if (_listMiniBossPopUp[0] != null)
                {
                    _listMiniBossPopUp[0].GetComponent<PopUp_Boss>().Hit(MainGame.Instance.totalDPS);
                }
                else if (_listPopUp[0] != null)
                {
                    Debug.Log("click auto");
                    _listPopUp[0].GetComponent<PopUp_Script>().Hit(MainGame.Instance.totalDPS);
                    _listPopUp[0].transform.DOMoveZ(-1, 0.1f);
                }
                if (_listMoneyPopUp[0] != null)
                {
                    _listMoneyPopUp[0].GetComponent<Pop_Up_Money>().Hit(MainGame.Instance.totalDPS);
                }
            }*/
        }
    }


    public void LanceSpawn()
    {
        howManyDied++;
        resetDied++;
        if (resetDied % (10 + addWeightWave) == 0)
        {
            //_lifeOfPopUp += 10;
            _lifeOfPopUp += _lifeOfPopUp;
            Debug.Log("vie popup" + _lifeOfPopUp);
            addMoney+=2;

            StartCoroutine(SpawnNewPopUp());
        }
        else if (howManyDied % 20 == 0)
        {
            isMoney = true;
            StartCoroutine(SpawnNewPopUp());
        }
        else if (resetDied % (15 + addWeightWave) == 0)
        {
            isBoss = true;
            //_lifeOfPopUp += 100;
            //Debug.Log("allo le boss " + PopUp_Script.Instance.isBoss);
            StartCoroutine(SpawnNewPopUp());
            //_lifeOfPopUp -= 100;
            resetDied = 0;
            addWeightWave += 2;
            whichWave++;
            addNewPop++;
            UpdateWave();
        }
        else
            StartCoroutine(SpawnNewPopUp());

    }

    public void UpdateWave()
    {
        MainGame.Instance.totalDPC++;
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

        for (int j = 0; j <= 5; j++)
        {
            if (_listPopUp[j] == null)
            {
                _listPopUp.RemoveAt(j);
                break;
            }
        }

        /*if (_listPopUp[0] == null)
            _listPopUp.RemoveAt(0);
        else if (_listPopUp[1] == null)
            _listPopUp.RemoveAt(1);
        else if (_listPopUp[2] == null)
            _listPopUp.RemoveAt(2);
        else if (_listPopUp[3] == null)
            _listPopUp.RemoveAt(3);
        else if (_listPopUp[4] == null)
            _listPopUp.RemoveAt(4);
        else if (_listPopUp[5] == null)
            _listPopUp.RemoveAt(5);*/

        var i = Random.Range(0, SpawnPlace.Count);
        if (isBoss)
        {
            if (_listMiniBossPopUp[0] == null)
                _listMiniBossPopUp.RemoveAt(0);
            else if (_listMiniBossPopUp[1] == null)
                _listMiniBossPopUp.RemoveAt(1);

            GameObject go = GameObject.Instantiate(PopUpBoss, SpawnPlace[i].transform, false);
            go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;
            _listMiniBossPopUp.Add(go);
            isBoss = false;
        }
        if (isMoney)
        {
            GameObject go = GameObject.Instantiate(PopUpMoney, SpawnPlace[i].transform, false);
            go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 2;
            _listMoneyPopUp.Add(go);
            isMoney = false;

            if (_listMoneyPopUp[0] == null)
                _listMoneyPopUp.RemoveAt(0);
            //if (_listmoneypopup[1] == null)
            //    _listmoneypopup.removeat(1);

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
