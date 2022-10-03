using UnityEngine;

public class DestroyMusicObject : MonoBehaviour
{
    public void DestroyTheMusicObject()
    {
        if (GameObject.Find("Music") != null)
        {
            Destroy(GameObject.Find("Music"));
        }
    }
}
