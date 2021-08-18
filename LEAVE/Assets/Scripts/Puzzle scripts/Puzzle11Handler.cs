using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle11Handler : PuzzleHandler
{
    // Start is called before the first frame update
    #region Private variables
    private GameObject rose;
    private GameObject crow;
    private bool flying;
    private float speed;
    private bool stop;
    #endregion
    void Start()
    {
        stop = false;
        speed = 3.0f;
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name == "Rose")
            {
                rose = children[i].gameObject;

            }
            

        }

        Transform puzzle12 = transform.parent.GetChild(2);
        crow = puzzle12.GetChild(1).gameObject ;
        flying = false;
        StartCoroutine(CheckConditions());
    }

    private IEnumerator CheckConditions()
    {
        while (finished() != true)
        {

            if (rose.GetComponent<PuzzleObjectHandler>().getMaterial() == "beef")
            {

                flying = true;
                Debug.Log("flying!");
                completepuzzle();

            }
            yield return null;
        }
    }

    private void FixedUpdate()
    {

        if (flying)
        {
            float distanceToTarget = Vector3.Distance(crow.transform.position, rose.transform.position);
            float distanceThreshold = 2f;
            if (distanceToTarget <= distanceThreshold)
            {
                stop = true;
            }
            if ( !stop)
            {
                Vector3 dir = rose.transform.position - crow.transform.position;
                dir.Normalize();
                crow.GetComponent<Rigidbody>().MovePosition(crow.transform.position + dir * speed * Time.fixedDeltaTime);
            }
        }
        
    }
    
}
