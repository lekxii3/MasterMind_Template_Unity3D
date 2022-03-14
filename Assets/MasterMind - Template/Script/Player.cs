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
  
   private Lignes _accesToSphere;
   private Sphere sphere;
   
   public Color[] _tableauColor5 = new Color[] {Color.blue,Color.red,Color.magenta, Color.white, };
   //---------------------------//

   public delegate void TestColor();

   public static event TestColor jetest;
   public LigneATrouver LigneATrouver;
   private GameObject SphereATrouver; 


   private void Awake()
   {
       jetest += Comparaison;
       
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
            lines[index].gameObject.GetComponent<Lignes>().enabled = false;
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
                if (hitInfo.collider.gameObject.GetComponent<Sphere>() && hitInfo.collider.transform.parent.gameObject.GetComponent<Lignes>().enabled == true ) 
                {
                    Vector3 distanceToTarget = hitInfo.point - Camera.main.transform.position;
                    Vector3 direction = distanceToTarget.normalized;
                    //Debug.Log(hitInfo.transform.name);
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



    private void Comparaison()
    {
        Debug.Log("je compare");
        //---------------------------//
        // permet de décomposé et de trouver le probleme 
        var sphere = LigneATrouver.sphere[0];
        var render = sphere.GetComponent<Renderer>();
        var material = render.material;
        var color = material.color;
        //---------------------------//
        
        SphereATrouver.GetComponent<Renderer>().material.color = LigneATrouver.sphere[0].GetComponent<Renderer>().material.color;

        for (int i = 0; i < lines[i].spherePositions.Length; i++)
        {
            if (LigneATrouver.sphere[0].GetComponent<Renderer>().material.color ==
                lines[i].spherePositions[i].GetComponent<Renderer>().material.color) ;
            {
                Debug.Log("c'est la bonne couleur à la bonne position");
            }
        }
    }

    private void OnDisable()
    {
        jetest.Invoke();
    }


    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    // code essai non fonctionnel 
    /*   Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint((mousePos));
        Debug.DrawRay(transform.position,mousePos-transform.position,Color.cyan);*/
    
}
