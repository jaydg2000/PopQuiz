﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Models
{
    public class QuizListViewModel
    {
        public IEnumerable<QuizSummaryViewModel> QuizSummaries { get; set; }
    }
}
