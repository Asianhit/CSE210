using System;
using System.Collections.Generic;

public class PromptGenerator
{
    List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "Who made a positive impact on your life today?",
        "What challenge did you overcome today?",
        "What is something you are grateful for Today?",
        "What would you like to improve tomorrow?",
        "What is one thing that made you smile today?",
        "What is something new you would like to try?",
        "What is a goal you are working toward?",
        "What is one kind thing you did for someone today?"
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);

        return _prompts[index];
    }

    // GetRandomPrompt();
}