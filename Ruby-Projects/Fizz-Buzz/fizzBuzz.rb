

def fizzBuzz (maxValue)
  # array that holds the fizz's and buzz's
  printArray = []
    
  # populates the array
  1.upto(maxValue).each do |num|
    # is divisible by 3 and 5 FizzBuzz
    if ((num % 3 == 0) && (num % 5 == 0))
      printArray << "FizzBuzz"
    # is divisable by 3 Fizz
    elsif (num % 3 == 0)
      printArray << "Fizz"
    # is divisable by 5 Buzz
    elsif (num % 5 == 0)
      printArray << "Buzz"
    # else number
    else
      printArray << num
    end
  end
  # return the array with added spaces
  return printArray.join(', ')

end

print fizzBuzz(100)