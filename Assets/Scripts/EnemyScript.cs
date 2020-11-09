using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct Enemystat{
  //  public float health;
}

public class EnemyScript : MonoBehaviour
{
   // [SerializeField]private Enemystat enemystat;



    // Start is called before the first frame update
    void Start()
    {
   //     enemystat.health = 100;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Debug.Log("hi~");
    }


}
