using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ItemExtension
{
    public static IEnumerable<Item> ShuffleItem(this IList<Item> target)
    {
        var count = target.Count;
        var last = count - 1;

        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = target[i];
            target[i] = target[r];
            target[r] = tmp;
        }

        return target;
    }
}