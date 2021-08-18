using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHelper : MonoBehaviour
{
    #region Private trigger variables
    private bool collided;
    private bool portalActivated;
    private bool sudokuboxCollided;
    private bool sudokuballCollided;
    private bool crowCollided;
    #endregion
    void Start()
    {
        collided = false;
        portalActivated = false;
        sudokuboxCollided = false;
        sudokuballCollided = false;
        crowCollided = false;
    }

    

    #region Accessor methods
    public bool getsudokuballCollided()
    {
        return sudokuballCollided;
    }
    public bool getsudokuboxCollided()
    {
        return sudokuboxCollided;
    }
    public bool getCollided()
    {
        return collided;
    }
    public bool getPortalActivated()
    {
        return portalActivated;

    }
    public bool getCrowCollided()
    {
        return crowCollided;
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (name.Equals("flower") && other.name.Equals("ceiling"))
        {
            collided = true;
        }
         if (name.Equals("Ceilling Lamp") && other.name.Equals("Floor"))
        {
            Destroy(other);
        }
         if (name.Equals("Portal") && other.name.Equals("Player"))
            portalActivated = true;
        if (name.Equals("Crow") && other.name.Equals("Scale"))
            crowCollided = true;
        
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.collider.gameObject;
        if (name.Equals("SudokuBox") && other.name.Equals("Ball1 (1)"))
            sudokuboxCollided = true;
        if (name.Equals("SudokuBall"))
            sudokuballCollided = true;
        if ((name.Equals("destroyblock") || name.Equals("destroyblock2")) && other.name.Equals("Ball1"))
        {
            Debug.Log("collided:" + other.name);
            Destroy(other);
        }
        if (name.Equals("Smoke") && other.name.Equals("Player"))
            SceneManager.LoadScene("Final Scene");
    }
}
