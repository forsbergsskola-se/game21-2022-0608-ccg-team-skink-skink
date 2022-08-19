using Meta.Interfaces;
using TMPro;
using UnityEngine;
using Utility;

public class EndGameHandler : MonoBehaviour {
    
    [SerializeField] int normalCoinWinReward;
    [SerializeField] int normalCoinLoseReward;
    [SerializeField] int lootBoxWinRewardAmount;
    [SerializeField] int lootBoxLoseRewardAmount;

    [SerializeField] private TextMeshProUGUI winLoseText;

    [SerializeField] TextMeshProUGUI normalCoinRewardTextMesh;
    [SerializeField] TextMeshProUGUI lootBoxAmountRewardTextMesh;

    [SerializeField] private GameObject endOfGameScreenObject;

    [SerializeField, RequireInterface(typeof(ILevel))] Object level;

    void Start() {
        Dependencies.Instance.EndOfGameRelay.OnWin += WinScreen;
        Dependencies.Instance.EndOfGameRelay.OnLose += LoseScreen;
    }
    

    void WinScreen() {
        endOfGameScreenObject.SetActive(true);
        UpdateTextAndRewardPlayer(normalCoinWinReward, lootBoxWinRewardAmount);
        winLoseText.text = "You Win!";
    }
    void LoseScreen() {
        endOfGameScreenObject.SetActive(true);
        UpdateTextAndRewardPlayer(normalCoinLoseReward, lootBoxLoseRewardAmount);
        winLoseText.text = "You Lose!";
    }

    public void LoadMainMenu() {
        Dependencies.Instance.LevelLoader.LoadLevel(level as ILevel);
    }
    
    void UpdateTextAndRewardPlayer(int normalCoin, int lootBoxAmount) {
        normalCoinRewardTextMesh.text = normalCoin.ToString();
        Dependencies.Instance.NormalCoinCarrier.Amount += normalCoin;
        
        lootBoxAmountRewardTextMesh.text = lootBoxAmount.ToString();
        Dependencies.Instance.LootBoxAmountModel.Amount += lootBoxAmount;
    }

    void OnDestroy() {
        Dependencies.Instance.EndOfGameRelay.OnWin -= WinScreen;
        Dependencies.Instance.EndOfGameRelay.OnLose -= LoseScreen;
    }
}
