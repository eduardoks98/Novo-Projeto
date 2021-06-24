using UnityEngine;
using TMPro;
using EKS.Items;

namespace EKS.Panel
{
    public class ItemTooltip : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI ItemNameText;
        [SerializeField] TextMeshProUGUI ItemTypeText;
        [SerializeField] TextMeshProUGUI ItemDescriptionText;

       

        public void ShowTooltip(Item item)
        {
            ItemNameText.text = item.ItemName;
            ItemTypeText.text = item.GetItemType();

            ItemDescriptionText.text =item.GetDescription();

            gameObject.SetActive(true);
        }
        public void HideTooltip()
        {
            gameObject.SetActive(false);

        }
       
    }
}
