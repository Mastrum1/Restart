using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Slider _Hp;

    public void HealthUpdate()
    {
        _Hp.maxValue = _playerHealth.MaxHealth;
        _Hp.value = _playerHealth.CurrentHealth;
    }
}
