using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform _leftEdge;
    [SerializeField] private Transform _rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform _enemy;
    private EnemyHealth _enemyHealth;

    [Header("Movement parameters")]
    [SerializeField] private float _speed;
    private Vector3 _initScale;
    private bool _movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float _idleDuration;
    private float _idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator _enemyAnimator;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _initScale = _enemy.localScale;
    }
    private void OnDisable()
    {
        _enemyAnimator.SetBool("moving", false);
    }

    private void Update()
    {
        if (_movingLeft)
        {
            if (_enemy.position.x >= _leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (_enemy.position.x <= _rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        _enemyAnimator.SetBool("moving", false);
        _idleTimer += Time.deltaTime;

        if (_idleTimer > _idleDuration)
            _movingLeft = !_movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        if (_enemyHealth.IsAlive)
        {
            _idleTimer = 0;
            _enemyAnimator.SetBool("moving", true);

            //Make _enemy face direction
            _enemy.localScale = new Vector3(Mathf.Abs(_initScale.x) * _direction,
                _initScale.y, _initScale.z);

            //Move in that direction
            _enemy.position = new Vector3(_enemy.position.x + Time.deltaTime * _direction * _speed,
                _enemy.position.y, _enemy.position.z);
        }
    }
}