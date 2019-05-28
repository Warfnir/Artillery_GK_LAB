using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
       // ParticleSystem ps;
       // ps = Instantiate(explosion, transform);
       // ps.Play();
       // ps.transform.parent = null;
    }
}
