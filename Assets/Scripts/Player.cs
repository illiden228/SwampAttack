using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Health;
    public ParticleSystem Shootgun;
    public Action<float, float> ChangeHealth;
    public int Money;
    public TMP_Text MoneyText;
    public Image CurrentWeaponIcon;
    public TMP_Text CurrentWeaponName;
    public List<Weapon> Weapons;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private float _currentHealth;
    private Animator _animator;

    void Start()
    {
        MoneyText.text += Money.ToString();
        ChangeWeapon(Weapons[_currentWeaponNumber]);   
        _currentHealth = Health;
        _animator = GetComponent<Animator>();
    }

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
        ChangeHealth?.Invoke(_currentHealth, Health);
        if(_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetReward(int reward)
    {
        Money += reward;
        MoneyText.text = "Денег: " + Money.ToString();
    }

    public void GetWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        Shootgun = weapon.ShootEffect;
        SetWeaponUI(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == Weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }
        ChangeWeapon(Weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = Weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }
        ChangeWeapon(Weapons[_currentWeaponNumber]);
    }

    public void SetWeaponUI(Weapon weapon)
    {
        CurrentWeaponName.text = weapon.Name;
        CurrentWeaponIcon.sprite = weapon.Icon;
    }
}
