using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 11, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < 0)
        { 
            transform.position = new Vector3(Random.Range(-14f, 14f), 11, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.transform.name);
        if (other.tag == "Player")
        {
            other.transform.GetComponent<Player>().Damage();
            Destroy(this.gameObject);

        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy distroyed!");
            Destroy(this.gameObject);
        }
    }
}
