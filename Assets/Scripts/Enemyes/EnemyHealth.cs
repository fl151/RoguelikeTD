using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(EnemyColorController))]
[RequireComponent(typeof(EnemyAudioController))]
public class EnemyHealth : MonoBehaviour
{
    private EnemyAudioController _audioController;

    private float _maxHealth;
    private float _currentHealth;
    [SerializeField] private float _diyingTime = 0.5f;

    private Animator _animator;
    private EnemyStats _stats;
    private EnemyColorController _colorController;

    private bool _isAlive = true;

    public event UnityAction<EnemyHealth> Dead;

    public bool IsAlive => _isAlive;
    public EnemyColorController ColorController => _colorController;

    private void Awake()
    {
        _stats = GetComponent<EnemyStats>();
        _colorController = GetComponent<EnemyColorController>();
        _animator = GetComponent<Animator>();
        _audioController = GetComponent<EnemyAudioController>();
    }

    private void OnEnable()
    {
        _isAlive = true;

        _stats.Inited += OnStatsInited;
    }

    private void OnDisable()
    {
        _stats.Inited -= OnStatsInited;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        _colorController.AddEffect(new ColorEffect(Color.red, 0.1f, 5));

        if (_audioController != null)
        {
            _audioController.PlayDamageSound();
        }

        if (_currentHealth <= 0)
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        _animator.SetTrigger("isDie");
        _isAlive = false;

        yield return new WaitForSeconds(_diyingTime);

        Dead?.Invoke(this);

        gameObject.SetActive(false);
    }

    private void OnStatsInited()
    {
        _maxHealth = _stats.MaxHealth;

        _currentHealth = _maxHealth;
    }
}