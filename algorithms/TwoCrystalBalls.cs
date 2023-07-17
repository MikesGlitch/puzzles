namespace algorithms;

public class TwoCrystalBalls
{
    // Assumes sorted Array
    // Trying to find the point in the array which the crystal ball breaks
    // Think of it like a ladder, we take the square root of the number of steps, then go up the ladded by that amount until breaks
    // Once it breaks go down the ladder by the last increment then traverse the ladder one step at a time
    // Time Complexity: O(sqrt n)
    [Theory]
    [InlineData(new bool[] { true, true, true, true }, 0)]
    [InlineData(new bool[] { false, false, false, false, true, true, true, true }, 4)]
    [InlineData(new bool[] { false, false, false, false, false, false, false }, null)]
    public void Search(bool[] data, int? expectedIndexOfBreak)
    {
        var jumpIncrement = (int)Math.Floor(Math.Sqrt(data.Length));
        var i = jumpIncrement;
        int? indexOfBreak = null;

        for (; i < data.Length; i += jumpIncrement) {
            if (data[i] == true) {
                break; // found instance of a break - exit
            }
        }

        i -= jumpIncrement; // jump back

        for (var j = 0; j <= jumpIncrement && i < data.Length; j++, ++i) {
            if (data[i] == true) {
                indexOfBreak = i; // First instance of break
                break;
            }
        }

        Assert.Equal(indexOfBreak, expectedIndexOfBreak);
    }
}