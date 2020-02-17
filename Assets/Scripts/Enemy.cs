using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float Health;
    public float Speed;
    public int AttackDamage;
    public float AttackDelay;
    public float AttackRange;
    public float ParticleDamage;
    public int Reward;
    public event UnityAction<int> OnEnemyDie;

    private Player _target;
    private float _lastAttackTime;
    private Animator _animator;

    void Start()
    {
        AttackRange = Random.Range(AttackRange - 0.5f, AttackRange + 0.5f);
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(_target == null)
        {
            return;
        }


        if(Vector2.Distance(transform.position, _target.transform.position) <= AttackRange)
        {
            if(_lastAttackTime <= 0)
            {
                _animator.Play("Attack");
                _lastAttackTime = AttackDelay;
                _target.Attack(AttackDamage);
            }
            _lastAttackTime -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, Speed * Time.deltaTime);
        }
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    private void OnParticleCollision(GameObject other)
    {
        Health -= ParticleDamage;
        if(Health <= 0)
        {
            OnEnemyDie?.Invoke(Reward);
            Destroy(gameObject);
        }
    }
}