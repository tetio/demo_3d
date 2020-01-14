using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 9.9f) {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.up*speed*Time.deltaTime);

    }
}
