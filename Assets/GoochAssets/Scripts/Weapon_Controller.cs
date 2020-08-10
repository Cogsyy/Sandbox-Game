using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.XInput;

public class Weapon_Controller : MonoBehaviour
{
    [SerializeField] private FP_Controller _fp_Controller;
    //Weapon Friend Settings
    [SerializeField] private GameObject _weaponFriend;
    [SerializeField] private GameObject _splitProjectile;
    [SerializeField] private Transform _weaponFriendUIView;
    [SerializeField] private AutoShoot _autoShoot;
    [SerializeField] private float _splitTime;
    [SerializeField] private float _splitFireSpeed = 100f;
    [SerializeField] private float _maxMergeDistance;
    private bool _isSpawning;
    private bool _isFriendActive = false;

    //Gun Mode Settings
    [SerializeField] private GameObject _gunObject;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _projectileSpeed = 10f;

    //Hammer Settings
    [SerializeField] private GameObject _hammerObject;
    [SerializeField] private float _swingDuration;
    [SerializeField] private float _returnIdleDuration;
    [SerializeField] private Vector3 _hammerHitRotation;
    private Quaternion _hammerIdleRotation;
    [SerializeField] private AnimationCurve _swingCurve;
    [SerializeField] private AnimationCurve _returnIdleCurve;

    //Grapple Settings
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _grappleSpeed;
    private Ray _grappleRay;
    private RaycastHit _grapplePoint;
    private bool _isGrappling = false;
    private float _grappleDistance;
    
    private PlayerControls _playerControls = null;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.PlayerOne.Enable();
        _weaponFriendUIView.gameObject.SetActive(false);
        _hammerIdleRotation = _hammerObject.transform.rotation;
    }

    private void Update()
    {
        _grappleRay = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(_grappleRay, out hit))
        {
            print("I'm looking at " + hit.transform.name);
        }
        else
            print("nothing to look at");
    }

    private void OnDisable()
    {
        _playerControls.PlayerOne.Disable();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Vector3 forward = _projectileSpawnPoint.TransformDirection(Vector3.forward);

        if (context.started)
        {
            if (_gunObject.activeSelf)
            {
                GameObject bullet = Instantiate(_projectile, _projectileSpawnPoint.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(forward * _projectileSpeed);
            }
            if(_hammerObject.activeSelf)
            {
                StartCoroutine(SwingHammerCo(true));
            }
        }
    }

    private IEnumerator SwingHammerCo(bool hit)
    {
        float t = 0;
        Quaternion hitRot = Quaternion.Euler(_hammerHitRotation);

        if (hit)
        {
            while (t < 1)
            {
                t += Time.deltaTime / _swingDuration;
                SetRotation(Quaternion.Lerp(_hammerIdleRotation, hitRot, _swingCurve.Evaluate(t)));
                yield return null;
            }
        }

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / _returnIdleDuration;
            SetRotation(Quaternion.Lerp(hitRot, _hammerIdleRotation, _returnIdleCurve.Evaluate(t)));
            yield return null;
        }
    }
    private void SetRotation(Quaternion rotation)
    {
        _hammerObject.transform.localRotation = rotation;
    }

    public void SplitOrMerge(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!_isSpawning)
            {
                if (_isFriendActive)
                    Merge();
                else
                    Split();
            }
        }
    }

    private void Split()
    {
        _isSpawning = true;
        _gunObject.SetActive(false);
        _hammerObject.SetActive(true);
        _splitProjectile.SetActive(true);
        _fp_Controller.SetNewMoveSpeed(7.5f);
        StartCoroutine(FriendSpawnCo());
    }

    private IEnumerator FriendSpawnCo()
    {
        _splitProjectile.transform.position = _projectileSpawnPoint.position;
        Vector3 forward = _projectileSpawnPoint.TransformDirection(Vector3.forward);
        _splitProjectile.GetComponent<Rigidbody>().AddForce(forward * _splitFireSpeed);

        yield return new WaitForSeconds(_splitTime);

        _splitProjectile.SetActive(false);
        _weaponFriend.transform.position = _splitProjectile.transform.position;

        if (_weaponFriend.transform.position.y < 3f)
            _weaponFriend.transform.position = new Vector3(_weaponFriend.transform.position.x, 3f, _weaponFriend.transform.position.z);

        _weaponFriend.SetActive(true);
        _isFriendActive = true;
        _isSpawning = false;
        _weaponFriendUIView.gameObject.SetActive(true);
        _autoShoot.TriggerAutoShoot();
    }

    private void Merge()
    {
        float distance = Vector3.Distance(_weaponFriend.transform.position, transform.position);
        if (distance <= _maxMergeDistance)
        {
            _weaponFriend.SetActive(false);
            _gunObject.SetActive(true);
            _hammerObject.SetActive(false);
            _isFriendActive = false;
            _weaponFriendUIView.gameObject.SetActive(false);
            _fp_Controller.SetNewMoveSpeed(5f);
            _autoShoot.TriggerAutoShoot();
        }
    }

    public void Grapple(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(Physics.Raycast(_grappleRay, out _grapplePoint))
            {

                if (_grapplePoint.transform.CompareTag("WeaponFriend"))
                {
                    _isGrappling = true;
                    Vector3 grappleDirection = (_grapplePoint.point - transform.position);
                    _playerRigidbody.velocity = grappleDirection.normalized * _grappleSpeed;
                    StartCoroutine(GrappleCo());
                }
                else
                    print("no friend to grapple");
            }
        }
        if(context.canceled)
        {
            _isGrappling = false;
        }
    }


    private IEnumerator GrappleCo()
    {
        while(_isGrappling)
        {
            transform.LookAt(_grapplePoint.point);
            Vector3 grappleDirection = (_grapplePoint.point - transform.position);

            if (_grappleDistance < grappleDirection.magnitude)
            {
                float velocity = _playerRigidbody.velocity.magnitude;
                Vector3 newDirection = Vector3.ProjectOnPlane(_playerRigidbody.velocity, grappleDirection);
                _playerRigidbody.velocity = newDirection.normalized * velocity;
            }
            else
                _playerRigidbody.AddForce(grappleDirection.normalized * _grappleSpeed);

            _grappleDistance = grappleDirection.magnitude;

            Merge();
            if (_grappleDistance <= 2)
                _isGrappling = false;

            yield return null;
        }

        _playerRigidbody.velocity = Vector3.zero;

        yield return null;
    }
}
