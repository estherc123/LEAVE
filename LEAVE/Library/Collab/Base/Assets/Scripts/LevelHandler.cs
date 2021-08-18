using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField]
    private int m_mode;

    [SerializeField]
    private int m_numberofscenes;

    private int numbersolved;
    private GameObject selectedObject;
    private GameObject highlightedObject;
    

    private void Start()
    {
        selectedObject = null;
        highlightedObject = null;
        numbersolved = 0;

        if(m_mode==2)
        {
            transform.root.GetComponent<GameRunnerHandler>().changeMode(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }


   public bool HasSolvedScene()
    {
        if(numbersolved==m_numberofscenes)
        {
            return true;
        }
        return false;
    }

    public void SolveScene()
    {
        numbersolved++;
    }
    
    public void selectObject(RaycastHit hitInfo)
    {

        GameObject objHit = findCorrectObject(hitInfo);
        Debug.Log(objHit.name);
        if (objHit.CompareTag("Physics-game Object"))
            objHit = objHit.transform.parent.gameObject ;
        if (objHit.tag == "PuzzleObject")
        {
            if (selectedObject != null)
            {
                if (objHit == selectedObject)
                {
                    return;
                }
                clearSelection();
            }
            if (objHit == highlightedObject)
            {
                clearHighlight();
            }

            
            
                selectedObject = objHit;
                Debug.Log(selectedObject.name);
                transform.root.GetComponent<GameRunnerHandler>().changeAndEnableSelectedToolbar(selectedObject.GetComponent<PuzzleObjectHandler>().getToolbar());
                
           

        }

        if(objHit.CompareTag("PuzzleBox"))
        {
            Application.LoadLevelAdditive(objHit.GetComponent<AssociateScene>().GetAssociateScene());
            Debug.Log("puzzle box" + objHit.GetComponent<AssociateScene>().GetAssociateScene());
            transform.root.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void highlightObject(RaycastHit hitInfo) {

        GameObject objHit= findCorrectObject(hitInfo);

        if (highlightedObject != null)
        {
            if(objHit == highlightedObject)
            {
                return;
            }
            clearHighlight();
        }
        if (objHit == selectedObject)
        {
            return;
        }
        //if (!objHit.CompareTag("PuzzleObject"))
          //  return;
        highlightedObject = objHit;
    }

    
    public void clearHighlight()
    {
        highlightedObject = null;
    }

    public void clearSelection()
    {
        selectedObject = null;
    }


    private GameObject findCorrectObject(RaycastHit hitInfo)
    {
        return hitInfo.transform.gameObject;
    }

    public void changeSelectedObjectsMaterial(int matSelect)
    {
        if (selectedObject != null)
        {
            Debug.Log(selectedObject.name);
            selectedObject.GetComponent<PuzzleObjectHandler>().changeMaterial(matSelect);
        }

    }


    private void Update()
    {
        if(highlightedObject != null) {
            //Debug.Log("Highlighted is" + highlightedObject.name);
        }
        if (selectedObject != null)
        {
           //Debug.Log("Selected is" + selectedObject.name);
        }
        else
        {
           

        }
    }

}
