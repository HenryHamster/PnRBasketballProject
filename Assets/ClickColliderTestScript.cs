using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickColliderTestScript : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("Clicked on: " + name);
    }
    private void Update()
    {
        //Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit rh, 100);
        //if(rh.collider!=null)//Debug.Log("Raycast hit: " + rh.collider.name);
    }
}
