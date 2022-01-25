using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUp_Boss : MonoBehaviour
{
    public Sprite m_Sprite;
    private int _life;
    [SerializeField] private int _lifeMax = 100;
    public Text Textlife;
    public Image ImageLife;
    public Image ImagePopUp;
    public GameObject Croix;
    public Rigidbody2D rb;
    public int MoveInZ = -1;
    //public GameObject PopUpPrefab;
    //public bool isBoss;



    public static PopUp_Boss Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Debug.Log("yo le spawn de popup");
        
        Debug.Log("bonjour c'est le boss");
        m_Sprite = Spawn_PopUp.Instance.popUpSprites[0];
        ImagePopUp.sprite = m_Sprite;
        _lifeMax = Spawn_PopUp.Instance._lifeOfPopUp * 10;
        _life = _lifeMax;
        Updatelife();
        
    }

    public void OnClickCroix()
    {
        //Spawn_PopUp.Instance.HasClickCroix();
        Hit(Spawn_PopUp.Instance.damageOnClick);
        gameObject.transform.DOMoveZ(-3, 0.1f);
        Debug.Log("first click");
        //OnClickNimporte();
    }
    public void Updatelife()
    {
        Textlife.text = $"{_life}/{_lifeMax}";

        float percent = (float)_life / (float)_lifeMax;
        ImageLife.fillAmount = percent;
    }
    public void Hit(int damage)
    {
        gameObject.transform.DOMoveZ(-3, 0.1f);
        Croix.transform.DOComplete();
        Croix.transform.DOPunchScale(new Vector3(0.01f, 0.01f, 0), 0.3f);
        _life -= damage;
        MainGame.Instance.myMoney++;

        if (_life <= 0)
        {
            _life = 0;
            GoDestroy();
        }

        Updatelife();
    }

    public void GoDestroy()
    {
        //Spawn_PopUp.Instance.LanceSpawn();
        Destroy(gameObject);
    }
}
