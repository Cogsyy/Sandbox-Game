using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this class is just to simply have a Monobehaviour to run coroutines on from anywhere. 
//Usage: Coroutiner.Instance.StartCoroutine(MyCoroutine());

public class Coroutiner : Singleton<Coroutiner>
{
    private static List<IEnumerator> _registeredCoroutines = new List<IEnumerator>();
    private static List<Action> _registeredSingletonCoroutines = new List<Action>();

    #region Registering

    //If the time at which you want to start a coroutine could occur before this singleton inits itself, then register it this way, it will
    //run itself whenever its ready to run this way
    public static void RegisterCoroutine(IEnumerator routine)
    {
        if (Instance == null)
        {
            if (!_registeredCoroutines.Contains(routine))
            {
                _registeredCoroutines.Add(routine);
            }
        }
        else
        {
            Instance.StartCoroutine(routine);
        }
    }

    public static void RegisterSingletonCoroutine(IEnumerator routine, Coroutine handle)
    {
        if (Instance == null)
        {
            _registeredSingletonCoroutines.Add(() => Instance.StartSingletonCoroutine(routine, handle));
        }
        else
        {
            Instance.StartSingletonCoroutine(routine, handle);
        }
    }

    protected override void OnSetSingleton()
    {
        base.OnSetSingleton();
        for (int i = 0; i < _registeredCoroutines.Count; i++)
        {
            Instance.StartCoroutine(_registeredCoroutines[i]);
        }

        for (int i = 0; i < _registeredSingletonCoroutines.Count; i++)
        {
            _registeredSingletonCoroutines[i].Invoke();
        }
    }

    #endregion

    #region Utility

    public Coroutine StartSingletonCoroutine(IEnumerator routine, Coroutine handle)
    {
        if (handle != null)
        {
            StopCoroutine(handle);
        }

        handle = StartCoroutineWithCompleteAction(routine, () => handle = null);
        return handle;
    }

    private Coroutine StartCoroutineWithCompleteAction(IEnumerator routine, Action onComplete)
    {
        return StartCoroutine(PerformAndCompleteCo(routine, onComplete));
    }

    private IEnumerator PerformAndCompleteCo(IEnumerator routine, Action onComplete)
    {
        yield return StartCoroutine(routine);
        onComplete.Invoke();
    }

    #endregion
}
