using System.Globalization;

namespace algorithms;

public class FizzBuzz
{
    private readonly string[] ExpectedOutput = new string [100] {
        "1",
        "2",
        "Fizz",
        "4",
        "Buzz",
        "Fizz",
        "7",
        "8",
        "Fizz",
        "Buzz",
        "11",
        "Fizz",
        "13",
        "14",
        "FizzBuzz",
        "16",
        "17",
        "Fizz",
        "19",
        "Buzz",
        "Fizz",
        "22",
        "23",
        "Fizz",
        "Buzz",
        "26",
        "Fizz",
        "28",
        "29",
        "FizzBuzz",
        "31",
        "32",
        "Fizz",
        "34",
        "Buzz",
        "Fizz",
        "37",
        "38",
        "Fizz",
        "Buzz",
        "41",
        "Fizz",
        "43",
        "44",
        "FizzBuzz",
        "46",
        "47",
        "Fizz",
        "49",
        "Buzz",
        "Fizz",
        "52",
        "53",
        "Fizz",
        "Buzz",
        "56",
        "Fizz",
        "58",
        "59",
        "FizzBuzz",
        "61",
        "62",
        "Fizz",
        "64",
        "Buzz",
        "Fizz",
        "67",
        "68",
        "Fizz",
        "Buzz",
        "71",
        "Fizz",
        "73",
        "74",
        "FizzBuzz",
        "76",
        "77",
        "Fizz",
        "79",
        "Buzz",
        "Fizz",
        "82",
        "83",
        "Fizz",
        "Buzz",
        "86",
        "Fizz",
        "88",
        "89",
        "FizzBuzz",
        "91",
        "92",
        "Fizz",
        "94",
        "Buzz",
        "Fizz",
        "97",
        "98",
        "Fizz",
        "Buzz"
    };

    // Implementation of FizzBuzz involves printing numbers from 1 to 100. 
    // If the numbers are multiples of 3 then Fizz is printed. 
    // If they are multiples of 5, then Buzz is printed 
    // and if they are multiples of both 3 and 5 then FizzBuzz is printed.
    // Time Complexity: O(n)
    [Fact]
    public void Run()
    {
        var output = new string[100];
        for (var i = 1; i <= 100; i++) {
            var fizz = i % 3 == 0;
            var buzz = i % 5 == 0;

            if (fizz && buzz) {
                output[i - 1] = "FizzBuzz";
            } else if (fizz) {
                output[i - 1] = "Fizz";
            } else if (buzz) {
                output[i - 1] = "Buzz";
            } else {
                output[i - 1] = i.ToString(CultureInfo.InvariantCulture);
            }
        }

        Assert.Equal(output, ExpectedOutput);
    }
}