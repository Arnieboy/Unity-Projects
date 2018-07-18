using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private float upForce = 100f;
    private Animator anim;

    private bool IsDead=false;
    private Rigidbody2D rb2d;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    void Update ()
    {
		if(IsDead==false)
        {
            if(Input.GetMouseButton(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce (new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
	}

    void OnCollisionEnter2D ()
    {
        rb2d.velocity = Vector2.zero;
        IsDead = true;
        anim.SetTrigger("Die");
        GameController.instance.BirdDied ();
    }
}
