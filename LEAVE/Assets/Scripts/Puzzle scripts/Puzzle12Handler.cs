using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle12Handler : PuzzleHandler
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject m_finalportal;
    

    private GameObject crow;
    private GameObject heart;
    void Start()
    {
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name == "Crow")
            {
                crow = children[i].gameObject;
            }
            if(children[i].name=="heart")
            {
                heart = children[i].gameObject;
            }
        }
        Debug.Log("heart?" + heart);
        Debug.Log("crow!" + crow);
        StartCoroutine(CheckConditions());
    }

    private IEnumerator CheckConditions()
    {
        while (finished() != true)
        {

            if (crow.GetComponent<PuzzleObjectHandler>().getMaterial() == "gold" && heart!=null)
            {
                
                Instantiate(m_finalportal);
                Debug.Log("final portal instantiated!");
                completepuzzle();

            }
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
