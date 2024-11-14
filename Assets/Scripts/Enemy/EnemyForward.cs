using UnityEngine;

     public class EnemyForward : Enemy
     {
         public float speed = 5f;

         protected override void Start()
         {
             base.Start();
             rb.velocity = Vector2.down * speed;
         }
     }