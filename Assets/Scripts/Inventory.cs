using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int totalCoins;
    public Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance inventaire");
            return;
        }
        instance = this;
    }

    public void addCoins(int count)
    {
        totalCoins += count;
        coinsCountText.text = totalCoins.ToString();
    }
}
