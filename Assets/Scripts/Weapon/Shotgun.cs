using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _scatter;
    [SerializeField] private int _bulletCount;
    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Vector3 bulletPosition = new Vector3(shootPoint.position.x, shootPoint.position.y + Random.Range(-_scatter, _scatter), 0);
            Instantiate(Bullet, bulletPosition, Quaternion.identity);
        }
    }
}
