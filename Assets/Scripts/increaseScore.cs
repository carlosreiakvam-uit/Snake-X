using TMPro;
using UnityEngine;

public class increaseScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void increase(int score)
    {
        scoreText.text = score.ToString();
    }
}