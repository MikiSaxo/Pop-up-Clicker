using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public List<Sprite> backgroundSprite;
    public Sprite backSprite;
    public Image backgroundImage;
    float timer = 0.0f;
    int n = 0;
    bool onChangeBack = false;
    // Start is called before the first frame update
    void Start()
    {
        n = Random.Range(0, backgroundSprite.Count);
        backSprite = backgroundSprite[n];
        backgroundImage.sprite = backSprite;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int secondes = (int)timer % 60;
        if (secondes % 10 == 0 && onChangeBack == true)
        {
            n++;
            if (n + 1 > backgroundSprite.Count)
            {
                n = 0;
            }
            backSprite = backgroundSprite[n];
            backgroundImage.sprite = backSprite;
            onChangeBack = false;
        }
        if (secondes % 2 == 1)
            onChangeBack = true;
    }
}
