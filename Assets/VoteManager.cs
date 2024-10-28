using UnityEngine;
using UnityEngine.SceneManagement;

public class VoteManager : MonoBehaviour
{
    // Variables to track votes for each candidate
    public string sceneName;
    public int candidate1Votes = 0;
    public int candidate2Votes = 0;
    public int candidate3Votes = 0;
    public int candidate4Votes = 0;

    // Function to update vote count for candidate 1
    public void VoteForCandidate1()
    {
        candidate1Votes++;
        SaveVoteData();
    }

    // Function to update vote count for candidate 2
    public void VoteForCandidate2()
    {
        candidate2Votes++;
        SaveVoteData();
    }

    // Function to update vote count for candidate 3
    public void VoteForCandidate3()
    {
        candidate3Votes++;
        SaveVoteData();
    }

    // Function to update vote count for candidate 4
    public void VoteForCandidate4()
    {
        candidate4Votes++;
        SaveVoteData();
    }

    // Save all vote data to PlayerPrefs
    void SaveVoteData()
    {
        PlayerPrefs.SetInt("Candidate1Votes", candidate1Votes);
        PlayerPrefs.SetInt("Candidate2Votes", candidate2Votes);
        PlayerPrefs.SetInt("Candidate3Votes", candidate3Votes);
        PlayerPrefs.SetInt("Candidate4Votes", candidate4Votes);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }

    // Load existing vote data from PlayerPrefs
    public void LoadVoteData()
    {
        candidate1Votes = PlayerPrefs.GetInt("Candidate1Votes", 0);
        candidate2Votes = PlayerPrefs.GetInt("Candidate2Votes", 0);
        candidate3Votes = PlayerPrefs.GetInt("Candidate3Votes", 0);
        candidate4Votes = PlayerPrefs.GetInt("Candidate4Votes", 0);
    }
}
