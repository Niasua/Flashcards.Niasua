using Flashcards.Niasua.Services;
using Spectre.Console;
using System.Data;

namespace Flashcards.Niasua.UI;

public class FlashcardMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[green]Flashcards Menu[/]")
                .AddChoices(new[]
                {
                    "Add",
                    "View",
                    "Edit",
                    "Delete",
                    "Back"
                }));

            switch (choice)
            {
                case "Add":

                    AddFlashcard();

                    break;

                default:
                    break;
            }
        }
    }

    public static void AddFlashcard()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[red]Create Flashcard:[/]\n");

            AnsiConsole.MarkupLine("Type the [green]name[/] of the Flashcard Stack (type 'zz' to return to the menu):");
            var stackName = Console.ReadLine();
            if (stackName?.ToLower() == "zzz") break;

            AnsiConsole.MarkupLine("\nType the [green]question[/] (type 'zz' to return to the menu):");
            var question = Console.ReadLine();
            if (question?.ToLower() == "zzz") break;

            AnsiConsole.MarkupLine("\nType the [green]answer[/] (type 'zz' to return to the menu):");
            var answer = Console.ReadLine();
            if (answer?.ToLower() == "zzz") break;

            var creation = FlashcardService.CreateFlashcard(stackName, question, answer);

            if (creation)
            {
                AnsiConsole.MarkupLine("\n[green]Flashcard successfully added![/]:");
            }
            else
            {
                AnsiConsole.MarkupLine("\n[red]The stack was not found[/]:");
            }

            AnsiConsole.MarkupLine("\nPress any key to add another flashcard or type [red]'zzz'[/] to return.");

            var input = Console.ReadLine();
            if (input?.ToLower() == "zzz") break;
        }
    }
}
