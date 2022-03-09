using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerPlayer : MonoBehaviour
{
    private float speed = 10f;                                                  // Скорость персонажа 
    private float JumpForce = 145f;                                             // Сила применяемая к персонажу в момент прыжка
    
    private bool isGround;                                                      // Переменная которая отвечает за состояние на земле ли персонаж?

    private Rigidbody2D rb;                                                     
    private SpriteRenderer SP;                                                  // Ссылки
    private Animator Anim;                                                     

    public float Health = 1f;                                                   // Количество жизней, что логично в целом)
    private int Score = 0;                                                      // Количество очков

    public Transform SpawnPos;                                                  // Позиция на карте, где спавнится персонаж. Позицией выступают координаты пустого объекта. В дальнейшем, можно настроить координаты Vector
   

    public Image Bar;
    /// <summary>
    /// Получение компонентов
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
    /// Метод который отвечает за отнимание шкалы здоровья 
    /// </summary>
    public void BarFill()
    {
        Health -= 0.25f;
        Bar.fillAmount = Health;  
    }
    /// <summary>
    /// Проверка сдох ли игрок, ну вернее упал ли он за карту, или не задамажили ли его
    /// </summary>
    private void Update()
    {
        DeadCheck();
    }
    /// <summary>
    /// Вызываются методы передвижения, не в зависимости от частоты кадров с фиксированной величиной
    /// </summary>
    void FixedUpdate()
    {
        Move();
        Jump();
    }
    /// <summary>
    /// Движение объекта, идет проверка по нажатию клавиш
    /// </summary>
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
            Anim.SetBool("Run", true);                                      // Включение анимации бега
            SP.flipX = true;                                                // Поворот объекта
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
            Anim.SetBool("Run", true);                                      // Включение анимации бега
            SP.flipX = false;
        }
        else
        {    
            Anim.SetBool("Run", false);
        }
    }
    /// <summary>
    /// Метод отвечает за прыжок, идет проверка стоит ли персонаж на земле, если это так, то к персонажу применяется сила 
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
        if (transform.position.y < -10f)                                    // Проверка на каких координатах стоит объект и не упал ли он за сцену
        {
            
            BarFill();
            if (Health >= 0.25f)                                            // Если жизней хватает на спавн* Перемещение персонажа на исходную точку
            {
                transform.position = SpawnPos.position;
            }
            else
            {
                Destroy(this.gameObject);                                   // В любом другом случае наш герой уничтожается и игра считается завершенной 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)                  // Проверка на вход в объект тэга земля
    {
        if (collision.transform.tag == "Ground")            
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)                   // Проверка на выход в объект тэга земля
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false;
            Anim.SetTrigger("Jump");                                        // В воздухе проигрывается анимация прыжка и падения поочередно
            Anim.SetTrigger("Jumpdrop");
            
        }
    }


}
