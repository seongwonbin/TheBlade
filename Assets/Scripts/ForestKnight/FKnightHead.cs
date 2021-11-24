using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKnightHead : MonoBehaviour
{
    private Rigidbody2D rigid;
    public Transform player;

    private bool isActive = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Dummy Character").transform;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == false)
            Head();

        timer += Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, timer*150f));

        if (timer >= 5.0f)
            Destroy(gameObject);
    }

    void Head()
    {
        isActive = true;

        if (transform.position.x < player.position.x)
        {
            rigid.AddForce(new Vector2(-4, 9), ForceMode2D.Impulse);
            rigid.AddForce(new Vector2(-4, 9), ForceMode2D.Impulse);
        }

        if (transform.position.x > player.position.x)
        {
            rigid.AddForce(new Vector2(4, 9), ForceMode2D.Impulse);
            rigid.AddForce(new Vector2(4, 9), ForceMode2D.Impulse);
        }

       
    }
}
