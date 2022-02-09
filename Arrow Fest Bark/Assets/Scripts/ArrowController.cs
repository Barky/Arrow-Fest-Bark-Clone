using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.EditorCoroutines.Editor;

public class ArrowController : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    public GameObject arrow;
    public Transform parent;
    public float minX, maxX;
    public LayerMask layerMask;
    public float distance;
    private bool isdecreasing = false;
    private int arrowcount = 1, arrowlayers = 1;
    public InputField inp;

    private float arrowRadius = 0.3f, currentradius = 0.5f, radiusparam = 0.2f;
    private void Update()
    {
        
    }


    void CreateArrow(int no)
    {
        arrowcount += no;
        for (int i = arrows.Count; i < arrowcount; i++)
        {
            GameObject newarrow = Instantiate(arrow, parent);
            arrows.Add(newarrow);
            newarrow.transform.position = Vector3.zero;
        }
        
        Arrange();
    }

    void DestroyArrow(int result)
    {
        arrowcount -= result;
        for (int i = arrows.Count - 1; i >= arrowcount; i--)
        {
            GameObject deletearrow = arrows[arrowcount - 1];
            arrows.RemoveAt(arrowcount - 1);
            StartCoroutine(DestroyObject(deletearrow));
        }
        Arrange();
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
        int amount = howmanyarrowstokeep(currentradius);
        
        float spacing = 2 * Mathf.PI / amount;

        int tempno = amount;

        float arrowCount = arrows.Count;
        Debug.Log("first amount: " + amount + " arrowlayers: " + arrowlayers + " arrow count: "+arrowCount);
        arrows[0].transform.position = Vector3.zero;
        for (int i = 1; i < arrowCount; i++)
        {
            
            if(i == tempno+1)
            {
                currentradius += radiusparam;
                amount = howmanyarrowstokeep(currentradius);
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
            arrow.position = Vector3.zero + pos;
            timer++;
        }

        Debug.Log("last amount: " + amount + " arrowlayers: " + arrowlayers + " arrow count: " + arrowCount);
    }
    int howmanyarrowstokeep(float radius)
    {
        
        float circleCircumference = 2 * Mathf.PI * radius;
        int amount = (int)(circleCircumference / arrowRadius);
        return amount;
    }
    public void TakeNumberPositive()
    {
        int.TryParse(inp.text, out int result);
        CreateArrow(result);
    }
    public void TakeNumberNegative()
    {
        int.TryParse(inp.text, out int result);
        DestroyArrow(result);
    }

    //void getRay()
    //{
    //    Debug.Log("çalýþtý");
    //    Vector3 mousepos = Input.mousePosition;
    //    mousepos.z = Camera.main.transform.position.z;

    //    Ray ray = Camera.main.ScreenPointToRay(mousepos);
    //    RaycastHit hit;

    //    if(Physics.Raycast(ray, out hit, 100, layerMask))
    //    {
    //        Vector3 mouse =hit.point;

    //        mouse.x = Mathf.Clamp(mouse.x, minX, maxX);

    //        distance = mouse.x; 

    //        Arrange();
    //    }
    //}
}
                

                
        
    



