using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle8Handler : PuzzleHandler
{
    private GameObject spider;
    private bool startTimer;
    private float timer;
    private float actionDelayedTime;
    void Start()
    {
        actionDelayedTime = 2.0f;
        timer = actionDelayedTime;
        startTimer = false;

        Debug.Log("puzzle 8 children:" + children.Length);
        for (int i = 0; i < children.Length; i++)
        {
            Debug.Log("find children");
            if (children[i].name == "spider")
            {
                Debug.Log("find spider");
                spider = children[i].gameObject;

            }

        }
        StartCoroutine(CheckConditions());
    }


    private IEnumerator CheckConditions()
    {
        while (finished() != true)
        {
            Debug.Log(spider.GetComponent<PuzzleObjectHandler>());

            if (spider.GetComponent<PuzzleObjectHandler>().getMaterial() == "porcelain")
            {
                Debug.Log("porcelain");
                Destroy(spider);

                //StartCoroutine(ChainReaction());
                startTimer = true;
                completepuzzle();

            }
            yield return null;
        }
    }


    private IEnumerator ChainReaction()
    {
        while (true)
        {
           

            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
        }
    }
}
