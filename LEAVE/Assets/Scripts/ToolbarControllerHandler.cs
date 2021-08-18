using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarControllerHandler : MonoBehaviour
{

    private GameObject currentToolbar;

    public void gettoolbar(GameObject toolbar)
    {
        currentToolbar = toolbar;
    }

    public void showtoolbar()
    {
        if (currentToolbar != null)
        {
            currentToolbar.SetActive(true);
        }
    }

    public void hidetoolbar()
    {
        if (currentToolbar != null)
        {
            currentToolbar.SetActive(false);
        }

    }

}
