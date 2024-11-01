using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private PlayerMovement playerMovement;
    private Animator animator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerMovement = FindObjectOfType<PlayerMovement>();
        animator = GameObject.Find("EngineEffect")?.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        if (animator != null)
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }
}