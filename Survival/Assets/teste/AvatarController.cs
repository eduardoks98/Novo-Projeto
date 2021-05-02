using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Assets.teste.EnumScript;

namespace Assets.teste
{
    public class AvatarController : MonoBehaviour, IAvatarActions, ICastSkill
    {
        private IAtributes _stats;
        private Faction _faction;

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

        private bool _isCasting;

        public IAtributes Atributes { get => _stats; set => _stats = value; }
        public Faction Faction { get => _faction; set => _faction = value; }
        public float HealthValue { get => _healthValue; set => _healthValue = value; }
        public bool IsAlive => HealthValue > 0;


        public float TimerMax => 50;
        public float TimerValue { get => _timerValue; set => _timerValue = value; }
        public bool IsCasting { get => _isCasting; set => _isCasting = value; }
        public Slider UITimerSlider => _UITimerSlider;
        public Text UITimerText => _UITimerText;
        public Image UITimerImage => _UITimerImage;
        public Color UITimerColor => _UITimerColor;

        public Color UITimerCooldownColor => _UITimerCooldownColor;

        public string SkillName { get => "TESTE"; set => SkillName = value; }



        // Use this for initialization
        void Start()
        {
            _faction = Faction.Avatares;
            if (Atributes == null)
            {
                Atributes = new JobChoose();
                Atributes.Job = Job.Mage;
                
                Debug.Log("No class selected! Setup default class!");
            }

            TimerValue = TimerMax;
            UITimerSlider.maxValue = TimerMax;
            UITimerText.text = ((int)TimerValue).ToString();
            UITimerSlider.value = TimerValue;
            UITimerImage.color = UITimerColor;

        }

        // Update is called once per frame
        void Update()
        {
            if (Atributes == null)
            {
                Debug.Log("Character need a class!");
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                IsCasting = true;
            }


        }
        void FixedUpdate()
        {
            IsCasting = TimerManager(IsCasting);
        }

        public bool TimerManager(bool isCasting)
        {
            if (!isCasting) { return false; }

            if (TimerValue <= 0)
            {
                TimerValue = TimerMax;
                UITimerText.text = ((int)TimerValue).ToString();
                UITimerSlider.value = TimerValue;
                UITimerImage.color = UITimerColor;
                return false;
            }

            TimerValue -= Time.fixedDeltaTime;
            UITimerText.text = ((int)TimerValue).ToString();
            UITimerSlider.value = TimerValue;
            UITimerImage.color = UITimerCooldownColor;
            return true;
        }
    }
}