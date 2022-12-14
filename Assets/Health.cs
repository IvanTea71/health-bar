using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _hpChanged;

    private float _maxHp = 1f;
    private float _minHp = 0;
    private float _currentHp = 1f;

    public event UnityAction<float> HpChanged
    {
        add => _hpChanged.AddListener(value);
        remove => _hpChanged.RemoveListener(value);
    }

    public void Heal(float heal)
    {
        _currentHp = Mathf.Clamp(_currentHp + heal, _minHp, _maxHp);

        _hpChanged?.Invoke(_currentHp);
    }

    public void TakeDamage(float damage)
    {
        _currentHp = Mathf.Clamp(_currentHp - damage, _minHp, _maxHp);

        _hpChanged?.Invoke(_currentHp);
    }
}
