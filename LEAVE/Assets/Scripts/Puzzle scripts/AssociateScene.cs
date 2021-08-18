using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssociateScene : MonoBehaviour
{
    [SerializeField]
    private string m_scene;
    
    public string GetAssociateScene()
    {
        return m_scene;
    }
}
