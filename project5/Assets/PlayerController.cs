using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator m_animator;

    private Vector3 m_velocity;

    private bool m_wasGrounded;
    private bool m_isGrounded = true;

    public float m_moveSpeed = 2.0f;
    public float m_jumpForce = 5.0f; //위로 올리는 값

    void Start()
    {
       
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_animator.SetBool("Grounded", m_isGrounded);
        PlayerMove();
        JumpingAndLanding();
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            transform.localScale = new Vector3(2, 1, 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("hi");
            this.transform.localScale = new Vector3(2, 2, 2);
        }
        m_wasGrounded = m_isGrounded;
    }
    private void PlayerMove()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float gravity = 20.0f;

        if (controller.isGrounded)
        {
            m_velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            m_velocity = m_velocity.normalized;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                m_velocity *= 2.0f;
            }
            m_animator.SetFloat("MoveSpeed", m_velocity.magnitude);

            if (Input.GetButtonDown("Jump"))
            {
                m_velocity.y = m_jumpForce;
            }
            else if (m_velocity.magnitude > 0.5)
            {
                transform.LookAt(transform.position + m_velocity);
            }
        }
        m_velocity.y -= gravity * Time.deltaTime; // y값이 계속 줄어들지만 character controller가 rigidbody와 collider 의 역할을 일부 수행해주기 때문에 하염없이 떨어지지 않는다.
        controller.Move(m_velocity * m_moveSpeed * Time.deltaTime);
        m_isGrounded = controller.isGrounded;
    }
    private void JumpingAndLanding()
    {
        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }


}
