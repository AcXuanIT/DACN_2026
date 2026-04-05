using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public class BuildAnimation : MonoBehaviour
{
    [SerializeField] private GameObject house;

    [SerializeField] private List<LevelHouse> levelHouses = new List<LevelHouse>();

    [Header("AnimationClip")]
    [SerializeField] private AnimationClip _level0to1Clip;
    [SerializeField] private AnimationClip _level1to2Clip;
    [SerializeField] private AnimationClip _level2to3Clip;
    [SerializeField] private AnimationClip _level3to4Clip;
    [SerializeField] private AnimationClip _level4to5Clip;

    [SerializeField] private Animation _anim;

    public int level = 1;

    private void Awake()
    {
        house = this.gameObject;
        _anim = this.GetComponent<Animation>();
    }
    private void Start()
    {
        InitListLevel(7);
        AddChildToList();
        StartLevel();
    }
    public void InitListLevel(int levelMax)
    {
       for(int i=0;i<levelMax;i++)
       {
            levelHouses.Add(new LevelHouse());     
       }
    }

    public void AddChildToList()
    {
        if (house == null) return;
        ProcessingChild(house.transform);
    }

    public void ProcessingChild(Transform parent)
    {
        foreach(Transform child in parent)
        {
            if(child.name.EndsWith("_G"))
            {
                var matches = Regex.Matches(child.name, @"L(\d+)");
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        int level = int.Parse(match.Groups[1].Value);
                        levelHouses[level].objects.Add(child.gameObject);
                    }
                }
            }

            ProcessingChild(child);
        }
    }

    public void StartLevel()
    {
        Debug.Log("Start Run Animation");
        switch(level)
        {
            case 0:
                TurnOnLevel(0);
                break;
            case 1:
                TurnOnLevel(1);
                _anim.Play(_level0to1Clip.name);
                break;
            case 2:
                TurnOnLevel(2);
                _anim.Play(_level1to2Clip.name);
                DelayTurnOff(_level1to2Clip, 1);
                break;
            case 3:
                TurnOnLevel(3);
                _anim.Play(_level2to3Clip.name);
                DelayTurnOff(_level2to3Clip, 2);
                break;
            case 4:
                TurnOnLevel(4);
                _anim.Play(_level3to4Clip.name);
                DelayTurnOff(_level3to4Clip, 3);
                break;
            case 5:
                TurnOnLevel(5);
                _anim.Play(_level4to5Clip.name);
                DelayTurnOff(_level4to5Clip, 4);
                break;
            default:
                Debug.Log("Out Level");
                break;
        }
    }

    public void DelayTurnOff(AnimationClip clip, int level)
    {
        DOVirtual.DelayedCall(clip.length, () =>
        {
            TurnOffLevel(level, level +1 ) ;
        });
    }

    public void TurnOnLevel(int index)
    {
        foreach(GameObject obj in levelHouses[index].objects)
        {
            MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
            mesh.enabled = true;
        }
    }

    public void TurnOffLevel(int index, int indexcheck)
    {
        foreach(GameObject obj in levelHouses[(index)].objects)
        {
            if(indexcheck <= 5)
                if (levelHouses[indexcheck].objects.Contains(obj)) return;

            MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
            mesh.enabled = false;
        }
    }
    
}
