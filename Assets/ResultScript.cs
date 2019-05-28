using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public int hits;
    public int shoots;
    public Text result;

    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        shoots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        result.text = "Result: " + hits.ToString() + "/" + shoots.ToString();
    }
}
