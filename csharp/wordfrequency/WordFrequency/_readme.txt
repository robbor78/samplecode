Word Frequency (console application):

........


Structure of the Solution
The solution consists of 3 assemblies. 
1. WordFrequencyLib An assembly that contains the logic. This assembly provides a class (WordCount) that can determine the occurrences of words that were previously added to the class. The assembly also contains a utility class to build a WordCount object from a text file.
2. A unit test assembly. WordFrequencyLibTest. Tests the WordCount logic and the utility class. Includes the Gutenberg copy of "War and Peace" for test purposes.
3. A console application (WordFrequencyConsole) which accepts, as a command line argument, the path to a text file, which it then parses and determines the 10 most commonly occurring words. The top 10 occurrences are displayed to the screen.

Features of the solution.
- Encapsulation is used extensively, e.g. instead of return a List<OccurenceInfo> the application hides the List inside a WordOccurences class. This is overkill for a small application. This is done to demonstrate information hiding.
- The algorithm is unit tested.
- The algorithm uses a dictionary to determine the occurrences of all distinct words. To determine the most frequent words, an array is used. The index of the array is the occurrence and the entry in the array is the list of words (for that occurrence). The algorithm then returns the top n occurrences from that array. Source of the algorithm is stack overflow but I have forgotten the exact link. 