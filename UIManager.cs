using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject youWinPanel;
    public GameObject youLosePanel;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI bonesText;
    public DogPlayerController player;

    void Update()
    {
        lifeText.text = "Life points: " + player.life;
        bonesText.text = "Bones points: " + player.bones;
    }
}
