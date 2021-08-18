using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler : MonoBehaviour
{
    public virtual void changeMaterial(string materialSelect)
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
    public virtual void changetoCopper()
    { }
    public virtual void changetoPaper()
    {   
    }
    public virtual void changetoGold()
    {
    }

    public virtual void changetoDirt()
    {
        
    }

    public virtual void changetoBeef()
    {
       
    }
    public virtual void changetoPorcelain()
    {
        
    }
    public virtual void changetoWood()
    {

       
    }
    public virtual void changetoIce()
    {
        
    }
    public virtual void changetoWater()
    {
        
    }
    #endregion

}
