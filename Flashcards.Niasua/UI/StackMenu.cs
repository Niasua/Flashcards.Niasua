using Flashcards.Niasua.Services;
using Spectre.Console;
using System.Data;

namespace Flashcards.Niasua.UI;

public class StackMenu
{
    public static void Show()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[green]Stacks Menu[/]")
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

                    AddStack();

                    break;

                case "View":

                    ViewStacks();

                    break;

                case "Back":

                    exit = true;

                    break;

                default:
                    break;
            }
        }
    }


    private static void AddStack()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[red]Create Stack:[/]\n");

            AnsiConsole.MarkupLine("Type the [green]name[/] of the Stack (type 'zzz' to return to the menu):");
            var stackName = Console.ReadLine();
            if (stackName?.ToLower() == "zzz") break;

            if (string.IsNullOrWhiteSpace(stackName))
            {
                AnsiConsole.MarkupLine("[red]The stack name cannot be empty.[/]");
                continue;
            }

            var creation = StackService.CreateStack(stackName);

            if (creation)
            {
                AnsiConsole.MarkupLine("\n[green]Stack successfully added![/]:");
            }
            else
            {
                AnsiConsole.MarkupLine("\n[red]A stack with that name already exists[/]:");
            }

            AnsiConsole.MarkupLine("\nPress any key to add another stack or type [red]'zzz'[/] to return.");

            var input = Console.ReadLine();
            if (input?.ToLower() == "zzz") break;
        }
    }
    private static void ViewStacks()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[red]View Stacks:[/]\n");

            var stacks = StackService.GetAllStacks();
            Display.ShowStacks(stacks);

            AnsiConsole.MarkupLine("\n[grey]Press any key to to return...[/]");
            Console.ReadKey();
            break;
        }
    }
}
