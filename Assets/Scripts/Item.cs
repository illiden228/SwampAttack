using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public event UnityAction<Weapon> OnButtonClick;
    public Weapon Weapon;

    public TMP_Text Name;
    public TMP_Text Price;
    public Image Icon;
    public Button Button;

    private void Start()
    {
        Button.onClick.AddListener(() => OnButtonClick?.Invoke(Weapon));
        Button.onClick.AddListener(() => CheckWeaponAtate());

        Name.text = Weapon.Name;
        Price.text = Weapon.Price.ToString();
        Icon.sprite = Weapon.Icon;
    }

    private void CheckWeaponAtate()
    {
        if(Weapon.IsBuy)
        {
            Button.interactable = false;
        }
    }
}
