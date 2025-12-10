using UnityEngine;

public class Enemy : Controller
{
    [SerializeField]
    private Transform[] spots;

    private float waitTime;
    [SerializeField]
    private float startTime;
    void Start()
    {
        anim=GetComponent<Animator>();
        waitTime = startTime;
        facingRight = false;
    }
    internal void son()
    {

        Destroy(gameObject);
    }
    private void anison()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if (facingRight)
        {
            if(waitTime <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, spots[1].position, speed * Time.deltaTime);

                anim.SetBool("speed", true);
                if (Vector2.Distance(transform.position, spots[1].position) < .5f)
                {
                    Flip();
                    waitTime = startTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
                anim.SetBool("speed", false);
            }
        }
        else
        {
            if (waitTime <= 0)
            {
                anim.SetBool("speed", true);
                transform.position = Vector2.MoveTowards(transform.position, spots[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, spots[0].position) < .5f)
                {
                    Flip();
                    waitTime = startTime;
                }
            }
            else
            {
                anim.SetBool("speed", false);
                waitTime -= Time.deltaTime;
            }               
        }
    }
    void Flip( )
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    
}
