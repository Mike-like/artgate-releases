using UnityEngine;

/// <summary>
/// Shows the game's art through artgate's index: the hero's walk animations, in any scene, without
/// setting anything up. Placeholders until real art arrives; after `artgate apply`, the same code
/// shows the real art, including any frames the artist added.
/// </summary>
public class ArtDemo : MonoBehaviour
{
    const float Fps = 8f;
    Sprite[] frames = new Sprite[0];
    SpriteRenderer spriteRenderer;
    float time;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Spawn()
    {
        var missing = 0;
        foreach (var animation in ArtIndex.Frames.Keys) if (ArtIndex.IsPlaceholder(animation)) missing++;
        Debug.Log($"{missing} animations still use placeholders; coin icon listed: {ArtIndex.Has("ui/icon_coin")}");

        var x = -1.5f;
        foreach (var animation in ArtIndex.Frames.Keys)
        {
            var go = new GameObject($"artgate demo: {animation}");
            go.transform.position = new Vector3(x, 0f, 0f);
            go.AddComponent<ArtDemo>().Play(animation);
            x += 1.2f;
        }
    }

    void Play(string animation)
    {
        frames = ArtIndex.LoadFrames(animation);
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        if (frames.Length > 0) spriteRenderer.sprite = frames[0];
    }

    void Update()
    {
        if (frames.Length == 0) return;
        time += Time.deltaTime;
        spriteRenderer.sprite = frames[(int)(time * Fps) % frames.Length];
    }
}
