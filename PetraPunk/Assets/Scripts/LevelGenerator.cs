using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public bool IsEndless;

    [Header("Possible Segments")]
    public LevelSegment[] LevelSegments;

    [Header("Level order")]
    public SceneGenrator LevelGenerationData;

    [Header("Set this up as the first Segment")]
    public Segment lastSegement;

    GameObject currentBlock;
    GameObject lastBlock;



    //first list is difficulty second list is segments of that difficuly
    List<List<int>> listOfLists = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {


        sortSegementsInTheListOfLists();
        GenerateBlock();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEndless)
        {
            if (PlayerController.progress >= lastSegement.EndOfScene.transform.position.z - 300)
            {
                Destroy(lastBlock);
                lastBlock = currentBlock;
                print("next segment created");
                GenerateBlock();

            }
        }
        
    }

    void sortSegementsInTheListOfLists()
    {
        for (int i = 0; i < LevelSegments.Length; i++)
        {

            print(LevelSegments[i].Difficulty > listOfLists.Count - 1);
            while (LevelSegments[i].Difficulty > listOfLists.Count - 1)
            {

                List<int> temp = new List<int>();

                listOfLists.Add(temp);


            }
            listOfLists[LevelSegments[i].Difficulty].Add(i);

        }
    }

    void GenerateBlock()
    {
        currentBlock = new GameObject();
        currentBlock.name = "currentBlock";

        for (int i = 0; i < LevelGenerationData.SegementDifficulty.Length; i++)
        {
            print(LevelGenerationData.SegementDifficulty[i]);
            int selectedLevelOfDiff = Mathf.RoundToInt(Random.Range(0, listOfLists[LevelGenerationData.SegementDifficulty[i]].Count));

            print(selectedLevelOfDiff);

            GameObject segmentToSpawn = LevelSegments[listOfLists[LevelGenerationData.SegementDifficulty[i]][selectedLevelOfDiff]].Segment;
            segmentToSpawn = Instantiate(segmentToSpawn);

            Segment segemntData = segmentToSpawn.GetComponent<Segment>();

            segmentToSpawn.transform.position = lastSegement.EndOfScene.transform.position - segemntData.StartOfScene.transform.position;
            lastSegement = segemntData;

            segmentToSpawn.transform.SetParent(currentBlock.transform);

        }
    }
}
