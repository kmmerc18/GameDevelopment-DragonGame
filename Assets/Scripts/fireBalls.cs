using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBalls : MonoBehaviour
{
    [SerializeField] float velocity;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.right * Time.deltaTime * velocity;
        transform.position += movement;

        if(!gameObject.GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
