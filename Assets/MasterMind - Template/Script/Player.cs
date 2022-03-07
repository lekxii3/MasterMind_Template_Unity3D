using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //---------------------------//
    private int index = 0;
    public GameObject[] line;
    //---------------------------//

   public Camera cam;

    private void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            index++;
            line[index].SetActive(true);
        }


        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay((Input.mousePosition));

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("Sphere"))
                {
                    Vector3 distanceToTarget = hitInfo.point - transform.position;
                    Vector3 direction = distanceToTarget.normalized;
                    Debug.Log(hitInfo.transform.name);
                    
                }
            }
        }
        
        
        
            

    }


  
    
    
    
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    // code essai non fonctionnel 
    /*   Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint((mousePos));
        Debug.DrawRay(transform.position,mousePos-transform.position,Color.cyan);*/
    
}
