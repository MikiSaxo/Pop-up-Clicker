using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFeedBackGold : MonoBehaviour
{
    public bool canSpawn;
    public GameObject FeedbackGold;
    public GameObject target;
    public static SpawnFeedBackGold Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (canSpawn)
        {
            Instantiate(FeedbackGold, target.transform);
            canSpawn = false;
        }
    }
}
