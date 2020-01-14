using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private int lives = 3;

    private float nextFire = -1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        fireLaser();


    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 1f, 0);
        }
        else if (transform.position.y > 9.8)
        {
            transform.position = new Vector3(transform.position.x, 9.8f, 0);
        }
        if (transform.position.x < -14)
        {
            transform.position = new Vector3(14, transform.position.y, 0);
        }
        else if (transform.position.x > 14)
        {
            transform.position = new Vector3(-14, transform.position.y, 0);
        }
    }

    void fireLaser() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            Instantiate(laserPrefab, transform.position+new Vector3(0, 1.0f, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void Damage() 
    {
        lives -= 1;
        Debug.Log("I've been hit, remaining lives= "+ lives);

        if (lives < 1) {
            Destroy(this.gameObject);
        }
    }
}
