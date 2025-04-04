using UnityEngine;

public class VerticalRocket : Item
{
    private readonly MatchType matchType = MatchType.Special;

    public void PrepareVerticalRocketItem(ItemBase itemBase)
    {
        SoundID = SoundID.TNT;
        var bombSprite = ItemImageLibrary.Instance.VerticalRocketSprite;
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

        RocketPart upRocket = new RocketPart();
        RocketPart downRocket = new RocketPart();

        upRocket.Initialize(startPos, Vector2.up);  
        downRocket.Initialize(startPos, Vector2.down); 

        upRocket.Move();
        downRocket.Move();
    }
}

