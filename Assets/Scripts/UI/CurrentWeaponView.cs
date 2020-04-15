using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;

    private void OnEnable()
    {
        _player.WeaponChanged += Render;
    }

    private void Render(Weapon weapon)
    {
        _label.text = weapon.Label;
        _icon.sprite = weapon.Icon;
    }

}
