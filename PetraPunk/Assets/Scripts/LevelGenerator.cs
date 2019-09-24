using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Possible Segments")]
    public LevelSegment[] LevelSegments;

    [Header("Level order")]
    public SceneGenrator LevelGenerationData;

    public Segment StartSegment;

    //first list is difficulty second list is segments of that difficuly
    List<List<int>> listOfLists = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LevelSegments.Length; i++)
        {
            while(LevelSegments[i].Difficulty > listOfLists.Count)
            {
                listOfLists.Add(new List<int>());
            }
            listOfLists[LevelSegments[i].Difficulty].Add(i);
            
        }
        print(listOfLists.Count);

        for (int i = 0; i < LevelGenerationData.SegementDifficulty.Length; i++)
        {
            int selectedLevelOfDiff = (int) Random.Range(0, listOfLists[ LevelGenerationData.SegementDifficulty[i]].Count);
            GameObject segmentToSpawn = LevelSegments[listOfLists[LevelGenerationData.SegementDifficulty[i]][selectedLevelOfDiff]].Segment;
            segmentToSpawn= Instantiate(segmentToSpawn);



        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
