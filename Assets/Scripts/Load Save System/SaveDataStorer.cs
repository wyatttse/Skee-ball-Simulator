using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SaveDataStorer : MonoBehaviour
{
    public List<int> scores = new List<int>(5);
    public static readonly int size = 5;

    public int AddScore(int score){
        var i = 0;

        if (scores.Count == 0)
            scores.Add(score);
        else {
            for (; i < scores.Count; ++i)
                if (score > scores[i]) {
                    if (scores.Count == size)
                        scores.RemoveAt(scores.Count - 1);
                    scores.Insert(i, score);
                    break;
                }

            if (i == scores.Count && i < size)
                scores.Add(score);
        }

        return i;
    }

    public int GetMax() { return scores[0]; }
}
