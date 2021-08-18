using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjectHandler : MonoBehaviour
{
    // Start is called before the first frame update
    #region Private Variables

    //[SerializeField]
    private MaterialHandler m_materialhandler;
    private Transform[] children;
    //[SerializeField]
    //[Tooltip("name of the starting material of the object")]
    private string m_material;
    private bool hasChanged;
  
    #endregion

    #region Serialized Field
    

    [SerializeField]
    [Tooltip("list of materials the object can be changed to.")]
    private string[] m_Materials;
    
    private PuzzleHandler puzzle;

    private GameObject toolbar;

    #endregion

    void Update()
    {
        
    }

    private void Start()
    {
        Debug.Log("start puzzleobj");
        hasChanged = false;
        m_material = "default";
        m_materialhandler = GetComponent<MaterialHandler>();
        GameObject obj=transform.parent.gameObject;
        while (!obj.CompareTag("Puzzle Handler"))
            obj = obj.transform.parent.gameObject;

        puzzle = obj.GetComponent<PuzzleHandler>();
        
        
        
        
            




        children = GetComponentsInChildren<Transform>();
        /*
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].CompareTag("Toolbar"))
            {
                toolbar = children[i].gameObject;
            }
        }
        */
        toolbar = transform.GetChild(0).gameObject;
        Debug.Log(toolbar.tag);
        
    }

    public GameObject getToolbar()
    {
        return toolbar;
    }
    /*
    public bool GetHasChanged()
    {
        return hasChanged;
    }
    public void changeHasChanged()
    {
        hasChanged = true;
    }*/
    public void changeMaterial(int matSelect)
    {
            switch (matSelect)
            {

                case 1:
                    m_materialhandler.changeMaterial(m_Materials[0]);
               
                    m_material = m_Materials[0];
                    transform.root.GetComponent<GameRunnerHandler>().hideToolbar();
                transform.parent.parent.GetComponent<LevelHandler>().clearSelection();
                    break;

                case 2:
                    
                    m_materialhandler.changeMaterial(m_Materials[1]);
                    m_material = m_Materials[1];
                    transform.root.GetComponent<GameRunnerHandler>().hideToolbar();
                transform.parent.parent.GetComponent<LevelHandler>().clearSelection();

                break;

                case 3:
                    m_materialhandler.changeMaterial(m_Materials[2]);
                    m_material = m_Materials[2];
                    transform.root.GetComponent<GameRunnerHandler>().hideToolbar();
                transform.parent.parent.GetComponent<LevelHandler>().clearSelection();

                break;

                case 4:
                    m_materialhandler.changeMaterial(m_Materials[3]);
                    m_material = m_Materials[3];
                    transform.root.GetComponent<GameRunnerHandler>().hideToolbar();
                transform.parent.parent.GetComponent<LevelHandler>().clearSelection();
                


                break;

                case 5:
                    m_materialhandler.changeMaterial(m_Materials[4]);
                    m_material = m_Materials[4];
                    transform.root.GetComponent<GameRunnerHandler>().hideToolbar();
                transform.parent.parent.GetComponent<LevelHandler>().clearSelection();

                break;
            }
       //}
    }

    public string getMaterial()
    {
        return m_material;
    }



    /*
    public void Change()
    {
        hasChanged = !hasChanged;
    }
#endregion
    // Update is called once per frame

#region Private Variables
//whether the player has selected the object or not
private bool is_selected;
//the material of the object
private string m;

private bool hasChanged;
#endregion

#region initialization
void Start()
{
 is_selected = false;
 hasChanged = false;
 m = m_material;
}
#endregion

#region Accessor
//to see if the object has been selected
public bool Selected()
{
 return is_selected;
}

//return its material
public string GetMaterial()
{
 return m;
}



public bool HasChanged()
{
 return hasChanged;
}
#endregion

#region Mutator
public void Select()
{
 is_selected = true;
}
*/


}
