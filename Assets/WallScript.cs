using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject target;
    private GameObject act_target;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(act_target == null)
        {
            Vector3 pos = new Vector3(-23.5f, Random.Range(3.0f, 20.0f), Random.Range(-5.0f, 5.0f));
            Transform trans = transform;
            act_target = Instantiate(target, pos, transform.rotation);
            act_target.transform.Rotate(0, 0, 90);
            Debug.Log("CREATED");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            ParticleSystem ps;
            ps = Instantiate(explosion, collision.collider.transform.position, transform.rotation);
            ps.Play();
            Destroy(collision.collider.gameObject);
        }
    }
}
