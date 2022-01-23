using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUp_Script : MonoBehaviour
{
    public Sprite m_Sprite;
    private int _life;
    [SerializeField] private int _lifeMax = 100;
    public Text Textlife;
    public Image ImageLife;
    public GameObject Croix;


    public static PopUp_Script Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        _life = _lifeMax;
        Updatelife();
    }

    public void OnClickCroix()
    {
        Spawn_PopUp.Instance.HasClickCroix();
        Debug.Log("first click");
    }

    public void Updatelife()
    {
        Textlife.text = $"{_life}/{_lifeMax}";

        float percent = (float)_life / (float)_lifeMax;
        ImageLife.fillAmount = percent;
    }
    public void Hit(int damage)
    {
        Croix.transform.DOComplete();
        Croix.transform.DOPunchScale(new Vector3(0.01f, 0.01f, 0), 0.3f);
        _life -= damage;

        if(_life <= 0)
        {
            GoDestroy();
        }

        Updatelife();
    }

    public void GoDestroy()
    {
        Spawn_PopUp.Instance.SpawnNewPopUp();
        Destroy(gameObject);
    }
}
