using UnityEngine;

namespace EKS.Inputs 
{ 
    public class InventoryInput : MonoBehaviour
    {
        [SerializeField] GameObject characterPanelGameObject;
        [SerializeField] GameObject equipmentPanelGameObject;
        [SerializeField] KeyCode[] toggleCharacterPanelKeys;
        [SerializeField] KeyCode[] toggleInventoryPanelKeys;

        void Update()
        {
            for (int i = 0; i < toggleCharacterPanelKeys.Length; i++)
            {
                if (Input.GetKeyDown(toggleCharacterPanelKeys[i]))
                {
                    characterPanelGameObject.SetActive(!characterPanelGameObject.activeSelf);

                    if (characterPanelGameObject.activeSelf)
                    {
                        equipmentPanelGameObject.SetActive(true);
                        ShowMouseCursor();
                    }
                    else
                    {
                        HideMouseCursor();
                    }
                    break;
                }
            }

            for (int i = 0; i < toggleInventoryPanelKeys.Length; i++)
            {
                if (Input.GetKeyDown(toggleInventoryPanelKeys[i]))
                {
                    if (!characterPanelGameObject.activeSelf)
                    {
                        characterPanelGameObject.SetActive(true);
                        equipmentPanelGameObject.SetActive(false);
                        ShowMouseCursor();
                    }
                    else if (equipmentPanelGameObject.activeSelf)
                    {
                        equipmentPanelGameObject.SetActive(false);
                    }
                    else
                    {
                        characterPanelGameObject.SetActive(false);
                        HideMouseCursor();
                    }
                    break;
                }
            }
        }

        public void ShowMouseCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void HideMouseCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void ToggleEquipmentPanel()
        {
            equipmentPanelGameObject.SetActive(!equipmentPanelGameObject.activeSelf);
        }
    }
}
