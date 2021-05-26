using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public static class ExtensionMethods
{
    //Extended Method for CanvasGroup API
    public static void SetActive(this CanvasGroup canvasGroup, bool state)
    {
        if (state)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public static void SetTransformPoint(this GameObject actor, Transform spawnPoint)
    {
        if (spawnPoint == null)return;

        actor.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
    }

    public static void ResetObject(this GameObject actor)
    {
        actor.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

}

public static class IListExtensions
{
    public static void Swap<T>(this IList<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }

    /// <summary>
    /// Shuffle the list in place using the Fisher-Yates method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static void Shuffle<T>(this IList<T> list, int count)
    {
        System.Random rng = new System.Random();
        int n = count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    /// <summary>
    /// Return a random item from the list.
    /// Sampling with replacement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T RandomItem<T>(this IList<T> list)
    {
        if (list.Count == 0)throw new System.IndexOutOfRangeException("Cannot select a random item from an empty list");
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    /// <summary>
    /// Removes a random item from the list, returning that item.
    /// Sampling without replacement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T RemoveRandom<T>(this IList<T> list)
    {
        if (list.Count == 0)throw new System.IndexOutOfRangeException("Cannot remove a random item from an empty list");
        int index = UnityEngine.Random.Range(0, list.Count);
        T item = list[index];
        list.RemoveAt(index);
        return item;
    }
}

public class RandomizeExtension
{
    private static int lastRandomNumber;

    public static int GenerateRandomNumber(int min, int max)
    {
        int result = Random.Range(min, max);

        if (result == lastRandomNumber)
        {
            return GenerateRandomNumber(min, max);
        }

        lastRandomNumber = result;
        return result;
    }
}

public static class FloatRound
{
    public static float Round(this float t, float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        t = Mathf.Round(value * mult) / mult;
        return t;
    }
}

public class PlayerPrefs2
{
    public static void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
}

public static class StringTimeConverter
{
    public static string ConvertString(this string t, float value)
    {
        string format = "{0:D2}:{1:D2}:{2:D2}";
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(value);
        string timeText = string.Format(format, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        t = timeText;
        return t;
    }

    public static string ConvertString(this string t, double value)
    {
        string format = "{0:D2}:{1:D2}:{2:D2}";
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(value);
        string timeText = string.Format(format, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        t = timeText;
        return t;
    }

    public static string ConvertString(float value)
    {
        string format = "{0:D2}:{1:D2}:{2:D2}";
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(value);
        string timeText = string.Format(format, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        return timeText;
    }

    public static string ConvertString(double value)
    {
        string format = "{0:D2}:{1:D2}:{2:D2}";
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(value);
        string timeText = string.Format(format, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        return timeText;
    }

    public static string ConvertStringMilliseconds(float value)
    {
        string format = "{0:D2}:{1:D2}:{2:D2}";
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(value);
        string timeText = string.Format(format, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        return timeText;
    }
    public static string ConvertStringMilliseconds(double value)
    {
        string format = "{0:D2}:{1:D2}:{2:D2}";
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(value);
        string timeText = string.Format(format, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        return timeText;
    }
    public static string ConvertStringMilliseconds2DP(double value)
    {
        string format = "{0:D2}.{1:D2}";
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(value);
        string timeText = string.Format(format, timeSpan.Seconds, timeSpan.Milliseconds);

        return timeText;
    }
}

public static class StringBuilderExtensions
{
    public static int StringAppendArrayInt<T>(this IList<T> value)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < value.Count; i++)
        {
            sb.Append(value[i]);
        }

        int result = int.Parse(sb.ToString());
        return result;
    }
}