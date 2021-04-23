using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_chasing : MonoBehaviour
{
    public int speed;
    public float ray_distance;
    public static Animator animator;
    public GameObject player;
    private SpriteRenderer mySpriteRenderer;
    public static int move_vertical;
    public static int move_horizontal;
    public GameObject the_end;
    public LayerMask barrier;
    public static int mode;
    public GameObject cat;
    private Animation anim;



    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        anim = gameObject.GetComponent<Animation>();
        move_vertical = 1;
        move_horizontal = 1;
        // mode = 0;
        // Vector2 sightDist = (1,0);
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, ray_distance, barrier);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("blink"))
        {
            //  Debug.Log("not blink");

            if (hit.collider != null)
            {

                move_vertical = 0;
                move_horizontal = 2;
                //   print("hit barrier");



            }
            else
            {
                move_vertical = 1;
                move_horizontal = 1;
            }
        }
        else
        {

            move_vertical = 0;
            move_horizontal = 0;
        }
        if (mode == 0 || mode == 2)
        {

            Vector3 localPosition = player.transform.position - transform.position;
            localPosition = localPosition.normalized; // The normalized direction in LOCAL space
            transform.Translate(localPosition.x * Time.deltaTime * speed * move_vertical, move_horizontal * localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);

        }
        if (mode == 1)
        {
            Vector3 localPosition = cat.transform.position - transform.position;
            localPosition = localPosition.normalized; // The normalized direction in LOCAL space
            transform.Translate(localPosition.x * Time.deltaTime * speed * move_vertical, move_horizontal * localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
        //   Vector3 fwd = transform.TransformDirection(-1,0,0);
        if (player.transform.position.x < transform.position.x)
        {
            mySpriteRenderer.flipX = false;
        }
        else
        {
            mySpriteRenderer.flipX = true;
        }


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "cat")
        {
            mode = 2;
        }
        if (other.gameObject.name == "main_char")
        {



            Destroy(player);
            StartCoroutine(ExampleCoroutine());
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5.0f);
        the_end.SetActive(true);



    }
}
