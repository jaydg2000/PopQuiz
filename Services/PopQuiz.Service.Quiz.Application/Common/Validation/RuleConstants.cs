﻿namespace PopQuiz.Service.Quiz.Application.Common.Validation
{
    sealed internal class RuleConstants
    {
        static public int QUIZ_NAME_MINIMUM_LENGTH = 2;
        static public int QUIZ_NAME_MAXIMUM_LENGTH = 50;
        static public string QUIZ_NAME_REGEX = @"(^[a-zA-Z0-9#$()!+=,@&. -]*$)";
        static public int QUIZ_DESCRIPTION_MINIMUM_LENGTH = 0;
        static public int QUIZ_DESCRIPTION_MAXIMUM_LENGTH = 500;

        static public int QUESTION_TEXT_MINIMUM_LENGTH = 10;
        static public int QUESTION_TEXT_MAXIMUM_LENGTH = 2000;
        static public string QUESTION_TEXT_REGEX = @"(^[a-zA-Z0-9#$()!/\+=,@&?. -]*$)";
        static public int QUESTION_MINIMUM_NUMBER_OF_CHOICES = 2;
    }
}