using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //---------------------------//
    // variable pour apparition des lignes // 
    private int index = 0;
    public Lignes[] lines = new Lignes[12];
    

    //---------------------------//
    // variable pour raycast // 

   public Camera cam;
   
   //---------------------------//

   private LigneATrouver _tableauColorClass;
   private Lignes _accesToSphere;
   private Sphere sphere;
   
   public Color[] _tableauColor5 = new Color[] {Color.blue,Color.red,Color.magenta, Color.white, };


    private void Start()
    {
        
    }


    void Update()
    {
        apparitionLines();
        infoRaycastChangeColor();
    }

    private void apparitionLines()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            index++;
            lines[index].gameObject.SetActive(true);
            
        }
    }

    private void infoRaycastChangeColor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay((Input.mousePosition));

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Sphere>()) 
                {
                    Vector3 distanceToTarget = hitInfo.point - Camera.main.transform.position;
                    Vector3 direction = distanceToTarget.normalized;
                    Debug.Log(hitInfo.transform.name);
                    Debug.DrawRay(Camera.main.transform.position,hitInfo.point,Color.cyan);
                    
                    sphere = hitInfo.collider.gameObject.GetComponent<Sphere>();
                    
                    hitInfo.collider.GetComponent<MeshRenderer>().material.SetColor("_Color",_tableauColor5[sphere.index]);
                    sphere.index++;
                    if (sphere.index == 4)
                    {
                        sphere.index = 0;
                    }
                    
                    

                }
            }
        }


        //public Color GetSphereColor()
        {
           // return GetComponent<MeshRenderer>().material.GetColor("__color");
        }

        //public void SetSphereColor(Color newColor)
        {
            //GetComponent<MeshRenderer>().material.SetColor("__color",newColor);
        }


    }


  
    
    
    
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    // code essai non fonctionnel 
    /*   Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint((mousePos));
        Debug.DrawRay(transform.position,mousePos-transform.position,Color.cyan);*/
    
}
