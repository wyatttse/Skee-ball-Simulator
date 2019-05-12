/*
 * Author: Tse Chi Ho
 * Description: The class is used to make "scores" be serializable. Some functions for "scores" are also included.
 */
using System.Collections.Generic;

[System.Serializable]
public class SaveDataStorer {
    public List<int> scores = new List<int>(5);
    public static readonly int size = 5;


    // Add "score" to "scores" if "score" is larger than any element in "scores" in a descending order for easier manipulation
    // Return the position of "score" in "scores".
    public int AddScore(int score){
        var i = 0;

        // Directly add "score" to "scores" if there is no any element in "scores"
        if (scores.Count == 0)
            scores.Add(score);
        else {
            // Compare all elements in "scores" with "score"
            for (; i < scores.Count; ++i)
                if (score > scores[i]) {
                    // Remove the smallest element in "scores" if it is full
                    if (scores.Count == size)
                        scores.RemoveAt(scores.Count - 1);
                    scores.Insert(i, score);
                    break;
                }

            // Directly add "score" to "scores" if "score" is not larger than all elements in "scores" but is not full
            if (i == scores.Count && i < size)
                scores.Add(score);
        }

        return i;
    }


    // Return the largest score
    public int GetMax() { return scores.Count == 0 ? 0 : scores[0]; }
}
