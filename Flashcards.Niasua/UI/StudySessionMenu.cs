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
                    "Back to Main Menu
                }));

            switch (choice)
            {
                case "Start a Study Session":

                    CreateStudySession();

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

    private static void CreateStudySession()
    {
        throw new NotImplementedException();
    }

    private static void ViewHistory()
    {
        throw new NotImplementedException();
    }
}
