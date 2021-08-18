using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Puzzle3Handler : PuzzleHandler
{
    #region Private Variables
    private GameObject fire;
    private GameObject windowFrame;
    private GameObject computerDesk;
    private Transform lantern;
    private float countDownTime;
    private float timer;
    private bool startTimer;
    #endregion

    private void Start()
    {
        timer = 0;
        startTimer = false;
        StartCoroutine(Checkconditions());
        countDownTime = 1.0f;
        fire = (GameObject)Resources.Load("Prefabs/Level2/Fire");
        for(int i=0; i<children.Length;i++)
        {
            if(children[i].name=="Window Frame")
            {
                windowFrame = children[i].gameObject;
                
            }
            if(children[i].name=="Computer Desk")
            {
                computerDesk = children[i].gameObject;
            }
            if (children[i].name == "Lantern")
            {
                lantern = children[i];
            }
        }
    }

    private IEnumerator Checkconditions()
    {
        PuzzleObjectHandler outerHandler = null;
        Transform outer = null;
        PuzzleObjectHandler glassPartHandler = null;
        Transform glassPart = null;
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name.Equals("Outer"))
            {
                outer = children[i];
                outerHandler = children[i].GetComponent<PuzzleObjectHandler>();
            }
            if(children[i].name.Equals("Glass Part"))
            {
                glassPart = children[i];
                glassPartHandler = children[i].GetComponent<PuzzleObjectHandler>();
            }
        }

        while (finished() != true)
        {
            
            if (outerHandler.getMaterial() == "paper" && glassPartHandler.getMaterial()=="paper")
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
        while (windowFrame != null)
        {
            Vector3 pos1 = lantern.position;
            Vector3 pos2 = windowFrame.transform.position;







            if (timer > countDownTime * 7)
            {
                Instantiate(fire, pos2, Quaternion.identity);
                Destroy(windowFrame);
            }
            else if (timer > countDownTime * 6)
            {
                Instantiate(fire, pos2 + new Vector3(5, -0.5f, 0), Quaternion.identity);
                
            }
            else if (timer > countDownTime * 5)
            {
                Instantiate(fire, pos2 + new Vector3(10, -0.5f, 0), Quaternion.identity);
            }
            else if (timer > countDownTime * 4)
            {
                Instantiate(fire, pos1 + new Vector3(2, -0.5f, 0), Quaternion.identity);
                Instantiate(fire, pos1 + new Vector3(0, -0.5f, 2), Quaternion.identity);
                Instantiate(fire, pos1 + new Vector3(-2, -0.5f, 0), Quaternion.identity);
                Instantiate(fire, pos1 + new Vector3(0, -0.5f, -2), Quaternion.identity);
            }
            else if (timer > countDownTime * 3)
            {
                Instantiate(fire, pos1 + new Vector3(0, -0.5f, 0), Quaternion.identity);

            }
            else if (timer > countDownTime * 2)
            {
                Instantiate(fire, pos1 + new Vector3(0, -0.2f, 0), Quaternion.identity);

            }
            else if (timer > countDownTime)
            {
                Instantiate(fire, pos1, Quaternion.identity);

            }

            yield return null;
        }
        

    }

    public override void LoadNextScene()
    {
        SceneManager.LoadScene("Level1");
    }
    private void Update()
    {
        if(startTimer)
        timer += Time.deltaTime;
        //Debug.Log(timer);
    }
}
