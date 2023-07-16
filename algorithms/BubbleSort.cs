namespace algorithms;

public class BubbleSort
{
    // Start at beginning of array
    // compare first val with next one, if first val is bigger swap it
    // move to next value in array and repeat that logic
    // once finished the largest item in the array should have bubbled to the top, move onto the second val and repeat
    // Time Complexity: O(n^2)
    [Theory]
    [InlineData(new int[] { 8, 3, 5, 6, 1, 4, 3 }, new int[] {1, 3, 3, 4, 5, 6, 8 } )]
    public void Sort(int[] data, int[] expected)
    {
        for (var i = 0; i < data.Length; i++) {
            for (var j = 0; j < data.Length - 1 - i; j++) {
                if (data[j] > data[j + 1]) {
                    (data[j + 1], data[j]) = (data[j], data[j + 1]);
                }
            }
        }

        Assert.Equal(data, expected);
    }
}