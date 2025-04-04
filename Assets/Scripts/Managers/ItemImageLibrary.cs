using UnityEngine;

public class ItemImageLibrary : Singleton<ItemImageLibrary>
{
    [Header("Cubes")]
    public Sprite GreenCubeSprite;
    public Sprite GreenCubeRocketHintSprite;

    public Sprite YellowCubeSprite;
    public Sprite YellowCubeRocketHintSprite;

    public Sprite BlueCubeSprite;
    public Sprite BlueCubeRocketHintSprite;

    public Sprite RedCubeSprite;
    public Sprite RedCubeRocketHintSprite;


    [Header("Obstacles")]
    public Sprite BoxSprite;
    public Sprite StoneSprite;
    public Sprite VaseLayer1Sprite;
    public Sprite VaseLayer2Sprite;

    [Header("Rocket")]
    public Sprite HorizontalRocketSprite;
    public Sprite VerticalRocketSprite;

    public Sprite GetSpriteForItemType(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.GreenCube: return GreenCubeSprite;
            case ItemType.YellowCube: return YellowCubeSprite;
            case ItemType.BlueCube: return BlueCubeSprite;
            case ItemType.RedCube: return RedCubeSprite;
            case ItemType.Box: return BoxSprite;
            case ItemType.Stone: return StoneSprite;
            case ItemType.VaseLayer1: return VaseLayer1Sprite;
            case ItemType.VaseLayer2: return VaseLayer2Sprite;
            case ItemType.HorizontalRocket: return HorizontalRocketSprite;
            case ItemType.VerticalRocket: return VerticalRocketSprite;
            default: return null;
        }
    }
}
