using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Background : MonoBehaviour
{
    public List<Sprite> backgroundSprite;
    public Sprite backSprite;
    public Image backgroundImage;
    public Image backgroundImage2;
    public GameObject background;
    float timer = 0.0f;
    int n = 0;
    int backg = 0;
    int oldbackg = -1;
    bool onChangeBack = false;
    bool test = false;
    // Start is called before the first frame update
    void Start()
    {
        n = Random.Range(0, backgroundSprite.Count);
        backSprite = backgroundSprite[n];
        backgroundImage.sprite = backSprite;
        backgroundImage2.sprite = backSprite;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int secondes = (int)timer % 60;
        if (secondes % 60 == 0 && onChangeBack == true)
        {
            n++;
            if (n + 1 > backgroundSprite.Count)
            {
                n = 0;
            }
            backSprite = backgroundSprite[n];
            backgroundImage.sprite = backSprite;
            onChangeBack = false;
            if (test == true)
            {
                background.transform.DOMoveY(0, 1);
                background.transform.DOMoveX(0, 1);
                background.transform.DOScale(1, 1);
                test = false;
            }
        }
        if (secondes % 30 == 0 && onChangeBack == true)
        {
            backg = Random.Range(0, 4);
            while (backg == oldbackg)
            {
                backg = Random.Range(0, 4);
            }
            oldbackg = backg;
            n++;
            if (n + 1 > backgroundSprite.Count)
            {
                n = 0;
            }
            backSprite = backgroundSprite[n];
            backgroundImage2.sprite = backSprite;
            onChangeBack = false;

            if (test == false)
            {
                if (backg == 0)
                {
                    background.transform.DOMoveY(10, 1);//décale en haut
                    test = true;
                }
                else if (backg == 1)
                {
                    background.transform.DOMoveX(18, 1);//décale a droite
                    test = true;
                }
                else if (backg == 2)
                {
                    background.transform.DOScale(0, 1);
                    test = true;
                }
                else if (backg == 3)
                {
                    background.transform.DOMoveY(-10, 1);//décale en bas
                    test = true;
                }
                else if (backg == 4)
                {
                    background.transform.DOMoveX(-18, 1);//décale a gauche
                    test = true;
                }
            }
        }
        if (secondes % 2 == 1)
        {
            onChangeBack = true;
        }
    }
}