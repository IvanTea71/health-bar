using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent _hpChanged;

    public event UnityAction HpChanged
    {
        add => _hpChanged.AddListener(value);
        remove => _hpChanged.RemoveListener(value);
    }

    public bool IsHealing { get; private set; }

    public void HpUp()
    {
        IsHealing = true;
        _hpChanged?.Invoke();
    }

    public void HpDown()
    {
        IsHealing = false;
        _hpChanged?.Invoke();
    }
}
