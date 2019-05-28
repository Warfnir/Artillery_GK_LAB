using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public ParticleSystem explosion;
    ResultScript resScript;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Result");
        resScript = canvas.GetComponent<ResultScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem ps;
        ps = Instantiate(explosion, collision.collider.transform.position, transform.rotation);
        ps.Play();
        resScript.hits += 1;
        Destroy(this.gameObject);
        Destroy(collision.collider.gameObject);
    }
}
