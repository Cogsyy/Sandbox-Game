using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assume whatever object has this, is where we check range and distance of interactables
public class InteractivityController : MonoBehaviour
{
    private static List<IInteractable> _interactiveList = new List<IInteractable>();

    private void Start()
    {

    }

    public static void Register(IInteractable interactable)
    {
        if (!_interactiveList.Contains(interactable))
        {
            _interactiveList.Add(interactable);
        }
    }

    public static void DeRegister(IInteractable interactable)
    {
        if (_interactiveList.Contains(interactable))
        {
            _interactiveList.Remove(interactable);
        }
    }

    private void Update()
    {
        UpdateInteractable();
    }

    private void UpdateInteractable()
    {
        float distanceToClosest;
        IInteractable closestInteractable = GetClosestInteractable(out distanceToClosest);
        if (closestInteractable == null)
        {
            return;
        }

        bool closeEnough = distanceToClosest <= closestInteractable.GetMinimumLookDistance();

        Vector3 towardsInteractable = closestInteractable.GetTransform().position - transform.position;
        float lookAngle = Vector3.Angle(towardsInteractable, transform.forward);
        bool withinAngle = lookAngle < closestInteractable.GetMinimumLookAngle();

        if (closeEnough && withinAngle && HasLineOfSight(closestInteractable))
        {
            Debug.Log("Looking at: " + closestInteractable.GetTransform().name);
        }
    }

    private IInteractable GetClosestInteractable(out float closestDistance)
    {
        IInteractable closestInteractable = null;
        closestDistance = float.MaxValue;

        for (int i = 0; i < _interactiveList.Count; i++)
        {
            IInteractable interactable = _interactiveList[i];
            if (interactable == null)
            {
                //Consider potentially removing from the list in this case, not sure if necessary
                continue;
            }

            float distanceTo = Vector3.Distance(transform.position, interactable.GetTransform().position);
            if (distanceTo < closestDistance)
            {
                closestDistance = distanceTo;
                closestInteractable = interactable;
            }
        }

        return closestInteractable;
    }

    private bool HasLineOfSight(IInteractable interactable)
    {
        const float maxDistance = 9999;//REALLY far, but not infinity

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue, 1);
            return true;
        }

        return false;
    }
}
