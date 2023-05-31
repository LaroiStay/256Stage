using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TurssQueue.GameObjects.Enqueue(this.gameObject);
    }

    
   
}
