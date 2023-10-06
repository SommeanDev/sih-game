using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;

public class CreativeQuestion : MonoBehaviour
{
    public GameObject questionPanel; // Reference to the panel you want to deactivate.
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    

    private string[] questions = {
        "What is your favorite color?",
        "Describe your iron man like armour concept in 8-9 words.",
        "Explain your concept of flying car in less than 20 words.",
        "What are your free time hobbies.",
        "How do you approach problem-solving?"
    };

    // Create an array of functions to hold evaluation logic for each question.
    private Func<string, int>[] evaluationFunctions;

    private int questionsAsked; // Counter for questions asked.

    private List<int> displayedQuestionIndices = new List<int>();

    int creativityPercentage;
    int innovationPercentage;

    private void Start()
    {
        // Initialize evaluation functions.
        evaluationFunctions = new Func<string, int>[]
        {
            EvaluateFavoriteColor,
            EvaluateCreativeIdea,
            EvaluateInnovativeConcept,
            EvaluateUniqueThought,
            EvaluateProblemSolvingApproach
        };
        questionsAsked = 0;
        creativityPercentage = 0;
        innovationPercentage = 0;
        DisplayNextQuestion();
    }

    public void SubmitAnswer()
  {
    string answer = answerInput.text;

    // Get the index of the current question.
    int currentQuestionIndex = Array.IndexOf(questions, questionText.text);


    // Check the current question index and adjust the scoring logic accordingly.
    if (currentQuestionIndex == 0 || currentQuestionIndex == 1|| currentQuestionIndex == 3)
    {
        // First and second questions: Calculate only creativity score.
        creativityPercentage += evaluationFunctions[currentQuestionIndex](answer);
    }
    
    else if (currentQuestionIndex == 2 || currentQuestionIndex == 4)
    {
       
      innovationPercentage += evaluationFunctions[currentQuestionIndex](answer);
      
    }

   

    questionsAsked++;

    if (questionsAsked >= questions.Length)
    {
        PlayerPrefs.SetInt("CreativeQuotient", creativityPercentage);
        PlayerPrefs.SetInt("InnovativeQuotient", innovationPercentage);
        questionsAsked = 0;
        questionPanel.SetActive(false);
         ResetGameState();
        
    }
    else
    {
        
        DisplayNextQuestion();
    }
}

private void ResetGameState()
    {
        questionsAsked = 0;
        creativityPercentage = 0;
        innovationPercentage = 0;
        displayedQuestionIndices.Clear(); // Clear the list of displayed questions.
        DisplayNextQuestion(); // Start the questions again.
    }



   void DisplayNextQuestion()
  {
   

    int randomIndex;
    do
    {
        randomIndex = UnityEngine.Random.Range(0, questions.Length);
    } while (displayedQuestionIndices.Contains(randomIndex));

    // Store the displayed index.
    displayedQuestionIndices.Add(randomIndex);

    questionText.text = questions[randomIndex];
    answerInput.text = ""; // Clear previous answer.
  }

    // Define evaluation logic for each question.
   private int EvaluateFavoriteColor(string answer)
  {
    // Convert the answer to lowercase for case-insensitive comparison.
    answer = answer.ToLower();

    // Check if the answer contains specific color keywords.
    if (answer.Contains("blue") || answer.Contains("cyan"))
    {
        return 20; // Creativity score of 20 for blue and cyan.
    }
    else if (answer.Contains("green"))
    {
        return 10; // Creativity score of 10 for green.
    }
    else if (answer.Contains("yellow"))
    {
        return 5; // Creativity score of 5 for yellow.
    }
    else
    {
        return 2; // Creativity score of 2 for any other color.
    }
  }



    private int EvaluateCreativeIdea(string answer)
  {
    // Convert the answer to lowercase and split it into words.
    string[] words = answer.ToLower().Split(' ');

    // List of creative keywords to match.
    List<string> creativeKeywords = new List<string>
    {
        "nanotechnology", "mind", "control", "ai", "self", "healing", "jarvis",
        "thruster", "repulsor", "titanium", "alloy", "reactor"
    };

    // Count how many creative keywords are present in the answer.
   int matchingKeywords = words.Count(word => creativeKeywords.Contains(word));

    // Calculate the creativity score based on the number of matching keywords.
    int creativityScore = matchingKeywords * 8;

    // Cap the creativity score at 20.
    if (creativityScore > 40)
    {
        creativityScore = 40;
    }

    // If the answer exceeds 5 words, return a creativity score of 0.
    if (words.Length > 9)
    {
        return 0;
    }

    return creativityScore;
  }


    private int EvaluateInnovativeConcept(string answer)
  {
    // Convert the answer to lowercase and split it into words.
    string[] words = answer.ToLower().Split(' ');

    // List of keywords for creativity and innovation.
    List<string> innovativeKeywords = new List<string>
    {
        "antigravity", "thruster", "repulsor", "spacecar", "transform", "self", "driving","aerodynamic", "carbon", "fibre", "drone", "autopilot", "lightweight", "battery", "nanodiamond"
    };

   

    
    int innovativeMatches = words.Count(word => innovativeKeywords.Contains(word));

    int innovationScore = Mathf.Clamp(innovativeMatches * 10, 0, 40);

    if (words.Length > 20)
    {
   
        innovationScore = 0;
    }

    return innovationScore;
  }


   private int EvaluateUniqueThought(string answer)
  {
    // Convert the answer to lowercase and split it into words.
    string[] words = answer.ToLower().Split(' ');

    // Lists of keywords for creativity.
    List<string> creativeKeywords1 = new List<string>
    {
        "painting", "sketching", "drawing", "craft", "project", "making","reading", "brainstorming", "learning", "new", "concepts"
    };

  
    // Count how many creative keywords from each list are present in the answer.
    int creativeMatches1 = words.Count(word => creativeKeywords1.Contains(word));
    

    // Calculate creativity score based on matches.
    int creativityScore = Mathf.Clamp((creativeMatches1) * 10, 0, 40);

    return creativityScore;
  }


    private int EvaluateProblemSolvingApproach(string answer)
  {
    // Convert the answer to lowercase and split it into words.
    string[] words = answer.ToLower().Split(' ');

    // List of keywords for innovation.
    List<string> innovativeKeywords = new List<string>
    {
        "reading", "thoroughly", "understanding", "searching", "thinking","solution", "multiple", "possibilities", "meaning"
    };

    // Count how many innovative keywords are present in the answer.
    int innovativeMatches = words.Count(word => innovativeKeywords.Contains(word));

    // Calculate innovation score based on matches.
    int innovationScore = Mathf.Clamp(innovativeMatches * 10, 0, 60);

    return innovationScore;
  }
}



