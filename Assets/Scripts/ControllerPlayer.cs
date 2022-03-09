using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerPlayer : MonoBehaviour
{
    private float speed = 10f;                                                  // �������� ��������� 
    private float JumpForce = 145f;                                             // ���� ����������� � ��������� � ������ ������
    
    private bool isGround;                                                      // ���������� ������� �������� �� ��������� �� ����� �� ��������?

    private Rigidbody2D rb;                                                     
    private SpriteRenderer SP;                                                  // ������
    private Animator Anim;                                                     

    public float Health = 1f;                                                   // ���������� ������, ��� ������� � �����)
    private int Score = 0;                                                      // ���������� �����

    public Transform SpawnPos;                                                  // ������� �� �����, ��� ��������� ��������. �������� ��������� ���������� ������� �������. � ����������, ����� ��������� ���������� Vector
   

    public Image Bar;
    /// <summary>
    /// ��������� �����������
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SP = GetComponent<SpriteRenderer>();

    }
    void Start()
    {

    }
    /// <summary>
    /// ����� ������� �������� �� ��������� ����� �������� 
    /// </summary>
    public void BarFill()
    {
        Health -= 0.25f;
        Bar.fillAmount = Health;  
    }
    /// <summary>
    /// �������� ���� �� �����, �� ������ ���� �� �� �� �����, ��� �� ���������� �� ���
    /// </summary>
    private void Update()
    {
        DeadCheck();
    }
    /// <summary>
    /// ���������� ������ ������������, �� � ����������� �� ������� ������ � ������������� ���������
    /// </summary>
    void FixedUpdate()
    {
        Move();
        Jump();
    }
    /// <summary>
    /// �������� �������, ���� �������� �� ������� ������
    /// </summary>
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
            Anim.SetBool("Run", true);                                      // ��������� �������� ����
            SP.flipX = true;                                                // ������� �������
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
            Anim.SetBool("Run", true);                                      // ��������� �������� ����
            SP.flipX = false;
        }
        else
        {    
            Anim.SetBool("Run", false);
        }
    }
    /// <summary>
    /// ����� �������� �� ������, ���� �������� ����� �� �������� �� �����, ���� ��� ���, �� � ��������� ����������� ���� 
    /// </summary>

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGround)                           
            {         
                rb.AddForce(Vector3.up * JumpForce);
            }     
        }
    }

    void DeadCheck()
    {
        if (transform.position.y < -10f)                                    // �������� �� ����� ����������� ����� ������ � �� ���� �� �� �� �����
        {
            
            BarFill();
            if (Health >= 0.25f)                                            // ���� ������ ������� �� �����* ����������� ��������� �� �������� �����
            {
                transform.position = SpawnPos.position;
            }
            else
            {
                Destroy(this.gameObject);                                   // � ����� ������ ������ ��� ����� ������������ � ���� ��������� ����������� 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)                  // �������� �� ���� � ������ ���� �����
    {
        if (collision.transform.tag == "Ground")            
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)                   // �������� �� ����� � ������ ���� �����
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false;
            Anim.SetTrigger("Jump");                                        // � ������� ������������� �������� ������ � ������� ����������
            Anim.SetTrigger("Jumpdrop");
            
        }
    }


}
