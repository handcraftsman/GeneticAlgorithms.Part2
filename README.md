## "Hello world!" - Genetic Algorithms 1

This is the C# source code for [part 1 of my series on genetic algorithms][part1].

In this part we build a genetic solver that can reproduce a string, e.g. "Hello world!", without direct access to the string. It does this by calling a fitness function with a guess.  The fitness function returns an integer value representing how many of the characters in the string are correct, but not which ones - somewhat like the game Hang Man.

Sample run:

	generation          1 fitness    0 rl!dHdrwl  r elapsed: 00:00:00.0093788
	generation          4 fitness    1 re!dHdrwl  r elapsed: 00:00:00.0110906
	generation         18 fitness    2 He!dHdrwl  r elapsed: 00:00:00.0112696
	generation         20 fitness    3 He!lHdrwl  r elapsed: 00:00:00.0115229
	generation         24 fitness    4 He!lHdrol  r elapsed: 00:00:00.0117862
	generation         31 fitness    5 He!lHdroll r elapsed: 00:00:00.0120102
	generation         52 fitness    6 He!lHdrorl r elapsed: 00:00:00.0122658
	generation         97 fitness    7 He!lodrorl r elapsed: 00:00:00.0124217
	generation        125 fitness    8 He!lodrorl ! elapsed: 00:00:00.0125791
	generation        213 fitness    9 He!lodrorld! elapsed: 00:00:00.0127173
	generation        234 fitness   10 Hellodrorld! elapsed: 00:00:00.0128413
	generation        327 fitness   11 Hello rorld! elapsed: 00:00:00.0129618
	generation        460 fitness   12 Hello world! elapsed: 00:00:00.0131015
	Hello world!
	
## License		

[MIT License][mitlicense]

[mitlicense]: http://www.opensource.org/licenses/mit-license.php
[part1]: http://handcraftsman.wordpress.com/2011/05/27/genetic-programming-hello-world/
