using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Assets.teste.EnumScript;

namespace Assets.teste
{
    public class AvatarController : MonoBehaviour, IAvatarActions, ICastSkill
    {
        private JobChoose _jobController;
        private Faction _faction;
        private AvatarState _state;

        public bool showTimer;
        public GameObject Timer;

        private float _healthValue;
        [SerializeField]
        private float _timerValue;

        [SerializeField]
        private Slider _UITimerSlider;
        [SerializeField]
        private Text _UITimerText;
        [SerializeField]
        private Image _UITimerImage;
        [SerializeField]
        private Color _UITimerColor;
        [SerializeField]
        private Color _UITimerCooldownColor;

        private bool _inCooldown;
        public AvatarState State { get => _state; set => _state = value; }
        public JobChoose JobController { get => _jobController; set => _jobController = value; }
        public Faction Faction { get => _faction; set => _faction = value; }
        public float HealthValue { get => _healthValue; set => _healthValue = value; }
        public bool IsAlive => HealthValue > 0;


        public float TimerMax => JobController.AttackRate;
        public float TimerValue { get => _timerValue; set => _timerValue = value; }
        public bool InCooldown { get => _inCooldown; set => _inCooldown = value; }
        public Slider UITimerSlider => _UITimerSlider;
        public Text UITimerText => _UITimerText;
        public Image UITimerImage => _UITimerImage;
        public Color UITimerColor => _UITimerColor;

        public Color UITimerCooldownColor => _UITimerCooldownColor;

        public string SkillName { get => "TESTE"; set => SkillName = value; }





        // Use this for initialization
        void Start()
        {
            Timer = this.GetComponentInChildren<Canvas>().gameObject;

            Faction = Faction.Avatares;
            State = AvatarState.Idle;
            if (JobController == null)
            {
                JobController = new JobChoose(Contract.Warrior);

                Debug.Log("No class selected! Setup default class!");
            }
            HealthValue = JobController.Health;

            TimerValue = TimerMax;
            UITimerSlider.maxValue = TimerMax;
            UITimerText.text = ((int)TimerValue).ToString();
            UITimerSlider.value = TimerValue;
            UITimerImage.color = UITimerColor;

        }

        // Update is called once per frame
        void Update()
        {
            Timer.SetActive(showTimer);

            if (JobController == null)
            {
                Debug.Log("Character need a class!");
                return;
            }

            if (Input.GetMouseButton(0))
            {
                InCooldown = true;

            }
            if (Input.GetMouseButtonDown(1))
            {
                changeClass();
            }


        }
        void FixedUpdate()
        {
            InCooldown = TimerManager(InCooldown);
        }

        public bool TimerManager(bool inCooldown)
        {

            if (!inCooldown) { return false; }

            if (TimerValue <= 0)
            {
                TimerValue = TimerMax;
                UpdateTimer(false);
                State = AvatarState.Idle;
                return false;
            }
            State = AvatarState.Attack;
            TimerValue -= Time.fixedDeltaTime;
            UpdateTimer(false);
            return true;
        }

        void changeClass()
        {

            if (JobController.Contract == Contract.Mage)
            {
                Debug.Log("WARRIOR");
                JobController.Job = JobController.SwitchJob(Contract.Warrior);
            }
            else if (JobController.Contract == Contract.Warrior)
            {
                Debug.Log("MAGE");
                JobController.Job = JobController.SwitchJob(Contract.Mage);
            }
            UpdateTimer(true);
        }


        public void UpdateTimer(bool updateMaxValue)
        {
            
            if (updateMaxValue)
            {
                UITimerSlider.maxValue = TimerMax;
                TimerValue = TimerMax;
                
            }

            UITimerText.text = ((int)TimerValue).ToString();
            UITimerSlider.value = TimerValue;
            if (!InCooldown) { return; }
            if (TimerValue <= 0)
            {
                UITimerImage.color = UITimerColor;
            }
            else
            {
                UITimerImage.color = UITimerCooldownColor;

            }

        }
    }
}