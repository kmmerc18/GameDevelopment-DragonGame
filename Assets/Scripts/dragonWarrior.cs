using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonWarrior : MonoBehaviour
{
    [SerializeField] bool enemy = true;
    [SerializeField] float velocity = 5.0f;
    [SerializeField] GameObject fireball;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myAnimator.SetBool("alive", false);
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy)
        {
            Vector3 movement = Vector3.up * velocity * Time.deltaTime
                * Input.GetAxis("Vertical");
            transform.position += movement;

            if (Input.GetAxis("Vertical") == 0.0f)
            {
                // idling
                myAnimator.SetBool("walking", false);

            }
            else
            {
                // walking
                myAnimator.SetBool("walking", true);
            }

            if(Input.GetButtonDown("Fire1"))
            {
                Vector3 fireballPosition = transform.position +
                    new Vector3(1.0f, -0.5f, 0.0f);
                Instantiate(fireball, fireballPosition, transform.rotation);
            }
        }

    }
}
