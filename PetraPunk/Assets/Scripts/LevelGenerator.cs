using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Possible Segments")]
    public LevelSegment[] LevelSegments;

    [Header("Level order")]
    public SceneGenrator LevelGenerationData;

    public Segment lastSegement;

    

    //first list is difficulty second list is segments of that difficuly
    List<List<int>> listOfLists = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 0; i < LevelSegments.Length; i++)
        {

            print(LevelSegments[i].Difficulty > listOfLists.Count - 1);
            while(LevelSegments[i].Difficulty > listOfLists.Count-1)
            {
                
                List<int> temp = new List<int>();

                listOfLists.Add(temp);
                
                
            }
            listOfLists[LevelSegments[i].Difficulty].Add(i);
            
        }
       

        for (int i = 0; i < LevelGenerationData.SegementDifficulty.Length; i++)
        {
            print(LevelGenerationData.SegementDifficulty[i]);
            int selectedLevelOfDiff = Mathf.RoundToInt( Random.Range(0, listOfLists[ LevelGenerationData.SegementDifficulty[i]].Count));

            print(selectedLevelOfDiff);

            GameObject segmentToSpawn = LevelSegments[listOfLists[LevelGenerationData.SegementDifficulty[i]][selectedLevelOfDiff]].Segment;
            segmentToSpawn= Instantiate(segmentToSpawn);

            Segment segemntData = segmentToSpawn.GetComponent<Segment>();

            segmentToSpawn.transform.position = lastSegement.EndOfScene.transform.position-segemntData.StartOfScene.transform.position;
            lastSegement = segemntData;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
