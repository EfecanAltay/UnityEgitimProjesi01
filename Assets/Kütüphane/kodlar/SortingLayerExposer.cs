using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortingLayerExposer : MonoBehaviour
{

    List<SpriteRenderer> triggeredSprites = new List<SpriteRenderer>();
    private void OnTriggerStay2D(Collider2D collision)
    {
        var sp = collision.gameObject.GetComponent<SpriteRenderer>();
        if (sp != null)
        {
            if (triggeredSprites.Contains(sp) == false)
            {
                triggeredSprites.Add(sp);
            }
            var nullList = triggeredSprites.Where(x => x == null).ToArray();
            foreach (var item in nullList)
            {
                triggeredSprites.Remove(item);
            }
            var orderedSprites = triggeredSprites.OrderBy(s => s.gameObject.transform.position.y).ToArray();
            int orderNum = orderedSprites.Length - 1;
            foreach (var sprite in orderedSprites)
            {
                sprite.sortingOrder = orderNum;
                orderNum--;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var sp = collision.gameObject.GetComponent<SpriteRenderer>();
        if (sp != null)
        {
            triggeredSprites.Remove(sp);
        }
    }
}
