using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Health _health;
    private Coroutine _controlHp;

    public void DoAction()
    {
        if (_health.IsHealing == true)
        {
            _health.HpChanged += SliderUp;
        }
        else
        {
            _health.HpChanged += SliderDown;
        }
    }

    private void SliderUp()
    {
        float target = _slider.value + 0.1f;
        CoroutineControl(target);
    }

    private void SliderDown()
    {
        float target = _slider.value - 0.1f;
        CoroutineControl(target);
    }

    private void CoroutineControl(float target)
    {
        if (_controlHp != null)
        {
            StopCoroutine(_controlHp);
        }

        _controlHp = StartCoroutine(HpChanger(target));
    }

    private IEnumerator HpChanger(float target)
    {
        float recoveryRate = 0.1f;

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
