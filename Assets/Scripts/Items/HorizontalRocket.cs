using UnityEngine;

public class HorizontalRocket : Item
{
    private readonly MatchType matchType = MatchType.Special;

    public void PrepareHorizontalRocketItem(ItemBase itemBase)
    {
        SoundID = SoundID.TNT;
        var bombSprite = ItemImageLibrary.Instance.HorizontalRocketSprite;
        Prepare(itemBase, bombSprite);
    }

    public override MatchType GetMatchType()
    {
        return matchType;
    }

    public override void TryExecute()
    {
        var explodeCellArea = Cell.allArea;

        AudioManager.Instance.PlayEffect(SoundID);
        base.TryExecute();

        ExplodeAndDivide();

        for (int i = 0; i < explodeCellArea.Count; i++)
        {
            var currentCell = explodeCellArea[i];
            if (currentCell.item == null) continue;
            var item = currentCell.item;
            item.TryExecute();
        }
    }

    private void ExplodeAndDivide()
    {
        Vector2 startPos = this.transform.position;

        RocketPart leftRocket = new RocketPart();
        RocketPart rightRocket = new RocketPart();

        leftRocket.Initialize(startPos, Vector2.left);  
        rightRocket.Initialize(startPos, Vector2.right);

        leftRocket.Move();
        rightRocket.Move();
    }
}

