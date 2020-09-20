using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

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

    //Ammunition & Reload Settings
    [SerializeField] private Image _reloadBarImage;
    [SerializeField] private TMP_Text _reloadInputText;
    [SerializeField] private int _maxClipSize;
    [SerializeField] private TMP_Text _maxClipSizeText;
    [SerializeField] private int _currentClipCount;
    [SerializeField] private TMP_Text _currentClipCountText;
    [SerializeField] private int _ammunitionPool;
    [SerializeField] private TMP_Text _ammunitionPoolText;
    [SerializeField] private float _maxReloadTime;
    [SerializeField] private float _currentReloadSpeed;
    [SerializeField] private float _noInputReloadSpeed;
    [SerializeField] private float _inputReloadSpeed;
    [SerializeField] private List<float> _reloadFlagTimes;
    // flase = Press Reload 2, true = Press Reload 1
    [SerializeField] private List<bool> _reloadFlagBools;
    private bool _isReloading = false;
    private bool _isAnyReloadPressed = false;
    private bool _isReload1Pressed = false;
    private bool _isWaitingforNextFlag;

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
        _reloadBarImage.enabled = false;
        _currentClipCountText.text = _currentClipCount.ToString();
        _maxClipSizeText.text = _maxClipSize.ToString();
        _ammunitionPoolText.text = _ammunitionPool.ToString();
        _weaponFriendUIView.gameObject.SetActive(false);
        _hammerIdleRotation = _hammerObject.transform.rotation;
    }

    private void Update()
    {
        _grappleRay = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        /*
        if (Physics.Raycast(_grappleRay, out hit))
        {
            print("I'm looking at " + hit.transform.name);
        }
        else
            print("nothing to look at");
        */
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
                if (_currentClipCount > 0)
                {
                    GameObject bullet = Instantiate(_projectile, _projectileSpawnPoint.position, Quaternion.identity) as GameObject;
                    bullet.GetComponent<Rigidbody>().AddForce(forward * _projectileSpeed);
                    _currentClipCount--;
                    _currentClipCountText.text = _currentClipCount.ToString();
                }
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

    public void Reload1(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (_isReloading && !_isWaitingforNextFlag)
            {
                _isAnyReloadPressed = true;
                _isReload1Pressed = true;
            }

            if (_currentClipCount < _maxClipSize && !_isReloading)
            {
                if(_ammunitionPool > 0 && !_isFriendActive)
                    StartCoroutine(ReloadCo());
            }
        }
    }
    public void Reload2(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (_isReloading && !_isWaitingforNextFlag)
            {
                _isAnyReloadPressed = true;
                _isReload1Pressed = false;
            }
        }
    }
    private IEnumerator ReloadCo()
    {
        float t = 0;
        int currentFlag = 0;
        _currentReloadSpeed = _noInputReloadSpeed;
        _reloadBarImage.enabled = true;
        _reloadBarImage.color = Color.yellow;
        _isReloading = true;
        while(_isReloading)
        {
            t += Time.deltaTime * _currentReloadSpeed;
            _reloadBarImage.fillAmount = t / _maxReloadTime;
           
            if (t < _maxReloadTime)
            {
                if (_reloadFlagBools[currentFlag])
                    _reloadInputText.text = "R";
                else _reloadInputText.text = "E";

                if (t >= _reloadFlagTimes[currentFlag] && currentFlag < _reloadFlagTimes.Count - 1)
                {
                    currentFlag++;
                    _reloadBarImage.color = Color.yellow;
                    _isWaitingforNextFlag = false;
                    _currentReloadSpeed = _noInputReloadSpeed;
                }

                if(_isAnyReloadPressed && !_isWaitingforNextFlag)
                {
                    if (_isReload1Pressed == _reloadFlagBools[currentFlag])
                    {
                        Debug.Log("Correct reload input!");
                        _currentReloadSpeed = _inputReloadSpeed;
                        _reloadBarImage.color = Color.green;
                    }
                    else
                    {
                        Debug.Log("Incorrect reload input");
                        _currentReloadSpeed = _noInputReloadSpeed;
                        _reloadBarImage.color = Color.red;
                    }

                    _isWaitingforNextFlag = true;
                    _isAnyReloadPressed = false;
                    _isReload1Pressed = false;
                }
                yield return null;
            }
            else
            {
                TransferAmmunitionFromPool();
                _isWaitingforNextFlag = false;
                _reloadBarImage.enabled = false;
                _isReloading = false;
                _reloadInputText.text = "";
            }
            yield return null;
        }
        yield return null;
    }

    private void TransferAmmunitionFromPool()
    {
        int reloadAmount = _maxClipSize - _currentClipCount;
        _ammunitionPool -= reloadAmount;
        if(_ammunitionPool < 0)
        {
            int overflow = _ammunitionPool * -1;
            reloadAmount -= overflow;
            _ammunitionPool = 0;
        }
        _currentClipCount += reloadAmount;
        _currentClipCountText.text = _currentClipCount.ToString();
        _ammunitionPoolText.text = _ammunitionPool.ToString();
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
