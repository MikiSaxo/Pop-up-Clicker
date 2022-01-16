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
    private List<Upgrade> _unlockedUpgrades = new List<Upgrade>();
    private float _timerAutoDamage = 0;
    //public Text DamageClic;
    //public int damageClic = 1;

    public static MainGame Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Monster.SetMonster(Monsters[_currentMonster]);
        foreach (var upgrade in Upgrades)
        {
            GameObject go = GameObject.Instantiate(PrefabUpgradeUI, ParentUprades.transform, false);
            go.transform.localPosition = Vector3.zero;
            go.GetComponent<UpgradeUI>().Initialize(upgrade);
        }
    }

    private void Hits(int damage, Monster monster)
    {
        monster.Hit(damage);

        GameObject go = GameObject.Instantiate(PrefabHitPoint, monster.Canvas.transform, false);
        go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 100;
        go.transform.DOLocalMoveY(150, 0.8f);
        go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(go, 0.8f);

        if (monster.IsAlive()== false)
        {
            NextMonster();
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
    //public void UpdateDamage()
    //{
    //    DamageClic.text = $"{damageClic}";
    //}
        // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);
            if (hit.collider!= null)
            {
                //Debug.Log(hit.collider.name);
               Monster monster = hit.collider.GetComponent<Monster>();
                Hits(1, Monster);
                //monster.Hit(1);
                //GameObject go = GameObject.Instantiate(PrefabHitPoint, monster.Canvas.transform, false);
                //go.transform.localPosition = new Vector3(0, 0, 0);
                //go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 100;
                //go.transform.DOLocalMoveY(150, 0.8f);
                //go.GetComponent<Text>().DOFade(0, 0.8f);
                //GameObject.Destroy(go, 0.8f);

                //if (monster.IsAlive()== false)
                //{
                //    NextMonster();
                //}
            }

        }

        _timerAutoDamage += Time.deltaTime;

        if (_timerAutoDamage >= 1.0f)
        {
            _timerAutoDamage = 0;
            foreach (var upgrade in _unlockedUpgrades)
            {
                //Monster.Hit(upgrade.DPS);
                Hits(upgrade.DPS, Monster);
            }
        }

    }
}
