using UnityEngine;

     public class EnemyHorizontal : Enemy
     {
         public float speed = 5f;
         private Vector2 direction;

         protected override void Start()
         {
             base.Start();

             // Tentukan spawn dari kiri atau kanan layar
             float spawnSide = Random.Range(0, 2) == 0 ? -1f : 1f;
             direction = new Vector2(spawnSide, 0);

             // Set posisi spawn dan arah gerakan
             transform.position = new Vector3(spawnSide * 10, Random.Range(0f, 5f), 0);
             rb.velocity = direction * speed;
         }

         private void Update()
         {
             // Ubah arah ketika sudah melewati layar
             if (transform.position.x < -10 || transform.position.x > 10)
             {
                 direction = -direction;
                 rb.velocity = direction * speed;
             }
         }
     }