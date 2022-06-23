using UnityEngine;
using UnityEngine.UI;

public class InventoryScrollController : MonoBehaviour
{
    [SerializeField] private RectTransform inventoryTransform;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    public void ChangeInventoryHeight()
    {
        inventoryTransform.sizeDelta = new Vector2(0, gridLayoutGroup.preferredHeight);
    }
}
