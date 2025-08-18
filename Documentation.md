OPP (Old Phone Pad) Project Documentation
Overview

The OPP Project simulates input from an old mobile phone keypad. It provides a library to process numeric sequences into letters, a web interface to test input in real time, and a unit testing project to validate functionality and exception handling.

The project consists of three main components:

Class Library (OPPClassLibrary)

Web Application (OPPWebApp)

Unit Testing Project (OPPTestProject)

1. Class Library: OPPClassLibrary

The library contains the core logic to convert numeric input sequences into letters according to a traditional mobile phone keypad layout.

Main Classes
Data.cs

Stores the mapping of keys to characters.

Dictionary<char, char[]> Keys – Maps each numeric key to its corresponding characters.

Example:

{ '2', new char[] { 'A', 'B', 'C' } }


GetKeyChars(char key) – Returns the array of characters associated with a numeric key.

GetCharAt(char key, int index) – Returns the character at the specified position for a given key. Throws exceptions if the key is invalid or the index is out of range.

OldPhonePad.cs

Orchestrates the conversion from numeric input sequences to a string of letters.

ProcessOldPhonePad(string input)
Entry point for processing a string input. Handles null inputs and calls the other internal methods. Returns the final string.

ProcessInputToList(string input)
Parses the raw input into sequences, handling:

Spaces between sequences

* to clear the current sequence

* character # is ignored

Changes in consecutive digits

Throws exceptions for invalid characters

TranslateToLetters(List<string> inputList)
Converts numeric sequences into letters using the Data class. Handles sequence length exceeding the number of characters on a key (caps at maximum available).

JoinTranslatedLetters(List<char> letters)
Concatenates letters into a single string. Handles null or empty lists.

Exception Handling

The library throws meaningful exceptions to be handled by the web interface or unit tests:

ArgumentNullException – Input or list is null

ArgumentException – Invalid character or key

IndexOutOfRangeException – Key sequence exceeds available characters

InvalidOperationException – Unexpected translation failure

2. Web Application: OPPWebApp

The web application provides a Razor Pages interface to simulate old phone pad input in real time.

Structure

Pages/Index.cshtml – User interface:

Input field for numeric sequences

Displays result or exception messages

JavaScript handles a 1-second delay between key presses to automatically insert spaces

Pages/Index.cshtml.cs – PageModel:

Injects IOldPhonePadService to handle processing

Handles input via OnPost()

Exception handling is done here to prevent application crashes and display user-friendly messages

Services/OPPService.cs – Implements the IOldPhonePadService interface:

Encapsulates calls to the OldPhonePad class

Centralizes logic and exception handling if needed

Features

Real-time input simulation with 1-second timeout between key presses

Error messages displayed in the UI instead of crashing the app

Integration with the class library via dependency injection

3. Unit Testing Project: OPPTestProject

The unit testing project validates both normal scenarios and exception scenarios.

Structure
OPPBasicT.cs

Tests expected input sequences

Covers:

Single key presses

Repeated key presses

Combined sequences with spaces

Ignored # characters

Example inputs:

[InlineData("2", "A")]
[InlineData("7777#33", "SF")]
[InlineData("4433555 555666#", "HELLO")]

OPPExpT.cs

Tests exception handling

Covers:

null input

Invalid characters

Out-of-range key presses

Invalid key access

Null input lists
