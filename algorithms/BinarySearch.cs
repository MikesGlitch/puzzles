namespace algorithms;

public class BinarySearch
{
    // Assumes sorted Array
    // do the following while not found or searched every valid value
    // Find the middle number in the current array view - low + (high - low) / 2
    // is the middle number the search value? if so we've found it - exit
    // If the middle value is bigger, add one and use it as the start index
    // otherwise it's lower, use middle number as the end index
    // If low number is equal to high the number is not in the array - exit
    // return whether or not item is found
    // Time Complexity: O(log n) - because of the halfing nature of it
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 0, false)]
    [InlineData(new int[] { 1, 2, 3 }, 1, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 3, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 12, false)]
    public void Search(int[] data, int searchValue, bool expected)
    {
        bool found = false;
        var low = 0;
        var high = data.Length - 1;
        
        do {
            var midpoint = (int)Math.Floor((decimal)low + (high - low) / 2);
            if (searchValue == data[midpoint]) { 
                found = true;
                break;
            } else if (searchValue > data[midpoint]) {
                low = midpoint + 1;
            } else {
                high = midpoint - 1;
            }
        } while(low <= high);

        Assert.Equal(found, expected);
    }
}