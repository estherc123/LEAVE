using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle5Handler : PuzzleHandler
{
    private GameObject ivy;
    private GameObject bulbLight;
    private bool startTimer;
    private float timer;
    private float actionDelayedTime;
    void Start()
    {
        actionDelayedTime = 2.0f;
        timer = actionDelayedTime;
        startTimer = false;
        
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name == "Ivy")
            {
                ivy = children[i].gameObject;

            }
            if (children[i].name == "BulbLight")
            {
                bulbLight = children[i].gameObject;

            }
        }
        StartCoroutine(CheckConditions());
    }

    
    private IEnumerator CheckConditions()
    {
        while (finished() != true)
        {

            if (ivy.GetComponent<PuzzleObjectHandler>().getMaterial() == "copper" )
            {

                StartCoroutine(ChainReaction());
                startTimer = true;
                completepuzzle();

            }
            yield return null;
        }
    }


    private IEnumerator ChainReaction()
    {
        while(true)
        {
            if(timer<0)
            {
                for(int i=0; i<bulbLight.transform.childCount; i++)
                {
                    bulbLight.transform.GetChild(i).GetComponent<Light>().intensity = 3;
                }
                timer = actionDelayedTime;
                break;
            }
           
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(startTimer)
        {
            timer -= Time.deltaTime;
        }
    }
}
