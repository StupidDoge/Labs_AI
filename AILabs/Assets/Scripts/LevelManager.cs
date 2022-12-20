using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Action OnAllNinjasDefeated;

    private List<Ninja> _ninjas;

    private void Start()
    {
        _ninjas = new List<Ninja>(FindObjectsOfType<Ninja>());
    }

    private void OnEnable()
    {
        Entity.OnEnemyDie += DecreaseNinjasCount;
    }

    private void OnDisable()
    {
        Entity.OnEnemyDie -= DecreaseNinjasCount;
    }

    private void DecreaseNinjasCount()
    {
        if (_ninjas.Count > 0)
            _ninjas.RemoveAt(_ninjas.Count - 1);

        if (_ninjas.Count == 0)
            OnAllNinjasDefeated?.Invoke();
    }
}
