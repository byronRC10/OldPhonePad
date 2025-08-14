## Project Structure

The project contains three main classes:

1. **Program.cs**  
   - Contains the `Main` method.  
   - Handles console input, including delays between key presses and insertion of spaces.  
   - Calls the `Functions` class to process input.

2. **Functions.cs**  
   - Contains the core processing logic.  
   - Main method: `ProcessOldPhonePad(string input)` – orchestrates the processing flow.  
   - `ProcessInputToList(string input)` – parses input into a list of numeric sequences, ignoring invalid characters like `#` and handling spaces between numbers or changes in consecutive digits.  
   - `TranslateToLetters(List<string> inputList)` – converts numeric sequences into letters using the mapping in the `Data` class.  
   - `JoinTranslatedLetters(List<char> letters)` – concatenates the resulting characters into a single string.

3. **Data.cs**  
   - Contains the keypad mapping of numbers to letters.  
   - `GetKeyChars(char key)` – retrieves the array of characters associated with a number key.  
   - `GetCharAt(char key, int index)` – returns the character at a specific position for a given number key.

---

## Main Classes and Methods

### Program.cs

- **Main()**: Handles console input and timing to detect pauses between key presses.  
- **OldPhonePad(string input)**: Calls `Functions.ProcessOldPhonePad` with user input.

### Functions.cs

- **ProcessOldPhonePad(string input)**: Main entry point for processing input.  
- **ProcessInputToList(string input)**: Parses the input into separate sequences, considering spaces, `*`, `#`, and numeric changes.  
- **TranslateToLetters(List<string> inputList)**: Uses `Data` to convert numeric sequences into letters.  
- **JoinTranslatedLetters(List<char> letters)**: Combines letters into a final string output.

### Data.cs

- **Dictionary**: Dictionary mapping each numeric key to its corresponding letters.  
- **GetKeyChars(char key)**: Returns all characters for a given key.  
- **GetCharAt(char key, int index)**: Retrieves a specific character for a key based on the number of presses.

