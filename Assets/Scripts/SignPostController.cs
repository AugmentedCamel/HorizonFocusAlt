using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SignPostController : MonoBehaviour
{
    [SerializeField] List<SignPost> _signPostsA;
    [SerializeField] List<SignPost> _signPostsB;
    
    [SerializeField] private GameObject _testAim;
    
    private SignPost _currentSignPost;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Button]
    public void TestSignPost()
    {
        SetSignPostsAActive(0, _testAim, "Test");
    }
    
    public void SetSignPostsAActive(int index, GameObject aim, string text)
    {
        if (_signPostsA.Count > index)
        {
            _signPostsA[index].ActivateSignPost(aim, text);
            _currentSignPost = _signPostsA[index];
            
        }
    }

    public void SpawnSignPostAt(int index, string targetText)
    {
        if (_signPostsA.Count > index)
        {
            _signPostsA[index].StartAimSignPost(targetText);
            _currentSignPost = _signPostsA[index];
        }
    }
    
    public void SaveCurrentSignPosts(float correctLocalAngle)
    {
        if (_currentSignPost != null)
        {
            _currentSignPost.Save(correctLocalAngle);
            Debug.Log("arrow Saved");
            _currentSignPost = null;
        }
        
        //should spawn a new signpost at the correct angle here,
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
