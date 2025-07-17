﻿namespace Flashcards.Niasua.Models
{
    internal class Flashcard
    {
        public int FlashcardId { get; set; }
        public int StackId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Stack Stack { get; set; }
    }
}