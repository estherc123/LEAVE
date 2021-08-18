using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler3D : MaterialHandler
{
    
    


    private Rigidbody cc_Rb;
    private Material cc_material;
    private Transform transform;
    private Renderer cc_renderer;
    public override void changeMaterial(string materialSelect)
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

            case "ice":
                changetoIce();
                break;

            case "porcelain":
                changetoPorcelain();
                break;

            case "dirt":
                changetoDirt();
                break;

            case "beef":
                changetoBeef();
                break;

            case "paper":
                changetoPaper();
                break;
            case "copper":
                changetoCopper();
                break;
            default:
                break;
        }
    }

    
    #region Changing material methods
    public override void changetoCopper()
    {
        Debug.Log("changed materail to copper");

        cc_renderer.material = (Material)Resources.Load("Materials/Copper", typeof(Material));

    }
    public override void changetoPaper()
    {
        cc_renderer.material= (Material)Resources.Load("Materials/paper", typeof(Material));
    }
    public override void changetoGold()
    {

        Debug.Log("crow changed!");
        cc_material.color = Color.yellow ;
        cc_material.SetFloat("_Metallic", 1.0F);
        cc_material.SetFloat("_Glossiness", 0.7F);



    }

    public override void changetoDirt()
    {
        Vector3 oldPosition = cc_Rb.position;
        Destroy(cc_Rb.gameObject);
        Instantiate((GameObject)Resources.Load("Prefabs/Level1/dirt"), oldPosition, Quaternion.identity);
    }

    public override void changetoBeef()
    {
       cc_renderer.material = (Material)Resources.Load("Materials/texture of beef", typeof(Material));
    }
    public override void changetoPorcelain()
    {
        
        cc_material.color = Color.white;
        cc_material.SetFloat("_Glossiness", 1.0F);
    }
    public override void changetoWood()
    {

        Debug.Log("rose changed");
        cc_material = (Material)Resources.Load("Materials/wood/showcase",typeof (Material));
        
    }
    public override void changetoIce()
    {
        Color iceblue = new Color(179 / 256f, 238 / 256f, 255 / 256f);
        
        cc_material.color = iceblue;
        cc_material.SetFloat("_Metallic", 0.0F);
        cc_material.SetFloat("_Glossiness", 0.8F);
    }
    public override void changetoWater()
    {
        //cc_Rb.SetDensity(1.0F);
        cc_material.color = Color.blue;
        cc_material.SetFloat("_Metallic", 0.8F);
        cc_material.SetFloat("_Glossiness", 0.8F);
    }
    #endregion

    private void Awake()
    {
        cc_Rb= GetComponent<Rigidbody>();
        cc_renderer = GetComponent<Renderer>();
        cc_material = cc_renderer.material;
        transform = GetComponent<Transform>();
        

    }
}
