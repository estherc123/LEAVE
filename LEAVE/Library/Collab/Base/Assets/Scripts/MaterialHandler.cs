using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler : MonoBehaviour
{
    private Rigidbody cc_Rb;
    private Material cc_material;
    private Transform transform;
    private Renderer cc_renderer;
    public void changeMaterial(string materialSelect)
    {
        switch (materialSelect)
        {
            case "gold":
                changetoGold();

                break;

            case "wood":
                changetoWood();
                break;

            case "water":
                changetoWater();
                break;

            default:
                break;
        }
    }

    public void changetoGold()
    {
        cc_Rb.SetDensity(19.32F);
        cc_material.color = Color.yellow;
        cc_material.SetFloat("_Metallic", 0.8F);
        cc_material.SetFloat("_Glossiness", 0.8F);


    }
    public void changetoWood()
    {

    }

    public void changetoWater()
    {

    }

    private void Awake()
    {
        cc_Rb= GetComponent<Rigidbody>();
        cc_renderer = GetComponent<Renderer>();
        cc_material = cc_renderer.GetComponent<Material>();
        transform = GetComponent<Transform>();
        

    }
}
