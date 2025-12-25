using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField]
    private float has = 20;
    Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        player.knockFromTop = Mathf.Abs(transform.position.x - player.transform.position.x) <= 1;

        if(other.gameObject.name == "Player")
        {
            player.health -= has;
            player.knockbackTimer = player.knockbackLength;
            GetComponent<Collider2D>().enabled = false;

        }
        else if (player.transform.position.x < transform.position.x && !player.knockFromTop)
        {
            GetComponent<Collider2D>().enabled = false;
            player.knockFromRight = false;
        }
        else if(player.transform.position.x>transform.position.x && !player.knockFromTop)
        {
            player.knockFromRight = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
