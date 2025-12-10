using UnityEngine;

public class Controller : MonoBehaviour
{
    internal Animator anim;

    internal Rigidbody2D rigid;
    [SerializeField]
    internal float speed;
    internal bool facingRight;
}
