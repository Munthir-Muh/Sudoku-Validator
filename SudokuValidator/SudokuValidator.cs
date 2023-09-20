namespace SudokuValidator
{
    public class Sudoku
    {
        public static bool Validate(string[] sudoku)
        {
            try
            {
                var sudokoList = Enumerable.Range(0, 9)
                    .Select(s => sudoku[s].Split().Select(s => int.Parse(s)).ToList())
                    .ToList();

                return Validate(sudokoList);
            }
            catch
            {
                return false;
            }

        }
        public static bool Validate(List<List<int>>? sudoku)
        {
            if (sudoku is null ||
                sudoku.Count != 9 ||
                sudoku.Any(s => s.Count != 9 || s.Min() < 1 || s.Max() > 9)
                )
                return false;

            //Check Rows 
            if (sudoku.Any(s => s.Distinct().Count() != 9))
                return false;

            //Check Columns
            for (int i = 0; i <= 8; i++)
            {
                var columUnique = Enumerable.Range(0, 9)
                    .Select(s => sudoku[s][i])
                    .Distinct()
                    .Count();

                if (columUnique != 9)
                    return false;
            }

            //Check Region 
            for (int hr = 0; hr <= 6; hr += 3)
            {
                for (int vr = 0; vr <= 6; vr += 3)
                {
                    var regionUnique = Enumerable
                        .Range(vr, 3)
                        .SelectMany(s => sudoku[s].Skip(hr).Take(3))
                        .Distinct()
                        .Count();

                    if (regionUnique != 9)
                        return false;
                }
            }

            return true;
        }
    }
}