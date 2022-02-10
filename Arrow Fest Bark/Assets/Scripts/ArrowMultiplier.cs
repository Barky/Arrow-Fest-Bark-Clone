using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMultiplier : MonoBehaviour
{
    private List<GameObject> arrows = new List<GameObject>();
    public GameObject arrow;
    public Transform parent;
    private int arrowcount = 1, arrowlayers = 1;

    [HideInInspector] public bool istriggered;

    private float arrowRadius = 0.3f, currentradius = 0.5f, radiusparam = 0.2f;

    private void Start()
    {
        if (arrows.Count == 0)
        {
            GameObject firstarrow = Instantiate(arrow, parent);
            firstarrow.tag = "Arrow";
            arrows.Add(firstarrow);
            
        }
        
    }

    

    public void Calculations(string tag, int no)
    {
        
        switch (tag)
        {
            case "PlusGate":
                CreateArrow(no);
                break;
            case "MinusGate":
                DestroyArrow(no);
                break;
            case "MultiplyGate":
                int plus_no = (int) (arrowcount * (no - 1));
                CreateArrow((plus_no));
                break;
            case "DivideGate":
                int to_divide = (int) arrowcount / no;
                int minus_no = (arrowcount - to_divide > 1) ? (arrowcount - to_divide) : 1;
                DestroyArrow(minus_no);
                break;
            default:
                throw new ArgumentException("error verdi");
        }
        Arrange();
        Debug.LogError(arrowcount);
    }
    void CreateArrow(int no)
    {
        arrowcount += no;
        for (int i = arrows.Count; i < arrowcount; i++)
        {
            GameObject newarrow = Instantiate(arrow, parent);
            newarrow.tag = "CloneArrow";
            arrows.Add(newarrow);
            newarrow.transform.position = Vector3.zero;
        }
    }

    public void DestroyArrow(int result)
    {
        if (arrowcount - result <= 0)
        {
            Debug.LogError("game over");
            return;
        }
        
        arrowcount -= result;
        
        for (int i = arrows.Count - 1; i >= arrowcount; i--)
        {
            GameObject deletearrow = arrows[arrowcount - 1];
            arrows.RemoveAt(arrowcount - 1);
            StartCoroutine(DestroyObject(deletearrow));
        }
    }
    IEnumerator DestroyObject(GameObject arrow)
    {
        yield return new WaitForEndOfFrame();
        Destroy(arrow);
    }
    void Arrange()
    {
        currentradius = 0.5f;
        int timer = 1;
        int amount = arrowstokeep(currentradius);
        
        float spacing = 2 * Mathf.PI / amount;

        int tempno = amount;

        float arrowCount = arrows.Count;


        for (int i = 1; i < arrowCount; i++)
        {
            
            if(i == tempno+1)
            {
                currentradius += radiusparam;
                amount = arrowstokeep(currentradius);
                spacing = 2 * Mathf.PI / amount;
                tempno += amount;
                timer = 1;
                arrowlayers++;
            }
            Transform arrow = arrows[i].transform;
            Vector3 pos = Vector3.zero;
            float theta = timer * spacing;
            pos.x = Mathf.Sin(theta) * currentradius;
            pos.y = Mathf.Cos(theta) * currentradius;
            arrow.position = arrows[0].transform.position + pos;
            timer++;
        }
    }
    int arrowstokeep(float radius)
    {
        
        float circleCircumference = 2 * Mathf.PI * radius;
        int amount = (int)(circleCircumference / arrowRadius);
        return amount;
    }

}
                

                
        
    



