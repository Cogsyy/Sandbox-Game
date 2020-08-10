using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    private bool _isAutoActive = false;
    [SerializeField] private GameObject _autoProjectile;
    [SerializeField] private Transform _autoProjectileSpawnPoint;
    [SerializeField] private float _autoProjectileSpeed;

    public void TriggerAutoShoot()
    {
        _isAutoActive = !_isAutoActive;

        if (_isAutoActive)
            StartCoroutine(AutoShootCo());
    }

    private IEnumerator AutoShootCo()
    {
        Vector3 forward = _autoProjectileSpawnPoint.TransformDirection(Vector3.forward);
        while (_isAutoActive)
        {
            GameObject bullet = Instantiate(_autoProjectile, _autoProjectileSpawnPoint.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(forward * _autoProjectileSpeed);
            yield return new WaitForSeconds(0.5f);
        }

        yield return null;
    }
}
