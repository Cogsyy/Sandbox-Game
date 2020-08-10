using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandTheFuckUp : MonoBehaviour
{
    void Update()
    {
        Vector3 v = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, v.y, 0);
    }
}
