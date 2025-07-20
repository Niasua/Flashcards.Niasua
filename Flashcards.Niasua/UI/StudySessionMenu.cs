using Flashcards.Niasua.Models;
using Flashcards.Niasua.Services;
using Spectre.Console;

namespace Flashcards.Niasua.UI;

public class StudySessionMenu
{
    public static void Show()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[green]Study Sessions Menu[/]")
                .AddChoices(new[]
                {
                    "Start a Study Session",
                    "View Study Sessions History",
                    "Back to Main Menu"
                }));

            switch (choice)
            {
                case "Start a Study Session":

                    StartStudySession();

                    break;

                case "View Study Sessions History":

                    ViewHistory();

                    break;

                case "Back to Main Menu":

                    exit = true;

                    break;
            }
        }
    }

    private static void StartStudySession()
    {
        var isStudying = true;

        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[red]Start Study Session:[/]\n");

            var stacks = StackService.GetAllStacks();

            Display.ShowStacks(stacks);

            AnsiConsole.MarkupLine("\nType the [green]ID[/] of the Stack you want to study (type 'zzz' to return to the menu):");
            var stackId = Console.ReadLine();
            if (stackId?.ToLower() == "zzz") break;

            if (!int.TryParse(stackId, out int displayId) || displayId < 1 || displayId > stacks.Count)
            {
                AnsiConsole.MarkupLine("\n[red]Invalid ID. Press any key to try again...[/]:\n");
                Console.ReadKey();
                continue;
            }

            var stack = stacks[displayId - 1];

            var flashcards = FlashcardService.GetFlashcardsByStack(stack.Name);

            var score = Display.ShowFlashcards(flashcards, isStudying);

            if (score.HasValue)
            {
                StudySessionService.CreateStudySession(stack.Name, score.Value);
            }
            else
            {
                AnsiConsole.MarkupLine("[yellow]Session not saved because no answers were given.[/]");
            }

            AnsiConsole.MarkupLine("\nPress any key to study again or type [red]'zzz'[/] to return.");

            var input = Console.ReadLine();
            if (input?.ToLower() == "zzz") break;
        }
    }

    private static void ViewHistory()
    {
        throw new NotImplementedException();
    }
}
