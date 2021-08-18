using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler2D : MaterialHandler
{
    private Rigidbody2D cc_Rb;
    private Material cc_material;
    private Transform transform;
    private SpriteRenderer cc_renderer;
    private bool fly;
    public override  void changeMaterial(string materialSelect)
    {
        switch (materialSelect)
        {
            case "gold":
                changetoGold();

                break;
            case "paper":
                changetoPaper();
                break;
            case "Calcium":
                changetoCalcium();
                break;
            case "Sodium":
                changetoSodium();
                break;
            case "Lithium":
                changetoLithium();
                break;
            case "wood":
                changetoWood();
                break;

            case "ice":
                changetoIce();
                break;
            case "Helium":
                changetoHelium();
                break;

            case "aluminum":
                changetoAluminum();
                break;
            case "copper":
                changetoCopper();
                break;
            default:
                break;
        }
    }
    #region Changing material methods
    public void changetoCalcium()
    {
        fly = false;
        cc_Rb.mass = 1.55F;
        cc_renderer.color = new Color(189 / 256f, 189 / 256f, 189 / 256f);
        cc_material.SetFloat("_Metallic", 0.8F);
        cc_material.SetFloat("_Glossiness", 0.8F);
    }

    public void changetoHelium()
    {
        fly = true;
        cc_Rb.mass = 1;
        cc_renderer.color = new Color(238 / 256f, 238 / 256f, 238 / 256f, 0.5f);
    }

    public void changetoSodium()
    {
        fly = false;
        cc_Rb.mass = 0.97F;
        cc_renderer.color = Color.white;
    }

    public void changetoLithium()
    {
        fly = false;
        cc_Rb.mass = 0.534F;
        cc_renderer.color = new Color(158 / 256f, 158 / 256f, 158 / 256f);
        
    }

    public override void changetoCopper()
    {
        fly = false;
        Debug.Log("changed materail to copper");
        cc_Rb.mass=8.96F;
        cc_renderer.color = new Color(255 / 256f, 124 / 256f, 58 / 256f);

    }
    public void changetoAluminum()
    {
        fly = false;
        cc_Rb.mass = 2.0F;
        cc_renderer.color = new Color(148 / 256f, 148 / 256f, 148 / 256f);
       
    }
    public override void changetoPaper()
    {
        fly = false;
        cc_Rb.mass = 1.0F;
        Debug.Log(cc_renderer.color);
        cc_renderer.color = new Color(193/256f, 191 / 256f, 169 / 256f);
        Debug.Log(cc_renderer.color);
        Debug.Log("changed to paper" + transform.name);
    }
    public override void changetoGold()
    {
        //unit for density is g/cm3
        fly = false;
        cc_Rb.mass=19.32F;
        cc_renderer.color = Color.yellow;
        

    }

    public override void changetoWood()
    {
        fly = false;
        cc_Rb.mass = 0.2f;
        cc_renderer.color = new Color(92/256f,49/256f,12/256f);
        
    }
    public override void changetoIce()
    {
        fly = false;
        Color iceblue = new Color(179 / 256f, 238 / 256f, 255 / 256f);
        cc_Rb.mass=0.8F;
        cc_renderer.color = iceblue;
        cc_material.SetFloat("_Metallic", 0.0F);
        cc_material.SetFloat("_Glossiness", 0.8F);
    }
    

    #endregion
    void Awake()
    {
        cc_Rb = GetComponent<Rigidbody2D>();
        cc_renderer = GetComponent<SpriteRenderer>();
        cc_material = cc_renderer.material;
        transform = GetComponent<Transform>();
        fly = false;
    }
    private void Update()
    {
        if(fly)
            cc_Rb.AddForce(new Vector2(0.0f, 20.0f));
    }


}
