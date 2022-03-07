using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LigneATrouver : MonoBehaviour
{
 //---------------------------------------------------------//
 private Color _bleu = Color.blue;
 private Color _rouge = Color.red;
 private Color _violet = Color.magenta;
 private Color _blanc = Color.white;

 private Color[] _tableauColor = new Color[4];

 public GameObject[] sphere;
 //---------------------------------------------------------//
 
 private void Start()
 {
  _tableauColor = new[] {_bleu, _rouge, _violet, _blanc};


  sphere[0].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];  //et non pas Random.Range(0,3), car si un jour je change de nombre de couleur, je risque de perdre du temps a changer
  sphere[1].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];
  sphere[2].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];
  sphere[3].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];


  //sphere[0].GetComponent<Renderer>().material.color = _blanc;

 }
}
