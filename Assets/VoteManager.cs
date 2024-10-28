using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class VoteData
{
    public int candidate1Votes;
    public int candidate2Votes;
    public int candidate3Votes;
    public int candidate4Votes;
}

public class VoteManager : MonoBehaviour
{
    public int candidate1Votes = 0;
    public int candidate2Votes = 0;
    public int candidate3Votes = 0;
    public int candidate4Votes = 0;
    public string sceneName;

    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "VoteData.json");
        LoadVoteData();  // Load existing data at start
    }

    public void VoteForCandidate1()
    {
        candidate1Votes++;
        SaveVoteData();
    }

    public void VoteForCandidate2()
    {
        candidate2Votes++;
        SaveVoteData();
    }

    public void VoteForCandidate3()
    {
        candidate3Votes++;
        SaveVoteData();
    }

    public void VoteForCandidate4()
    {
        candidate4Votes++;
        SaveVoteData();
    }

    // Save data to JSON file
    private void SaveVoteData()
    {
        VoteData data = new VoteData
        {
            candidate1Votes = candidate1Votes,
            candidate2Votes = candidate2Votes,
            candidate3Votes = candidate3Votes,
            candidate4Votes = candidate4Votes
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        SceneManager.LoadScene(sceneName);
    }

    // Load data from JSON file
    private void LoadVoteData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            VoteData data = JsonUtility.FromJson<VoteData>(json);

            candidate1Votes = data.candidate1Votes;
            candidate2Votes = data.candidate2Votes;
            candidate3Votes = data.candidate3Votes;
            candidate4Votes = data.candidate4Votes;
        }
        else
        {
            Debug.Log("No save file found. Starting fresh.");
        }
    }
}
