using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemon : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    //private Transform transform;
    private Vector3 m_Movement;
    private Quaternion m_Rotation = Quaternion.identity;

    public float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        //transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(0f, horizontal);
        bool hasVerticalInput = !Mathf.Approximately(0f, vertical);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        //bool isWalk = vertical > 0;
        //transform.Rotate(new Vector3(0, horizontal, 0));
        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,
            m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
        //Debug.Log(m_Movement);
        Debug.Log(desiredForward);
    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position
            + m_Movement * m_Animator.deltaPosition.magnitude);
        //Debug.Log(m_Rotation);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
