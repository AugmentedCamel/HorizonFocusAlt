using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OpenAI;
using TMPro;
using Unity.VisualScripting;

public class ChatGPTManager : MonoBehaviour
{
    
    public UnityEvent OnChatGPTCoordinateResponse;
    private OpenAIApi _openAI;
    private List<ChatMessage> _messages = new List<ChatMessage>();
    private string _colorText;
    [SerializeField] private TextMeshPro _answerText;
    [SerializeField] private TextMeshPro _inputText;
    
    private void Start()
    {
        string apiKey = "";
        //Debug.Log(apiKey);
        //string apiKey = Config.OpenAI_API_Key;
        string organizationId = "";
       
        _openAI = new OpenAIApi(apiKey, organizationId);

    }

    public async void AskChatGPT(string newText)
    {
        //user message
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";
        _messages.Add(newMessage);
        
        //system message
        ChatMessage systemMessage = new ChatMessage();
        //systemMessage.Content = "You are a summarizer that only replies with a summary of the input wih maximum 5 words. You get extra points if you are brief and concise.";
        systemMessage.Content = "You will only reply with a summarized concept of the input wih maximum 7 words or less. The input is an idea or part of an idea. You get extra points if you are brief and concise. ";

        systemMessage.Role = "system";
        _messages.Add(systemMessage);
        
        
        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = _messages;
        request.Model = "gpt-3.5-turbo";
        
        
        var response = await _openAI.CreateChatCompletion(request);
        
        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            _messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);
            SetAnswerText(chatResponse.Content);
            //OnChatGPTResponse?.Invoke();
            
        }

    }
    
    public async void AskChatGPTCoordinates(string newText)
    {
        //user message
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";
        _messages.Add(newMessage);
        
        //system message
        ChatMessage systemMessage = new ChatMessage();
        //systemMessage.Content = "You are a summarizer that only replies with a summary of the input wih maximum 5 words. You get extra points if you are brief and concise.";
        systemMessage.Content =
            "You will only reply with coordinates of the input. The input is a location or a place. only respond with the following format: latitude,longitude";

        systemMessage.Role = "system";
        _messages.Add(systemMessage);
        
        
        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = _messages;
        request.Model = "gpt-3.5-turbo";
        
        
        var response = await _openAI.CreateChatCompletion(request);
        
        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            _messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);
            SetColorText(chatResponse.Content);
            OnChatGPTCoordinateResponse?.Invoke();
            
            
        }

    }
    // Start is called before the first frame update
    void SetAnswerText(string text)
    {
        _answerText.text = text;
    }
    
    void SetColorText(string text)
    {
        _colorText = text;
    }
    
    public string GetColorText()
    {
        return _colorText;
    }
    public string GetChatGPTResponse()
    {
        return _answerText.text;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
