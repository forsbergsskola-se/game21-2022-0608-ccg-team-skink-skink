using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPauseMenu : MonoBehaviour
{
    public LevelMusic LM;
    [SerializeField] private GameObject visibleObject;
    [SerializeField] private GameObject invisibleObject;
    
    public void PauseGame()
    {
        invisibleObject.gameObject.SetActive(false);
        visibleObject.gameObject.SetActive(true);
        Time.timeScale = 0;
        LM.PauseMenuAudio();


    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        invisibleObject.gameObject.SetActive(true);
        visibleObject.gameObject.SetActive(false);
        LM.PauseMenuStopAudio();

    }

    public void ChangeCanvas(GameObject canvasToActivate)
    {
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInParent<CanvasGroup>().alpha = 0;
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInParent<CanvasGroup>().interactable = false;
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInParent<CanvasGroup>().blocksRaycasts=false;
        canvasToActivate.GetComponent<CanvasGroup>().alpha = 1;
        canvasToActivate.GetComponent<CanvasGroup>().interactable = true;
        canvasToActivate.GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }

}
