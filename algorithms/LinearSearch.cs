namespace algorithms;

public class LinearSearch
{
    // for each item in the array check if it equals the search value
    // if the item is found, return the index position of the item in the array
    // if item is not found, return null
    // Time Complexity: O(n)
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5, 4)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 12, null)]
    public void FindIndex(int[] data, int searchValue, int? expected)
    {
        int? result = null;
        for (int i = 0; i < data.Length; i++) {
            if (data[i] == searchValue) {
                result = i;
                break;
            }
        }

        Assert.Equal(result, expected);
    }
}