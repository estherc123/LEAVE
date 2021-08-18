using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : PuzzleHandler
{
    [SerializeField]
    private GameObject m_blood;

    private GameObject rose;
    private GameObject crow;
    private bool startTimer;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
        startTimer = false;
        Transform puzzle12 = transform.parent;
        Transform puzzle11 = transform.parent.parent.GetChild(1);
        rose = puzzle11.GetChild(0).gameObject;
        crow = puzzle12.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (rose.GetComponent<PuzzleObjectHandler>().getMaterial().Equals("wood")&&(!startTimer))
        {
            Debug.Log("blood instantiated");
            m_blood.SetActive(true);
            startTimer = true;
        }

        if (startTimer)
            timer -= Time.deltaTime;
        if(timer<=0)
        {
            Destroy(gameObject);
            m_blood.SetActive(false);
        }

    }
}
