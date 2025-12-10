using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class Player : Controller
{           
    [SerializeField]
    private float jumpForce; 
    [SerializeField]
    private Transform[] groundTransform;    
    private bool grounded;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform ölüm;
    [SerializeField]
    private LayerMask düsman;
    [SerializeField]
    internal float height= 0.0009f;
    [SerializeField]
    internal float health;

    [SerializeField]
    internal float knockbackPower;
    internal float knockbackTimer;
    [SerializeField]
    internal float knockbackLength;
    internal bool knockFromRight;
    internal bool knockFromTop;

    private bool attack;
    private float attackTimer;
    [SerializeField]
    private float attackCoolDown;
    [SerializeField]
    private Collider2D attackCollider;
    float points = 0;
    private bool öl=false;
    private bool hara = true;
    public int score;
    void Start()
    {       
        facingRight = true;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = 0;
    }
    void Update()
    {
        Debug.Log(points);
        if(grounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            grounded = false;
            anim.SetBool("groundcheck", grounded);
            rigid.AddForce(new Vector2(0, jumpForce));            
        }
        if (öl)
        {
            Destroy(gameObject,1f);
            SceneManager.LoadScene(6);
        }
        
    }

    void FixedUpdate()
    {
        ölü();
        grounded = isGrounded();
        anim.SetBool("groundcheck", grounded);
        anim.SetFloat("yAxisSpeed", rigid.linearVelocity.y);
        float horizontal = Input.GetAxis("Horizontal");

        if (hara) 
        {
            Movement(horizontal);
        }
        
        Flip(horizontal);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Diamond")
        {
            Destroy(GameObject.FindWithTag("Diamond"));
            points += 50;
        }
    }
   public void Movement(float horizontal)
    {
        if (Mathf.Abs(horizontal) > 0)
        {
            Vector3 position = transform.position;
            position.y += height;
            transform.position = position;
        }

        if (knockbackTimer <= 0)
        {
            rigid.linearVelocity = new Vector2(horizontal * speed, rigid.linearVelocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                rigid.linearVelocity = new Vector2(knockbackPower, knockbackPower);
            }
            else if (!knockFromRight)
            {
                rigid.linearVelocity = new Vector2(-knockbackPower, knockbackPower);
            }
            else if (knockFromTop)
            {
                rigid.linearVelocity = new Vector2(0, knockbackPower);
            }
                knockbackTimer -= Time.deltaTime;
            //hara = false;
            anim.SetTrigger("darbe");
        }

        rigid.linearVelocity = new Vector2(horizontal * speed, rigid.linearVelocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontal));
    }
    void Flip(float horizontal)
    {
    if((horizontal>0 &&!facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
   private bool isGrounded()
    {
        if (rigid.linearVelocity.y <= 0)
        {
            foreach (Transform trans in groundTransform)
            {
                Collider2D [] colliders = Physics2D.OverlapCircleAll(trans.position, groundRadius, groundLayer);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject!=gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool ölü()
    {
        Collider2D colliders = Physics2D.OverlapCircle(ölüm.position, groundRadius, düsman);
        if (colliders != null && colliders.gameObject != gameObject)
        {
            Enemy ens = colliders.gameObject.GetComponent<Enemy>();
            if (ens != null)
            {
                ens.son();
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("dus"))
        {
            anim.SetTrigger("darbe");
            hara = false;

        }
        if (collision.gameObject.CompareTag("boþ"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(6);
        }
    }
    private void dar()
    {
        öl = true;
    }
}
