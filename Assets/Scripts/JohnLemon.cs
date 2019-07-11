using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemon : MonoBehaviour
{
    private Animator animator;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        bool isWalk = Input.GetAxis("Vertical") > 0;
        transform.Rotate(new Vector3(0, horizontal, 0));
        animator.SetBool("IsWalking", isWalk);
        //Debug.Log("update.");
    }

    void FixedUpdate()
    {
        //Debug.Log("fixed update.");
    }
}
