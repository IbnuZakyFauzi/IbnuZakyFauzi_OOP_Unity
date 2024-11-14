using UnityEngine;

     public class EnemyBoss : Enemy
     {
         public Weapon bossWeapon;
         public float attackInterval = 3f;
         private float attackTimer;

         protected override void Start()
         {
             base.Start();
             attackTimer = attackInterval;
         }

         private void Update()
         {
             attackTimer -= Time.deltaTime;
             if (attackTimer <= 0)
             {
                 Attack();
                 attackTimer = attackInterval;
             }
         }

         private void Attack()
         {
             if (bossWeapon != null)
             {
                 bossWeapon.Shoot(); // Fungsi Shoot dari Class Weapon
             }
         }
     }