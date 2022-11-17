using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _hpChanged;

    private float _maxHp = 1f;
    private float _minHp = 0f;
    private float _currentHp = 1f;

    public event UnityAction<float> HpChanged
    {
        add => _hpChanged.AddListener(value);
        remove => _hpChanged.RemoveListener(value);
    }

    public void Healing(float heal)
    {
        if (_currentHp <= _maxHp && _currentHp >= _minHp)
        {
            _currentHp += heal;
        }

        _hpChanged?.Invoke(_currentHp);
    }

    public void TakeDamage(float damage)
    {
        if (_currentHp <= _maxHp && _currentHp >= _minHp)
        {
            _currentHp -= damage;
        }

        _hpChanged?.Invoke(_currentHp);
    }
}
