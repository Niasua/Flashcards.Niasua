using Flashcards.Niasua.DTOs;
using Spectre.Console;
using System.Security.Cryptography.X509Certificates;

namespace Flashcards.Niasua.UI;

public class Display
{
    internal static void ShowFlashcards(List<FlashcardDTO> flashcards)
    {
        Console.Clear();
        if (flashcards == null || flashcards.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No flashcards found in this stack.[/]");
            Console.ReadKey();
            return;
        }

        int index = 0;
        bool showingQuestion = true;

        while (true)
        {
            Console.Clear();
            var card = flashcards[index];

            if (showingQuestion)
            {
                AnsiConsole.MarkupLine($"[yellow]Flashcard {index + 1}/{flashcards.Count}[/]");
                AnsiConsole.MarkupLine("[bold]Question[/]");
                AnsiConsole.MarkupLine($"{card.Question}");
                AnsiConsole.MarkupLine("\nPress [green]Enter[/] to reveal answer, [red]'n'[/] next card, [red]'q'[/] quit.");
            }
            else
            {
                AnsiConsole.MarkupLine($"[yellow]Flashcard {index + 1}/{flashcards.Count}[/]");
                AnsiConsole.MarkupLine("[bold]Answer:[/]");
                AnsiConsole.MarkupLine($"{card.Answer}");
                AnsiConsole.MarkupLine("\nPress [green]Enter[/] to show question again, [red]'n'[/] next card, [red]'q'[/] quit.");
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Q)
                break;

            if(key.Key == ConsoleKey.N)
            {
                index++;
                if (index >= flashcards.Count)
                {
                    index = 0; // vuelve a la primera flashcard
                    showingQuestion = true;
                    continue;
                }
                showingQuestion = true;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                showingQuestion = !showingQuestion;
            }
        }
    }
}
