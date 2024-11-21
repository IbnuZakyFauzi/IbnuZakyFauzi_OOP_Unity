using UnityEngine;

     public class EnemyTargeting : Enemy
     {
         public Transform player;
         public float speed = 5f;

        protected override void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

         private void Update()
         {
             if (player != null)
             {
                 Vector2 direction = (player.position - transform.position).normalized;
                 rb.velocity = direction * speed;
             }
         }

         private void OnTriggerEnter2D(Collider2D collision)
         {
             if (collision.CompareTag("Player"))
             {
                 Destroy(gameObject);
             }
         }
     }