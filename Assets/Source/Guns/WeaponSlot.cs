using Source.Guns;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    public bool occupied;
    public GunsData gunsData;
    public Image icon;
    public Transform modulesContainer;

    private SpriteRenderer[] moduleRenderers;

    void Start()
    {
        
        moduleRenderers = modulesContainer.GetComponentsInChildren<SpriteRenderer>();
    }

    public void UpdateIcon()
    {
        if (icon != null && gunsData != null)
        {
            
            Sprite combinedSprite = CombineModuleSprites();

            
            icon.sprite = combinedSprite;
        }
    }

    private Sprite CombineModuleSprites()
    {
        
        int width = (int)icon.rectTransform.rect.width;
        int height = (int)icon.rectTransform.rect.height;

       
        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        Camera renderCamera = new GameObject("RenderCamera").AddComponent<Camera>();
        renderCamera.targetTexture = renderTexture;
        renderCamera.orthographic = true;
        renderCamera.orthographicSize = height / 2;
        renderCamera.Render();

        
        foreach (SpriteRenderer moduleRenderer in moduleRenderers)
        {
            RenderModuleOnTexture(renderCamera, moduleRenderer);
        }

        
        Texture2D combinedTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        combinedTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        combinedTexture.Apply();
        RenderTexture.active = null;

        
        renderCamera.targetTexture = null;
        Destroy(renderCamera.gameObject);
        RenderTexture.ReleaseTemporary(renderTexture);

        
        Sprite combinedSprite = Sprite.Create(combinedTexture, new Rect(0, 0, width, height), Vector2.zero);

        return combinedSprite;
    }

    private void RenderModuleOnTexture(Camera renderCamera, SpriteRenderer moduleRenderer)
    {
        
        Vector3 originalPosition = moduleRenderer.transform.position;
        float originalSize = moduleRenderer.sprite.bounds.size.x;

        
        moduleRenderer.transform.position = new Vector3(moduleRenderer.sprite.bounds.size.x / 2,
            moduleRenderer.sprite.bounds.size.y / 2, 0);
        //moduleRenderer.sprite.bounds = new Bounds(Vector3.zero, new Vector3(originalSize, originalSize, originalSize));

    }
}