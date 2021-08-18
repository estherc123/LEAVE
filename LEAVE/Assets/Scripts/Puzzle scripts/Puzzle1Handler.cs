using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1Handler : PuzzleHandler
{
    [SerializeField]
    [Tooltip("prefab for flowing water")]
    private GameObject m_flowWater;

    [SerializeField]
    [Tooltip("prefab for  water")]
    private GameObject m_h2o;

    [SerializeField]
    [Tooltip("prefab for  flies")]
    private GameObject m_fly;

    private float countDownTime;
    private void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);
       
       
        StartCoroutine(Checkconditions());
        StartCoroutine(CheckPortal());
        countDownTime = 1.0f;
    }

    private IEnumerator CheckPortal()
    {
        Transform portal = null;
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name.Equals("Portal"))
            {
                portal = children[i];

            }
        }
        while (true)
        {
            

            if (portal.GetComponent<CollisionHelper>().getPortalActivated())
                SceneManager.LoadScene("Level2");
            yield return null;
        }
    }
    private IEnumerator Checkconditions()
    {
        PuzzleObjectHandler puzzleObjHandler = null;
        Transform puzzleObj = null;
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name.Equals("Vase"))
            {
                puzzleObj = children[i];
                puzzleObjHandler = children[i].GetComponent<PuzzleObjectHandler>();
            }
        }
        while (finished() != true)
        {
            
            

            if (puzzleObjHandler.getMaterial() == "dirt")
            {

                StartCoroutine(ChainReaction());
                completepuzzle();
            }

            else if(puzzleObjHandler.getMaterial() == "ice")
            {
                StartCoroutine(WaterOverflow(puzzleObj));
                completepuzzle();
            }

            else if(puzzleObjHandler.getMaterial()=="beef")
            {
                StartCoroutine(Fly());
                completepuzzle();
            }
            yield return null;
        }
    }

    private IEnumerator WaterOverflow(Transform vase)
    {

        float timer2 = countDownTime * 15;
        Vector3 pos1 = new Vector3(0.1f, -4.79f, 0.8f);
        Vector3 pos2 = vase.position + new Vector3(0, 1.0f, 0);
        Vector3 originalPosition = m_h2o.transform.position;
        Instantiate(m_h2o);
        Instantiate(m_flowWater, pos2, Quaternion.identity);
        
        
        while (timer2>0)
        {
            timer2 -= Time.deltaTime;
            Debug.Log("here water"+ m_h2o.transform.position.y);
            float y = 0.007f;
            
            m_h2o.transform.position += new Vector3(0, y, 0);

            yield return null;
        }

        Debug.Log(m_h2o.transform.localScale.y);
        m_h2o.transform.position = originalPosition;
        SceneManager.LoadScene("Level1");

    }

    private IEnumerator Fly()
    {
        float timer1 = countDownTime/2;
        float timer2 = countDownTime * 15;
        while (timer2>0)
        {
            
                Vector3 pos = new Vector3(Random.Range(-10, 10), Random.Range(0, 4), Random.Range(0, 20));
                Instantiate(m_fly, pos, Quaternion.identity);
                
            

            timer1 -= Time.deltaTime;
            timer2 -= Time.deltaTime;
            
            yield return null;
        }
        SceneManager.LoadScene("Level1");
    }
    private IEnumerator ChainReaction()
    {
        Transform flower=null;
        Transform lamp=null;
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name.Equals("flower"))
            {
                flower = children[i];
            }
        }

        while (!flower.GetComponent<CollisionHelper>().getCollided())
        {
            //Debug.Log("collided" +!flower.GetComponent<CollisionHelper>().getCollided());
             float x = 0.01f;
             
            flower.localScale += new Vector3(0, x, 0);
            yield return null;
        }

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] != null)
            {
                
                if (children[i].name.Equals("Ceilling Lamp"))
                {
                    //Debug.Log("lamp?");
                    lamp = children[i];
                }
            }
        }
        
        lamp.GetComponent<Rigidbody>().isKinematic = false;
        
        
    }

    

}
