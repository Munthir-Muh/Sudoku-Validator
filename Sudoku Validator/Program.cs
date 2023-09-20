using System.Text.Json;
using SudokuValidator;

//Input files
var sudoku = JsonSerializer.Deserialize<List<List<int>>>(File.ReadAllText("..\\..\\..\\sudoku.json"));
var sudokuArray = JsonSerializer.Deserialize<string[]>(File.ReadAllText("..\\..\\..\\sudokuArray.json"));

//2D List
Console.WriteLine(Sudoku.Validate(sudoku));

//String Array
Console.WriteLine(Sudoku.Validate(sudokuArray!));

