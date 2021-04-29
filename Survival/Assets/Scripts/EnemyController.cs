using Assets.Scripts.Interfaces.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public IEntity entity;
    public StatsController stats;
    [SerializeField]
    private UIBars _healthBar;

    public UIBars HealthBar { get => _healthBar; set => _healthBar = value; }

    private void Start()
    {
        entity = new Warrior();
        stats = new StatsController(entity);
        HealthBar.SetMaxValue(stats.Health);
    }

    private void Update()
    {
        if (!stats.IsAlive)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float value)
    {
        if (!stats.IsAlive) { return; }
        stats.TakeDamage(value);
        HealthBar.SetValue(stats.Health);
    }


}
