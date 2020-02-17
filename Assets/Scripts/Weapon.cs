using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Weapon
{
    public string Name;
    public int Price;
    public Sprite Icon;
    public ParticleSystem ShootEffect;
    public bool IsBuy = false;
}
