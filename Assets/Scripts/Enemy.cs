using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    public float Speed;
    public int AttackDamage;
    public float AttackDelay;
    public float AttackRange;
    public float ParticleDamage;

    private Player _target;
    private float _lastAttackTime;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
            Destroy(gameObject);
        }
    }
}