namespace Flashcards.Niasua.Models;

internal class Stack
{
    public int StackId { get; set; }
    public string Name { get; set; }
    public List<Flashcard> Flashcards { get; set; }
}
