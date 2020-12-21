using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILookable
{
    Transform GetTransform();
    float GetMinimumLookDistance();
    float GetMinimumLookAngle();
}
