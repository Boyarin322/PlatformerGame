using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    private EnemyHealth enemyHealth;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private Animator enemyAnimator;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAnimator = GetComponent<Animator>();
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        enemyAnimator.SetBool("moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        enemyAnimator.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        if (enemyHealth.IsAlive)
        {
            idleTimer = 0;
            enemyAnimator.SetBool("moving", true);

            //Make enemy face direction
            enemy.localScale = new Vector2(Mathf.Abs(initScale.x) * _direction,
                initScale.y);

            //Move in that direction
            enemy.position = new Vector2(enemy.position.x + Time.deltaTime * _direction * speed,
                enemy.position.y);
        }
    }
}