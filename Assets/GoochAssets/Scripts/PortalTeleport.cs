using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    //Portal doors are probably a really bad idea, as it will get really complicated with splitting perspectives, objects and such.
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _receiver;

    private bool _playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if(_playerIsOverlapping)
        {
            Vector3 portalToPlayer = _player.position = transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            if(dotProduct < 0f)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, _receiver.rotation);
                rotationDiff += 180;
                _player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                _player.position = _receiver.position + positionOffset;

                _playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerIsOverlapping = false;
        }
    }
}
