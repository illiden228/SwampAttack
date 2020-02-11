using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;
    public ParticleSystem Shootgun;

    private float _currentHealth;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Health;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shootgun.Play();
            _animator.Play("Shoot");
        }
    }

    public void Attack(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, Health);
        Debug.Log(_currentHealth);
    }
}
