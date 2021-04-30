using Assets.Scripts.Interfaces.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public IEntity entity;
    [SerializeField]
    public StatsController stats;
    [SerializeField]
    private UIBars _healthBar;

    public UIBars HealthBar { get => _healthBar; set => _healthBar = value; }
    private void Awake()
    {
        entity = new Warrior();
        stats = new StatsController(entity);
        HealthBar.SetMaxValue(stats.Health);
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (!stats.IsAlive)
        {
            Debug.Log("TA MORTINHO");
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float value)
    {
        Debug.Log("ta morto");
        Debug.Log(gameObject.name);
        Debug.Log(stats.CurrentHealth);
        Debug.Log(value);
        if (!stats.IsAlive) { return; }
        Debug.Log("ta vivo");
        stats.TakeDamage(value);
        HealthBar.SetValue(stats.CurrentHealth);
    }


}
