using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// 获取模型包围盒的中心点
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static Vector3 CENTER(this Transform model)
    {
        Vector3 result = Vector3.zero;
        int counter = 0;
        calculateCenter(model, ref result, ref counter);
        return result / counter;
    }


    /// <summary>
    /// 获取模型包围盒
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static Bounds BOUNDS(this Transform model)
    {
        Vector3 oldPos = model.position;
        model.position = Vector3.zero;
        Bounds resultBounds = new Bounds(model.CENTER(), Vector3.zero);
        calculateBounds(model, ref resultBounds);
        model.position = oldPos;
        Vector3 scalueValue = scaleValue(model); ;
        resultBounds.size = new Vector3(resultBounds.size.x / scalueValue.x, resultBounds.size.y / scalueValue.y, resultBounds.size.z / scalueValue.z);
        return resultBounds;
    }

    private static void calculateCenter(Transform model, ref Vector3 result, ref int counter)
    {
        if (model.childCount.Equals(0))
        {
            if (!model.GetComponent<Renderer>())
                return;
            //result += model.center();
            counter++;
            return;
        }
        /*List<Transform> childModels = model.GetComponentsInChildrenNoSelf<Transform>();
        for (int i = 0; i < childModels.Count; i++, ++counter)
            calculateCenter(childModels[i], ref result, ref counter);*/
    }

    private static Vector3 scaleValue(Transform model)
    {
        Vector3 result = model.localScale;
        return calculateScale(model, ref result);
    }

    private static Vector3 calculateScale(Transform model, ref Vector3 value)
    {
        if (model.parent)
        {
            Vector3 scale = model.parent.localScale;
            value = new Vector3(value.x * scale.x, value.y * scale.y, value.z * scale.z);
            calculateScale(model.parent, ref value);
        }
        return value;
    }

    private static void calculateBounds(Transform model, ref Bounds bounds)
    {
        if (model.childCount.Equals(0))
        {
            if (!model.GetComponent<Renderer>())
                return;
            //bounds.Encapsulate(model.bounds());
            return;
        }
        /*List<Transform> childModels = model.GetComponentsInChildrenNoSelf<Transform>();
        for (int i = 0; i < childModels.Count; i++)
            calculateBounds(childModels[i], ref bounds);*/
    }
}
