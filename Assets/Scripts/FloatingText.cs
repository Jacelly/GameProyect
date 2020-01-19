using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float My_TimeLife = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        My_TimeLife -= 0.03f;
        if (My_TimeLife <= 0)
        {
          Destroy(this.gameObject);
        }
    }
}
