using Assets.Correct.Util;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Correct.Scripts.Popups
{
    public class DamagePopup : MonoBehaviour
    {
        [SerializeField] private float disappearTimeMax = .4f;
        [SerializeField] private int textCrit = 6;
        [SerializeField] private int textHit = 4;
        [SerializeField] private Color colorCrit;
        [SerializeField] private Color colorHit;

        private static int sortingOrder;
        private float disappearTimer;

        private TextMeshPro textMesh;
        private Color textColor;
        private Vector3 moveVector;

        public static DamagePopup Create(Vector3 position, float damageAmount, bool isCriticalHit)
        {
            var damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position + new Vector3(0, 1.7f, 0), Quaternion.identity);

            DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
            damagePopup.Setup(damageAmount, isCriticalHit);
            return damagePopup;
        }

        private void Awake()
        {
            textMesh = transform.GetComponent<TextMeshPro>();
        }

        public void Setup(float damageAmount, bool isCriticalHit)
        {
            textMesh.SetText(damageAmount.ToString());
            textMesh.fontSize = isCriticalHit ? textCrit : textHit;
            textColor = isCriticalHit ? colorCrit : colorHit;
            textMesh.faceColor = textColor;
            textMesh.color = textColor;
            disappearTimer = disappearTimeMax;
            moveVector = new Vector3(.7f, 1) * 6f;
            sortingOrder++;
            textMesh.sortingOrder = sortingOrder;
        }

        private void Update()
        {
            transform.position += moveVector * Time.deltaTime;
            moveVector -= moveVector * 8f * Time.deltaTime;

            if (disappearTimer > disappearTimeMax * .5f)
            {
                float increaseScaleAmount = 1f;
                transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                float decreaseScaleAmount = 1f;
                transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
            }
            disappearTimer -= Time.deltaTime;
            if (disappearTimer < 0)
            {
                float disappearSpeed = 5f;
                textColor.a -= disappearSpeed * Time.deltaTime;
                textMesh.color = textColor;
                if (textColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}