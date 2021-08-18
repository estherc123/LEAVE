using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHandler : MonoBehaviour
{
    [SerializeField]
    private ToolbarControllerHandler m_toolbarcontrollerhandler;

    public void setandshowtoolbar(GameObject toolbar)
    {
        m_toolbarcontrollerhandler.hidetoolbar();
        m_toolbarcontrollerhandler.gettoolbar(toolbar);
        m_toolbarcontrollerhandler.showtoolbar();

    }
    public void hideToolbar()
    {
        m_toolbarcontrollerhandler.hidetoolbar();

    }
    /*
   Vector3 pos = new Vector3(0, 0, 0);

   GameObject parentGameObject = new GameObject();
   Canvas canvas = parentGameObject.AddComponent<Canvas>();

   GameObject imageGameObject = new GameObject();
   imageGameObject.transform.SetParent(canvas.transform);

   Image image = imageGameObject.AddComponent<Image>();
   image.color = new Color(1.0F, 0.0F, 0.0F);

   imageGameObject.transform.position = pos;
   */
}
