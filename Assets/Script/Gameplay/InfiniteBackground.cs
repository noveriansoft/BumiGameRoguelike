using UnityEngine;
using UnityEngine.UI;

public class InfiniteBackground : MonoBehaviour
{
    public Transform bg1;
    public Transform bg2;

    public float speed = 2f;
    public float width = 20f;

    [Header("Level Backgrounds")]
    public Sprite[] levelBackgrounds;

    private void Update()
    {
        bg1.Translate(Vector3.left * speed * Time.deltaTime);
        bg2.Translate(Vector3.left * speed * Time.deltaTime);

        if (bg1.position.x <= -width)
        {
            bg1.position = new Vector3(bg2.position.x + width,bg1.position.y,bg1.position.z);
        }

        if (bg2.position.x <= -width)
        {
            bg2.position = new Vector3(bg1.position.x + width,bg2.position.y,bg2.position.z);
        }
    }

    public void SetLevelBackground(int level)
    {
        if (level - 1 >= levelBackgrounds.Length)
            return;

        Sprite bg = levelBackgrounds[level - 1];

        bg1.GetComponent<SpriteRenderer>().sprite = bg;
        bg2.GetComponent<SpriteRenderer>().sprite = bg;
    }
}
