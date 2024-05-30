using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
  public GameObject ground;
  Vector3 nextSpawnPoint;


    void Start()
    {  
       Spawn();   
    }

    private void OnTriggerEnter(Collider other)
    {
        Spawn();
       
    }
     public void  Spawn()
    {
      GameObject temp = Instantiate(ground,nextSpawnPoint, Quaternion.identity);
      nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }   
}
