using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ECSRotator : MonoBehaviour
{
    [SerializeField] public float speed;
}

class RotatorSystem : ComponentSystem
{
    private struct Components
    {
        public ECSRotator rotator;
        public Transform transform;
    }

    protected override void OnUpdate()
    {
/*        Entities.ForEach((ref ECSRotator rotator, ref RotationQuaternion rotation) =>
       {

       });*/
    }
}
