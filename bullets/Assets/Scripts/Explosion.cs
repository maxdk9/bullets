using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion: MonoBehaviour
{
    private float duration;
    private void Start()
    {
        duration = this.GetComponent<ParticleSystem>().duration;
        Destroy(this.gameObject,duration);
        
    }


}
