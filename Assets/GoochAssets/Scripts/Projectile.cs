using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnEnable()
    {
        Object.Destroy(gameObject, 3f);
    }
}
