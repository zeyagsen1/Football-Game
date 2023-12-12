using System.Data;
using UnityEngine;
using UnityEngine.Animations;

public class player1 : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody2D rb;
    public float moveSpeed = 5;
    public bool isGround;
    private Rigidbody2D ballRb;
    
   void shoot(){

        if(canShoot){
          
          ballRb.AddForce(new Vector2(-1,1*Time.deltaTime),ForceMode2D.Impulse);


        }

        




    }

   
   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
          if (Input.GetKey(KeyCode.LeftShift ))
        {
          shoot();
         }
        // Movement controls
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
         
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
          

            if (isGround)
            {
                jump();
            }
        }
    }

    void jump()
    {
        if (isGround)
        {
            rb.AddForce(Vector2.up * 5000, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    void FixedUpdate()
    {
    
    

        Transform objectTransform = this.transform;

         objectTransform.eulerAngles = new Vector3(objectTransform.eulerAngles.x, objectTransform.eulerAngles.y, 0f);
         
    }
    public bool canShoot;
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("ball"))
        {
            
        
          
            
                Vector2 direction = collision.transform.position - transform.position;
                direction.Normalize();

               
                    ballRb.AddForce(direction * 3, ForceMode2D.Impulse);
                                     //    ballRb.velocity=direction*7;
                                      
            
                  
                   
                    //rb.constraints=RigidbodyConstraints2D.None;
 
             
               
        }
          
          
            
    }

   













    }

