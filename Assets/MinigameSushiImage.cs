using UnityEngine;
using UnityEngine.UI;

public class MinigameSushiImage : MonoBehaviour
{
    private void OnEnable()
    {
        SpriteRenderer currentSushiSpriteRenderer = GameManager.Instance.PlayerCharacter.CurrentSushi.GetComponent<SpriteRenderer>();
        Image thisImage = GetComponent<Image>();

        thisImage.sprite = currentSushiSpriteRenderer.sprite;
        currentSushiSpriteRenderer.color = Color.green;
    }
}
