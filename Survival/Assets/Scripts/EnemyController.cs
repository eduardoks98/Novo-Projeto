using Assets.Scripts.Interfaces.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public IEntity entity;
    public IEntity stats;
    [SerializeField]
    private UIBars _healthBar;

    public UIBars HealthBar { get => _healthBar; set => _healthBar = value; }

    private void Start()
    {
        entity = new Warrior();
        stats = new StatsController(entity);
        HealthBar.SetMaxValue(entity.Health);
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
