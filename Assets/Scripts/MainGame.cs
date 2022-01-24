using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    public List<MonsterInfos> Monsters;
    public Monster Monster;
    public GameObject PrefabHitPoint;
    public GameObject PrefabUpgradeUI;
    public GameObject ParentUprades;
    private int _currentMonster;
    public List<Upgrade> Upgrades;
    public List<Upgrade> _unlockedUpgrades = new List<Upgrade>();
    private float _timerAutoDamage = 0;

    public bool isShopOpen = true;
    public GameObject Shop;
    public GameObject verticalScrollbar;

    public Text MyMoney;
    public int myMoney = 0;
    //private int money = 1;
    //private int moneyBoss = 0;

    public static MainGame Instance;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        Monster.SetMonster(Monsters[_currentMonster]);
        foreach (var upgrade in Upgrades)
        {
            GameObject go = GameObject.Instantiate(PrefabUpgradeUI, ParentUprades.transform, false);
            go.transform.localPosition = Vector3.zero;
            go.GetComponent<UpgradeUI>().Initialize(upgrade);
            go.GetComponent<UpgradeUI>().GetValue(upgrade);
        }
    }

    private void Hits(int damage, Monster monster)
    {
        monster.Hit(damage);
        //myMoney += money;

        GameObject go = GameObject.Instantiate(PrefabHitPoint, monster.Canvas.transform, false);
        go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 100;
        go.transform.DOLocalMoveY(150, 0.8f);
        go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(go, 0.8f);

        if (monster.IsAlive()== false)
        {
            NextMonster();
            //money++;
            //moneyBoss = money * 5;
            //myMoney += moneyBoss; //pas opti
        }

    }
    private void HitDPS(int damage, Monster monster)
    {
        monster.Hit(damage);
        //myMoney += money;

        if (monster.IsAlive()== false)
        {
            NextMonster();
            //money++;
            //moneyBoss = money * 5;
            //myMoney += moneyBoss; //pas opti
        }

    }


    private void NextMonster()
    {
        _currentMonster++;
        Monster.SetMonster(Monsters[_currentMonster]);
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        _unlockedUpgrades.Add(upgrade);
    }

   

    void Update()
    {

        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);
            if (hit.collider.name == "PopUp" && Monster.Instance.canClick)
            {
                Debug.Log(hit.collider.name);
                Monster monster = hit.collider.GetComponent<Monster>();
                Hits(damageClic, Monster);
            }

        }*/

        //MyMoney.text = "" + myMoney + "$";

        _timerAutoDamage += Time.deltaTime;

        if (_timerAutoDamage >= 1.0f)
        {
            _timerAutoDamage = 0;
            foreach (var upgrade in _unlockedUpgrades)
            {
                HitDPS(upgrade.DPS, Monster);
            }
        }

        if (isShopOpen && Shop.transform.localScale.x <= 0)
        {
            Shop.transform.DOComplete();
            Shop.transform.DOScale(0, 0.2f).OnComplete(CloseShop);
        }
    }

    public void OnClickOpenShop()
    {
        if (isShopOpen)
        {
            Shop.transform.DOComplete();
            Shop.transform.DOScale(0, 0.2f).OnComplete(CloseShop);
        }
        else
        {
            
            //Shop.SetActive(true);
            Shop.transform.DOComplete();
            Shop.transform.DOScale(1, 0.2f).OnComplete(OpenShop);
            
            //Shop.transform.DOScale(0, 0.3f).OnComplete(CloseShop);
        }
    } 

    void CloseShop()
    {
        //Shop.SetActive(false);
        isShopOpen = false;
    }

    void OpenShop()
    {
        float scrollValue = verticalScrollbar.GetComponent<Scrollbar>().value = 1;
        isShopOpen = true;
    }
}
