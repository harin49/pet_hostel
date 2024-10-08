namespace utils
{
    public static class Utility
    {
        public static string getAndSanitizeUserInput()
        {
            string? readUserInput;
            do
            {
                readUserInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(readUserInput))
                {
                    readUserInput = readUserInput.Trim();
                }

            } while (string.IsNullOrWhiteSpace(readUserInput));
            return readUserInput;
        }
    }
}