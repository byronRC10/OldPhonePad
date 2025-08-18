# OPP (Old Phone Pad) Project Documentation

## Overview
The OPP Project simulates input from an old mobile phone keypad.  
It provides:
- A **Class Library** to process numeric sequences into letters.
- A **Web Application** for real-time input testing.
- A **Unit Testing Project** to validate functionality and exception handling.

## Project Components
1. **Class Library:** `OPPClassLibrary`  
2. **Web Application:** `OPPWebApp`  
3. **Unit Testing Project:** `OPPTestProject`  

---

## 1. Class Library: OPPClassLibrary
Contains the core logic to convert numeric input sequences into letters.

### Main Classes

#### Data.cs
- **Description:** Stores keypad mappings and helper methods.
- **Properties:**
  - `Keys` (Dictionary<char, char[]>): maps each numeric key to its characters.
    ```csharp
    { '2', new char[] { 'A', 'B', 'C' } }
    ```
- **Methods:**
  - `GetKeyChars(char key)`: Returns the characters for a numeric key.
  - `GetCharAt(char key, int index)`: Returns the character at a specific position.  
    Throws exceptions if key is invalid or index out of range.

#### OldPhonePad.cs
- **Description:** Orchestrates conversion from numeric sequences to letters.
- **Methods:**
  - `ProcessOldPhonePad(string input)`  
    Entry point for processing input. Handles null inputs.
    **Exceptions:** `ArgumentNullException`
  - `ProcessInputToList(string input)`  
    Parses input into sequences:
    - Handles spaces between sequences
    - `*` clears current sequence
    - `#` is ignored
    - Changes in consecutive digits  
    **Exceptions:** `ArgumentException` for invalid characters
  - `TranslateToLetters(List<string> inputList)`  
    Converts numeric sequences into letters using `Data` class.  
    Caps presses at the maximum characters for each key.  
    **Exceptions:** `ArgumentNullException`, `InvalidOperationException`
  - `JoinTranslatedLetters(List<char> letters)`  
    Concatenates letters into a final string.  
    **Exceptions:** `ArgumentNullException`

### Exception Handling
The library throws meaningful exceptions to be caught by the Web App or Unit Tests:
- `ArgumentNullException`: Input or list is null
- `ArgumentException`: Invalid character or key
- `IndexOutOfRangeException`: Key sequence exceeds available characters
- `InvalidOperationException`: Unexpected translation failure

---

## 2. Web Application: OPPWebApp
Provides a **Razor Pages interface** for simulating old phone pad input.

### Structure
- `Pages/Index.cshtml`: UI for numeric input, displays results and exceptions.
- `Pages/Index.cshtml.cs`: PageModel
  - Injects `IOldPhonePadService` for processing.
  - Handles input via `OnPost()`.
  - Catches exceptions to prevent app crashes.
- `Services/OPPService.cs`: Implements `IOldPhonePadService`
  - Encapsulates calls to `OldPhonePad`.
  - Centralizes logic and exception handling.

### Features
- Real-time input simulation with 1-second timeout between key presses.
- Error messages displayed in UI instead of crashing.
- Dependency Injection to connect Web App with Class Library.

---

## 3. Unit Testing Project: OPPTestProject
Validates both normal and exception scenarios.

### Test Classes

#### OPPBasicT
- **Description:** Tests expected input sequences.
- **Scenarios:**
  - Single key presses
  - Repeated key presses
  - Combined sequences with spaces
  - Ignored `#` characters
- **Example Inputs:**
  ```csharp
  [InlineData("2", "A")]
  [InlineData("7777#33", "SF")]
  [InlineData("4433555 555666#", "HELLO")]
  [InlineData("8 88777444666*664#", "TURING")]
OPPExpT

Description: Tests exception handling.

Scenarios:

Null input
Invalid characters
Out-of-range key presses
Invalid key access
Null input lists
