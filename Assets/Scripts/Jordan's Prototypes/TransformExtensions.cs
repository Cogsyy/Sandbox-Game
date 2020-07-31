using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    private static float TimeValue => Time.deltaTime;//Change if a TimeManager of sorts is implemented

    private static Coroutine _currentMovementCo;
    private static Coroutine _currentRotationCo;

    public static void MoveTo(this Transform transform, Vector3 location, float speed)
    {
        Coroutiner.RegisterSingletonCoroutine(MoveTowardsCo(transform, location, speed), _currentMovementCo);
    }

    private static IEnumerator MoveTowardsCo(Transform transform, Vector3 destination, float speed)
    {
        Vector3 starting = transform.position;

        float t = 0;
        while (t < 1)
        {
            t += TimeValue * speed;
            transform.position = Vector3.Lerp(starting, destination, t);
            yield return null;
        }
    }

    public static void RotateTo(this Transform transform, Vector3 targetPosition, float speed)
    {
        Coroutiner.RegisterSingletonCoroutine(RotateTowardsCo(transform, targetPosition, speed), _currentRotationCo);
    }

    private static IEnumerator RotateTowardsCo(Transform transform, Vector3 targetPosition, float speed)
    {
        Quaternion starting = transform.rotation;
        targetPosition.y = transform.position.y;//Put the y on the same height as the object. TBD if desired.
        Vector3 targetForward = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetForward);

        float t = 0;
        while (t < 1)
        {
            t += TimeValue * speed;
            transform.rotation = Quaternion.Lerp(starting, targetRotation, t);
            yield return null;
        }
    }
}
