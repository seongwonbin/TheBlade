using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCoolTimerScript : MonoBehaviour
{
    public float timer = 0.0f;

    public float coolTime = 1.0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= coolTime)
        {

            PlayerMoveScript.dashCoolTime = false;
            //Debug.Log("스크립트까지 접근완료");
           
            //animator.SetBool("isDash", false);

            Destroy(gameObject);
            
        }
    }
    private void FixedUpdate()
    {
    //    Debug.Log(Time.deltaTime);


    }
}
