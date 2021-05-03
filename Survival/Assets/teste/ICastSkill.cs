using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.teste
{
    interface ICastSkill
    {
        string SkillName { get; set; }
        bool InCooldown { get; set; }
        float TimerMax { get;}
        float TimerValue { get; set; }
        

        Slider UITimerSlider { get;}
        Text UITimerText { get; }
        Image UITimerImage { get; }
        Color UITimerColor { get; }
        Color UITimerCooldownColor { get; }
        bool TimerManager(bool isCasting);
    }
}
