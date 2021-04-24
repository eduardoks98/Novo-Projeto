using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ICharacterJob Job;
    [SerializeField]
    private UIBars _healthBar;

    public UIBars HealthBar { get => _healthBar; set => _healthBar = value; }

    private void Start()
    {
        Job = new Zombie();
        HealthBar.SetMaxValue(Job.MaxHealth);
    }

    private void Update()
    {
        if (!Job.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float value)
    {
        if (Job.IsAlive())
            HealthBar.SetValue(Job.TakeDamage(value));
    }
}
