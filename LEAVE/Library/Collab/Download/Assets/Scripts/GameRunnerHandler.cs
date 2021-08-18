using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameRunnerHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerHandler m_playerhandler;
    [SerializeField]
    private LevelHandler m_levelhandler;
    //[SerializeField]
    //private SoundMusicHandler m_soundmusichandler;
    [SerializeField]
    private DisplayHandler m_displayhandler;

    private float Hinput;
    private float VInput;
    private float XMinput;
    private float YMInput;
    private float MouseInput;
    private bool twoDMode;
    private Vector3 userInputPosition;

    // Start is called before the first frame update
    void Awake()
    {
        Hinput=0;
        VInput=0;
        XMinput=0;
        YMInput=0;
        MouseInput = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        twoDMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        Hinput = Input.GetAxisRaw("Horizontal"); 
        VInput = Input.GetAxisRaw("Vertical");
        XMinput = Input.GetAxisRaw("Mouse X");
        YMInput = Input.GetAxisRaw("Mouse Y");
        MouseInput = Input.GetAxisRaw("MouseClick");



        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        //Debug.Log("mouse2 " + Input.mousePosition);


        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            
            if (!twoDMode)
            {
                if (Input.GetKeyDown("space"))
                {
                    Debug.Log("hited" + hitInfo.transform.name);
                    m_levelhandler.selectObject(hitInfo);
                }
                else
                {
                    m_levelhandler.highlightObject(hitInfo);
                }
            }
            else if(twoDMode)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    m_levelhandler.selectObject(hitInfo);
                }
                else
                {
                    m_levelhandler.highlightObject(hitInfo);
                }
                   
            }
           
        }
        else
        {
            m_levelhandler.clearHighlight();
        }
  
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("here");
            m_levelhandler.changeSelectedObjectsMaterial(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_levelhandler.changeSelectedObjectsMaterial(2);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_levelhandler.changeSelectedObjectsMaterial(3);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            m_levelhandler.changeSelectedObjectsMaterial(4);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            m_levelhandler.changeSelectedObjectsMaterial(5);

        }
       
    }
    private void FixedUpdate()
    {
        if( !twoDMode) {
            //m_playerhandler.MoveAndRotatePlayer(XMinput, YMInput, Hinput, VInput);
            m_playerhandler.MoveAndRotatePlayerAuthentic(MouseInput, Hinput, VInput);
        }
    }
    
    public void changeMode(bool isTwoD)
    {
        twoDMode = isTwoD;
    }

    public void changeAndEnableSelectedToolbar(GameObject toolbar)
    {
        m_displayhandler.setandshowtoolbar(toolbar);
    }
    public void hideToolbar()
    {
        m_displayhandler.hideToolbar();
    }

    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
