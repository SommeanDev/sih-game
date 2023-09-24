using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuizHandler : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] optionButtons;
    public Image[] optionImages;

    private string[] questions;
    private string[][] options;
    private int[] correctAnswers;
    private int currentQuestionIndex;

    [NonSerialized] public bool answerIsCorrect = false;

    void Start()
    {
        // Initialize questions, options, and correct answers
        questions = new string[]
        {
            "Question 1: What does 'IPR' stand for?",
            "Question 2: Which of the following is NOT a type of intellectual property right?",
            "Question 3: What does a copyright protect?",
            "Question 4: Which type of intellectual property right is typically associated with protecting brand names, logos, and slogans?",
            "Question 5: How long does a typical copyright last?",
            "Question 6: What does a patent protect?",
            "Question 7: Which international organization administers patents and trademarks through the Patent Cooperation Treaty (PCT) and the Madrid Protocol?",
            "Question 8: What is the purpose of a trade secret?",
            "Question 9: Which of the following is an example of a trade secret?",
            "Question 10: What is the primary purpose of intellectual property rights?"
        };

        options = new string[][]
        {
            new string[] { "a) International Property Rights", "b) Intellectual Property Rights", "c) Invention Patent Registration", "d) Industrial Property Regulation" },
            new string[] { "a) Copyright", "b) Trademark", "c) Real Estate", "d) Patent" },
            new string[] { "a) Inventions and discoveries", "b) Original creative works", "c) Product designs", "d) Business names" },
            new string[] { "a) Patent", "b) Trademark", "c) Copyright", "d) Trade secret" },
            new string[] { "a) 5 years", "b) 20 years", "c) The lifetime of the creator plus 70 years", "d) Indefinitely" },
            new string[] { "a) Literary works", "b) Inventions and innovations", "c) Artistic creations", "d) Trade secrets" },
            new string[] { "a) United Nations (UN)", "b) World Trade Organization (WTO)", "c) World Intellectual Property Organization (WIPO)", "d) International Monetary Fund (IMF)" },
            new string[] { "a) To protect inventions", "b) To encourage innovation", "c) To protect confidential and valuable business information", "d) To promote fair competition" },
            new string[] { "a) A famous painting", "b) A closely guarded recipe for a popular soft drink", "c) A bestselling novel", "d) A new smartphone design" },
            new string[] { "a) To restrict access to creative works", "b) To promote the sharing of ideas and inventions", "c) To provide legal protection and incentives for innovation and creativity", "d) To increase the cost of goods and services" }
        };

        correctAnswers = new int[] { 1, 2, 1, 1, 2, 1, 2, 2, 1, 2 }; // Index of the correct option (0 to 3) for each question

        currentQuestionIndex = -1; // Start with no questions displayed
        ShowNextQuestion();
    }

    void Update()
    {
        // You can add any update logic here if needed
    }

    void ShowNextQuestion()
    {
        ResetOptionImages();
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];

            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex][i];

                int optionIndex = i; // To capture the current value of i in the lambda
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(optionIndex));
            }
        }
        else
        {
            // Quiz is over
            questionText.text = "Quiz is over!";
            for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = null;
        }
        }
    }

    void ResetOptionImages()
{
    // Set all option images to black
    foreach (Image optionImage in optionImages)
    {
        optionImage.color = Color.white;
    }
}

    void CheckAnswer(int selectedOption)
    {
        if (selectedOption == correctAnswers[currentQuestionIndex])
        {
            // Correct answer, change the image to green
            optionImages[selectedOption].color = Color.green;
            answerIsCorrect = true;
        }
        else
        {
            // Incorrect answer, change the selected image to red and correct answer image to green
            optionImages[selectedOption].color = Color.red;
            optionImages[correctAnswers[currentQuestionIndex]].color = Color.green;
            answerIsCorrect = false;
        }

        // Delay showing the next question for 1 second
        StartCoroutine(NextQuestionDelay());
    }

    IEnumerator NextQuestionDelay()
    {
        yield return new WaitForSeconds(1f);
        ShowNextQuestion();
    }
}

